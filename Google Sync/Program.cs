using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace Google_Sync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            src.Outlook Outlook = new Google_Sync.src.Outlook();
            Microsoft.Office.Interop.Outlook.MAPIFolder TaskFolder = Outlook.getTask();
            Microsoft.Office.Interop.Outlook.MAPIFolder CalenderFolder = Outlook.getCalender();
        }
    }
}
