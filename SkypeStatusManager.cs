using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SKYPE4COMLib;


namespace SkypeStatusMgr
{

    public partial class SkypeStatusManager : Form
    {
        sealed class Statuses
        {
            public const string OnThePhone = "On The Phone";
            public const string OffThePhone = "I'm Off The Phone";
            public const string Busy = "Busy";
            public const string Free = "Free";
            public const string GoneForTheDay = "Gone for the Day";
            public const string Back = "I'm Back";

        }

        private readonly Skype _Skype;
        private bool _Attached;
        private string _OldStatus = string.Empty;

        private readonly Timer _RecentChatTimer;
        private readonly Timer _FlickerTimer;
        private readonly Timer _OfflineTimer;
        private readonly Timer _BackTimer;
        private TOnlineStatus _OnlineStatus = TOnlineStatus.olsUnknown;
        private bool _Dragging;
        private Point _StartPoint;

        public SkypeStatusManager()
        {
            Resize += onSkypeStatusManagerResizeEvent;
            InitializeComponent();

            MouseMove += onMouseMoveInFormEvent;
            MouseDown += onMouseDownInFormEvent;
            MouseUp += onMouseUpInFormEvent;

            _OfflineTimer = new Timer
                                {
                                    Interval = 6000,
                                    Enabled = false
                                };
            _OfflineTimer.Tick += onOfflineTimerTickEvent;


            _RecentChatTimer = new Timer
                                   {
                                       Interval = 5000,
                                       Enabled = false
                                   };
            _RecentChatTimer.Tick += onRecentChatTimerTickEvent;


            _FlickerTimer = new Timer
                                {
                                    Interval = 250,
                                    Enabled = false
                                };
            _FlickerTimer.Tick += onFlickerTimerTickEvent;


            _BackTimer = new Timer
                             {
                                 Enabled = false
                             };
            _BackTimer.Tick += onBackTimerTickEvent;


            _Skype = new Skype();
            if( !_Skype.Client.IsRunning )
            {
                // start minimized with no splash screen
                _Skype.Client.Start( true, true );
            }
            _Skype.Attach( 6 );
            _Skype.OnlineStatus += onSkypeOnlineStatusChangeEvent;

            _Skype.UserMood += onSkypeUserMoodChangeEvent;
            _Skype.UserStatus += onSkypeUserStatusChangeEvent;
            _Skype.CallStatus += onSkypeCallStatusChangeEvent;

            _LoadCustomStatuses();
        }

        #region Form Events

        void onSkypeStatusManagerResizeEvent( object sender, EventArgs e )
        {
            // Height is being reset to 34 for some reason.  This fixes it.
            Height = 25;
        }

        void onMouseDownInFormEvent( object sender, MouseEventArgs e )
        {
            _Dragging = true;
            _StartPoint = e.Location;
        }
        void onMouseUpInFormEvent( object sender, MouseEventArgs e )
        {
            _Dragging = false;
        }
        private void onMouseMoveInFormEvent( object sender, MouseEventArgs e )
        {
            if( _Dragging )
            {
                Location = new Point( Math.Max( Location.X + ( e.Location.X - _StartPoint.X ), 0 ),
                                           Math.Max( Location.Y + ( e.Location.Y - _StartPoint.Y ), 0 ) );
            }
        }

        #endregion Form Events

        #region Tick Events

        void onRecentChatTimerTickEvent( object sender, EventArgs e )
        {
            Int32 MissedCount = _Skype.MissedChats.Count;
            UnreadValueLabel.Text = MissedCount.ToString();
            if( MissedCount > 0 )
            {
                _FlickerTimer.Enabled = true;
            }
            else
            {
                _FlickerTimer.Enabled = false;
                UnreadLabel.BackColor = Color.Transparent;
                UnreadValueLabel.BackColor = Color.Transparent;
            }
        }

        void onFlickerTimerTickEvent( object sender, EventArgs e )
        {
            if( UnreadValueLabel.BackColor == Color.Yellow )
            {
                UnreadLabel.BackColor = Color.OrangeRed;
                UnreadValueLabel.BackColor = Color.OrangeRed;
            }
            else
            {
                UnreadLabel.BackColor = Color.Yellow;
                UnreadValueLabel.BackColor = Color.Yellow;
            }
        }

