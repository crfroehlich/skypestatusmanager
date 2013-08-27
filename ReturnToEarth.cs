using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkypeStatusMgr
{
    public partial class ReturnToEarth : Form
    {
        public ReturnToEarth()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void NotifyForm_Load( object sender, EventArgs e )
        {

        }
    }
}
