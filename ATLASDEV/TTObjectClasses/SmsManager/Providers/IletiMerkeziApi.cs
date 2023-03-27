using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlasSmsManager
{
    public class IletiMerkeziApi : ISmsApi
    {
        public IletiMerkeziApiSettings settings;
        public IletiMerkeziApi()
        {
            var smsApiSettings = TTObjectClasses.SystemParameter.GetParameterValue("IletiMerkeziApiSettings", "");

            if (string.IsNullOrEmpty(smsApiSettings))
            {
                throw new Exception("SYSTEMPARAMETERS IletiMerkeziApiSettings Not Found!");
            }

            settings = JsonConvert.DeserializeObject<IletiMerkeziApiSettings>(smsApiSettings);
        }
        public bool SendSms(AtlasSMS sms)
        {
            String Xml = "<request>";
            Xml += "<authentication>";
            Xml += "<username>" + settings.UserName + "</username>";
            Xml += "<password>" + settings.Password + "</password>";
            Xml += "</authentication>";
            Xml += "<order>";
            Xml += "<sender>" + settings.Sender + "</sender>";
            Xml += "<sendDateTime></sendDateTime>";
            Xml += "<message>";
            Xml += "<text>" + sms.Text + "</text>";
            Xml += "<receipents>";
            Xml += "<number>" + sms.Number + "</number>";
            Xml += "</receipents>";
            Xml += "</message>";
            Xml += "</order>";
            Xml += "</request>";
            AtlasHttpClient.PostXML(settings.ServiceUrl,  Xml, null);
            return true;
        }

        public class IletiMerkeziApiSettings
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Sender { get; set; }
            public string ServiceUrl { get; set; }
        }
    }
}