        void onOfflineTimerTickEvent( object sender, EventArgs e )
        {
            _Attach();
        }

        void onBackTimerTickEvent( object sender, EventArgs e )
        {
            _BackTimer.Enabled = false;
            ReturnToEarth NotifyForm1 = new ReturnToEarth();
            DialogResult result = NotifyForm1.ShowDialog();
            if( result == DialogResult.Yes )
            {
                _RevertStatus();
            }
        }

        private void _SetBackTimer( Int32 Delay )
        {
            if( Delay < 1 )
                Delay = 1;
            _BackTimer.Interval = Delay * 60 * 1000;
            _BackTimer.Enabled = true;
        }

        #endregion Tick Events

        #region Button Events


        private void onButtonOnThePhoneClick( object sender, EventArgs e )
        {
            _SetStatus( TUserStatus.cusAway, Statuses.OnThePhone, Statuses.OffThePhone );
        }

        private void onButtonBusyClick( object sender, EventArgs e )
        {
            _SetStatus( TUserStatus.cusAway, Statuses.Busy, Statuses.Free );
        }

        private void onButtonBeRightBackClick( object sender, EventArgs e )
        {
            Int32 Minutes;
            Int32.TryParse( BackInComboBox.Text, out Minutes );

            DateTime BackTime = DateTime.Now.AddMinutes( Minutes );
            _SetStatus( TUserStatus.cusAway, "Back at " + BackTime.ToShortTimeString(), Statuses.Back );

            _SetBackTimer( Minutes );
        }

        private void onButtonGoneClick( object sender, EventArgs e )
        {
            _SetStatus( TUserStatus.cusAway, Statuses.GoneForTheDay, Statuses.Back );
            _SetBackTimer( 1 );
        }

        private void onButtonRevertClick( object sender, EventArgs e )
        {
            _RevertStatus();
        }

        private void onButtonCustomClickEvent( object sender, EventArgs e )
        {
            _SetStatus( TUserStatus.cusAway, CustomBox.Text, Statuses.Back );
            if( !CustomBox.Items.Contains( CustomBox.Text ) )
            {
                CustomBox.Items.Insert( 0, CustomBox.Text );
                _SaveCustomStatuses();
            }
        }
        private void onButtonClearClickEvent( object sender, EventArgs e )
        {
            _OldStatus = string.Empty;
            _RevertStatus();
        }

        private void onButtonStatusDeleteClick( object sender, EventArgs e )
        {
            CustomBox.Items.Remove( CustomBox.SelectedItem );
            _SaveCustomStatuses();
        }

        private void onButtonQuitClick( object sender, EventArgs e )
        {
            Close();
        }

        #endregion Button Events

        #region Skype Events

        void onSkypeCallStatusChangeEvent( Call pCall, TCallStatus Status )
        {
            if( Status == TCallStatus.clsRinging )
            {
                _SetStatus( TUserStatus.cusAway, Statuses.OnThePhone, Statuses.OffThePhone );
            }
            else if( Status == TCallStatus.clsFinished && StatusValueLabel.Text == Statuses.OnThePhone )
            {
                _RevertStatus();
            }
        }

        void onSkypeOnlineStatusChangeEvent( User User, TOnlineStatus status )
        {
            _OnlineStatus = status;
            if( _OnlineStatus != TOnlineStatus.olsOnline )
            {
                _SetOffline();
            }
        }

        void onSkypeUserStatusChangeEvent( TUserStatus Status )
        {
            StatusPicture.ImageLocation = _getImageForStatus( Status );
        }

        void onSkypeUserMoodChangeEvent( User pUser, string MoodText )
        {
            if( pUser.Handle == _Skype.CurrentUser.Handle )
            {
                StatusValueLabel.Text = MoodText;
            }
        }

        #endregion Skype Events

        #region Connectivity

        private sealed class Images
        {
            public const string Offline = "Images/face-devil-sad.png";
            public const string OnThePhone = "Images/face-angry-yelling.png";
            public const string Default = "Images/mgr.png";
            public const string Away = "Images/face-sleeping.png";
            public const string Here = "Images/face-angel2.png";
        }

