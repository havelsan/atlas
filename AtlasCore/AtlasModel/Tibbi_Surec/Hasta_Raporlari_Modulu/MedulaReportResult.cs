using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedulaReportResult
    {
        public Guid ObjectId { get; set; }
        public DateTime? SendReportDate { get; set; }
        public string ReportChasingNo { get; set; }
        public string ResultCode { get; set; }
        public string ResultExplanation { get; set; }
        public int? ReportRowNumber { get; set; }
        public string ReportNumber { get; set; }
        public Guid? StoneBreakUpRequestRef { get; set; }
        public Guid? PhysiotherapyOrderRef { get; set; }
        public Guid? HOTOrderRef { get; set; }
        public Guid? ManipulationRef { get; set; }
        public Guid? DialysisOrderRef { get; set; }
        public Guid? ParticipatnFreeDrugReportRef { get; set; }

        #region Parent Relations
        public virtual PhysiotherapyOrder PhysiotherapyOrder { get; set; }
        public virtual Manipulation Manipulation { get; set; }
        public virtual ParticipatnFreeDrugReport ParticipatnFreeDrugReport { get; set; }
        #endregion Parent Relations
    }
}