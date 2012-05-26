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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool[] checkbox = new bool[3];
            checkbox[0] = this.cal_box.Checked;
            checkbox[1] = this.task_box.Checked;
            checkbox[2] = this.contact_box.Checked;
            src.work work = new Google_Sync.src.work();
            work.irgendwas(checkbox);
        }

    }
}
