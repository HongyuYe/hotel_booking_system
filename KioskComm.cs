using System;
using System.Threading;
using System.Windows.Forms;
using OTI.Comm;
using OTI.Utilities;
using otiKiosk.Communication;

namespace UsbKiosk_TestApplication
{
    public delegate void _TransactionComplateEvent(AuthorizationDetails details);

    public delegate void _ReaderMessageEvent(int index);

    public delegate void _CommandSendReceive(string cmd);

    public delegate void _ErrorMessage(string errorMessage);


    public enum SoftwareComponent
    {
        otiKiosk,
        Reader
    }


    public enum Status
    {
        OK,
        Declined,
        Error,
        Timeout,
        Cancelled,
        Voided
    }

    public enum CancelStatus
    {
        OK,
        NoTransaction,
        CannotCancel
    };


    public enum AppStatus
    {
        NotReady,
        Ready,
        PaymentTransaction,
        Update
    };

    public class KioskComm
    {

        // The name of the key must include a valid root.

        private CommDll _clsComm;
        private readonly OTI.Reader.CommunicationsSettings _settings;
        private static readonly AutoResetEvent _autoEvent = new AutoResetEvent(false);
        private string _lastResult = "";
        private bool _isRunning;
        private int _lastIndex;



        #region Interface methodes

        public event _TransactionComplateEvent TransactionComplateArrived;
        public event _ReaderMessageEvent ReaderMessageEvent;
        public event _CommandSendReceive CommandSend;
        public event _CommandSendReceive CommandReceive;
        public event _ErrorMessage ErrorMessage;

        private readonly Thread _thread;



        public KioskComm()
        {
            _clsComm = new CommDll();
            _settings = new OTI.Reader.CommunicationsSettings();
            _thread = new Thread(ReceiveMessageFromDevice);

        }

        public void Start()
        {
            _isRunning = true;
            _thread.Start();
        }

        public void Stop()
        {
            _isRunning = false;
            _clsComm.Close();
        }

        
        /// <summary>
        /// Send a command using TCP port
        /// </summary>
        /// <param name="mi">The method info</param>
        /// <param name="methodValues">The method values</param>
        public bool SendCommand(System.Reflection.MethodInfo mi, object[] methodValues)
        {
            // if port not open then open it
            if (_clsComm == null || !_clsComm.IsOpen)
            {
                _clsComm = new CommDll();
                _settings.OpenComm(_clsComm);
            }

            // Serialize the method
            string usbp = KioskProtocol.Serialize(mi, methodValues);

            // send the command
            return WriteData(usbp);
        }


        /// <summary>
        /// Send and receive command
        /// </summary>
        /// <param name="mi">The method to send</param>
        /// <param name="methodValues">methos parameters</param>
        /// <returns>the response parameter</returns>
        public string SendReceiveCommand(System.Reflection.MethodInfo mi, object[] methodValues)
        {
            // send the command
            if (!SendCommand(mi, methodValues))
                throw new Exception("Communication error on command " + mi.Name);
            _autoEvent.Reset();
            // wait for response from Telebox
            if (!_autoEvent.WaitOne(5000))
                throw new Exception("no response to command " + mi.Name);

            return _lastResult;
        }

        /// <summary>
        /// Reading continuously the port for getting response messages
        /// </summary>
        private void ReceiveMessageFromDevice()
        {
            ByteArray ba = new ByteArray();
            while (_isRunning)
            {
                try
                {
                    Thread.Sleep(10);
                    // check if port open
                    if (!_clsComm.IsOpen)
                        continue;

                    // read data
                    ba += _clsComm.ReadData(1000, 100, 100);

                    // wait for the end of the message
                    if (IsEndOfMessage(ba))
                    {
                        string data = DByte.byte_array_to_String(ba);
                        ba = new ByteArray();
                        if (string.IsNullOrEmpty(data))
                            continue;

                        // if receive more the one message the split the message and handle each of the messages
                        string[] split = data.Split(new char[] {'\n', '\r'});

                        foreach (var response in split)
                        {

                            if (string.IsNullOrEmpty(response))
                                continue;

                            if (CommandReceive != null)
                                CommandReceive(response);
                            Application.DoEvents();

                            // handle message
                            HandleMessage(response);
                        }
                    }
                }

                catch (Exception ex)
                {

                    if (ErrorMessage != null)
                        ErrorMessage("Error get Response data - " + ex.Message);

                }
            }
        }

