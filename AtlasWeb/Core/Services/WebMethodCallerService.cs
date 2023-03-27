using RestSharp;

using TTUtils;

namespace Core.Services
{
    public class WebMethodCallerService
    {
        public object CallWebMethod(WebMethodCallHeader header, WebMethodCredential credential, TTWebMethodParameter[] parameters)
        {
            var client = new RestClient("http://localhost");
            var input = new CallWebMethodInput();
            input.Header = header;
            input.Credential = credential;
            input.Parameters = parameters;
            var request = new RestRequest("api/service/WebMethodCall", Method.POST);
            request.AddParameter("input", input);
            IRestResponse<CallWebMethodOutput> response = client.Execute<CallWebMethodOutput>(request);
            return response.Data.ReturnValue;
        }
    }
}