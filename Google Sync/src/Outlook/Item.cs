﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Sync.src.Outlook
{
    class Item
    {
        private Microsoft.Office.Interop.Outlook.AppointmentItem oItem;

        public string id { get; private set; }
        public string subject { get; private set; }
        public string description { get; private set; }
        public string category { get; private set; }
        public string startTime { get; private set; }
        public string endTime { get; private set; }
        public string group { get; private set; }
        public string location { get; private set; }
        public bool isReturning { get; private set; }

        public Item(Microsoft.Office.Interop.Outlook.AppointmentItem oItem)
        {
            // TODO: Complete member initialization

            this.id = oItem.EntryID;
            this.subject = oItem.Subject;
            this.description = oItem.Body;
            this.category = oItem.Categories;
            this.startTime = oItem.StartInStartTimeZone.ToString();
            this.endTime = oItem.EndInEndTimeZone.ToString();
            this.location = oItem.Location;
            this.group = getRecipients(oItem);
            this.isReturning = oItem.IsRecurring;

        }

        private string getRecipients(Microsoft.Office.Interop.Outlook.AppointmentItem oItem)
        {
            string Srecips = null;
            Microsoft.Office.Interop.Outlook.Recipients recips = oItem.Recipients;
            foreach (Microsoft.Office.Interop.Outlook.Recipient recip in recips)
            {
                Srecips = recip.Address + ";" + Srecips;
            }
            return Srecips;
        }
    }
}