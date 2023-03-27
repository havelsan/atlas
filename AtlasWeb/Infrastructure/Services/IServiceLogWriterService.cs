using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Services
{
    public interface IServiceLogWriterService
    {
        void WriteErrorLog(string requestMethod, string requestPath, string statusCode, DateTime callDate, string workstationIp, double elapsed);
    }
}
