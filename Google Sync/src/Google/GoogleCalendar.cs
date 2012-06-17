using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Google Calendar specific imports
using Google.Apis.Calendar.v3.Data;
#endregion

namespace Google_Sync.src.Google
{
    class GoogleCalendar
    {
        private Event calEvent;

        public void InsertEvent(Google_Sync.src.Outlook.Item[] itemArray)
        {
            List<Event> calEventList = new List<Event>();
            foreach (Google_Sync.src.Outlook.Item item in itemArray)
            {
                calEvent = new Event();

                //erforderliche Eigenschaften
                calEvent.Attendees = setAttendees(item);

                //optionale Eigenschaften
                calEvent.Summary = item.subject;
                calEventList.Add(calEvent);
            }
        }

        private List<EventAttendee> setAttendees (Google_Sync.src.Outlook.Item tItem)
        {
            List<EventAttendee> attendees = new List<EventAttendee>();

            for (int i = 0; i < tItem.attendees.Count; i++)
            {
                EventAttendee attendee = new EventAttendee();
                attendee.Email = tItem.attendees[i];
                attendees.Add(attendee);
            }
            return attendees;
        }
    }
}
