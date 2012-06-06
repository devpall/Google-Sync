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
        private src.Outlook.Item[] itemArray;
        private Google_Sync.src.Google.Google google;
        private int count = 0;

        private WriteIniFile wIni;
        private XMLWriter xFile;

        /// <summary>
        /// Konstruktor Form1
        /// </summary>
        public Form1()
        {
            wIni = new WriteIniFile();
            xFile = new XMLWriter();
            this.google = new src.Google.Google();
            
            InitializeComponent();

            if (SaveCredentials)
            {
                setCredentials();
                LoginAction();                
            }

            setRadio(getRadio());
            setVersionLbl();
        }

        delegate void IntParameterDelegate(int count);
        delegate void StringParameterDelegate(string value);
  




        /// <summary>
        /// Action für klicken auf Start Button
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (google.getAuth != null)
            {
                this.OCal = new src.OutlookCalendar();
                this.count = OCal.CalendarLength;
                itemArray = new src.Outlook.Item[OCal.CalendarLength];
                for (int i = 1; i < OCal.CalendarLength + 1; i++)
                {
                    AppointmentItem oItem = (AppointmentItem)OCal.Calendar.Items[i];
                    itemArray[i - 1] = new src.Outlook.Item(oItem);
                }
                xFile.write(itemArray);
                
            }
           
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
            if (SaveBx.Checked)
            {
                UserName = NameBx.Text;
                Password = PasswordBx.Text;
            }


            SaveCredentials = SaveBx.Checked;

            LoginAction();
            /*
             * Changed on 29.05.2012
             * Veraltet
             * By Andreas Fritz
            Settings["Login"]["Username"] = NameBx.Text;
            Settings["Login"]["Password"] = Encryption.EncryptString(PasswordBx.Text,password);
            Settings["Login"]["Save Credentials"] = SaveBx.Checked.ToString();
             */
        }
   
        #region getter und setter für Username, Passwort und Login Speicher Checkbox
        /// <summary>
        /// Liest und schreibt den Ini Datei Wert für das Speicher der Logins
        /// </summary>
        /// <returns></returns>
        private bool SaveCredentials
        {
            get
            {
                return wIni.Save;
            }
            set
            {
                wIni.Save = value;
            }
        }

        /// <summary>
        /// Liest und schreibt den Ini Datei Wert für den Usernamen
        /// </summary>
        /// <returns>Passwort aus der Ini Datei </returns>
        private string Password
        {
            get
            {
                return wIni.Password;
            }
            set
            {
                wIni.Password = value;
            }
        }

        /// <summary>
        /// Liest und schreibt den Ini Datei Wert für den Usernamen
        /// </summary>
        /// <returns>Username aus der Ini Datei</returns>
        private string UserName
        {
            get
            {
                return wIni.Username;
            }
            set
            {
                wIni.Username = value;
            }
        }
        #endregion

        #region Schreiben der Ini Datei werte für die Radio Buttons
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
        #endregion

        #region Methoden zum setzen der Steuerelemente, Login Info Label, Account Name Label, Radio Buttons, Versions Label
        /// <summary>
        /// Zeigt in der GUI an ob Login erfolgreich war oder nicht
        /// </summary>
        /// <param name="text"></param>
        private void showLoginInfoLbl(string text)
        {
            LoginInfoLbl.Text = text;
            LoginInfoLbl.Visible = true;
            this.Update();
        }

        /// <summary>
        /// Übergibt den Google Account Namen an die Form zurück
        /// </summary>
        private void showGoogleAccountName()
        {
            AccountLbl.Text = NameBx.Text;
            this.Update();
        }

        /// <summary>
        /// Setze die Radiobutton beim Start der Applikation
        /// </summary>
        /// <param name="radioArray">Werte für die einzelnen Radiobuttons</param>
        private void setRadio(bool[,] radioArray)
        {
            radioButton1.Checked = radioArray[0, 0];
            radioButton2.Checked = radioArray[0, 1];
            radioButton3.Checked = radioArray[0, 2];
            radioButton4.Checked = radioArray[1, 0];
            radioButton5.Checked = radioArray[1, 1];
            radioButton6.Checked = radioArray[1, 2];

        }

        /// <summary>
        /// Aus der Ini Datei gelesen werte für den Login werden zurück an die GUI geschickt.
        /// </summary>
        private void setCredentials()
        {
            SaveBx.Checked = SaveCredentials;
            NameBx.Text = UserName;
            PasswordBx.Text = Password;
        }

        /// <summary>
        /// Schreibt Version in den Versionlabel der Applikation
        /// </summary>
        private void setVersionLbl()
        {
            VersionLbl.Text = Version();
        }
        
        #endregion

        #region Action Methods

        /// <summary>
        /// Veranlasst den Login bei Google
        /// </summary>
        private void LoginAction()
        {
            this.google = new src.Google.Google(NameBx.Text, PasswordBx.Text);
            if (google.loginSuccess)
            {
                showGoogleAccountName();
                showLoginInfoLbl("Logged in");
            }
            else
            {
                showLoginInfoLbl("Invalid Credentials");
            }
        }

        /// <summary>
        /// Gibt die Ini File Werte für die Sync Optionen wieder
        /// Category & Timeintervall
        /// </summary>
        /// <returns></returns>
        private bool[,] getRadio()
        {
            bool[,] radioArray = new bool[2, 3];

            string cat = wIni.Category;
            string tim = wIni.Intervall;

            switch (cat)
            {
                case "Label":
                    radioArray[0, 0] = true;
                    radioArray[0, 1] = false;
                    radioArray[0, 2] = false;
                    break;
                case "Calendar":
                    radioArray[0, 0] = false;
                    radioArray[0, 1] = true;
                    radioArray[0, 2] = false;
                    break;
                case "Nothing":
                    radioArray[0, 0] = false;
                    radioArray[0, 1] = false;
                    radioArray[0, 2] = true;
                    break;
                default:
                    radioArray[0, 0] = false;
                    radioArray[0, 1] = false;
                    radioArray[0, 2] = false;
                    break;
            }
            switch (tim)
            {
                case "Startup":
                    radioArray[1, 0] = true;
                    radioArray[1, 1] = false;
                    radioArray[1, 2] = false;
                    break;
                case "60":
                    radioArray[1, 0] = false;
                    radioArray[1, 1] = true;
                    radioArray[1, 2] = false;
                    break;
                case "Off":
                    radioArray[1, 0] = false;
                    radioArray[1, 1] = false;
                    radioArray[1, 2] = true;
                    break;
                default:
                    radioArray[1, 0] = false;
                    radioArray[1, 1] = false;
                    radioArray[1, 2] = false;
                    break;
            }



            return radioArray;

        }

        /// <summary>
        /// Ermittelt Version der Applikation
        /// </summary>
        /// <returns>Version der Applikation</returns>
        private string Version()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        #endregion
    }
}
