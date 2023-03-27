using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using TTServerConfiguration;
using TTUtils;

namespace Core.Services
{
    public class HL7EngineService : IHL7Engine
    {
        public Tuple<bool, string> SendHospitalMessageToEngine(List<Guid> ids, string messageType, string hostName)
        {
            return SendMessageToHL7Engine(ids, messageType, hostName);
        }

        private Tuple<bool, string> SendMessageToHL7Engine(List<Guid> ids, string messageType, string hostName)
        {
            if (HL7Configuration.HL7ServerItems.ContainsKey(hostName) == false)
            {
                throw new TTException($"HL7Configuration.xml HL7Servers/HL7Server altında {hostName} isimli bir HL7 sunucusu tanımı yapılmamış.");
            }

            HL7ServerItem hL7ServerItem = HL7Configuration.HL7ServerItems[hostName];
            var client = new RestClient($"http://{hL7ServerItem.HL7ServerName}:{hL7ServerItem.HL7TCPPort}");
            client.Timeout = hL7ServerItem.HL7SendTimeout;
            var request = new RestRequest("api/hl7engine/sendmessagetoengine", RestSharp.Method.POST);
            request.AddHeader("Accept", "application/json");
            var accessToken = TTUtils.ActiveUserService.Instance.GetAccessToken();
            request.AddParameter("Authorization", string.Format("Bearer " + accessToken), ParameterType.HttpHeader);

            var input = new SendMessageToEngineInput()
            {
                Ids = ids,
                MessageType = messageType,
                HostName = hostName,
            };
            var jsonContent = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", jsonContent, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response != null && response.ResponseStatus == ResponseStatus.Completed)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var errorMessage = response.Content;
                    var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                    if (errorObject != null)
                    {
                        var error = errorObject.Value<string>("error");
                        var detailedError = errorObject.Value<string>("detailedError");
                        errorMessage = error;
                    }
                    throw new TTException($"{response.StatusCode}-{errorMessage}");
                }
            }

            var webApiErrorMessage = response.ErrorException != null ? response.ErrorException.ToString() : response.ErrorMessage;
            if (string.IsNullOrWhiteSpace(webApiErrorMessage) == false)
            {
                throw new TTException($"{response.StatusCode}-{webApiErrorMessage}");
            }

            var result = JsonConvert.DeserializeObject<Tuple<bool, string>>(response.Content);
            return result;
        }
    }
}
