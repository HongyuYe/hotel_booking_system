using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbKiosk_TestApplication.Models
{
    class Refund
    {
        public int refundId { get; set; } //this is the auto-incremented
        public string reference { get; set; }
        public bool isRefund { get; set; }
        public string bookingNumber { get; set; }
        public string amount { get; set; }

    }
}
