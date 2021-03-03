using System;
using System.Reflection;
using otiKiosk.Communication;
using otiKiosk_Test_Application;

namespace UsbKiosk_TestApplication
{

    class KioskHandler
    {
        readonly LogDisplay _Logger;
        readonly KioskComm _clsUsbComm;

        public event _TransactionComplateEvent TransactionComplateEvent;
        public event _ReaderMessageEvent ReaderMessageEvent;
        public event _ErrorMessage ErrorMessage;
  
        public KioskHandler(LogDisplay logger)
        {
            _Logger = logger;
            _clsUsbComm = new KioskComm();
            _clsUsbComm.TransactionComplateArrived += _clsUsbCom_TransactionComplateArrived;
            _clsUsbComm.CommandReceive += _clsUsbCom_CommandReceive;
            _clsUsbComm.CommandSend += _clsUsbCom_CommandSend;
            _clsUsbComm.ReaderMessageEvent += _clsUsbCom_ReaderMessageEvent;
            _clsUsbComm.ErrorMessage += _clsUsbComm_ErrorMessage;
        }

        void _clsUsbComm_ErrorMessage(string errorMessage)
        {
            if (ErrorMessage != null)
                ErrorMessage(errorMessage);
        }

        /// <summary>
        /// Send the ReaderMessageEvent to application
        /// </summary>
        /// <param name="index"></param>
        void _clsUsbCom_ReaderMessageEvent(int index)
        {
            if (ReaderMessageEvent != null)
                ReaderMessageEvent(index);
        }

        /// <summary>
        /// Write the outgoing command to logger
        /// </summary>
        /// <param name="cmd"></param>
        void _clsUsbCom_CommandSend(string cmd)
        {
            _Logger.AddText(cmd, Messagetype.ToKiosk);
        }

        /// <summary>
        /// Write the incaming message to logger
        /// </summary>
        /// <param name="cmd"></param>
        void _clsUsbCom_CommandReceive(string cmd)
        {
            _Logger.AddText(cmd, Messagetype.FromKiosk);
        }

        /// <summary>
        /// Send the transaction complate event to application
        /// </summary>
        /// <param name="details"></param>
        void _clsUsbCom_TransactionComplateArrived(AuthorizationDetails details)
        {
            TransactionComplateEvent(details);
        }

     
        /// <summary>
        /// open communication port to Telebox
        /// </summary>
        /// <param name="commAddress"></param>
        /// <returns></returns>
        public bool OpenComm(out string commAddress)
        {
            return _clsUsbComm.OpenComm(out commAddress);
        }

        #region POS commands

        /// <summary>
        /// Send command to Telebox
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        private bool SendCommand(string methodName, object[] prms)
        {
            _Logger.AddText(string.Format("Send {0} message", methodName), Messagetype.ToKiosk);
            MethodInfo mi = GetType().GetMethod(methodName);
            return _clsUsbComm.SendCommand(mi, prms);
        }

        /// <summary>
        /// Send Payment Transaction request
        /// </summary>
        /// <param name="amount">Amout of the transaction</param>
        /// <param name="currencyCode">Transaction Currence Code</param>
        /// <param name="timeout">Trnasactuion Timeout</param>
        public void PayTransaction(decimal amount, ushort currencyCode, int timeout)
        {
            object[] prms = { amount, currencyCode, timeout };
            if (!SendCommand("PayTransaction", prms))
                throw new Exception("Communication error - PayTransaction");

         }


        /// <summary>
        /// Send Authorize Transaction request
        /// </summary>
        /// <param name="amount">Amout of the transaction</param>
        /// <param name="currencyCode">Transaction Currence Code</param>
        /// <param name="timeout">Trnasactuion Timeout</param>
        public void PreAuthorize(decimal amount, ushort currencyCode, int timeout)
        {
            object[] prms = { amount, currencyCode, timeout };
            if (!SendCommand("PreAuthorize", prms))
                throw new Exception("Communication error - PreAuthorize");
        }

