using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbKiosk_TestApplication.Models
{
    public class Transaction
    {
        public int transactionId { get; set; } //this is the auto-incremented 
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public decimal total { get; set; }
        public string bookingNumber { get; set; }
        public string phoneNumber { get; set; }
        public bool paid { get; set; }
        public bool cardDetected { get; set; }
        public bool deposit { get; set; }
        public bool cancel { get; set; }
    }
}
