using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public interface IErrorLogWriterService
    {
        void WriteErrorLog(string userID, string workstationNameOrIpAddress, string description);
    }
}
