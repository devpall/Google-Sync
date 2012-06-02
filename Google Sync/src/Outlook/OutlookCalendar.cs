using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;

namespace Google_Sync.src
{
    public class OutlookCalendar
    {
        private Microsoft.Office.Interop.Outlook.Application oApp;
        private Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace;
        private Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder;

        public OutlookCalendar()
        {
            this.oApp = new Microsoft.Office.Interop.Outlook.Application();
            this.mapiNamespace = this.oApp.GetNamespace("MAPI");
            this.CalendarFolder = this.mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
        }

        public MAPIFolder Calendar
        {
            get
            {
                return this.CalendarFolder;
            }

        }
        public int CalendarLength
        {
            get
            {
                return this.Calendar.Items.Count;
            }
        }
    }
}


/*
for (int i = 1; i < CalendarFolder.Items.Count + 1; i++)
{
    var item = (AppointmentItem)CalendarFolder.Items[i];
    Console.WriteLine("Betreff:\t" + item.Subject);
    Console.WriteLine("Location:\t" + item.Location);
    Console.WriteLine(item.Importance);
    Console.WriteLine(item.Categories);
    Console.WriteLine("Optional:\t" + item.OptionalAttendees);
    Console.WriteLine("Organizierer:\t" + item.Organizer);
    Console.WriteLine("Erforderlich:\t" + item.RequiredAttendees);
    Console.WriteLine("Startdatum:\t" + item.Start);
    Console.WriteLine(item.StartInStartTimeZone);
    Console.WriteLine(item.StartUTC);
    Console.WriteLine(item.End);
    Console.WriteLine(item.EndUTC);
    Console.WriteLine(item.Duration);
}
Console.Read();
 * 
 * 
public Microsoft.Office.Interop.Outlook.MAPIFolder getTask()
        {
            mapiNamespace = oApp.GetNamespace("MAPI");
            Microsoft.Office.Interop.Outlook.MAPIFolder TaskFolder = null;
            TaskFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderTasks);
            return TaskFolder;
        }
 */