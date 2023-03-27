using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTObjectClasses;

namespace AtlasSmsManager
{
    public class EkoMesajApi : ISmsApi
    {
        public EkoMesajApiSettings settings;
        public EkoMesajApi()
        {
            var smsApiSettings = TTObjectClasses.SystemParameter.GetParameterValue("EkoMesajApiSettings", "");

            if (string.IsNullOrEmpty(smsApiSettings))
            {
                throw new Exception("SYSTEMPARAMETERS EkoMesajApiSettings Not Found!");
            }
            settings = JsonConvert.DeserializeObject<EkoMesajApiSettings>(smsApiSettings);
        }
        public bool SendSms(AtlasSMS sms)
        {
            var c1 = new UserMessage.SmsClass();

            c1.Credential = new UserMessage.Credential();
            c1.Credential.Username = settings.UserName;
            c1.Credential.Password = settings.Password;
            c1.Credential.ResellerID = settings.ResellerID;

            c1.Sms = new UserMessage.Sms();
            c1.Sms.SmsTitle = settings.Title;
            c1.Sms.SenderName = settings.Title;
            c1.Sms.SmsContent = sms.Text;

            var toMsisdn = new UserMessage.ToMsisdn();
            string phoneNumber = sms.Number.Replace(" ", "").Trim();

            if (!phoneNumber.StartsWith("90"))
            {
                phoneNumber = "90" + phoneNumber.Trim();
            }

            toMsisdn.Msisdn = Convert.ToInt64(phoneNumber);
            c1.Sms.ToMsisdns = new UserMessage.ToMsisdn[] { toMsisdn };


            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(c1);
            var client = new RestClient(settings.ServiceUrl);
            var request = new RestRequest("/json/syncreply/SendInstantSms", RestSharp.Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonContent, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response != null && response.ResponseStatus == ResponseStatus.Completed)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

    public class EkoMesajApiSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ResellerID { get; set; }
        public string Title { get; set; }
        public string ServiceUrl { get; set; }
    }
}
