﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Sync.src.Outlook
{
    class Item
    {

        public string id { get; private set; }
        public string subject { get; private set; }
        public string description { get; private set; }
        public string category { get; private set; }
        public string location { get; private set; }
        public string body { get; private set; }
        public string status { get; private set; }
        public string recipients { get; private set; }


        public bool isReturning { get; private set; }
        public bool allDayEvent { get; private set; }
        public bool noEndDate { get; private set; }

        public DateTime startTime { get; private set; }
        public DateTime endTime { get; private set; }
        public DateTime patternEndDate { get; private set; }
        public DateTime patternStartDate { get; private set; }

        public int intervall { get; private set; }
        public int occurences { get; private set; }

        public List<string> attendees { get; private set; }



        public Item(Microsoft.Office.Interop.Outlook.AppointmentItem oItem)
        {

            this.id = oItem.EntryID;
            this.subject = oItem.Subject;
            this.description = oItem.Body;
            this.category = oItem.Categories;
            this.startTime = oItem.StartInStartTimeZone;
            this.endTime = oItem.EndInEndTimeZone;
            this.location = oItem.Location;
            this.isReturning = oItem.IsRecurring;
            if (isReturning)
            {
                getReccuringInfos(oItem);
            }
            this.allDayEvent = oItem.AllDayEvent;
            this.body = oItem.Body;
            this.attendees = setAttendees(oItem);
            foreach (string recip in attendees)
            {
                this.recipients = recip + ";" + this.recipients;
            }
        }

        private List<string> setAttendees(Microsoft.Office.Interop.Outlook.AppointmentItem oItem)
        {
            List<string> list = new List<string>();
            Microsoft.Office.Interop.Outlook.Recipients recips = oItem.Recipients;
            foreach (Microsoft.Office.Interop.Outlook.Recipient recip in recips)
            {
                list.Add(recip.Address);
            }
            return list;
        }


        private void getReccuringInfos(Microsoft.Office.Interop.Outlook.AppointmentItem oItem)
        {
            Microsoft.Office.Interop.Outlook.RecurrencePattern pattern = oItem.GetRecurrencePattern();
            this.intervall = pattern.Interval;
            this.occurences = pattern.Occurrences;
            this.patternStartDate = pattern.PatternStartDate;
            this.patternEndDate = pattern.PatternEndDate;
            this.noEndDate = pattern.NoEndDate;
        }
    }
}
