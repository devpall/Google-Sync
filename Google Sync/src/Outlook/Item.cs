using System;
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
        public string startTime { get; private set; }
        public string endTime { get; private set; }
        public string group { get; private set; }
        public string location { get; private set; }

        public Item(string id, string subject, string description, string category, string startTime, string endTime, string group, string location)
        {
            this.id = id;
            this.subject = subject;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.endTime = endTime;
            this.group = group;
            this.location = location;
        }
    }
}
