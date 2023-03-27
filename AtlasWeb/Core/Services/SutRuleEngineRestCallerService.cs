using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using TTUtils;
using TTUtils.Entities;

namespace Core.Services
{
    public class SutRuleEngineRestCallerService : IRuleCheckEngine
    {
        const string ContentTypeApplicationJson = "application/json";
        const string HeaderAcceptName = "Accept";
        const string HeaderAuthorizationName = "Authorization";
        const string ServerIPAddressSettingName = "SUTRULECHECKERSERVERIP";
        private string GetToken()
        {
            return TTUtils.ActiveUserService.Instance.GetAccessToken();
        }

        private string GetServerIPAddress()
        {
            string serverIpAddress = TTObjectClasses.SystemParameter.GetParameterValue(ServerIPAddressSettingName, string.Empty);
            return serverIpAddress;
        }

        private IRestResponse ExecutePostRequest(string actionUri, object input)
        {
            var serverIpAddress = GetServerIPAddress();
            var url = $"{serverIpAddress}{actionUri}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader(HeaderAcceptName, ContentTypeApplicationJson);
            request.AddParameter(HeaderAuthorizationName, string.Format($"{JwtBearerDefaults.AuthenticationScheme‌​} " + GetToken()), ParameterType.HttpHeader);
            request.AddJsonBody(input);
            var response = client.Execute(request);
            return response;
        }

        private bool IsSutRuleEngineEnabled()
        {
            string sutRuleEngineEnabled = TTObjectClasses.SystemParameter.GetParameterValue("SUT_RULE_ENGINE_ENABLED", string.Empty);
            if (sutRuleEngineEnabled != "TRUE")
                return false;
            return true;
        }

        public string Echo(string message)
        {
            if (IsSutRuleEngineEnabled() == false)
                return string.Empty;

            var input = new { Message = message };
            var actionUri = "/api/ruleengine/echo";
            var response = ExecutePostRequest(actionUri, input);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return response.Content;
            }

            return string.Empty;
        }

        public RuleValidateResultDto ValidateRules(object patientId
            , object admissionId
            , IEnumerable<ProcedureEntryDto> procedureEntries
            , IEnumerable<string> icd10CodesEntries)
        {
            if (IsSutRuleEngineEnabled() == false)
                return null;

            var input = new { PatientId = patientId, AdmissionId = admissionId, ProcedureEntries = procedureEntries, Icd10CodesEntries = icd10CodesEntries };
            var actionUri = "/api/ruleengine/validaterules";
            var response = ExecutePostRequest(actionUri, input);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                var result = JsonConvert.DeserializeObject<RuleValidateResultDto>(response.Content);
                return result;
            }

            // TODO: convert error object
            throw new ApplicationException(response.Content);
        }

        public RuleValidateResultDto ValidateRulesForInvoice(object patientId, object episodeId)
        {
            if (IsSutRuleEngineEnabled() == false)
                return null;

            var input = new { PatientId = patientId, AdmissionId = episodeId };
            var actionUri = "/api/ruleengine/ValidateRulesForInvoice";
            var response = ExecutePostRequest(actionUri, input);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                var result = JsonConvert.DeserializeObject<RuleValidateResultDto>(response.Content);
                return result;
            }

            // TODO: convert error object
            throw new ApplicationException(response.Content);
        }
    }
}
