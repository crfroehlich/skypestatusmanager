namespace SkypeStatusMgr
{
    partial class SkypeStatusManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkypeStatusManager));
            this.StatusValueLabel = new System.Windows.Forms.Label();
            this.ButtonOTP = new System.Windows.Forms.Button();
            this.ButtonRevert = new System.Windows.Forms.Button();
            this.ButtonBRB = new System.Windows.Forms.Button();
            this.ButtonBusy = new System.Windows.Forms.Button();
            this.ButtonCustom = new System.Windows.Forms.Button();
            this.CustomBox = new System.Windows.Forms.ComboBox();
            this.ButtonDeleteStatus = new System.Windows.Forms.Button();
            this.ButtonQuit = new System.Windows.Forms.Button();
            this.StatusPicture = new System.Windows.Forms.PictureBox();
            this.ButtonGone = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.UnreadLabel = new System.Windows.Forms.Label();
            this.UnreadValueLabel = new System.Windows.Forms.Label();
            this.BackInComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusValueLabel
            // 
            this.StatusValueLabel.AutoEllipsis = true;
            this.StatusValueLabel.AutoSize = true;
            this.StatusValueLabel.Location = new System.Drawing.Point(22, 2);
            this.StatusValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusValueLabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.StatusValueLabel.Name = "StatusValueLabel";
            this.StatusValueLabel.Size = new System.Drawing.Size(130, 13);
            this.StatusValueLabel.TabIndex = 0;
            this.StatusValueLabel.Text = "[No Current Skype Status]";
            // 
            // ButtonOTP
            // 
            this.ButtonOTP.Location = new System.Drawing.Point(237, 3);
            this.ButtonOTP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonOTP.Name = "ButtonOTP";
            this.ButtonOTP.Size = new System.Drawing.Size(42, 20);
            this.ButtonOTP.TabIndex = 2;
            this.ButtonOTP.Text = "OTP";
            this.ButtonOTP.UseVisualStyleBackColor = true;
            this.ButtonOTP.Click += new System.EventHandler(this.onButtonOnThePhoneClick);
            // 
            // ButtonRevert
            // 
            this.ButtonRevert.BackColor = System.Drawing.Color.Red;
            this.ButtonRevert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRevert.ForeColor = System.Drawing.Color.White;
            this.ButtonRevert.Location = new System.Drawing.Point(797, 1);
            this.ButtonRevert.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonRevert.Name = "ButtonRevert";
            this.ButtonRevert.Size = new System.Drawing.Size(124, 23);
            this.ButtonRevert.TabIndex = 3;
            this.ButtonRevert.Text = "Revert";
            this.ButtonRevert.UseVisualStyleBackColor = false;
            this.ButtonRevert.Visible = false;
            this.ButtonRevert.Click += new System.EventHandler(this.onButtonRevertClick);
            // 
            // ButtonBRB
            // 
            this.ButtonBRB.Location = new System.Drawing.Point(366, 3);
            this.ButtonBRB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonBRB.Name = "ButtonBRB";
            this.ButtonBRB.Size = new System.Drawing.Size(55, 20);
            this.ButtonBRB.TabIndex = 4;
            this.ButtonBRB.Text = "Back In:";
            this.ButtonBRB.UseVisualStyleBackColor = true;
            this.ButtonBRB.Click += new System.EventHandler(this.onButtonBeRightBackClick);
            // 
            // ButtonBusy
            // 
            this.ButtonBusy.Location = new System.Drawing.Point(278, 3);
            this.ButtonBusy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonBusy.Name = "ButtonBusy";
            this.ButtonBusy.Size = new System.Drawing.Size(46, 20);
            this.ButtonBusy.TabIndex = 12;
            this.ButtonBusy.Text = "Busy";
            this.ButtonBusy.UseVisualStyleBackColor = true;
            this.ButtonBusy.Click += new System.EventHandler(this.onButtonBusyClick);
            // 
            // ButtonCustom
            // 
            this.ButtonCustom.Location = new System.Drawing.Point(487, 3);
            this.ButtonCustom.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonCustom.Name = "ButtonCustom";
            this.ButtonCustom.Size = new System.Drawing.Size(54, 20);
            this.ButtonCustom.TabIndex = 13;
            this.ButtonCustom.Text = "Custom:";
            this.ButtonCustom.UseVisualStyleBackColor = true;
            this.ButtonCustom.Click += new System.EventHandler(this.onButtonCustomClickEvent);
            // 
            // CustomBox
            // 
            this.CustomBox.FormattingEnabled = true;
            this.CustomBox.Location = new System.Drawing.Point(541, 3);
            this.CustomBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.CustomBox.Name = "CustomBox";
            this.CustomBox.Size = new System.Drawing.Size(138, 21);
            this.CustomBox.TabIndex = 14;
            // 
            // ButtonDeleteStatus
            // 
            this.ButtonDeleteStatus.Location = new System.Drawing.Point(680, 3);
            this.ButtonDeleteStatus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonDeleteStatus.Name = "ButtonDeleteStatus";
            this.ButtonDeleteStatus.Size = new System.Drawing.Size(55, 20);
            this.ButtonDeleteStatus.TabIndex = 15;
            this.ButtonDeleteStatus.Text = "Remove";
            this.ButtonDeleteStatus.UseVisualStyleBackColor = true;
            this.ButtonDeleteStatus.Click += new System.EventHandler(this.onButtonStatusDeleteClick);
            // 
            // ButtonQuit
            // 
            this.ButtonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonQuit.FlatAppearance.BorderSize = 0;
            this.ButtonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonQuit.Image = ((System.Drawing.Image)(resources.GetObject("ButtonQuit.Image")));
            this.ButtonQuit.Location = new System.Drawing.Point(920, 1);
            this.ButtonQuit.Name = "ButtonQuit";
            this.ButtonQuit.Size = new System.Drawing.Size(22, 22);
            this.ButtonQuit.TabIndex = 16;
            this.ButtonQuit.UseVisualStyleBackColor = true;
            this.ButtonQuit.Click += new System.EventHandler(this.onButtonQuitClick);
            // 
            // StatusPicture
            // 
            this.StatusPicture.Image = ((System.Drawing.Image)(resources.GetObject("StatusPicture.Image")));
            this.StatusPicture.ImageLocation = "Images/cusAway.gif";
            this.StatusPicture.InitialImage = null;
            this.StatusPicture.Location = new System.Drawing.Point(3, 3);
            this.StatusPicture.Name = "StatusPicture";
            this.StatusPicture.Size = new System.Drawing.Size(16, 16);
            this.StatusPicture.TabIndex = 17;
            this.StatusPicture.TabStop = false;
            // 
            // ButtonGone
            // 
            this.ButtonGone.Location = new System.Drawing.Point(323, 3);
            this.ButtonGone.Name = "ButtonGone";
            this.ButtonGone.Size = new System.Drawing.Size(44, 20);
            this.ButtonGone.TabIndex = 18;
            this.ButtonGone.Text = "Gone";
            this.ButtonGone.UseVisualStyleBackColor = true;
            this.ButtonGone.Click += new System.EventHandler(this.onButtonGoneClick);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(199, 3);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(39, 20);
            this.ButtonClear.TabIndex = 19;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.onButtonClearClickEvent);
            // 
            // UnreadLabel
            // 
            this.UnreadLabel.AutoSize = true;
            this.UnreadLabel.Location = new System.Drawing.Point(758, 7);
            this.UnreadLabel.Name = "UnreadLabel";
            this.UnreadLabel.Size = new System.Drawing.Size(40, 13);
            this.UnreadLabel.TabIndex = 20;
            this.UnreadLabel.Text = "unread";
            // 
            // UnreadValueLabel
            // 
            this.UnreadValueLabel.AutoSize = true;
            this.UnreadValueLabel.Location = new System.Drawing.Point(746, 7);
            this.UnreadValueLabel.Name = "UnreadValueLabel";
            this.UnreadValueLabel.Size = new System.Drawing.Size(13, 13);
            this.UnreadValueLabel.TabIndex = 21;
            this.UnreadValueLabel.Text = "0";
            // 
            // BackInComboBox
            // 
            this.BackInComboBox.FormattingEnabled = true;
            this.BackInComboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "45",
            "60",
            "90"});
            this.BackInComboBox.Location = new System.Drawing.Point(424, 3);
            this.BackInComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.BackInComboBox.Name = "BackInComboBox";
            this.BackInComboBox.Size = new System.Drawing.Size(46, 21);
            this.BackInComboBox.TabIndex = 22;
            this.BackInComboBox.Text = "15";
            // 
            // SkypeStatusManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.CancelButton = this.ButtonQuit;
            this.ClientSize = new System.Drawing.Size(944, 25);
            this.Controls.Add(this.BackInComboBox);
            this.Controls.Add(this.UnreadValueLabel);
            this.Controls.Add(this.UnreadLabel);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonGone);
            this.Controls.Add(this.StatusPicture);
            this.Controls.Add(this.ButtonQuit);
            this.Controls.Add(this.ButtonDeleteStatus);
            this.Controls.Add(this.CustomBox);
            this.Controls.Add(this.ButtonCustom);
            this.Controls.Add(this.ButtonBusy);
            this.Controls.Add(this.ButtonBRB);
            this.Controls.Add(this.ButtonRevert);
            this.Controls.Add(this.ButtonOTP);
            this.Controls.Add(this.StatusValueLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(200, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.Name = "SkypeStatusManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Skype Status Manager";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusValueLabel;
        private System.Windows.Forms.Button ButtonOTP;
        private System.Windows.Forms.Button ButtonRevert;
        private System.Windows.Forms.Button ButtonBRB;
        private System.Windows.Forms.Button ButtonBusy;
        private System.Windows.Forms.Button ButtonCustom;
        private System.Windows.Forms.ComboBox CustomBox;
        private System.Windows.Forms.Button ButtonDeleteStatus;
        private System.Windows.Forms.Button ButtonQuit;
        private System.Windows.Forms.PictureBox StatusPicture;
        private System.Windows.Forms.Button ButtonGone;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Label UnreadLabel;
        private System.Windows.Forms.Label UnreadValueLabel;
        private System.Windows.Forms.ComboBox BackInComboBox;
    }
}

