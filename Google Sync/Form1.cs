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
       

        private OutlookCalendar OCal;
        private Google_Sync.src.Google.Google google;
        private int i;
        private int count;
        private string progress = null;

        private WriteIniFile wIni;

        /// <summary>
        /// Konstruktor Form1
        /// </summary>
        public Form1()
        {
            wIni = new WriteIniFile();

            
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
        /// <summary>
        /// Action für den Stop Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopBtn_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Action für den Ok Button im Config Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            wIni.Username = NameBx.Text;
            wIni.Password = PasswordBx.Text;
            wIni.Save = SaveBx.Checked;
            
            this.google = new src.Google.Google(NameBx.Text, PasswordBx.Text);
            this.google.Login();

            /*
             * Changed on 29.05.2012
             * Veraltet
             * By Andreas Fritz
            Settings["Login"]["Username"] = NameBx.Text;
            Settings["Login"]["Password"] = Encryption.EncryptString(PasswordBx.Text,password);
            Settings["Login"]["Save Credentials"] = SaveBx.Checked.ToString();
             */
        }

        /// <summary>
        /// Gibt den Ini File Wert zurück ob Login gespeichert oder nicht.
        /// </summary>
        /// <returns></returns>
        private bool checkSaveCredentials()
        {
            return wIni.Save;
        }

        /// <summary>
        /// Gibt den Ini File Wert für den Usernamen zurück
        /// </summary>
        /// <returns></returns>
        private string getUserName()
        {
            return wIni.Username;
        }

        /// <summary>
        /// Gibt den Ini File Wert für das Passwort decrypted zurück
        /// </summary>
        /// <returns></returns>
        private string getPassword()
        {
            return wIni.Password;
        }

        /// <summary>
        /// Gibt die Ini File Werte für die Sync Optionen wieder
        /// Category & Timeintervall
        /// </summary>
        /// <returns></returns>
        private bool[,] getRadio()
        {
            bool[,] radioArray = new bool[2,3];
            
            string cat = wIni.Category;
            string tim = wIni.Intervall;
            
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

        /// <summary>
        /// Action für den ersten Radio Button (Categorie - neues Label)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            wIni.Category = "Label";
        }

        /// <summary>
        /// Action für den zweiten Radio Button (Categorie - neuer Kalender)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            wIni.Category = "Calendar";
        }

        /// <summary>
        /// Action für den dritten Radio Button (Categorie - Alles in einem)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            wIni.Category = "Nothing";
        }

        /// <summary>
        /// Action für den vierten Radio Button (Intervall - beim Starten syncen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            wIni.Intervall = "Startup";
        }

        /// <summary>
        /// Action für den fünften Radio Button (Intervall - aller 60 minuten syncen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            wIni.Intervall = "60";
        }

        /// <summary>
        /// Action für den sechsten Radio Button (Intervall - aus)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            wIni.Intervall = "Off";
        }

        /// <summary>
        /// Setze die Radiobutton beim Start der Applikation
        /// </summary>
        /// <param name="radioArray">Werte für die einzelnen Radiobuttons</param>
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
