using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicReportRevision
    {
        public Guid ObjectId { get; set; }
        public bool? IsMain { get; set; }
        public int? RevisionNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ReportComment { get; set; }
        public Guid? ReportJSONContent { get; set; }
        public bool? Enabled { get; set; }
        public Guid? CreatedByRef { get; set; }
        public Guid? DynamicReportRef { get; set; }

        #region Parent Relations
        public virtual ResUser CreatedBy { get; set; }
        public virtual DynamicReport DynamicReport { get; set; }
        #endregion Parent Relations
    }
}