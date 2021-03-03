using otiKiosk_Test_Application;

namespace UsbKiosk_TestApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._btnPay = new System.Windows.Forms.Button();
            this._btnVoid = new System.Windows.Forms.Button();
            this._tbProductNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnPreAuthorize = new System.Windows.Forms.Button();
            this._tbAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._comboCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbManagerEmail = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._lblAdd4 = new System.Windows.Forms.Label();
            this._tbAdd4 = new System.Windows.Forms.TextBox();
            this._lblAdd3 = new System.Windows.Forms.Label();
            this._tbAdd3 = new System.Windows.Forms.TextBox();
            this._lblAdd1 = new System.Windows.Forms.Label();
            this._tbAdd1 = new System.Windows.Forms.TextBox();
            this._tbAdd2 = new System.Windows.Forms.TextBox();
            this._lblAdd2 = new System.Windows.Forms.Label();
            this._tbCardType = new System.Windows.Forms.TextBox();
            this._tbTransactionReference = new System.Windows.Forms.TextBox();
            this._tbPan = new System.Windows.Forms.TextBox();
            this._tbAmountResult = new System.Windows.Forms.TextBox();
            this._tbError = new System.Windows.Forms.TextBox();
            this._tbStatus = new System.Windows.Forms.TextBox();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblPan = new System.Windows.Forms.Label();
            this.lblAuthCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._lblIPAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._btnSaturnVersion = new System.Windows.Forms.Button();
            this._btnKioskVersion = new System.Windows.Forms.Button();
            this._lblOtiKioskVersion = new System.Windows.Forms.Label();
            this._lblReaderVersion = new System.Windows.Forms.Label();
            this._btnLog = new System.Windows.Forms.Button();
            this._tbLog = new System.Windows.Forms.TextBox();
            this._btnGetKioskID = new System.Windows.Forms.Button();
            this._lblKioskID = new System.Windows.Forms.Label();
            this._btnGetStatus = new System.Windows.Forms.Button();
            this._lblGetStatus = new System.Windows.Forms.Label();
            this._btnShowMessage = new System.Windows.Forms.Button();
            this._tbLine1 = new System.Windows.Forms.TextBox();
            this._tbLine2 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._lblReaderMessageIndex = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._lblReaderMessage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._Logger = new otiKiosk_Test_Application.LogDisplay();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this._tbManagerEmailPassword = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this._tbTimeout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._tbEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._btnPay);
            this.groupBox2.Controls.Add(this._btnVoid);
            this.groupBox2.Controls.Add(this._tbProductNo);
            this.groupBox2.Controls.Add(this._tbEmail);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this._btnConfirm);
            this.groupBox2.Controls.Add(this._tbTimeout);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._btnCancel);
            this.groupBox2.Controls.Add(this._btnPreAuthorize);
            this.groupBox2.Controls.Add(this._tbAmount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._comboCurrency);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(372, 540);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // _btnPay
            // 
            this._btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._btnPay.Location = new System.Drawing.Point(9, 229);
            this._btnPay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnPay.Name = "_btnPay";
            this._btnPay.Size = new System.Drawing.Size(321, 51);
            this._btnPay.TabIndex = 22;
            this._btnPay.Text = "Pay Now";
            this._btnPay.UseVisualStyleBackColor = true;
            this._btnPay.Click += new System.EventHandler(this._btnPay_Click);
            // 
            // _btnVoid
            // 
            this._btnVoid.Enabled = false;
            this._btnVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._btnVoid.Location = new System.Drawing.Point(9, 411);
            this._btnVoid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnVoid.Name = "_btnVoid";
            this._btnVoid.Size = new System.Drawing.Size(321, 51);
            this._btnVoid.TabIndex = 20;
            this._btnVoid.Text = "Void";
            this._btnVoid.UseVisualStyleBackColor = true;
            this._btnVoid.Click += new System.EventHandler(this._btnVoid_Click);
            // 
            // _tbProductNo
            // 
            this._tbProductNo.Location = new System.Drawing.Point(164, 154);
            this._tbProductNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbProductNo.Name = "_tbProductNo";
            this._tbProductNo.Size = new System.Drawing.Size(166, 26);
            this._tbProductNo.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Booking Number:";
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Enabled = false;
            this._btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._btnConfirm.Location = new System.Drawing.Point(9, 351);
            this._btnConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(321, 51);
            this._btnConfirm.TabIndex = 17;
            this._btnConfirm.Text = "Confirm";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfir_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Enabled = false;
            this._btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._btnCancel.Location = new System.Drawing.Point(9, 472);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(321, 51);
            this._btnCancel.TabIndex = 13;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnPreAuthorize
            // 
            this._btnPreAuthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._btnPreAuthorize.Location = new System.Drawing.Point(9, 290);
            this._btnPreAuthorize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnPreAuthorize.Name = "_btnPreAuthorize";
            this._btnPreAuthorize.Size = new System.Drawing.Size(321, 51);
            this._btnPreAuthorize.TabIndex = 12;
            this._btnPreAuthorize.Text = "Pre Authorize";
            this._btnPreAuthorize.UseVisualStyleBackColor = true;
            this._btnPreAuthorize.Click += new System.EventHandler(this._btnPreAuthorize_Click);
            // 
            // _tbAmount
            // 
            this._tbAmount.Location = new System.Drawing.Point(164, 73);
            this._tbAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbAmount.Name = "_tbAmount";
            this._tbAmount.Size = new System.Drawing.Size(166, 26);
            this._tbAmount.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Payment Amount:";
            // 
            // _comboCurrency
            // 
            this._comboCurrency.FormattingEnabled = true;
            this._comboCurrency.Location = new System.Drawing.Point(164, 30);
            this._comboCurrency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._comboCurrency.Name = "_comboCurrency";
            this._comboCurrency.Size = new System.Drawing.Size(166, 28);
            this._comboCurrency.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Currency:";
            // 
            // _tbManagerEmail
            // 
            this._tbManagerEmail.Location = new System.Drawing.Point(513, 594);
            this._tbManagerEmail.Name = "_tbManagerEmail";
            this._tbManagerEmail.Size = new System.Drawing.Size(242, 26);
            this._tbManagerEmail.TabIndex = 25;
            this._tbManagerEmail.Text = "put_manager_email_address_here";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this._tbCardType);
            this.groupBox3.Controls.Add(this._tbTransactionReference);
            this.groupBox3.Controls.Add(this._tbPan);
            this.groupBox3.Controls.Add(this._tbAmountResult);
            this.groupBox3.Controls.Add(this._tbError);
            this.groupBox3.Controls.Add(this._tbStatus);
            this.groupBox3.Controls.Add(this.lblCardType);
            this.groupBox3.Controls.Add(this.lblPan);
            this.groupBox3.Controls.Add(this.lblAuthCode);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(380, 48);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(657, 538);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paymet Result";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._lblAdd4);
            this.groupBox4.Controls.Add(this._tbAdd4);
            this.groupBox4.Controls.Add(this._lblAdd3);
            this.groupBox4.Controls.Add(this._tbAdd3);
            this.groupBox4.Controls.Add(this._lblAdd1);
            this.groupBox4.Controls.Add(this._tbAdd1);
            this.groupBox4.Controls.Add(this._tbAdd2);
            this.groupBox4.Controls.Add(this._lblAdd2);
            this.groupBox4.Location = new System.Drawing.Point(0, 300);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(638, 228);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Additional Parameters";
            // 
            // _lblAdd4
            // 
            this._lblAdd4.AutoSize = true;
            this._lblAdd4.Location = new System.Drawing.Point(9, 169);
            this._lblAdd4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblAdd4.Name = "_lblAdd4";
            this._lblAdd4.Size = new System.Drawing.Size(25, 20);
            this._lblAdd4.TabIndex = 18;
            this._lblAdd4.Text = "    ";
            // 
            // _tbAdd4
            // 
            this._tbAdd4.Location = new System.Drawing.Point(183, 165);
            this._tbAdd4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbAdd4.Name = "_tbAdd4";
            this._tbAdd4.ReadOnly = true;
            this._tbAdd4.Size = new System.Drawing.Size(445, 26);
            this._tbAdd4.TabIndex = 19;
            // 
            // _lblAdd3
            // 
            this._lblAdd3.AutoSize = true;
            this._lblAdd3.Location = new System.Drawing.Point(9, 122);
            this._lblAdd3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblAdd3.Name = "_lblAdd3";
            this._lblAdd3.Size = new System.Drawing.Size(25, 20);
            this._lblAdd3.TabIndex = 16;
            this._lblAdd3.Text = "    ";
            // 
            // _tbAdd3
            // 
            this._tbAdd3.Location = new System.Drawing.Point(183, 119);
            this._tbAdd3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbAdd3.Name = "_tbAdd3";
            this._tbAdd3.ReadOnly = true;
            this._tbAdd3.Size = new System.Drawing.Size(445, 26);
            this._tbAdd3.TabIndex = 17;
            // 
            // _lblAdd1
            // 
            this._lblAdd1.AutoSize = true;
            this._lblAdd1.Location = new System.Drawing.Point(9, 34);
            this._lblAdd1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblAdd1.Name = "_lblAdd1";
            this._lblAdd1.Size = new System.Drawing.Size(25, 20);
            this._lblAdd1.TabIndex = 12;
            this._lblAdd1.Text = "    ";
            // 
            // _tbAdd1
            // 
            this._tbAdd1.Location = new System.Drawing.Point(183, 29);
            this._tbAdd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbAdd1.Name = "_tbAdd1";
            this._tbAdd1.ReadOnly = true;
            this._tbAdd1.Size = new System.Drawing.Size(445, 26);
            this._tbAdd1.TabIndex = 13;
            // 
            // _tbAdd2
            // 
            this._tbAdd2.Location = new System.Drawing.Point(183, 74);
            this._tbAdd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbAdd2.Name = "_tbAdd2";
            this._tbAdd2.ReadOnly = true;
            this._tbAdd2.Size = new System.Drawing.Size(445, 26);
            this._tbAdd2.TabIndex = 15;
            // 
            // _lblAdd2
            // 
            this._lblAdd2.AutoSize = true;
            this._lblAdd2.Location = new System.Drawing.Point(9, 82);
            this._lblAdd2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblAdd2.Name = "_lblAdd2";
            this._lblAdd2.Size = new System.Drawing.Size(25, 20);
            this._lblAdd2.TabIndex = 14;
            this._lblAdd2.Text = "    ";
            // 
            // _tbCardType
            // 
            this._tbCardType.Location = new System.Drawing.Point(188, 251);
            this._tbCardType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbCardType.Name = "_tbCardType";
            this._tbCardType.ReadOnly = true;
            this._tbCardType.Size = new System.Drawing.Size(445, 26);
            this._tbCardType.TabIndex = 11;
            // 
            // _tbTransactionReference
            // 
            this._tbTransactionReference.Location = new System.Drawing.Point(188, 161);
            this._tbTransactionReference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbTransactionReference.Name = "_tbTransactionReference";
            this._tbTransactionReference.ReadOnly = true;
            this._tbTransactionReference.Size = new System.Drawing.Size(445, 26);
            this._tbTransactionReference.TabIndex = 10;
            // 
            // _tbPan
            // 
            this._tbPan.Location = new System.Drawing.Point(188, 206);
            this._tbPan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbPan.Name = "_tbPan";
            this._tbPan.ReadOnly = true;
            this._tbPan.Size = new System.Drawing.Size(445, 26);
            this._tbPan.TabIndex = 9;
            // 
            // _tbAmountResult
            // 
            this._tbAmountResult.Location = new System.Drawing.Point(188, 118);
            this._tbAmountResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbAmountResult.Name = "_tbAmountResult";
            this._tbAmountResult.ReadOnly = true;
            this._tbAmountResult.Size = new System.Drawing.Size(445, 26);
            this._tbAmountResult.TabIndex = 8;
            // 
            // _tbError
            // 
            this._tbError.Location = new System.Drawing.Point(188, 72);
            this._tbError.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbError.Name = "_tbError";
            this._tbError.ReadOnly = true;
            this._tbError.Size = new System.Drawing.Size(445, 26);
            this._tbError.TabIndex = 7;
            // 
            // _tbStatus
            // 
            this._tbStatus.Location = new System.Drawing.Point(188, 28);
            this._tbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbStatus.Name = "_tbStatus";
            this._tbStatus.ReadOnly = true;
            this._tbStatus.Size = new System.Drawing.Size(445, 26);
            this._tbStatus.TabIndex = 6;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(14, 258);
            this.lblCardType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(81, 20);
            this.lblCardType.TabIndex = 5;
            this.lblCardType.Text = "Card Type";
            // 
            // lblPan
            // 
            this.lblPan.AutoSize = true;
            this.lblPan.Location = new System.Drawing.Point(14, 214);
            this.lblPan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPan.Name = "lblPan";
            this.lblPan.Size = new System.Drawing.Size(41, 20);
            this.lblPan.TabIndex = 4;
            this.lblPan.Text = "PAN";
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.AutoSize = true;
            this.lblAuthCode.Location = new System.Drawing.Point(14, 171);
            this.lblAuthCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(171, 20);
            this.lblAuthCode.TabIndex = 3;
            this.lblAuthCode.Text = "Transaction Reference";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Error";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Status";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this._lblIPAddress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 930);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1565, 32);
            this.statusStrip1.TabIndex = 6;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(251, 25);
            this.toolStripStatusLabel1.Text = "Communication Port/Address:";
            // 
            // _lblIPAddress
            // 
            this._lblIPAddress.Name = "_lblIPAddress";
            this._lblIPAddress.Size = new System.Drawing.Size(27, 25);
            this._lblIPAddress.Text = "IP";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.communicationToolStripMenuItem,
            this.communicationToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1565, 33);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(33, 29);
            this.communicationToolStripMenuItem.Text = " ";
            this.communicationToolStripMenuItem.Click += new System.EventHandler(this.communicationToolStripMenuIte_Click);
            // 
            // communicationToolStripMenuItem1
            // 
            this.communicationToolStripMenuItem1.Name = "communicationToolStripMenuItem1";
            this.communicationToolStripMenuItem1.Size = new System.Drawing.Size(154, 29);
            this.communicationToolStripMenuItem1.Text = "Communication";
            // 
            // _btnSaturnVersion
            // 
            this._btnSaturnVersion.Location = new System.Drawing.Point(9, 85);
            this._btnSaturnVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnSaturnVersion.Name = "_btnSaturnVersion";
            this._btnSaturnVersion.Size = new System.Drawing.Size(204, 35);
            this._btnSaturnVersion.TabIndex = 2;
            this._btnSaturnVersion.Text = "Get Saturn Version";
            this._btnSaturnVersion.UseVisualStyleBackColor = true;
            this._btnSaturnVersion.Click += new System.EventHandler(this._btnSaturnVersion_Click);
            // 
            // _btnKioskVersion
            // 
            this._btnKioskVersion.Location = new System.Drawing.Point(9, 29);
            this._btnKioskVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnKioskVersion.Name = "_btnKioskVersion";
            this._btnKioskVersion.Size = new System.Drawing.Size(204, 35);
            this._btnKioskVersion.TabIndex = 1;
            this._btnKioskVersion.Text = "Get otiKiosk Version";
            this._btnKioskVersion.UseVisualStyleBackColor = true;
            this._btnKioskVersion.Click += new System.EventHandler(this._btnKioskVersion_Click);
            // 
            // _lblOtiKioskVersion
            // 
            this._lblOtiKioskVersion.AutoSize = true;
            this._lblOtiKioskVersion.Location = new System.Drawing.Point(244, 38);
            this._lblOtiKioskVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblOtiKioskVersion.Name = "_lblOtiKioskVersion";
            this._lblOtiKioskVersion.Size = new System.Drawing.Size(24, 20);
            this._lblOtiKioskVersion.TabIndex = 3;
            this._lblOtiKioskVersion.Text = "---";
            // 
            // _lblReaderVersion
            // 
            this._lblReaderVersion.AutoSize = true;
            this._lblReaderVersion.Location = new System.Drawing.Point(244, 92);
            this._lblReaderVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblReaderVersion.Name = "_lblReaderVersion";
            this._lblReaderVersion.Size = new System.Drawing.Size(24, 20);
            this._lblReaderVersion.TabIndex = 4;
            this._lblReaderVersion.Text = "---";
            // 
            // _btnLog
            // 
            this._btnLog.Location = new System.Drawing.Point(9, 249);
            this._btnLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnLog.Name = "_btnLog";
            this._btnLog.Size = new System.Drawing.Size(204, 35);
            this._btnLog.TabIndex = 7;
            this._btnLog.Text = "Log";
            this._btnLog.UseVisualStyleBackColor = true;
            this._btnLog.Click += new System.EventHandler(this._btnLog_Click);
            // 
            // _tbLog
            // 
            this._tbLog.Location = new System.Drawing.Point(249, 251);
            this._tbLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbLog.Name = "_tbLog";
            this._tbLog.Size = new System.Drawing.Size(210, 26);
            this._tbLog.TabIndex = 8;
            this._tbLog.Text = "Log Sample";
            // 
            // _btnGetKioskID
            // 
            this._btnGetKioskID.Location = new System.Drawing.Point(9, 140);
            this._btnGetKioskID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnGetKioskID.Name = "_btnGetKioskID";
            this._btnGetKioskID.Size = new System.Drawing.Size(204, 35);
            this._btnGetKioskID.TabIndex = 9;
            this._btnGetKioskID.Text = "Get Kiosk ID";
            this._btnGetKioskID.UseVisualStyleBackColor = true;
            this._btnGetKioskID.Click += new System.EventHandler(this._btnGetKioskID_Click);
            // 
            // _lblKioskID
            // 
            this._lblKioskID.AutoSize = true;
            this._lblKioskID.Location = new System.Drawing.Point(244, 148);
            this._lblKioskID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblKioskID.Name = "_lblKioskID";
            this._lblKioskID.Size = new System.Drawing.Size(24, 20);
            this._lblKioskID.TabIndex = 10;
            this._lblKioskID.Text = "---";
            // 
            // _btnGetStatus
            // 
            this._btnGetStatus.Location = new System.Drawing.Point(9, 194);
            this._btnGetStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnGetStatus.Name = "_btnGetStatus";
            this._btnGetStatus.Size = new System.Drawing.Size(204, 35);
            this._btnGetStatus.TabIndex = 11;
            this._btnGetStatus.Text = "Get Status";
            this._btnGetStatus.UseVisualStyleBackColor = true;
            this._btnGetStatus.Click += new System.EventHandler(this._btnGetStatus_Click);
            // 
            // _lblGetStatus
            // 
            this._lblGetStatus.AutoSize = true;
            this._lblGetStatus.Location = new System.Drawing.Point(244, 201);
            this._lblGetStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblGetStatus.Name = "_lblGetStatus";
            this._lblGetStatus.Size = new System.Drawing.Size(24, 20);
            this._lblGetStatus.TabIndex = 12;
            this._lblGetStatus.Text = "---";
            // 
            // _btnShowMessage
            // 
            this._btnShowMessage.Location = new System.Drawing.Point(9, 305);
            this._btnShowMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnShowMessage.Name = "_btnShowMessage";
            this._btnShowMessage.Size = new System.Drawing.Size(204, 35);
            this._btnShowMessage.TabIndex = 13;
            this._btnShowMessage.Text = "Show Message";
            this._btnShowMessage.UseVisualStyleBackColor = true;
            this._btnShowMessage.Click += new System.EventHandler(this._btnShowMessage_Click);
            // 
            // _tbLine1
            // 
            this._tbLine1.Location = new System.Drawing.Point(249, 308);
            this._tbLine1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbLine1.Name = "_tbLine1";
            this._tbLine1.Size = new System.Drawing.Size(210, 26);
            this._tbLine1.TabIndex = 14;
            this._tbLine1.Text = "First Line";
            // 
            // _tbLine2
            // 
            this._tbLine2.Location = new System.Drawing.Point(249, 365);
            this._tbLine2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbLine2.Name = "_tbLine2";
            this._tbLine2.Size = new System.Drawing.Size(210, 26);
            this._tbLine2.TabIndex = 15;
            this._tbLine2.Text = "Second Line";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._lblReaderMessageIndex);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this._lblReaderMessage);
            this.groupBox5.Location = new System.Drawing.Point(9, 419);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(450, 125);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Reader Display";
            // 
            // _lblReaderMessageIndex
            // 
            this._lblReaderMessageIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblReaderMessageIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblReaderMessageIndex.Location = new System.Drawing.Point(370, 50);
            this._lblReaderMessageIndex.Name = "_lblReaderMessageIndex";
            this._lblReaderMessageIndex.Size = new System.Drawing.Size(73, 64);
            this._lblReaderMessageIndex.TabIndex = 2;
            this._lblReaderMessageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Index";
            // 
            // _lblReaderMessage
            // 
            this._lblReaderMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblReaderMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblReaderMessage.Location = new System.Drawing.Point(17, 25);
            this._lblReaderMessage.Name = "_lblReaderMessage";
            this._lblReaderMessage.Size = new System.Drawing.Size(346, 89);
            this._lblReaderMessage.TabIndex = 0;
            this._lblReaderMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this._tbLine2);
            this.groupBox1.Controls.Add(this._tbLine1);
            this.groupBox1.Controls.Add(this._btnShowMessage);
            this.groupBox1.Controls.Add(this._lblGetStatus);
            this.groupBox1.Controls.Add(this._btnGetStatus);
            this.groupBox1.Controls.Add(this._lblKioskID);
            this.groupBox1.Controls.Add(this._btnGetKioskID);
            this.groupBox1.Controls.Add(this._tbLog);
            this.groupBox1.Controls.Add(this._btnLog);
            this.groupBox1.Controls.Add(this._lblReaderVersion);
            this.groupBox1.Controls.Add(this._lblOtiKioskVersion);
            this.groupBox1.Controls.Add(this._btnKioskVersion);
            this.groupBox1.Controls.Add(this._btnSaturnVersion);
            this.groupBox1.Location = new System.Drawing.Point(1045, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(476, 551);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maintenance";
            // 
            // _Logger
            // 
            this._Logger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Logger.ControlToInvoke = null;
            this._Logger.Location = new System.Drawing.Point(18, 622);
            this._Logger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._Logger.Name = "_Logger";
            this._Logger.Size = new System.Drawing.Size(1526, 300);
            this._Logger.TabIndex = 0;
            this._Logger.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(376, 600);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Manager\'s Email:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(758, 597);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Password:";
            // 
            // _tbManagerEmailPassword
            // 
            this._tbManagerEmailPassword.Location = new System.Drawing.Point(847, 594);
            this._tbManagerEmailPassword.Name = "_tbManagerEmailPassword";
            this._tbManagerEmailPassword.PasswordChar = '*';
            this._tbManagerEmailPassword.Size = new System.Drawing.Size(190, 26);
            this._tbManagerEmailPassword.TabIndex = 25;
            this._tbManagerEmailPassword.Text = "11HongYu";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // _tbTimeout
            // 
            this._tbTimeout.Location = new System.Drawing.Point(164, 113);
            this._tbTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._tbTimeout.Name = "_tbTimeout";
            this._tbTimeout.Size = new System.Drawing.Size(166, 26);
            this._tbTimeout.TabIndex = 15;
            this._tbTimeout.Text = "60";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Time out:";
            // 
            // _tbEmail
            // 
            this._tbEmail.Location = new System.Drawing.Point(119, 189);
            this._tbEmail.Name = "_tbEmail";
            this._tbEmail.Size = new System.Drawing.Size(211, 26);
            this._tbEmail.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Your Email:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 962);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._tbManagerEmailPassword);
            this.Controls.Add(this._tbManagerEmail);
            this.Controls.Add(this._Logger);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "otiKiosk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFor_FormClosing);
            this.Load += new System.EventHandler(this.MainFor_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LogDisplay _Logger;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button _btnPreAuthorize;
        private System.Windows.Forms.TextBox _tbAmount;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox _comboCurrency;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblAuthCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbCardType;
        private System.Windows.Forms.TextBox _tbTransactionReference;
        private System.Windows.Forms.TextBox _tbPan;
        private System.Windows.Forms.TextBox _tbAmountResult;
        private System.Windows.Forms.TextBox _tbError;
        private System.Windows.Forms.TextBox _tbStatus;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label lblPan;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.Button _btnVoid;
        private System.Windows.Forms.TextBox _tbProductNo;
        private System.Windows.Forms.TextBox _tbManagerEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbAdd1;
        private System.Windows.Forms.Label _lblAdd1;
        private System.Windows.Forms.TextBox _tbAdd2;
        private System.Windows.Forms.Label _lblAdd2;
        private System.Windows.Forms.TextBox _tbAdd3;
        private System.Windows.Forms.Label _lblAdd3;
        private System.Windows.Forms.Button _btnPay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label _lblAdd4;
        private System.Windows.Forms.TextBox _tbAdd4;
        private System.Windows.Forms.ToolStripStatusLabel _lblIPAddress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.Button _btnSaturnVersion;
        private System.Windows.Forms.Button _btnKioskVersion;
        private System.Windows.Forms.Label _lblOtiKioskVersion;
        private System.Windows.Forms.Label _lblReaderVersion;
        private System.Windows.Forms.Button _btnLog;
        private System.Windows.Forms.TextBox _tbLog;
        private System.Windows.Forms.Button _btnGetKioskID;
        private System.Windows.Forms.Label _lblKioskID;
        private System.Windows.Forms.Button _btnGetStatus;
        private System.Windows.Forms.Label _lblGetStatus;
        private System.Windows.Forms.Button _btnShowMessage;
        private System.Windows.Forms.TextBox _tbLine1;
        private System.Windows.Forms.TextBox _tbLine2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label _lblReaderMessageIndex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label _lblReaderMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _tbManagerEmailPassword;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox _tbTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbEmail;
        private System.Windows.Forms.Label label9;
    }
}

