using AtlasSmsManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasSmsManager
{
    public class AsistApi : ISmsApi
    {
        public AsistApiSettings settings;
        public AsistApi()
        {
            var smsApiSettings = TTObjectClasses.SystemParameter.GetParameterValue("AsistApiSettings", "");

            if (string.IsNullOrEmpty(smsApiSettings))
            {
                throw new Exception("SYSTEMPARAMETERS AsistApi Not Found!");
            }

            settings = JsonConvert.DeserializeObject<AsistApiSettings>(smsApiSettings);

        }
        public bool SendSms(AtlasSMS sms)
        {
            string xmlData =
@"
<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:sms='http://xxxxxx.com/SmsProxy'>
   <soapenv:Header/>
   <soapenv:Body>
      <sms:sendSms>
         <sms:requestXml>
<![CDATA[ 
<SendSms>
<Username>{0}</Username>
<Password>{1}</Password>
<UserCode>{2}</UserCode>
<AccountId>{3}</AccountId>
<Originator>{4}</Originator>
<SendDate></SendDate>
<ValidityPeriod>{5}</ValidityPeriod>
<MessageText>{6}</MessageText>
<IsCheckBlackList>0</IsCheckBlackList>
<ReceiverList>
<Receiver>{7}</Receiver>
</ReceiverList>
</SendSms>
]]> 
         </sms:requestXml>
      </sms:sendSms>
   </soapenv:Body>
</soapenv:Envelope>                
";

            sms.Number = sms.Number.Replace(" ", "").Trim();

            if (!sms.Number.StartsWith("90"))
            {
                sms.Number = "90" + sms.Number;
            }

            string xml = string.Format(
                xmlData,
                settings.Username,//0
                settings.Password,//1
                settings.UserCode,//2
                settings.AccountId,//3
                settings.Originator,//4
                settings.ValidityPeriod,//5
                sms.Text,//6
                sms.Number//7
                );

            var headers = new Dictionary<string, string>();
            headers.Add("SOAPAction", settings.SOAPAction);
            string response = AtlasHttpClient.PostXML(settings.ServiceUrl, xml, headers, "text/xml;charset=UTF-8");

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

    public class AsistApiSettings
    {
        public string ServiceUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserCode { get; set; }
        public string AccountId { get; set; }
        public string Originator { get; set; }
        public string ValidityPeriod { get; set; }
        public string SOAPAction { get; set; }
    }
}
