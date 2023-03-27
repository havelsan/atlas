using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.ReportUtils
{
    public class ReportRevisionDto
    {
        public DateTime CreatedDate { get; set; }
        public bool Enabled { get; set; }
        public string ReportComment { get; set; }
        public string ReportJSONContent { get; set; }
        public int? RevisionNumber { get; set; }
        public string DynamicReport { get; set; }
        public Guid ObjectID { get; set; }
    }
}
