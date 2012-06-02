﻿using System;

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


        /// <summary>
        /// Konstruktor nur mit service
        /// </summary>
        /// <param name="serviceToUse"></param>
        public GoogleLogin(Service serviceToUse)
        {
            this.service = serviceToUse;
        }

        /// <summary>
        /// Konstruktor mit username und service
        /// </summary>
        /// <param name="serviceToUse"></param>
        /// <param name="username"></param>
        public GoogleLogin(Service serviceToUse, string username)
        {
            this.service = serviceToUse;
            this.username = username;
        }

        public GoogleLogin(Service serviceToUse, string username, string pw)
        {
            this.service = serviceToUse;
            this.username = username;
            this.password = pw;
        }


        /// <summary>
        /// Gibt Token zurück
        /// </summary>
        public string AuthenticationToken
        {
            get
            {
                return this.authToken;
            }
        }

        /// <summary>
        /// Gibt und erzeugt Username
        /// </summary>
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


        /// <summary>
        /// Gibt und erzeugt Username
        /// </summary>
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


        public void Login()
        {
            this.service.setUserCredentials(this.username, this.password);
            try
            {
                this.authToken = this.service.QueryClientLoginToken();
            }
            catch (Exception exception)
            {
                this.authToken = "Invalid Credentials";
            }
        }
    }
}
