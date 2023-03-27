using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TTUtils;

namespace Core.Models.DataSourceOptionsParser
{
    public class SummaryParser
    {
        public string SelectStatement { get; set; }




        public static DbCommand Parse(DbCommand command, DataSourceLoadOptions loadOptions)
        {
            string select = string.Empty;
            if (loadOptions.RequireTotalCount || loadOptions.RequireGroupCount)
            {
                select += "COUNT(*) count";
            }

            if (loadOptions.TotalSummary != null && loadOptions.TotalSummary.Count() > 0)
            {
                foreach (var item in loadOptions.TotalSummary)
                {
                    var summaryItem = item as dynamic;

                    if(summaryItem.summaryType == "avg")
                    {
                        select += ((select.Length > 0 ? "," : string.Empty) + "ROUND(" + summaryItem.summaryType + "(" + summaryItem.selector + "),8) " + summaryItem.selector);
                    }
                    else
                    {
                        select += ((select.Length > 0 ? "," : string.Empty) + summaryItem.summaryType + "(" + summaryItem.selector + ") " + summaryItem.selector);
                    }
                    
                }
            }

            command.CommandText = DevexpressSQLHelper.NestedSelectAdd(command.CommandText, select);

            return command;
        }

        public static LoadResult SummaryResultParser(DataTable countResultSet, LoadResult result)
        {
            DataRow countResult = countResultSet.Rows[0];
            var summary = new List<dynamic>();

            foreach (DataColumn item in countResultSet.Columns)
            {
                if (item.ColumnName.ToUpper() == "COUNT")
                {
                    result.totalCount = countResult.GetFieldValueAsInteger(item.ColumnName).Value;
                }
                else
                {
                    //summary.Add(new { selector = item.ColumnName, value = countResult[item] });
                    summary.Add(countResult[item]);
                }
            }
            result.summary = summary.ToArray();
            return result;
        }
    }

}