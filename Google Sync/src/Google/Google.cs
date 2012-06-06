using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Google Calendar specific imports
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Calendar;
using Google.GData.AccessControl;
#endregion

using Microsoft.Office.Interop.Outlook;

namespace Google_Sync.src.Google
{
    class Google
    {
        private string googleAuthToken = null;
        private string user;
        private string pw;
        private Uri postUri = new Uri("http://www.google.com/calendar/feeds/default/private/full");
        private EventFeed feed;
        private EventQuery query;
        
        public bool loginSuccess = false;


        private CalendarService calendarService = null;

        public Google()
        {
            this.calendarService = new CalendarService("GoogleCalendar");
        }

        public Google(string username, string password)
        {
            this.user = username;
            this.pw = password;
            this.calendarService = new CalendarService("GoogleCalendar");

            if (this.googleAuthToken == null)
            {
                this.calendarService.setUserCredentials(this.user, this.pw);
                try
                {
                    this.googleAuthToken = this.calendarService.QueryClientLoginToken();
                    loginSuccess = true;
                }
                catch (System.Exception exception)
                {
                    this.googleAuthToken = "Invalid Credentials";
                    loginSuccess = false;
                }
            }
        }

        public void createEvent(AppointmentItem item)
        {
                    EventEntry entry = new EventEntry();
                    // Set the title and content of the entry.
                    entry.Title.Text = item.Subject;
                    entry.Content.Content = item.Body;

                    // Set a location for the event.
                    Where eventLocation = new Where();
                    eventLocation.ValueString = item.Location;
                    entry.Locations.Add(eventLocation);

                    When eventTime = new When(item.StartInStartTimeZone, item.EndInEndTimeZone);
                    entry.Times.Add(eventTime);

                    // Send the request and receive the response
                    AtomEntry insertedEntry = calendarService.Insert(postUri, entry);
        }

        public void getEvents()
        {
            this.query = new EventQuery(postUri.ToString());
            this.feed = this.calendarService.Query(query);
        }

        public string getAuth
        {
            get
            {
                return this.googleAuthToken;
            }
        }
    }
}
