using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TaniTeshisİliskisi
    {
        public Guid ObjectId { get; set; }
        public Guid? DiagnosisGridRef { get; set; }
        public Guid? TeshisRef { get; set; }
        public Guid? ReportDiagnosisRef { get; set; }

        #region Parent Relations
        public virtual DiagnosisGrid DiagnosisGrid { get; set; }
        public virtual ReportDiagnosis ReportDiagnosis { get; set; }
        #endregion Parent Relations
    }
}