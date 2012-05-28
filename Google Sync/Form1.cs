using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Google_Sync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            setVersionLbl();
        }

        private string Version()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void setVersionLbl()
        {
            VersionLbl.Text = Version();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
