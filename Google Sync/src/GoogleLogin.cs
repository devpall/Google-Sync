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
    }
}
