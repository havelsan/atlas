using Core.Models.DataSourceOptionsParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTConnectionManager;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTUtils;

namespace Core.Models
{
    public class SortParser
    {
        public string Selector { get; set; }
        public string Desc { get; set; }
        public string OrderInjection { get; set; }
        public static List<SortParser> DevexpressSortParser(DataSourceLoadOptions loadOptions, string orderInjection)
        {
            if (loadOptions == null)
            {
                return null;
            }

            List<SortParser> sortList = new List<SortParser>();

            if (loadOptions.Sort != null)
            {
                foreach (var sort in loadOptions.Sort)
                {
                    string selector = sort.Selector;
                    bool desc = sort.Desc;
                    sortList.Add(new SortParser() { Selector = selector, Desc = desc ? "desc" : "", OrderInjection = orderInjection });
                }
            }

            if (!string.IsNullOrEmpty(orderInjection) )
            {
                sortList.Add(new SortParser() { Selector = orderInjection, Desc = string.Empty, OrderInjection = orderInjection });
            }
            if (sortList.Count > 0)
                return sortList;
            else
                return null;
        }

        public static DbCommand Parse(DbCommand command, List<SortParser> sortParserList)
        {
            if (sortParserList != null && sortParserList.Count > 0)
            {
                string orderBy = string.Empty;
                foreach (var sortParser in sortParserList)
                {
                    if (string.IsNullOrEmpty(orderBy))
                        orderBy += " ORDER BY " + sortParser.Selector + " " + sortParser.Desc;
                    else
                        orderBy += "," + sortParser.Selector + " " + sortParser.Desc;
                }
                command.CommandText = DevexpressSQLHelper.NestedOrderAdd(command.CommandText, orderBy, sortParserList[0].OrderInjection);
            }
            return command;
        }
    }
}
