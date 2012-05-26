using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Sync.src
{
    public class work
    {
        private bool[] checkbox = null;

        
        public void irgendwas(bool[] in_check)
        {
            this.checkbox = in_check;
            src.Outlook Outlook = new Google_Sync.src.Outlook();

            if (this.checkbox[1])
            {
                Microsoft.Office.Interop.Outlook.MAPIFolder TaskFolder = Outlook.getTask();
            }
        }

    }
}
