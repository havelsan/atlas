using Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace Core.Services
{
    public class AtlasInfoMessageService : TTUtils.IInfoMessageService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public AtlasInfoMessageService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public void ShowMessage(string message)
        {
            var response = _httpContextAccessor.HttpContext.Response;
            if (response != null)
            {
                Microsoft.Extensions.Primitives.StringValues oldMessage;
                if (response.Headers.TryGetValue(CustomHeaderNames.InfoMessageHeader, out oldMessage))
                {
                    oldMessage = Encoding.UTF8.GetString(Convert.FromBase64String(oldMessage));
                    response.Headers[CustomHeaderNames.InfoMessageHeader] = GetBase64EncodedString(oldMessage  + "\r\n" + message);
                }
                else
                {
                    response.Headers[CustomHeaderNames.InfoMessageHeader] = GetBase64EncodedString(message);
                }
            }
        }

        private string GetBase64EncodedString(string message)
        {
            var messageBuffer = Encoding.UTF8.GetBytes(message);
            return Convert.ToBase64String(messageBuffer);
        }
    }
}