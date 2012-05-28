using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Office.Interop.Outlook;

namespace Google_Sync.src
{
    public class Worker
    {
        int i;

        public Worker()
        {
            i = 0;
        }
        public void DoWork()
        {
            while (!_shouldStop)
            {
                
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        private volatile bool _shouldStop;
    }
}

/*
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
*/