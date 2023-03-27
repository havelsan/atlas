using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TTConnectionManager;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Models.DataSourceOptionsParser
{
    public class PaginationParser
    {
        public static PaginationInfo DevexpressPaginationParser(DataSourceLoadOptions loadOptions)
        {
            PaginationInfo pi = new PaginationInfo();
            if (loadOptions == null)
            {
                pi.Skip = 0;
                pi.PageSize = 100;
                return pi;
            }
            pi.Skip = loadOptions.Skip;
            pi.PageSize = loadOptions.Take;
            return pi;
        }

        public static DbCommand ParseSQLWithPaging(string query, List<DbParameter> parameters, PaginationInfo pi, DbConnection cn)
        {
            INQLParser parser = ConnectionManager.GetNqlParser(TTObjectDefManager.Instance);
            string sql = parser.ParseSQL(query, pi);
            var cmd = ParseSQL(sql, parameters, cn);
            return parser.GetDBCommandByPaginationParameters(pi, cmd);

        }

        public static DbCommand ParseSQL(string sql, List<DbParameter> parameters, DbConnection cn)
        {
            var dbCommand = ConnectionManager.CreateCommand(sql, cn);

            foreach (var item in parameters)
            {
                dbCommand.Parameters.Add((item as ICloneable).Clone() as DbParameter);
            }
            return dbCommand;
        }

        public static DbCommand Parse(DbCommand command, PaginationInfo pi, DbConnection cn)
        {
            if (pi.PageSize > 0)
            {
                command = PaginationParser.ParseSQLWithPaging(command.CommandText, command.Parameters.Cast<DbParameter>().ToList(), pi, cn);
            }
 
            return command;
        }
    }
}
