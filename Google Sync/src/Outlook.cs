using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Sync.src
{
    public class Outlook
    {
        private Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
        private Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;

        public Microsoft.Office.Interop.Outlook.MAPIFolder getCalender()
        {
            mapiNamespace = oApp.GetNamespace("MAPI");
            Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
            CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);

            return CalendarFolder;
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
             */
        }

        public Microsoft.Office.Interop.Outlook.MAPIFolder getTask()
        {
            mapiNamespace = oApp.GetNamespace("MAPI");
            Microsoft.Office.Interop.Outlook.MAPIFolder TaskFolder = null;
            TaskFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderTasks);
            return TaskFolder;
        }
    }
}
