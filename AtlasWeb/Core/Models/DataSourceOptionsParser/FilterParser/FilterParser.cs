using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TTDefinitionManagement;

namespace Core.Models.DataSourceOptionsParser.FilterParser
{
    public class FilterParser
    {
        public static string DevexpressFilterParser(DataSourceLoadOptions loadOptions, TTQueryDef queryDef)
        {
            if (loadOptions == null)
            {
                return string.Empty;
            }
            string sqlWhereClause = string.Empty;
            if (loadOptions.Filter != null)
            {
                var Builder = new WhereClauseBuilder();
                var jarray = new JArray(loadOptions.Filter);
                sqlWhereClause = Builder.BuildFor(jarray, queryDef);
            }
            return sqlWhereClause;
        }

        public static DbCommand Parse(DbCommand command , string gridFilter)
        {
            if (!string.IsNullOrEmpty(gridFilter))
            {
                command.CommandText = DevexpressSQLHelper.NestedConditionAdd(command.CommandText, gridFilter);
            }
            return command;
        }
    }
}
