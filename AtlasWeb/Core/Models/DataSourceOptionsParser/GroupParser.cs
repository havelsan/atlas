using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.DataSourceOptionsParser
{
    public class GroupParser
    {
        public string SelectStatement { get; set; }

        public string GroupStatement { get; set; }

        public string OrderStatement { get; set; }

        public string Key { get; set; }

        public static GroupParser DevexpressGroupParser(DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return null;
            }
            if (loadOptions.Group == null)
            {
                return null;
            }
            if (loadOptions.Group.Length < 1)
            {
                return null;
            }

            var result = new GroupParser()
            {
                SelectStatement = "SELECT COUNT(1) AS count,",
                GroupStatement = "GROUP BY ",
                OrderStatement = "ORDER BY "
            };

            result.Key = loadOptions.Group[0].Selector;
            result.SelectStatement += (loadOptions.Group[0].Selector + " AS key, ");
            result.GroupStatement += (loadOptions.Group[0].Selector + ", ");
            result.OrderStatement += ("key");

            
            //for (int i = 0; i < loadOptions.Group.Length; i++)
            //{
            //    result.SelectStatement += (loadOptions.Group[i].Selector + " AS KEY" + i + ", ");
            //    result.GroupStatement += (loadOptions.Group[i].Selector + ", ");
            //    result.OrderStatement += ("KEY" + i + ", ");
            //}

            result.SelectStatement = result.SelectStatement.Substring(0, result.SelectStatement.Length - 2);
            result.GroupStatement = result.GroupStatement.Substring(0, result.GroupStatement.Length - 2);
            //result.OrderStatement = result.OrderStatement.Substring(0, result.OrderStatement.Length - 2);
            return result;
        }

        public static DbCommand Parse(DbCommand command, GroupParser groupParser)
        {
            if (groupParser != null)
            {
                command.CommandText = DevexpressSQLHelper.NestedGroupAdd(command.CommandText, groupParser.SelectStatement, groupParser.GroupStatement, groupParser.OrderStatement);
            }
            return command;
        }
    }
}
