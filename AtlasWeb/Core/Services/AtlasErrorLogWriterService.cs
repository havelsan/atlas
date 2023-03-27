
using System;
using Infrastructure.Services;
using System.Data.Common;
using TTConnectionManager;
using TTDefinitionManagement;
using Microsoft.Extensions.Logging;
using Serilog.Debugging;

namespace Core.Services
{
    public class AtlasErrorLogWriterService : IErrorLogWriterService
    {
        public void WriteErrorLog(string userID, string workstationNameOrIpAddress, string description)
        {
            DbConnection dbConnection = ConnectionManager.CreateConnection();
            dbConnection.Open();

            try
            {
                char pc = ConnectionManager.ParameterChar;
                string sql = "INSERT INTO TTERRORLOG (USERID, WORKSTATIONNAME, ERRORDATE, DESCRIPTION) " +
                             "VALUES (" + pc + "USERID, " + pc + "WORKSTATIONNAME, " + pc + "ERRORDATE, " + pc + "DESCRIPTION)";
                DbCommand cmd = ConnectionManager.CreateCommand(sql, dbConnection);
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "USERID", userID));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "WORKSTATIONNAME", workstationNameOrIpAddress));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "ERRORDATE", TTObjectDefManager.GetRealServerTime(false)));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "DESCRIPTION", description));
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
