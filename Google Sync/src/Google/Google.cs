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

namespace Google_Sync.src.Google
{
    class Google
    {
        private string googleAuthToken = null;
        private string user;
        private string pw;
        private Google_Sync.src.GoogleLogin loginDialog;

        private CalendarService calendarService = null;

        public Google(string username, string password)
        {
            this.user = username;
            this.pw = password;
            this.calendarService = new CalendarService("GoogleCalendar");
            this.loginDialog = new GoogleLogin(this.calendarService, this.user, this.pw);
        }

        public void Login()
        {
            if (this.googleAuthToken == null)
            {
                this.loginDialog.Login();
                this.googleAuthToken = loginDialog.AuthenticationToken;
                if (this.googleAuthToken != null)
                {
                    this.calendarService.SetAuthenticationToken(this.googleAuthToken);
                }
            }
        }

    }
}
