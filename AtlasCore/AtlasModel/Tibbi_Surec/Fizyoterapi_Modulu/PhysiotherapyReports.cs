using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysiotherapyReports
    {
        public Guid ObjectId { get; set; }
        public Guid? LocalReportId { get; set; }
        public string PackageProcedureInfo { get; set; }
        public string TreatmentProcessType { get; set; }
        public int? SessionLimit { get; set; }
        public bool? ReportType { get; set; }
        public string ReportInfo { get; set; }
        public int? ReportTime { get; set; }
        public DateTime? ReportEndDate { get; set; }
        public string ReportNo { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public TreatmentQueryReportTypeEnum? TreatmentType { get; set; }
        public string DiagnosisGroup { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}