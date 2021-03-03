using System;

namespace UsbKiosk_TestApplication
{
    public enum ErrorCodes
    {
        messageParse = -32700,
        General = -1000,
        Terminate = -999,
        Timeout = -998,
        Payment = -997,
        ReaderCommunication = -996
    }

    class KioskCommException:Exception
    {
        readonly ErrorCodes _ErrorCodes;

        public ErrorCodes Code{get{return _ErrorCodes;}}

        public KioskCommException(ErrorCodes code, string message, string additionalMessage)
            : base(string.Format("{0} - {1}. Error Code:{2}", message, additionalMessage ?? "", code))
        {
            _ErrorCodes = code;
        }
    }
}
