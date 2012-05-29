using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Google_Sync.src;


namespace Google_Sync
{
    public partial class Form1 : Form
    {
        const string password = "bNvG$G&MnK_%alpbSu7x[c0/63A90#]f{6w0>C6*5[Vfn[fX[Ex%";

        private OutlookCalendar OCal;
        private int i;
        private int count;
        private string progress = null;

        private IniFile Settings;

        /// <summary>
        /// Konstruktor Form1
        /// </summary>
        public Form1()
        {
            Settings = new src.IniFile(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Google Sync\config.ini");

            
            InitializeComponent();

            if (checkSaveCredentials())
            {
                SaveBx.Checked = checkSaveCredentials();
                NameBx.Text = getUserName();
                PasswordBx.Text = getPassword();
            }
            setRadio(getRadio());
            setVersionLbl();
        }

        delegate void IntParameterDelegate(int count);
        delegate void StringParameterDelegate(string value);
  
        /// <summary>
        /// Ermittelt Version der Applikation
        /// </summary>
        /// <returns>Version der Applikation</returns>
        private string Version()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Schreibt Version in den Versionlabel der Applikation
        /// </summary>
        private void setVersionLbl()
        {
            VersionLbl.Text = Version();
        }

        /// <summary>
        /// Action für klicken auf Start Button
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            this.OCal = new src.OutlookCalendar();
            this.count = OCal.CalendarLength;

           
        }        
        private void StopBtn_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings["Login"]["Username"] = NameBx.Text;
            Settings["Login"]["Password"] = Encryption.EncryptString(PasswordBx.Text,password);
            Settings["Login"]["Save Credentials"] = SaveBx.Checked.ToString();
        }

        private bool checkSaveCredentials()
        {
            if (Settings["Login"]["Save Credentials"] == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string getUserName()
        {
            return Settings["Login"]["Username"];
        }

        private string getPassword()
        {
            return Encryption.DecryptString(Settings["Login"]["Password"], password);
        }

        private bool[,] getRadio()
        {
            bool[,] radioArray = new bool[2,3];
            
            string cat = Settings["Sync Options"]["Category"];
            string tim = Settings["Sync Options"]["Intervall"];
            
            switch (cat)
            {
                case "Label":
                    radioArray[0,0] = true;
                    radioArray[0,1] = false;
                    radioArray[0,2] = false;
                    break;
                case "Calendar":
                    radioArray[0,0] = false;
                    radioArray[0,1] = true;
                    radioArray[0,2] = false;
                    break;
                case "Nothing":
                    radioArray[0,0] = false;
                    radioArray[0,1] = false;
                    radioArray[0,2] = true;
                    break;
                default:
                    radioArray[0,0] = false;
                    radioArray[0,1] = false;
                    radioArray[0,2] = false;
                    break;
            }
            switch (tim)
            {
                case "Startup":
                    radioArray[1,0] = true;
                    radioArray[1,1] = false;
                    radioArray[1,2] = false;
                    break;
                case "60":
                    radioArray[1,0] = false;
                    radioArray[1,1] = true;
                    radioArray[1,2] = false;
                    break;
                case "Off":
                    radioArray[1,0] = false;
                    radioArray[1,1] = false;
                    radioArray[1,2] = true;
                    break;
                default:
                    radioArray[1,0] = false;
                    radioArray[1,1] = false;
                    radioArray[1,2] = false;
                    break;
            }
      


            return radioArray;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings["Sync Options"]["Category"] = "Label";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Settings["Sync Options"]["Category"] = "Calendar";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Settings["Sync Options"]["Category"] = "Nothing";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Settings["Sync Options"]["Intervall"] = "Startup";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Settings["Sync Options"]["Intervall"] = "60";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Settings["Sync Options"]["Intervall"] = "Off";
        }

        private void setRadio(bool[,] radioArray)
        {
            radioButton1.Checked = radioArray[0,0];
            radioButton2.Checked = radioArray[0,1];
            radioButton3.Checked = radioArray[0,2];
            radioButton4.Checked = radioArray[1,0];
            radioButton5.Checked = radioArray[1,1];
            radioButton6.Checked = radioArray[1,2];

        }

    }
}
