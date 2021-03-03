using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UsbKiosk_TestApplication;

namespace otiKiosk.Communication
{
    class KioskProtocol
    {
        const string USB_SEND = "{0}(id={1} {2})";
        const string message_RESPONSE = "{{\"messagerpc\": \"2.0\", \"result\": {0}, \"id\": {1}}}";
        const string message_ERROR = "{{\"messagerpc\": \"2.0\", \"error\": {{\"code\": {0}, \"message\": \"{1}\"}}, \"id\": null}}";
        private static long _id = 1;

        #region serialize classes
        class messagePars
        {
            public string messagerpc { get; set; }
            public string method { get; set; }
            public Dictionary<string, object> Params { get; set; }
            public long id { get; set; }
        }

        class messageErrorPars
        {
            public string messagerpc { get; set; }
            public error error { get; set; }
            public long? id { get; set; }
        }

        class error
        {
            public int code { get; set; }
            public string message { get; set; }

        }


        class messageResult
        {
            public string messagerpc { get; set; }
            public string result { get; set; }
            public long id { get; set; }
        }

        class messageAuthorizationDetailsResult
        {
            public string messagerpc { get; set; }
            public AuthorizationDetails result { get; set; }
            public long id { get; set; }
        }


        #endregion

        /// <summary>
        /// Serializes the method  to a usb protocol, string.
        /// </summary>
        /// <param name="mi">The method info</param>
        /// <param name="methodValues">method values</param>
        /// <returns>message rpc string</returns>
        public static string Serialize(MethodInfo mi, object[] methodValues)
        {
            ParameterInfo[] prms = mi.GetParameters();
            string strParms = "";

            for (int i = 0; i < prms.Length; i++)
            {
                
                strParms += string.Format(",{0}={1}", prms[i].Name, methodValues[i]);
            }
            string usbp = string.Format(USB_SEND, mi.Name, ++_id, strParms);
            return usbp;
        }

      
 

        /// <summary>
        /// Serializes messager response to message rpc
        /// </summary>
        /// <param name="methodValues">The response values</param>
        /// <returns>message rpc string</returns>
        public static string SerializeResponse(object[] methodValues)
        {
            string strParms = string.Format("id={0},result={1}", _id, methodValues == null || methodValues.Length == 0 ? "null" : methodValues[0].ToString());
            return strParms;
        }

        /// <summary>
        /// Serializes messager response to message rpc
        /// </summary>
        /// <param name="response">The response message</param>
        /// <returns>The message rpc string</returns>
        public static string SerializeResponse(string response)
        {
            string message = string.Format(message_RESPONSE, response, _id);
            return message;

        }



      
        public static AuthorizationDetails GetAuthorizationDetails(string usbp)
        {
            AuthorizationDetails authorizationDetails = new AuthorizationDetails();
            int startOfParms = usbp.IndexOf("(");

            List<object> objs = new List<object>();
            string[] split = usbp.Substring(startOfParms).Split(new char[] { ',', '(', ')' });

            if (split == null)
                return null;

            for (int i = 0; i < split.Length; i++)
            {
                string[] sp = split[i].Split(new char[] { '=' });
                if (sp == null || sp.Length < 2)
                    continue;

                switch(sp[0])
                {
                    case "id":
                        _id = Convert.ToInt32(sp[1]);
                        break;
                    case "amountAuthorized":
                    case "Amnt":
                        {
                            decimal amount;
                            authorizationDetails.AmountAuthorized = decimal.TryParse(sp[1], out amount) ? amount : 0;
                            break;
                        }

                    case "partialPan":
                        {
                            authorizationDetails.PartialPan = sp[1];
                            break;
                        }

                    case "cardType":
                        {
                            authorizationDetails.CardType = sp[1];
                            break;
                        }

                    case "Transaction_Reference":
                    case "TrnsRef":
                        {
                            authorizationDetails.Transaction_Referance = sp[1];
                            break;
                        }

                    case "status":
                        {
                            Status status;
                            authorizationDetails.status = (Enum.TryParse(sp[1], out status)) ? status : Status.Error;
                            break;
                        }

                    case "errorCode":
                    case "Err":
                        authorizationDetails.ErrorCode = Convert.ToInt32(sp[1]);
                        break;

                         case "errorDescription":
                        authorizationDetails.ErrorDescription = sp[1];
                        break;


                    default:
                        {
                            authorizationDetails.additionalParameters.Add(new AdditionalParameters(sp[0], sp[1]));
                            break;
                        }
                }
            }

            return authorizationDetails;
        }

        /// <summary>
        /// Deserializes message string to response message
        /// </summary>
        /// <param name="usbp">The message string</param>
        /// <param name="args">respone values</param>
        public static string DeserializeResponse(string usbp)
        {
            try
            {
                if (!usbp.StartsWith("("))
                    throw new Exception("This is NOT Deserialize Response");
                List<object> objs = new List<object>();
                string[] split = usbp.Split(new char[] { ',', '(', ')' });

                if (split == null)
                    return null;

                foreach (var item in split)
                {
                    string[] sp = item.Split(new char[] { '=' });
                    if (sp == null || sp.Length < 2)
                        continue;
                    if (sp[0] == "id")
                        _id = Convert.ToInt32(sp[1]);
                    else
                        return sp[1];
                }
                return null;
            }
            catch (Exception e)
            {

                KioskCommException ex = new KioskCommException(ErrorCodes.messageParse, "Invalid Line was received by the connect 3000.", e.Message);
                throw ex;
            }

        }

   
            
    }
}
