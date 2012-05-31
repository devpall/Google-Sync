using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Google_Sync.src
{
    class HardwareID
    {
        private string hardwareID;


        public HardwareID()
        {
            hardwareID = setHardwareID(GetProccessorID(), GetMainboardID(), GetSystemDriveID());
        }

        /// <summary>
        /// Erhalte die CPU ID von einem oder mehreren CPUs
        /// TODO: Log Klasse schreiben
        /// </summary>
        /// <returns></returns>
        internal static string GetProccessorID()
        {
            StringBuilder sb = new StringBuilder();
            string squery = "SELECT ProcessorId FROM Win32_Processor";
            try
            {

                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(squery);
                ManagementObjectCollection oCollection = oSearcher.Get();

                foreach (ManagementObject oObject in oCollection)
                {
                    sb.Append(oObject["ProcessorId"].ToString());
                }
                return sb.ToString();
            }
            catch(Exception exception)
            {
                //TODO: Log Eintrag erzeugen.
                return "";
            }
        }

        internal static string GetSystemDriveID()
        {
            StringBuilder sb = new StringBuilder();
            string squery = "SELECT * FROM Win32_PhysicalMedia";
            try
            {

                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(squery);
                ManagementObjectCollection oCollection = oSearcher.Get();

                foreach (ManagementObject oObject in oCollection)
                {
                    sb.Append(oObject["SerialNumber"].ToString());
                }
                
            }
            catch(Exception exception)
            {
                //TODO: Log Eintrag erzeugen.
                sb.Append("");
            }

            return sb.ToString();
        }

        internal static string GetMainboardID()
        {
            StringBuilder sb = new StringBuilder();
            string squery = "SELECT * FROM Win32_BaseBoard";
            try
            {

                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(squery);
                ManagementObjectCollection oCollection = oSearcher.Get();

                foreach (ManagementObject oObject in oCollection)
                {
                    sb.Append(oObject["SerialNumber"].ToString());
                }
                return sb.ToString();
            }
            catch(Exception exception)
            {
                //TODO: Log Eintrag erzeugen.
                return "";
            }
        }

        internal static string setHardwareID(string cpuId, string mainboardId, string systemdriveId)
        {
            return cpuId + mainboardId + systemdriveId;
        }

        public string getHardawareID()
        {
            return this.hardwareID;
        }
    }
}
