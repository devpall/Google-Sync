using System;

#region Google API
using Google.GData.Client;
#endregion

namespace Google_Sync.src
{
    class GoogleLogin
    {
        private string authToken;
        private string username;
        private string password;

        private Service service;

        public GoogleLogin(Service serviceToUse)
        {
            this.service = serviceToUse;
        }

        public GoogleLogin(Service serviceToUse, string username)
        {
            this.service = serviceToUse;
            this.username = username;
        }

        public string AuthenticationToken
        {
            get
            {
                return this.authToken;
            }
        }

        public string User
        {
            get
            {
                return this.username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        private void Login()
        {
            this.service.setUserCredentials(this.username, this.password);
            this.authToken = this.service.QueryAuthenticationToken();
        }
    }
}
