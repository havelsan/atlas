using ReportClasses.Controllers.DynamicReporting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportClasses.ReportUtils
{
    public class ApiCaller
    {
        public static string IISBaseUrl = null;

        public static T CallAnyApiWithParams<T>(string reportParam, string methodName)
        {
            ReportParameters reportParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<ReportParameters>(reportParam);
            reportParameters.ReportMethodName = methodName;

            IRestResponse response = null;

            var requestUri = $"/api/ObjectDataSource/ResolveReportApi";
            var input = Newtonsoft.Json.JsonConvert.SerializeObject(reportParameters);
            var client = new RestClient($"{IISBaseUrl}{requestUri}");

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Parameters.Clear();
            request.AddParameter("Authorization", string.Format("Bearer " + reportParameters.Token), ParameterType.HttpHeader);
            request.AddJsonBody(input);

            response = client.Execute(request);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
        }

    }
}
