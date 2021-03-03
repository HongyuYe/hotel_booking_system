namespace otiKiosk_Test_Application
{
    partial class CommFrm
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
            this._rbTcp = new System.Windows.Forms.RadioButton();
            this._tbIPAddress = new System.Windows.Forms.TextBox();
            this._rbRs232 = new System.Windows.Forms.RadioButton();
            this._btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _rbTcp
            // 
            this._rbTcp.AutoSize = true;
            this._rbTcp.Location = new System.Drawing.Point(13, 13);
            this._rbTcp.Name = "_rbTcp";
            this._rbTcp.Size = new System.Drawing.Size(46, 17);
            this._rbTcp.TabIndex = 0;
            this._rbTcp.TabStop = true;
            this._rbTcp.Text = "TCP";
            this._rbTcp.UseVisualStyleBackColor = true;
            this._rbTcp.CheckedChanged += new System.EventHandler(this._rbTcp_CheckedChanged);
            // 
            // _tbIPAddress
            // 
            this._tbIPAddress.Location = new System.Drawing.Point(75, 13);
            this._tbIPAddress.Name = "_tbIPAddress";
            this._tbIPAddress.Size = new System.Drawing.Size(197, 20);
            this._tbIPAddress.TabIndex = 1;
            // 
            // _rbRs232
            // 
            this._rbRs232.AutoSize = true;
            this._rbRs232.Location = new System.Drawing.Point(13, 50);
            this._rbRs232.Name = "_rbRs232";
            this._rbRs232.Size = new System.Drawing.Size(58, 17);
            this._rbRs232.TabIndex = 2;
            this._rbRs232.TabStop = true;
            this._rbRs232.Text = "RS232";
            this._rbRs232.UseVisualStyleBackColor = true;
            this._rbRs232.CheckedChanged += new System.EventHandler(this._rbRs232_CheckedChanged);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(13, 92);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(197, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CommFrm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 127);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._rbRs232);
            this.Controls.Add(this._tbIPAddress);
            this.Controls.Add(this._rbTcp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Communication Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommFr_FormClosing);
            this.Load += new System.EventHandler(this.CommFr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton _rbTcp;
        private System.Windows.Forms.TextBox _tbIPAddress;
        private System.Windows.Forms.RadioButton _rbRs232;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button button2;
    }
}