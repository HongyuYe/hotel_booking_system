using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbKiosk_TestApplication;

namespace otiKiosk.Communication
{
    public class AuthorizationDetails
    {
        /// <summary>
        /// Transaction status
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// the autorized amount
        /// </summary>
        public decimal AmountAuthorized { get; set; }

        /// <summary>
        /// Transaction referance use in Confirm transaction or Void transaction
        /// </summary>
        public string Transaction_Referance { get; set; }

        /// <summary>
        /// Card PAN (Mask)
        /// </summary>
        public string PartialPan { get; set; }

        /// <summary>
        /// Card Type (Visa, Mastercard...)
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Additional parameters from clearing like autorization ID ...
        /// </summary>
        private List<AdditionalParameters> _additionalParameters;
        public List<AdditionalParameters> additionalParameters
        {
            get
            {
                if (_additionalParameters == null)
                    _additionalParameters = new List<AdditionalParameters>();
                return _additionalParameters;
            }

            set
            {
                _additionalParameters = value;
            }

        }

        /// <summary>
        /// Error code
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Error description
        /// </summary>
        public string ErrorDescription { get; set; }
    }

    public class AdditionalParameters
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public AdditionalParameters(string name,string val)
        {
            Name = name;
            Value = val;
        }
    }
}
