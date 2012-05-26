using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Sync.src
{
    public class work
    {
        private bool[] checkbox = null;
        private Microsoft.Office.Interop.Outlook.MAPIFolder folder;

        public Microsoft.Office.Interop.Outlook.MAPIFolder[] irgendwas(bool[] in_check)
        {
            this.checkbox = in_check;
            src.Outlook Outlook = new Google_Sync.src.Outlook();

            for (int i = 0; i < this.checkbox.Length; i++)
            {
                if (this.checkbox[i])
                {
                }
            }

            if (this.checkbox[1])
            {
                Microsoft.Office.Interop.Outlook.MAPIFolder TaskFolder = Outlook.getTask();
            }
        }

    }
}
