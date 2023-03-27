using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicReport
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ReportClassName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Enabled { get; set; }
    }
}