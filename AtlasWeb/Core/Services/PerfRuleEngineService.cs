using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using TTObjectClasses;
using TTUtils;

namespace Core.Services
{
    public class PerfRuleEngineService : TTUtils.IPerfRuleEngineService
    {
        //private readonly static string DefaultHospitalURL = "http://X.X.X.X:93";
        private readonly static string DefaultHospitalURL = "http://INTERNET-PC1863:83/";

        private string getToken()
        {
            string AppUrl = TTObjectClasses.SystemParameter.GetParameterValue("PERFORMANCESERVICEURL", DefaultHospitalURL);//DefaultHospitalURL;
            string userName = "ttcomm";
            string password = "1";

            var requestUri = $"/api/authenticate";
            var client = new RestClient($"{AppUrl}/{requestUri}");
            var request = new RestRequest();

            request.Method = Method.POST;
            request.AddParameter("username", userName, ParameterType.GetOrPost);
            request.AddParameter("password", password, ParameterType.GetOrPost);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            if (string.IsNullOrEmpty(response.Content))
                return null;
            var obj = JsonConvert.DeserializeObject(response.Content) as JObject;
            //Token alınamadı hatasının LOG'u SCHEDULEDTASKHISTORY tablsundan bakılacak
            if (obj == null)
                return "";
            var accessToken = obj.Property("access_token");
            string returnValue = (string)accessToken.Value;

            return returnValue;
        }
        public PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> Performance(PerformanceDetailDto pDetail)
        {
            string AppUrl = TTObjectClasses.SystemParameter.GetParameterValue("PERFORMANCESERVICEURL", DefaultHospitalURL);//DefaultHospitalURL;

            IRestResponse response = null;

            var requestUri = $"/api/RuleEngine/Performance";

            var client = new RestClient($"{AppUrl}/{requestUri}");
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Parameters.Clear();
            string token = getToken();
            if (string.IsNullOrEmpty(token))
                return new PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Token alınamadı.",
                };
            request.AddParameter("Authorization", string.Format("Bearer " + token), ParameterType.HttpHeader);
            request.AddJsonBody(pDetail);
            response = client.Execute(request);

            var perfResult = JsonConvert.DeserializeObject<PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>>>(response.Content);

            return perfResult;
        }


        public PerfRuleCheckerResult<PerformanceDetailIdDto> PerformanceCancel(ProcedureIdDto procedure)
        {
            IRestResponse response = null;

            var requestUri = $"/api/RuleEngine/PerformanceCancel";
            string AppUrl = TTObjectClasses.SystemParameter.GetParameterValue("PERFORMANCESERVICEURL", DefaultHospitalURL);//DefaultHospitalURL;

            var client = new RestClient($"{AppUrl}/{requestUri}");
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Parameters.Clear();
            string token = getToken();
            if (string.IsNullOrEmpty(token))
                return new PerfRuleCheckerResult<PerformanceDetailIdDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Token alınamadı.",
                };
            request.AddParameter("Authorization", string.Format("Bearer " + token), ParameterType.HttpHeader);
            request.AddJsonBody(procedure);
            response = client.Execute(request);

            var perfResult = JsonConvert.DeserializeObject<PerfRuleCheckerResult<PerformanceDetailIdDto>>(response.Content);

            return perfResult;
        }
    }
}