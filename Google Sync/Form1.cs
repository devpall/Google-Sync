using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.Threading;

namespace Google_Sync
{
    public partial class Form1 : Form
    {
        private src.OutlookCalendar OCal;
        private int i;
        private int count;
        private string progress = null;

        private Thread queryRunningThread;

        public Form1()
        {
            queryRunningThread = new Thread(new ThreadStart(ProcessLoop));
            queryRunningThread.Name = "ProcessLoop";
            queryRunningThread.IsBackground = true;   
            InitializeComponent();
            setVersionLbl();
        }

        delegate void IntParameterDelegate(int count);
        delegate void StringParameterDelegate(string value);
  
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
            this.OCal = new src.OutlookCalendar();
            this.count = OCal.CalendarLength;

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = count;
            this.progressBar1.Visible = true;

            this.progressLbl.Visible = true;
            if (queryRunningThread.IsAlive)
            {
                queryRunningThread.Resume();
            }
            else
            {
                queryRunningThread.Start();
            }

            SubjectLbl.Text = queryRunningThread.ThreadState.ToString();
            
        }

        private void ProcessLoop()
        {

            for (i = 1; i < OCal.CalendarLength + 1; i++)
            {
                var item = (AppointmentItem)OCal.Calendar.Items[i];
                progress = i.ToString() + " von " + OCal.CalendarLength.ToString();
                UpdateProgressBar(i);
                UpdateProgressLabel(progress);
                if (!this.ItemBx.Visible)
                {
                    this.ItemBx.Visible = true;
                }
                System.Threading.Thread.Sleep(1000);


            }
        }
       

        void UpdateProgressBar(int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IntParameterDelegate(UpdateProgressBar), new object[] { value });
                return;
            }
            progressBar1.Value = value;
        }

        void UpdateProgressLabel(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(UpdateProgressLabel), new object[] { value });
                return;
            }
            progressLbl.Text = value;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (queryRunningThread.IsAlive)
            {
                queryRunningThread.Suspend();
            }
        }


    }
}
