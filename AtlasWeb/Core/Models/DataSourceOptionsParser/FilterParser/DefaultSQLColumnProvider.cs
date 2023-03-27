using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Models
{
    public class DefaultSQLColumnProvider : ISQLColumnProvider
    {
        public static string GetDBDateValueConversion(string dateString)
        {
            if (dateString.Contains(" "))
            {
                var date = dateString.Split(' ')[0];
                return $"Convert(datetime,'{date}', 126)";
            }
            else if (dateString.Contains("+"))
            {
                var date = dateString.Split('+')[0];
                return $"Convert(datetime,'{date}', 126)";
            }
            else if (dateString.Count(x => x == '-') == 3)
            {
                var date = Regex.Replace(dateString, "-\\d\\d:{0,1}\\d\\d$", string.Empty);
                return $"Convert(datetime,'{date}', 126)";
            }
            else if (dateString.Contains("Z"))
            {
                return $"Convert(datetime,'{dateString}', 127)";
            }
            else
            {
                throw new Exception($"Unknown date format {dateString}.");
            }
        }

        public string GetDBColumnName(string columnName)
        {
            return columnName;
        }

        public string GetDBValueConversion(string columnName, string condition, string value)
        {
            if(condition == "contains" || condition == "not contains")
            {
                return $"'%{value}%'";
            }

            return $"'{value}'";
        }
    }
}
