using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otiKiosk_Test_Application
{

    public enum Messagetype { FromKiosk,ToKiosk,Message,Error}
    public class LogDisplay:System.Windows.Forms.RichTextBox
    {
        public Control ControlToInvoke{set;get;}


        public void AddText(string msg, Messagetype mtype)
        {
            if (ControlToInvoke == null)
                return;
            ControlToInvoke.BeginInvoke(new ThreadStart( delegate 
            { 
                Color oldColor = SelectionColor;
                SelectionColor = GetColor(mtype);
                msg = TextWithPrefix(mtype, msg);
                if (!Text.EndsWith("\n"))
                    msg = "\n" + msg;
                AppendText(msg); 
                ScrollToCaret();
                SelectionColor = oldColor;
                Invalidate();
            }));
            return;


         }

        private string TextWithPrefix(Messagetype mtype, string msg)
        {
            string prefix;
            switch (mtype)
            {
                case Messagetype.FromKiosk:
                    prefix = ">> ";
                    break;
                case Messagetype.ToKiosk:
                    prefix = "<< ";
                    break;
                case Messagetype.Message:
                    prefix = "** ";
                    break;
                case Messagetype.Error:
                    prefix = "!! ";
                    break;
                default:
                    prefix = "** ";
                    break;
            }

            return prefix + msg + "\n";
        }

        private Color GetColor(Messagetype mtype)
        {
            switch (mtype)
            {
                case Messagetype.FromKiosk:
                    return Color.Green;
                case Messagetype.ToKiosk:
                    return Color.Blue;
                case Messagetype.Message:
                    return Color.Black;
                case Messagetype.Error:
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }


        public void AddTextWithParams(string msg, object[] args, Messagetype messagetype)
        {

            if (args != null && args.Length > 0)
            {
                msg += " With parameters: ";
                foreach (var item in args)
                {
                    msg += item.ToString() + "' ";
                }
            }

            AddText(msg, messagetype);
        }
    }
}
