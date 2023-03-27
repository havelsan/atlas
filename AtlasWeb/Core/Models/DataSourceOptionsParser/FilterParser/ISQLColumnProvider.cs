using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface ISQLColumnProvider
    {
        string GetDBColumnName(string columnName);
        string GetDBValueConversion(string columnName, string condition, string value);
    }
}