        /// <summary>
        /// Confirm the transaction
        /// </summary>
        /// <param name="transactionReference">Transaction Referance from Authorize transaction response</param>
        /// <param name="amount">Amout to confirm</param>
        /// <param name="productID">the Product ID</param>
        /// <returns></returns>
        public bool ConfirmTransaction(string transactionReference, decimal amount, int productID)
        {
            object[] prms ={ transactionReference, amount, productID };
            return SendCommand("ConfirmTransaction", prms);
        }

        /// <summary>
        /// Cancel poll for card
        /// </summary>
        /// <returns></returns>
        public CancelStatus CancelTransaction()
        {
            CancelStatus eStatus;
            _Logger.AddText(string.Format("Send CancelTransaction message"), Messagetype.ToKiosk);
            MethodInfo mi = GetType().GetMethod("CancelTransaction");
            string strStatus = _clsUsbComm.SendReceiveCommand(mi, null);
            if (!Enum.TryParse(strStatus, false, out eStatus))
                throw new Exception("The returned CancelStatus value is ilegal");
            return eStatus;


        }

        /// <summary>
        /// Void Pay or Authorize transacrtion
        /// </summary>
        /// <param name="transactionReference"></param>
        /// <returns></returns>
        public bool VoidTransaction(string transactionReference)
        {

            object[] prms = { transactionReference };
            return SendCommand("VoidTransaction", prms);

        }

        /// <summary>
        /// Get Telebox or Reader firmware version
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public string GetVersion(SoftwareComponent component)
        {
            _Logger.AddText(string.Format("Send GetVersion message"), Messagetype.ToKiosk);
            MethodInfo mi = GetType().GetMethod("GetVersion");
            String strVersion = _clsUsbComm.SendReceiveCommand(mi, new object[] { component });
            if(string.IsNullOrEmpty(strVersion))
                throw new TimeoutException("GerVersion command not response");
            _Logger.AddText(strVersion, Messagetype.Message);
            return strVersion;
        }

        /// <summary>
        /// Get the Telebox Terminal ID
        /// </summary>
        /// <returns></returns>
        public string GetKioskID()
        {
            _Logger.AddText(string.Format("Send GetKioskID message"), Messagetype.ToKiosk);
            MethodInfo mi = GetType().GetMethod("GetKioskID");
            String strID = _clsUsbComm.SendReceiveCommand(mi, null);
            if (string.IsNullOrEmpty(strID))
                throw new TimeoutException("GetKioskID command not response");
            _Logger.AddText(strID, Messagetype.Message);

            return strID;

        }


        /// <summary>
        /// Get Status of the system
        /// </summary>
        /// <returns></returns>
        public AppStatus GetStatus()
        {
            _Logger.AddText(string.Format("Send GetStatus message"), Messagetype.ToKiosk);
            MethodInfo mi = GetType().GetMethod("GetStatus");
             String message = _clsUsbComm.SendReceiveCommand(mi, null);
            
            if(string.IsNullOrEmpty(message))
               throw new TimeoutException("GetStatus command not response");
            _Logger.AddText(message, Messagetype.Message);

            AppStatus status;
            if (!Enum.TryParse(message, out status))
                throw new TimeoutException("Illegal AppStatus value");

                return status;
        }

        /// <summary>
        /// Write messages to the Telebox Logs
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void log(int level, string message)
        {
            // Log level:0: don't log, 1:Error, 3: Info, 5: Debug
            object[] prms =  { level, message };
            if (!SendCommand("log", prms))
                throw new Exception("log method return with false");
        }

        /// <summary>
        /// Display message on reader screen
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        public void ShowMessage(string line1, string line2)
        {
            object[] prms = { line1, line2 };
            if(!SendCommand("ShowMessage", prms))
                throw new Exception("ShowMessage method return with false");

        }


        #endregion


        public void Close()
        {

            _clsUsbComm.Stop();
        }

        public void Start()
        {
            _clsUsbComm.Start();
        }
    }
}
