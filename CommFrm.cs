using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace otiKiosk_Test_Application
{
    public partial class CommFrm : Form
    {
        private OTI.Reader.CommunicationsSettings _settings = new OTI.Reader.CommunicationsSettings();
        public CommFrm()
        {
            InitializeComponent();
        }

        private void CommFr_Load(object sender, EventArgs e)
        {
            if (!_settings.LoadFromRegistry())
            {
                _rbTcp.Checked = true;
                return;
            }

            _tbIPAddress.Text = _settings.IP_Address;
            _rbTcp.Checked = _settings.Channel == OTI.Comm.Channels.TCP;
            _rbRs232.Checked = _settings.Channel == OTI.Comm.Channels.RS232;
            _tbIPAddress.Enabled = _rbTcp.Checked;
        }

        private void CommFr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            _settings.Channel = _rbTcp.Checked ? OTI.Comm.Channels.TCP : OTI.Comm.Channels.RS232;
            if (_rbTcp.Checked)
                _settings.IP_Address = _tbIPAddress.Text;

            _settings.SaveToRegistry();
        }

        private void _rbTcp_CheckedChanged(object sender, EventArgs e)
        {
            _tbIPAddress.Enabled = true;
        }

        private void _rbRs232_CheckedChanged(object sender, EventArgs e)
        {
            _tbIPAddress.Enabled = false;

        }
    }
}
