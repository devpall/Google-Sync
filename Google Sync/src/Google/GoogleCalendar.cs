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
                calEvent.Start = setTime(true, item);
                calEvent.End = setTime(false, item);

                //optionale Eigenschaften
                calEvent.Summary = item.subject;
                calEvent.Description = item.description;
                calEvent.Location = item.location;

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

        /// <summary>
        /// Setzt die Start und Endzeit eines Termins
        /// </summary>
        /// <param name="start">start = true    -> Starttermin
        ///                     start = false   -> Endtermin
        /// </param>
        /// <returns>Start/Endtermin als EventDateTime </returns>
        private EventDateTime setTime(bool start, Google_Sync.src.Outlook.Item tItem)
        {
            EventDateTime eventTime = new EventDateTime();
            if (start)
            {
                eventTime.Date = tItem.startTime.ToString();
            }
            else
            {
                eventTime.Date = tItem.endTime.ToString();
            }

            return eventTime;
        }

        private EventReminder 
    }
}
