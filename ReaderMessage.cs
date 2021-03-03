using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otiKiosk
{
    class ReaderMessage
    {
        private string[] _listMessages;

        private ReaderMessage()
        {
            _listMessages = new string[0x28];
            _listMessages[0x00] = "";
            _listMessages[0x01] = "Present card\n{0}";
            _listMessages[0x02] = "";
            _listMessages[0x03] = "{0}\nPlease present\none card only";
            _listMessages[0x04] = "Please\nremove card";
            _listMessages[0x05] = "Please present\none card only";
            _listMessages[0x06] = "Approved";
            _listMessages[0x07] = "Approved";
            _listMessages[0x08] = "Not Approved";
            _listMessages[0x09] = "Not Approved";
            _listMessages[0x0A] = "Terminated";
            _listMessages[0x0B] = "PIN Entry Required\n– see attendant";
            _listMessages[0x0C] = "See Phone";
            _listMessages[0x0D] = "Approved sign";
            _listMessages[0x0E] = "Use\nChip Reader";
            _listMessages[0x0F] = "";
            _listMessages[0x10] = "";
            _listMessages[0x11] = "Welcome";
            _listMessages[0x12] = "Thank You";
            _listMessages[0x13] = "";
            _listMessages[0x14] = "";
            _listMessages[0x15] = "Please Use\nOther Card";
            _listMessages[0x16] = "";
            _listMessages[0x17] = "";
            _listMessages[0x18] = "";
            _listMessages[0x19] = "Please Wait";
            _listMessages[0x1A] = "International\nCard, Please\nSwipe!";
            _listMessages[0x1B] = "";
            _listMessages[0x1C] = "";
            _listMessages[0x1D] = "";
            _listMessages[0x1E] = "Timed Out\nPlease insert\nor swipe card";
            _listMessages[0x1F] = "";
            _listMessages[0x20] = "";
            _listMessages[0x21] = "";
            _listMessages[0x22] = "Please Swipe\nCard";
            _listMessages[0x23] = "Card read\nOK Remove card";
            _listMessages[0x24] = "Authorizing\nPlease wait";
            _listMessages[0x25] = "Communication\nFailure";
            _listMessages[0x26] = "Please insert\nor swipe card";
            _listMessages[0x27] = "{0}\nRead error\nPlease try again";
        }

        public static string GetMessage(int index,string amount)
        {
            if (index < 0 || index > 0x27)
                return "";

            return string.Format(new ReaderMessage()._listMessages[index], amount); 
        }
    }
}
