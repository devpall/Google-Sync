using System.Runtime.InteropServices;
using System.Text;

namespace Google_Sync.src
{
    /// <summary>
    /// Klasse zum schreiben und lesen der Ini Datei
    /// </summary>
    public class IniFile
    {
        /// <summary>
        /// Pfad der Ini Datei
        /// </summary>
        private string path;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="INIPath">Pfad zur Ini-Datei</param>
        public IniFile(string INIPATH)
        {
            path = INIPATH;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                          int size, string filePath);
        /// <summary>
        /// Sektion der Ini Datei
        /// </summary>
        /// <param name="Section">Name der Sektion</param>
        /// <returns>Sektion</returns>
        public Section this[string Section]
        {
            get { return new Section(Section, this);}
        }
        /// <summary>
        /// Sektion Struktur
        /// </summary>
        public class Section
        {
            private string Name;
            private IniFile File;

            /// <summary>
            /// Konstruktor für Section
            /// </summary>
            /// <param name="name">Name der Sektion</param>
            /// <param name="file">Verweis auf Ini Datei</param>
            public Section(string name, IniFile file)
            {
                this.Name = name;
                this.File = file;
            }

            /// <summary>
            /// Schreibt oder ermittelt einen Ini Wert
            /// </summary>
            /// <param name="Key">Bezeichner des Wertes</param>
            /// <returns>String des Wertes</returns>
            public string this[string Key]
            {
                get { return File.IniReadValue(Name, Key); }
                set { if (value != this[Key]) File.IniWriteValue(Name, Key, value); }
            }
        }

        /// <summary>
        /// Schreibt einen Ini Wert
        /// </summary>
        /// <param name="Section">Name der Sektion</param>
        /// <param name="Key">Bezeichner des Wertes</param>
        /// <param name="Value">Wert</param>
        protected void IniWriteValue (string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        protected string IniReadValue (string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section,Key, "", temp, 255, this.path);
            return temp.ToString();
        }


    }
}