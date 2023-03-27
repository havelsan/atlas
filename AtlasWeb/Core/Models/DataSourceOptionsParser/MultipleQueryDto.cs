using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTDefinitionManagement;

namespace Core.Models.DataSourceOptionsParser
{
    public class MultipleQueryDto
    {
        public TTQueryDef QueryDef { get; set; }
        public string Injection { get; set; }

        public Dictionary<string, object> ParamList { get; set; }
    }
}
