using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockActionInspection
    {
        public Guid ObjectId { get; set; }
        public long? ReportNumberSeq { get; set; }
        public DateTime? InspectionDate { get; set; }
        public Guid? InspectionReport { get; set; }
        public string ReportNumberNotSeq { get; set; }
    }
}