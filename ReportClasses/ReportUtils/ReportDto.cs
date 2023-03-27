using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.ReportUtils
{
    public class ReportDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ReportClassName { get; set; }
        public Guid ObjectID { get; set; }
        public bool? Enabled { get; set; }

        public string LongName
        {
            get
            {
                return this.Name + " (Code = " + (string.IsNullOrEmpty(this.Code) ? "NULL" : this.Code) + ")";
            }
        }
    }
}
