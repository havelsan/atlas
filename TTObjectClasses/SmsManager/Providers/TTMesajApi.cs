using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlasSmsManager
{
    public class TTMesajApi : ISmsApi
    {
        public TTMesajApiSettings settings;
        public TTMesajApi()
        {
            var smsApiSettings = TTObjectClasses.SystemParameter.GetParameterValue("TTMesajApiSettings", "");

            if (string.IsNullOrEmpty(smsApiSettings))
            {
                throw new Exception("SYSTEMPARAMETERS TTMesajApiSettings Not Found!");
            }

            settings = JsonConvert.DeserializeObject<TTMesajApiSettings>(smsApiSettings);

        }
        public bool SendSms(AtlasSMS sms)
        {
            string xmlData =
@"<?xml version='1.0' encoding='utf-8'?>
<soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>
  <soap12:Body>
    <sendSingleSMS xmlns='http://tempuri.org/'>
      <username>{0}</username>
      <password>{1}</password>
      <numbers>{2}</numbers>
      <message>{3}</message>
      <origin>{4}</origin>
      <sd>0</sd>
      <ed>0</ed>
    </sendSingleSMS>
  </soap12:Body>
</soap12:Envelope>";


            sms.Number = sms.Number.Replace(" ", "").Trim();

            if (!sms.Number.StartsWith("90"))
            {
                sms.Number = "90" + sms.Number;
            }

            string xml = string.Format(
                xmlData,
                settings.UserName,
                settings.Password,
                sms.Number,
                sms.Text,
                settings.Origin);

            string response = AtlasHttpClient.PostXML(settings.ServiceUrl, xml, null, "application/soap+xml; charset=utf-8");

            if (response == "-1")
            {
                Console.Write("Error Sending SMS");
                return false;
            }
            else
            {
                Console.Write(response);
                return true;
            }
        }
    }

    public class TTMesajApiSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Origin { get; set; }
        public string ServiceUrl { get; set; }
    }
}
