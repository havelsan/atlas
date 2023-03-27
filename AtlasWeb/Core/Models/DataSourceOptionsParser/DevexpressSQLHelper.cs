using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTInstanceManagement;

namespace Core.Models.DataSourceOptionsParser
{
    public class DevexpressSQLHelper
    {
        public static string NestedConditionAdd(string command, string condition)
        {
            return "SELECT * FROM (" + command + ") WHERE " + condition;
        }
        public static string NestedCountAdd(string command)
        {
            return "SELECT COUNT(1) FROM (" + command + ")";
        }
        public static string NestedOrderAdd(string command, string orderBy, string orderInjection)
        {
            var sql = "SELECT * FROM (" + command + ")" + orderBy;

            //if(string.IsNullOrEmpty(orderBy) && !string.IsNullOrEmpty(orderInjection))
            //{
            //    sql += orderInjection;
            //}
            //else if (!string.IsNullOrEmpty(orderBy) && !string.IsNullOrEmpty(orderInjection))
            //{
            //    sql += ("," + orderInjection);
            //}
            return sql;
        }
        public static string NestedGroupAdd(string command, string selectStatement, string groupStatement, string orderStatement)
        {
            return selectStatement + " FROM (" + command + ") " + groupStatement + " " + orderStatement;
        }
        public static string NestedSelectAdd(string command, string selectStatement)
        {
            return "SELECT " + selectStatement + " FROM (" + command + ")";
        }
        public static string InjectFilters(TTList ttList, string injection)
        {
            string generatedInjection = ttList.GetListFilter(injection);

            string whereClause = string.Empty;

            if (!string.IsNullOrEmpty(generatedInjection))
            {
                whereClause += generatedInjection;
            }

            if (string.IsNullOrEmpty(whereClause))
            {
                return whereClause;
            }

            if (ttList.ListDef.IsWhereClauseExists)
            {
                whereClause = " and " + whereClause;
            }
            else
            {
                whereClause = " Where " + whereClause;
            }
            return whereClause;
        }
        public static string InjectFilters(TTQueryDef ttQuery, string injection)
        {
            string whereClause = string.Empty;

            if (!string.IsNullOrEmpty(injection))
            {
                whereClause += injection;
            }

            if (string.IsNullOrEmpty(whereClause))
            {
                return whereClause;
            }

            if (ttQuery.Nql.IndexOf("WHERE") > -1)
            {
                whereClause = " and " + whereClause;
            }
            else
            {
                whereClause = " Where " + whereClause;
            }
            return whereClause;
        }
    }
}
