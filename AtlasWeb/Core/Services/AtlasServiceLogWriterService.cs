
using System;
using Infrastructure.Services;
using System.Data.Common;
using TTConnectionManager;
using TTDefinitionManagement;
using Microsoft.Extensions.Logging;
using Serilog.Debugging;

namespace Core.Services
{
    public class AtlasServiceLogWriterService : IServiceLogWriterService
    {
        public void WriteErrorLog(string requestMethod, string requestPath, string statusCode, DateTime callDate , string workstationIp, double elapsed)
        {
            DbConnection dbConnection = ConnectionManager.CreateConnection();
            dbConnection.Open();

            try
            {
                char pc = ConnectionManager.ParameterChar;
                string sql = "INSERT INTO TTSERVICELOG (LOGID, REQUESTMETHOD, REQUESTPATH, STATUSCODE, CALLDATE, WORKSTATIONIP, ELAPSED) " +
                             "VALUES (" + pc + "LOGID, " + pc + "REQUESTMETHOD, " + pc + "REQUESTPATH, " + pc + "STATUSCODE, " + pc + "CALLDATE, " + pc + "WORKSTATIONIP, " + pc + "ELAPSED)";
                DbCommand cmd = ConnectionManager.CreateCommand(sql, dbConnection);
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "LOGID", Guid.NewGuid().ToString()));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "REQUESTMETHOD", requestMethod));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "REQUESTPATH", requestPath));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "STATUSCODE", statusCode));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "CALLDATE", callDate));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "WORKSTATIONIP", workstationIp));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "ELAPSED", elapsed));
                cmd.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }
    }
}