        private string _getImageForStatus( TUserStatus Status )
        {
            string Img;
            switch( Status )
            {
                case TUserStatus.cusDoNotDisturb:
                    Img = Images.OnThePhone;
                    break;
                case TUserStatus.cusAway:
                    Img = Images.Away;
                    break;
                case TUserStatus.cusOnline:
                case TUserStatus.cusSkypeMe:
                    Img = Images.Here;
                    break;
                default:
                    Img = Images.Default;
                    break;

            }
            return Img;
        }

        private bool _isOffline()
        {
            bool Ret = ( false == _Skype.Client.IsRunning ||
                         _Skype.CurrentUser.OnlineStatus == TOnlineStatus.olsOffline ||
                         _Skype.CurrentUser.OnlineStatus == TOnlineStatus.olsUnknown 
                       );

            return Ret;
        }

        private bool _Attach()
        {
            if( !_Attached )
            {
                _Skype.Attach( 6, false );
                if(  _isOffline() )
                {
                    _SetOffline();
                }
                else
                {
                    _OfflineTimer.Enabled = false;
                    _Attached = true;
                    StatusValueLabel.Text = _Skype.CurrentUser.MoodText;
                    StatusPicture.ImageLocation = _getImageForStatus( _Skype.CurrentUserStatus );
                    _RecentChatTimer.Enabled = true;
                }
            }
            return _Attached;
        }

        

        private void _SetOffline()
        {
            StatusValueLabel.Text = "[Skype is not running]";
            StatusPicture.ImageLocation = Images.Offline;
            _Attached = false;
            _OfflineTimer.Enabled = true;
            _RecentChatTimer.Enabled = false;
        }

        #endregion Connectivity

        #region Status

        private void _SetStatus( TUserStatus NewStatus, string NewMood, string RevertButtonText )
        {
            if( _Attach() )
            {
                _Skype.ChangeUserStatus( NewStatus );
                StatusPicture.ImageLocation = _getImageForStatus( NewStatus ); ;
                _OldStatus = _Skype.CurrentUser.MoodText;
                _Skype.Profile["MOOD_TEXT"] = NewMood;
                ButtonRevert.Visible = true;
                ButtonRevert.Text = RevertButtonText;

                ButtonBRB.Enabled = false;
                ButtonOTP.Enabled = false;
                ButtonBusy.Enabled = false;
                ButtonCustom.Enabled = false;
                ButtonGone.Enabled = false;
                ButtonClear.Enabled = false;
            }
        }

        private void _RevertStatus()
        {
            _SetStatus( TUserStatus.cusOnline, _OldStatus, "Revert" );
            _OldStatus = string.Empty; 
            _BackTimer.Enabled = false;

            ButtonRevert.Visible = false;
            ButtonBRB.Enabled = true;
            ButtonOTP.Enabled = true;
            ButtonBusy.Enabled = true;
            ButtonCustom.Enabled = true;
            ButtonGone.Enabled = true;
            ButtonClear.Enabled = true;
        }

        private void _LoadCustomStatuses()
        {
            CustomBox.Items.Clear();
            FileInfo CustomStatusFile = new FileInfo( "statuses.txt" );
            StreamReader Stream = null;
            try
            {
                Stream = CustomStatusFile.OpenText();
            }
            catch( Exception ex )
            {
                // Ignore 'file not found'
                if( !( ex is FileNotFoundException ) )
                {
                    throw;
                }
            }
            if( Stream != null )
            {
                string CustomStatuses = Stream.ReadToEnd();
                string[] CustomStatusLines = CustomStatuses.Split( new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries );
                foreach( string CustomStatus in CustomStatusLines )
                {
                    CustomBox.Items.Add( CustomStatus );
                }
                Stream.Close();
            }
        }
        private void _SaveCustomStatuses()
        {
            FileInfo CustomStatusFile = new FileInfo( "statuses.txt" ); 

            FileStream Stream = !CustomStatusFile.Exists ? CustomStatusFile.Create() : CustomStatusFile.Open( FileMode.Truncate, FileAccess.Write );

            foreach( string CustomStatus in CustomBox.Items )
            {
                Stream.Write( Encoding.ASCII.GetBytes( CustomStatus + "\r\n" ), 0, CustomStatus.Length + 2 );
            }
            Stream.Close();
        }

        #endregion Status

    }
}
