﻿using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System;
using Google_Sync.src;


namespace Google_Sync.src
{
    
    class WriteIniFile
    {
        private IniFile Settings;
        const string password = "bNvG$G&MnK_%alpbSu7x[c0/63A90#]f{6w0>C6*5[Vfn[fX[Ex%";

        public WriteIniFile()
        {
            Settings = new src.IniFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Google Sync\config.ini");
        }

        public string Username
        {
            get
            {
                return this.Settings["Login"]["Username"];
            }
            set
            {
                this.Settings["Login"]["Username"] = value;
            }
        }

        public string Password
        {
            get
            {
                return Encryption.DecryptString(this.Settings["Login"]["Password"], password);
            }
            set
            {
                this.Settings["Login"]["Password"] = Encryption.EncryptString(value, password); ;
            }
        }

        public bool Save
        {
            get
            {
                if (this.Settings["Login"]["Save Credentials"] == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                this.Settings["Login"]["Save Credentials"] = value.ToString();
            }
        }

        public string Category
        {
            get
            {
                return this.Settings["Sync Options"]["Category"];
            }
            set
            {
                this.Settings["Sync Options"]["Category"] = value;
            }
        }

        public string Intervall
        {
            get
            {
                return this.Settings["Sync Options"]["Intervall"];
            }
            set
            {
                this.Settings["Sync Options"]["Intervall"] = value;
            }
        }

    }
}