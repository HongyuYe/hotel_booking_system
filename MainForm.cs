using System;
using System.Threading;
using System.Windows.Forms;
using otiKiosk;
using otiKiosk.Communication;
using otiKiosk_Test_Application;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Collections.Generic;
using UsbKiosk_TestApplication.Models;
using Newtonsoft.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace UsbKiosk_TestApplication
{
    public enum CurrencyCodeChoice : ushort
    {
        //Pound_Sterling = 0826,
        //US_Dollar = 0840,
        //Euro = 0978,
        //Chinese_Yuan_Renminbi = 0156,
        AU_Dollar = 0036,
    }

    public enum ButtonState
    {
        Pay,
        Cancel,
        ConfirmVoid
    };

    public partial class MainForm : Form
    {
        private const string MSG_THANKS = "Thanks!";
        private const string MSG_IDLE1 = "oti Kiosk";
        private const string MSG_IDLE2 = "";
        private const string MSG_CONFIRM1 = "Please click";
        private const string MSG_CONFIRM2 = "on 'Confirm'";
        private readonly KioskHandler _kioskHandler;
        private bool _isPayTransaction;
        private readonly Label[] _labelsAddParams;
        private readonly TextBox[] _boxsAddParams;
        private int previousId = 1;
        private int previousRefundId = 1;
        private string apiURL = "put_api_url_here";
        private string apiURL2 = "put_api_url_here";
        //static HttpClient client = new HttpClient();
        private bool _isTransaction = false;



        public MainForm()
        {
            InitializeComponent();
            _labelsAddParams = new Label[] {_lblAdd1, _lblAdd2, _lblAdd3, _lblAdd4};
            _boxsAddParams = new TextBox[] {_tbAdd1, _tbAdd2, _tbAdd3, _tbAdd4};
            _Logger.ControlToInvoke = this;
            _kioskHandler = new KioskHandler(_Logger);
            _kioskHandler.TransactionComplateEvent += _kioskHandler_TransactionComplateEvent;
            _kioskHandler.ReaderMessageEvent += _kioskHandler_ReaderMessageEvent;
            _kioskHandler.ErrorMessage += _kioskHandler_ErrorMessage;
            timer1.Start();
            timer2.Start();
        }

        void _kioskHandler_ErrorMessage(string errorMessage)
        {
            _Logger.AddText(errorMessage, Messagetype.Error);
        }

        /// <summary>
        /// Raises the ReaderMessageArrived event.
        /// convert index to Reader Display Message
        /// </summary>
        /// <param name="index">Message index</param>
        private void _kioskHandler_ReaderMessageEvent(int index)
        {
            try
            {
                BeginInvoke(new ThreadStart(delegate
                {
                    decimal amount;
                    if (!decimal.TryParse(_tbAmount.Text, out amount))
                    {
                        throw new Exception("Illegal amount");
                    }

                    _lblReaderMessage.Text = ReaderMessage.GetMessage(index,
                        string.Format("{0}", amount));
                    _lblReaderMessageIndex.Text = index.ToString("X");
                }));
            }
            catch (Exception ex)
            {
                _Logger.AddText(ex.Message, Messagetype.Error);
            }
        }


        /// <summary>
        /// Init parameters, open communication port to Telebox and send Idle message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFor_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " v" + Application.ProductVersion;
            _Logger.AddText("Application Start", Messagetype.Message);
            _comboCurrency.DataSource = Enum.GetValues(typeof (CurrencyCodeChoice));
            _comboCurrency.Text = "AU_Dollar";

            _kioskHandler.Start();
            OpenComm();
            IdleMessage();
        }

        /// <summary>
        /// Open communication port to Telebox
        /// </summary>
        private void OpenComm()
        {
            string commAddress;
            if (!_kioskHandler.OpenComm(out commAddress))
                _Logger.AddText("No Communication", Messagetype.Error);
            _lblIPAddress.Text = commAddress;
        }

        /// <summary>
        /// Shows IDLE message on the Saturn Reader's display
        /// </summary>
        private void IdleMessage()
        {
            string error;
            try
            {
                ShowMessage(MSG_IDLE1, MSG_IDLE2);
                return;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                System.Threading.Thread.Sleep(1000);
            }
            _Logger.AddText(error, Messagetype.Error);
        }

        /// <summary>
        /// Close communication port to Telebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _kioskHandler.Close();
        }

        #region Maintenance

        /// <summary>
        /// The user click on 'Get otiKiosk Version' button to get otiKiosk version
        /// </summary>
        private void _btnKioskVersion_Click(object sender, EventArgs e)
        {
            try
            {
                string strVersion = _kioskHandler.GetVersion(SoftwareComponent.otiKiosk);
                _Logger.AddText("otiKiosk version: " + strVersion, Messagetype.Message);
                _lblOtiKioskVersion.Text = strVersion;
            }
            catch (KioskCommException jex)
            {
                _Logger.AddText(
                    string.Format("GetVersion failed with code: {0} and message: {1}", jex.Code, jex.Message),
                    Messagetype.Error);
            }
            catch (Exception ex)
            {
                _Logger.AddText(ex.ToString(), Messagetype.Error);
            }
        }

        /// <summary>
        /// The user click on 'Get Saturn Version' button to get Saturn Reader version
        /// </summary>
        private void _btnSaturnVersion_Click(object sender, EventArgs e)
        {
            try
            {
                string strVersion = _kioskHandler.GetVersion(SoftwareComponent.Reader);
                _Logger.AddText("Reader version: " + strVersion, Messagetype.Message);
                _lblReaderVersion.Text = strVersion;

            }
            catch (KioskCommException jex)
            {

                _Logger.AddText(
                    string.Format("GetVersion failed with code: {0} and message: {1}", jex.Code, jex.Message),
                    Messagetype.Error);
            }
            catch (Exception ex)
            {

                _Logger.AddText(ex.ToString(), Messagetype.Error);
            }

        }
        /// <summary>
        /// Send message to write to otiKiosk log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                // Log level:0: don't log, 1:Error, 3: Info, 5: Debug
                _kioskHandler.log(5, _tbLog.Text);

            }
            catch (Exception ex)
            {

                _Logger.AddText(ex.ToString(), Messagetype.Error);
            }
        }

        /// <summary>
        /// Display a message on satuen reader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnShowMessage_Click(object sender, EventArgs e)
        {
            ShowMessage(_tbLine1.Text, _tbLine2.Text);
        }

        private void ShowMessage(string line1, string line2)
        {
            try
            {
                _kioskHandler.ShowMessage(line1, line2);
                BeginInvoke(new ThreadStart(delegate
                {
                    _lblReaderMessage.Text = line1 + "\n" + line2;
                    _lblReaderMessageIndex.Text = "";
                }));

            }
            catch (Exception ex)
            {

                _Logger.AddText(ex.ToString(), Messagetype.Error);
            }

        }

        /// <summary>
        /// Get the Kiosh ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnGetKioskID_Click(object sender, EventArgs e)
        {
            try
            {
                string strID = _kioskHandler.GetKioskID();
                _Logger.AddText("Kiosk ID: " + strID, Messagetype.Message);
                _lblKioskID.Text = strID;

            }
            catch (KioskCommException jex)
            {

                _Logger.AddText(
                    string.Format("GetKioskID failed with code: {0} and message: {1}", jex.Code, jex.Message),
                    Messagetype.Error);
            }
            catch (Exception ex)
            {

                _Logger.AddText(ex.ToString(), Messagetype.Error);
            }
        }


        /// <summary>
        /// Return the otiKiosk status
        /// NotReady, Ready, PaymentTransaction, Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                AppStatus status = _kioskHandler.GetStatus();
                _Logger.AddText("Status: " + status, Messagetype.Message);
                _lblGetStatus.Text = status.ToString();

            }
            catch (KioskCommException jex)
            {

                _Logger.AddText(
                    string.Format("GetStatus failed with code: {0} and message: {1}", jex.Code, jex.Message),
                    Messagetype.Error);
            }
            catch (Exception ex)
            {

                _Logger.AddText(ex.ToString(), Messagetype.Error);
            }

        }

        #endregion

        #region Payment

        /// <summary>
        /// The Authorization Detail
        /// </summary>
        private AuthorizationDetails _authorizationDetails;

        private AuthorizationDetails LastAuthorizationDetails
        {
            get { return _authorizationDetails ?? (_authorizationDetails = new AuthorizationDetails()); }
            set { _authorizationDetails = value; }
        }

        /// <summary>
        /// Send Pay transaction request to Telebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnPay_Click(object sender, EventArgs e)
        {
            _isTransaction = true;
            try
            {
                _isPayTransaction = true;
            ushort currency;
            decimal Amount;
            int timeout;
            if (!PrepareTransaction(out currency, out Amount, out timeout))
                return;
                EnablePaymentButton(ButtonState.Cancel);
                // stat transaction
                _kioskHandler.PayTransaction(Amount, currency, timeout);

            }
            catch (Exception ex)
            {
                _Logger.AddText("Failed PayTransaction - " + ex.Message, Messagetype.Error);
                EnablePaymentButton(ButtonState.Pay);
            }
        }

        private void payNow(decimal payment)
        {
            _isTransaction = true;
            try
            {
                _isPayTransaction = true;
                ushort currency;
                decimal Amount = payment;
                int timeout;
                if (!PrepareTransaction(out currency, out Amount, out timeout))
                    return;
                EnablePaymentButton(ButtonState.Cancel);
                // stat transaction
                _kioskHandler.PayTransaction(Amount, currency, timeout);
            }
            catch (Exception ex)
            {
                _Logger.AddText("Failed PayTransaction - " + ex.Message, Messagetype.Error);
                EnablePaymentButton(ButtonState.Pay);
            }
        }


        /// <summary>
        /// Send Authorize Transaction to Telebox
        /// </summary>
        private void _btnPreAuthorize_Click(object sender, EventArgs e)
        {
            _isTransaction = true;
            try
            {
                _isPayTransaction = false;
            ushort currency;
            decimal Amount;
            int timeout;
            if (!PrepareTransaction(out currency, out Amount, out timeout))
                return;
                EnablePaymentButton(ButtonState.Cancel);
                // stat transaction
                _kioskHandler.PreAuthorize(Amount, currency, timeout);

            }
            catch (Exception ex)
            {
                _Logger.AddText("Failed StartTransaction - " + ex.Message, Messagetype.Error);
                EnablePaymentButton(ButtonState.Pay);
            }
        }

        private void preAuthorizeNow(decimal payment)
        {
            _isTransaction = true;
            try
            {
                _isPayTransaction = false;
                ushort currency;
                decimal Amount = payment;
                int timeout;
                if (!PrepareTransaction(out currency, out Amount, out timeout))
                    return;
                EnablePaymentButton(ButtonState.Cancel);
                // stat transaction
                _kioskHandler.PreAuthorize(Amount, currency, timeout);

            }
            catch (Exception ex)
            {
                _Logger.AddText("Failed StartTransaction - " + ex.Message, Messagetype.Error);
                EnablePaymentButton(ButtonState.Pay);
            }
        }

        /// <summary>
        /// Init control and get the transaction ditiles from user
        /// </summary>
        /// <param name="currency">return the currency code</param>
        /// <param name="Amount">return the actual amount</param>
        /// <param name="timeout">return the transaction timeout</param>
        /// <returns></returns>
        private bool PrepareTransaction(out ushort currency, out decimal Amount, out int timeout)
        {
            _tbStatus.Text = "";
            _tbError.Text = "";
            _tbAmountResult.Text = "";
            _tbTransactionReference.Text = "";
            _tbPan.Text = "";
            _tbCardType.Text = "";
            _tbAdd1.Text = "";
            _tbAdd2.Text = "";
            _tbAdd3.Text = "";
            timeout = 0;
            Amount = 0;
            Update();

            currency = 0;
            try
            {
                // Currency code
                CurrencyCodeChoice status;
                if (_comboCurrency.SelectedValue != null)
                {
                    Enum.TryParse(_comboCurrency.SelectedValue.ToString(), out status);
                    currency = Convert.ToUInt16(status);
                }
                else
                {
                    currency = Convert.ToUInt16(_comboCurrency.Text, 10);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Please type valid currency", @"Pay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // paymet amount

            if (!decimal.TryParse(_tbAmount.Text, out Amount))
            {
                MessageBox.Show("Please type valid Amount", @"Pay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }

            // transaction timeout

            if (!int.TryParse(_tbTimeout.Text, out timeout))
            {
                MessageBox.Show("Please type valid timeout", @"Pay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }

            return true;

        }

        /// <summary>
        /// The user click on 'Cancel' button to cancel a transaction before user present is card
        /// </summary>
        private void _btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                EnablePaymentButton(ButtonState.Pay);
                CancelStatus status = _kioskHandler.CancelTransaction();

                _Logger.AddText(string.Format("CancelTransaction return {0}", status), Messagetype.FromKiosk);

                // wait for built-in Kiosk 'CANCELLING' message to show
                System.Threading.Thread.Sleep(3000);
                IdleMessage();
            }
            catch (Exception ex)
            {
                _Logger.AddText(ex.Message, Messagetype.Error);
            }
            _isTransaction = false;
        }

        private void CancelNow()
        {
            try
            {
                EnablePaymentButton(ButtonState.Pay);
                CancelStatus status = _kioskHandler.CancelTransaction();

                _Logger.AddText(string.Format("CancelTransaction return {0}", status), Messagetype.FromKiosk);

                // wait for built-in Kiosk 'CANCELLING' message to show
                System.Threading.Thread.Sleep(3000);
                IdleMessage();
            }
            catch (Exception ex)
            {
                _Logger.AddText(ex.Message, Messagetype.Error);
            }
            _isTransaction = false;
        }

        /// <summary>
        /// The user click on 'Confirm' button to confirm the authorized  transaction
        /// </summary>
        private void _btnConfir_Click(object sender, EventArgs e)
        {
            // the confirm amount
            decimal Amount;
            if (!decimal.TryParse(_tbAmount.Text, out Amount))
            {
                MessageBox.Show("Please type valid Amount", @"Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // the product number, The Windsor Hotel doesn't have product number, set to 0
            int productNo;
            if (!int.TryParse("0", out productNo))
            {
                MessageBox.Show("Please type valid Product No.", @"Confirm", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!_kioskHandler.ConfirmTransaction(LastAuthorizationDetails.Transaction_Referance, Amount, productNo))
                    return;

                _tbAmountResult.Text = Amount.ToString("F");
                DisplayThanksMessage(Amount);
                LastAuthorizationDetails.Transaction_Referance = null;
                EnablePaymentButton(ButtonState.Pay);
            }
            catch (Exception ex)
            {
                _Logger.AddText("Failed ConfirmTransaction - " + ex.Message, Messagetype.Error);
            }
        }

        private void ConfirmNow(string reference, string amount)
        {
            // the confirm amount
            decimal Amount;
            if (!decimal.TryParse(amount, out Amount))
            {
                MessageBox.Show("Please type valid Amount", @"Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // the product number, The Windsor Hotel doesn't have product number, set to 0
            int productNo;
            if (!int.TryParse("0", out productNo))
            {
                MessageBox.Show("Please type valid Product No.", @"Confirm", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!_kioskHandler.ConfirmTransaction(reference, Amount, productNo))
                    return;

                _tbAmountResult.Text = Amount.ToString("F");
                DisplayThanksMessage(Amount);
                //LastAuthorizationDetails.Transaction_Referance = null;
                EnablePaymentButton(ButtonState.Pay);
            }
            catch (Exception ex)
            {
                _Logger.AddText("Failed ConfirmTransaction - " + ex.Message, Messagetype.Error);
            }
        }

        /// <summary>
        /// The user click on 'Void' button to void the authorized transaction
        /// </summary>
        private void _btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = _kioskHandler.VoidTransaction(LastAuthorizationDetails.Transaction_Referance);
                _Logger.AddText(string.Format("VoidTransaction return {0}", status), Messagetype.FromKiosk);
                if (status)
                    _tbStatus.Text = "Voided";
                EnablePaymentButton(ButtonState.Pay);
                IdleMessage();

            }
            catch (Exception ex)
            {
                _Logger.AddText(ex.Message, Messagetype.Error);
            }

        }

        private void VoidNow(string reference)
        {
            try
            {
                bool status = _kioskHandler.VoidTransaction(reference);
                _Logger.AddText(string.Format("VoidTransaction return {0}", status), Messagetype.FromKiosk);
                if (status)
                    _tbStatus.Text = "Voided";
                EnablePaymentButton(ButtonState.Pay);
                IdleMessage();
            }
            catch (Exception ex)
            {
                _Logger.AddText(ex.Message, Messagetype.Error);
            }

        }

        /// <summary>
        /// TransactionComplateEvent event arrived with the transaction details
        /// </summary>
        private async void _kioskHandler_TransactionComplateEvent(AuthorizationDetails authorizationDetails)
        {
            BeginInvoke(new ThreadStart(delegate
            {
                EnablePaymentButton(authorizationDetails.status == Status.OK && !_isPayTransaction
                    ? ButtonState.ConfirmVoid
                    : ButtonState.Pay);


                _tbStatus.Text = authorizationDetails.status.ToString();


                // display error
                if (authorizationDetails.ErrorCode != 0)
                {
                    _tbError.Text = string.Format("{0}. code: {1}", authorizationDetails.ErrorDescription,
                        authorizationDetails.ErrorCode);
                }
  
                // store transactopn detailes for Confirm or Void transaction
                LastAuthorizationDetails = authorizationDetails;

                // display transaction detailes
                _tbAmountResult.Text = authorizationDetails.AmountAuthorized.ToString("F");
                _tbTransactionReference.Text = authorizationDetails.Transaction_Referance;
                _tbPan.Text = authorizationDetails.PartialPan;
                _tbCardType.Text = authorizationDetails.CardType;

                // additional parameters
                for (int i = 0; i < _labelsAddParams.Length && i < _boxsAddParams.Length; i++)
                {
                    if (i >= authorizationDetails.additionalParameters.Count)
                    {
                        _labelsAddParams[i].Visible = false;
                        _boxsAddParams[i].Visible = false;
                        continue;
                    }
                    _labelsAddParams[i].Text = authorizationDetails.additionalParameters[i].Name;
                    _boxsAddParams[i].Text = authorizationDetails.additionalParameters[i].Value;
                }

                // show complete message on Saturn Reader
                try
                {
                    // wait for built-in Kiosk 'APPROVED' message to show
                    System.Threading.Thread.Sleep(3000);


                    // if error => display idle message
                    if (authorizationDetails.ErrorCode != 0 || authorizationDetails.status != Status.OK)
                    {
                        IdleMessage();
                        return;
                    }

                    if (_isPayTransaction)
                    {
                        DisplayThanksMessage(authorizationDetails.AmountAuthorized);
                    }
                    else // pre-auth
                        ShowMessage(MSG_CONFIRM1, MSG_CONFIRM2);

                }
                catch (Exception ex)
                {
                    _Logger.AddText(ex.ToString(), Messagetype.Error);
                }
            }));

            //update data and send emails
            //var response = await _httpClient.GetAsync(apiURL);
            ////var results = await response.Content.ReadAsAsync<IEnumerable<Transaction>>();
            //Transaction last_transaction = new Transaction();
            //if (response.IsSuccessStatusCode)
            //{
            //    List<Transaction> transactions = (new JavaScriptSerializer()).Deserialize<List<Transaction>>(response.Content.ReadAsStringAsync().Result);
            //    if (transactions.Count > 0) { last_transaction = transactions.Last(); }
            //}
            _isTransaction = false;
            Transaction last_transaction = new Transaction();
            last_transaction = await get_Last_Transaction(apiURL);
            if (authorizationDetails.status != Status.OK)
            {
                if(authorizationDetails.status == Status.Declined || authorizationDetails.status == Status.Voided || authorizationDetails.status == Status.Error)
                {
                    last_transaction.paid = false;
                    last_transaction.cardDetected = true;
                }
                else
                {
                    last_transaction.paid = false;
                    last_transaction.cardDetected = false;
                }
                await update_Transaction(last_transaction);
            }
            else
            {
                last_transaction.paid = true;
                last_transaction.cardDetected = true;
                await update_Transaction(last_transaction);
                sendEmail(_tbManagerEmail.Text, _tbManagerEmailPassword.Text, _tbEmail.Text, last_transaction, authorizationDetails);
            } 
        }

        /// <summary>
        /// Display Thanks message
        /// </summary>
        /// <param name="Amount"></param>
        private void DisplayThanksMessage(decimal Amount)
        {
            ShowMessage(MSG_THANKS, string.Format("{0}", Amount.ToString("F")));
            Application.DoEvents();
            System.Threading.Thread.Sleep(3000);
            // show idle messsage
            IdleMessage();
        }

        /// <summary>
        /// Enable or disable button according to the transaction process
        /// </summary>
        /// <param name="state"></param>
        private void EnablePaymentButton(ButtonState state)
        {
            _btnPreAuthorize.Enabled = state == ButtonState.Pay;
            _btnPay.Enabled = state == ButtonState.Pay;
            _btnCancel.Enabled = state == ButtonState.Cancel;
            _btnVoid.Enabled = state == ButtonState.ConfirmVoid || state == ButtonState.Pay;
            _btnConfirm.Enabled = state == ButtonState.ConfirmVoid;
        }

        #endregion

        /// <summary>
        /// Select communication mode and port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void communicationToolStripMenuIte_Click(object sender, EventArgs e)
        {
            CommFrm frm = new CommFrm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            OpenComm();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Transaction last_transaction = new Transaction();
            last_transaction = await get_Last_Transaction(apiURL);
            if(last_transaction.cancel == true && _isTransaction == true)
            {
                CancelNow();
            }
            if (last_transaction.email != "ujsvjdjvfs@protonmail.com")
            {
                if (previousId != last_transaction.transactionId)
                {
                    if(last_transaction.total == 0)
                    {
                        previousId = last_transaction.transactionId;
                        _tbEmail.Text = last_transaction.email;
                        sendEmail(_tbManagerEmail.Text, _tbManagerEmailPassword.Text, _tbEmail.Text, last_transaction);
                    }
                    else
                    {
                        previousId = last_transaction.transactionId;
                        //_tbName.Text = last_transaction.firstName + " " + last_transaction.lastName;
                        _tbEmail.Text = last_transaction.email;
                        _tbProductNo.Text = "0";
                        _tbAmount.Text = last_transaction.total.ToString();

                        if (last_transaction.deposit == true)
                        {
                            preAuthorizeNow(last_transaction.total);
                        }
                        else
                        {
                            payNow(last_transaction.total);
                        }
                    }
                }
            }
            else
            {
                previousId = last_transaction.transactionId;
            }
            timer1.Interval = 1000;
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            Refund last_refund = new Refund();
            last_refund = await get_Last_Refund(apiURL2);
            if (last_refund.reference != "0")
            {
                if (previousRefundId != last_refund.refundId)
                {
                    previousRefundId = last_refund.refundId;
                    if (last_refund.isRefund == true)
                    {
                        VoidNow(last_refund.reference);
                    }
                    else
                    {
                        ConfirmNow(last_refund.reference, last_refund.amount);
                    }
                }
            }
            else
            {
                previousRefundId = last_refund.refundId;
            }

            timer2.Interval = 1000;
        }


        static async Task<Transaction> update_Transaction(Transaction transaction)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("put_api_url_here");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/transactions/{transaction.transactionId}", transaction);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            transaction = await response.Content.ReadAsAsync<Transaction>();
            return transaction;
        }

        static async Task<Transaction> get_Last_Transaction(string path)
        {
            List<Transaction> transactions = null;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //transaction = await response.Content.ReadAsAsync<Transaction>();
                transactions = (new JavaScriptSerializer()).Deserialize<List<Transaction>>(response.Content.ReadAsStringAsync().Result);
            }
            return transactions.Last(); 
        }

        static async Task<Refund> get_Last_Refund(string path)
        {
            List<Refund> refunds = null;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //transaction = await response.Content.ReadAsAsync<Transaction>();
                refunds = (new JavaScriptSerializer()).Deserialize<List<Refund>>(response.Content.ReadAsStringAsync().Result);
            }
            return refunds.Last();
        }

        private void sendEmail(string senderAddress, string senderPassword, string receiverAddress, Transaction transaction, AuthorizationDetails authorizationDetails)
        {
            SmtpClient client = new SmtpClient();//create SmtpClient instance to send email
            client.Host = "smtp.gmail.com";//SMTP server host
            client.Port = 587;//port
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(senderAddress, senderPassword);//check email address and password
            client.EnableSsl = true;
            MailMessage message = new MailMessage();
            MailAddress from = new MailAddress(senderAddress);//get sender email address

            if (receiverAddress != "")
            {
                if (Regex.IsMatch(receiverAddress, "\\w+@\\w+(\\.\\w+)+"))  //use regular expression to check receiver email address
                {
                    MailAddress to = new MailAddress(receiverAddress);//get receiver email address
                    message.To.Add(to);//set receiver, the attribute To in MailMessage class can add multiple receivers
                }
                else
                {
                    MessageBox.Show("your email address is not valid.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("your email address cannot be empty.");
                return;
            }
            if (senderAddress != "")
            {
                if (Regex.IsMatch(senderAddress, "\\w+@\\w+(\\.\\w+)+"))
                {
                    MailAddress cc = new MailAddress(senderAddress);
                    message.CC.Add(cc);
                }
                else
                {
                    MessageBox.Show("manager's email address is not valid.");
                    return;
                }
            }

            if (transaction.deposit == true)
            {
                message.Subject = "Security bond / damage deposit receipt from The Windsor Hotel - Booking Number: " + transaction.bookingNumber;//get email title
                                                                                                                                                      //get the email body
                message.Body = "Security bond / damage deposit receipt from The Windsor Hotel<br/>" + "Booking Number: " + transaction.bookingNumber + "<br/>Transaction Reference Number: " + authorizationDetails.Transaction_Referance + "<br/>Name: " + transaction.firstName + " " + transaction.lastName + "<br/>Amount Paid: " + authorizationDetails.AmountAuthorized.ToString("F") + " AUD<br/>Phone Number: " + transaction.phoneNumber + "<br/>Card number:" + authorizationDetails.PartialPan + "<br/>Card Type: " + authorizationDetails.CardType + "<br/>Note: security bond / damage deposit will be released after check-out if no damage.";
            }
            else
            {
                message.Subject = "Receipt from The Windsor Hotel - Booking Number: " + transaction.bookingNumber;//get email title
                //get the email body
                message.Body = "Receipt from The Windsor Hotel<br/>" + "Booking Number: " + transaction.bookingNumber + "<br/>Transaction Reference Number: " + authorizationDetails.Transaction_Referance + "<br/>Name: " + transaction.firstName + " " + transaction.lastName + "<br/>Amount Paid: " + authorizationDetails.AmountAuthorized.ToString("F") + " AUD<br/>Phone Number: " + transaction.phoneNumber + "<br/>Card number:" + authorizationDetails.PartialPan + "<br/>Card Type: " + authorizationDetails.CardType;
            }
            message.From = from;//set sender email address.
            message.IsBodyHtml = true;
            client.Send(message);
        }

        private void sendEmail(string senderAddress, string senderPassword, string receiverAddress, Transaction transaction)
        {
            SmtpClient client = new SmtpClient();//create SmtpClient instance to send email
            client.Host = "smtp.gmail.com";//SMTP server host
            client.Port = 587;//port
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(senderAddress, senderPassword);//check email address and password
            client.EnableSsl = true;
            MailMessage message = new MailMessage();
            MailAddress from = new MailAddress(senderAddress);//get sender email address

            if (receiverAddress != "")
            {
                if (Regex.IsMatch(receiverAddress, "\\w+@\\w+(\\.\\w+)+"))  //use regular expression to check receiver email address
                {
                    MailAddress to = new MailAddress(receiverAddress);//get receiver email address
                    message.To.Add(to);//set receiver, the attribute To in MailMessage class can add multiple receivers
                }
                else
                {
                    MessageBox.Show("your email address is not valid.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("your email address cannot be empty.");
                return;
            }
            if (senderAddress != "")
            {
                if (Regex.IsMatch(senderAddress, "\\w+@\\w+(\\.\\w+)+"))
                {
                    MailAddress cc = new MailAddress(senderAddress);
                    message.CC.Add(cc);
                }
                else
                {
                    MessageBox.Show("manager's email address is not valid.");
                    return;
                }
            }

            message.Subject = "Booking from The Windsor Hotel - Booking Number: " + transaction.bookingNumber;//get email title
            //get the email body
            message.Body = "Booking from The Windsor Hotel<br/>" + "Booking Number: " + transaction.bookingNumber + "<br/>Name: " + transaction.firstName + " " + transaction.lastName + "<br/>Amount Paid: unknown (paid somewhere else) <br/>Phone Number: " + transaction.phoneNumber;
            message.From = from;//set sender email address.
            message.IsBodyHtml = true;
            client.Send(message);
        }
    }
}