        /// <summary>
        /// Handling the receiving message arriving from Telebox
        /// </summary>
        /// <param name="response">The response message</param>
        private void HandleMessage(string response)
        {
            try
            {
                // the response message is Transaction Complate event
                if (response.StartsWith("TransactionComplete"))
                {
                    AuthorizationDetails details = KioskProtocol.GetAuthorizationDetails(response);
                    TransactionComplateArrived(details);
                }

                // the response message is Reader Message event
                else if (response.StartsWith("ReaderMessageEvent"))
                {
                    string response1 = response.Replace("ReaderMessageEvent", "");
                    int index = Convert.ToInt32(KioskProtocol.DeserializeResponse(response1), 16);
                    // do not send the message index twice
                    if (_lastIndex == index)
                        return;
                    _lastIndex = index;

                    if (ReaderMessageEvent != null)
                        ReaderMessageEvent(index);
                }


                // the response message is Command response
                else
                {
                    _lastResult = KioskProtocol.DeserializeResponse(response);
                    _autoEvent.Set();

                }

            }
            catch
            {
                if (ErrorMessage != null)
                    ErrorMessage("Error Deserialize Response data - " + (response ?? "null"));
            }
        }

        /// <summary>
        /// Check if it is complate message from Telebox
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        private bool IsEndOfMessage(ByteArray ba)
        {
            if (ba == null || ba.Length < 2)
                return false;

            return (ba[ba.Length - 2] == 0x0D || ba[ba.Length - 2] == 0x0A) &&
                   (ba[ba.Length - 1] == 0x0D || ba[ba.Length - 1] == 0x0A);
        }

        #endregion

        /// <summary>
        /// Open communication port to Telebox
        /// </summary>
        /// <param name="commAddress">return the Communication port or address</param>
        /// <returns></returns>
        public bool OpenComm(out string commAddress)
        {
            commAddress = _settings.Channel == Channels.TCP ? _settings.IP_Address : "Port: " + _settings.Port;
            _settings.commSettings.BaudRate = CommDll.BaudRateChoice.Baud115200;
            bool commAlreadyOpen = false;

            try
            {
                commAlreadyOpen = _clsComm != null && _clsComm.IsOpen;
            }
            catch 
            {
                // continue
            }

            // try existing connection
            if (commAlreadyOpen)
            {
                return IsConnectedToTelebox();
            }

            // try last good connection
            if (_settings.LoadFromRegistry())
            {
                if (_settings.OpenComm(_clsComm))
                {
                    commAddress = _settings.Channel == Channels.TCP
                        ? _settings.IP_Address
                        : "Port: " + _settings.Port;
                    return IsConnectedToTelebox();
                }
                return false;
            }

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            _settings.Channel = Channels.RS232;
            foreach (var item in ports)
            {

                _settings.Port = Rs232.Rs232.GetNumFromPortName(item);
                if (_settings.OpenComm(_clsComm) && IsConnectedToTelebox())
                {
                    commAddress = _settings.Channel == Channels.TCP
                        ? _settings.IP_Address
                        : "Port: " + _settings.Port;
                    return true;
                }
                _clsComm.Close();
            }


            throw new Exception("No communication");
        }



        /// <summary>
        /// Get the connect firmware version
        /// </summary>
        /// <returns></returns>
        private bool IsConnectedToTelebox()
        {
            const string GET_VERSION_RESPONSE = "GetVersion(id=1 component=otiKiosk)";
            try
            { 
                _autoEvent.Reset();
                // send to connect 3000
                if (!WriteData(GET_VERSION_RESPONSE))
                    return false;
                _clsComm.TimeOut = 2000;
                // receive from connect 3000
                if (!_autoEvent.WaitOne(2000))
                    return false;
                return (!string.IsNullOrEmpty(_lastResult) && _lastResult != GET_VERSION_RESPONSE);


            }
            catch (Exception)
            {

                _clsComm.Close();
                return false;
            }
        }

        private bool WriteData(string cmd)
        {
            if (CommandSend != null)
                CommandSend(cmd);
            Application.DoEvents();

            return _clsComm.WriteData(cmd);

        }

        

    }
}
