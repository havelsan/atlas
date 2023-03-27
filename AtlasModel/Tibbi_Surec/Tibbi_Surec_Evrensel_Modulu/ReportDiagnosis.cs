using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReportDiagnosis
    {
        public Guid ObjectId { get; set; }
        public DateTime? DiagnoseDate { get; set; }
        public Guid? DiagnoseRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? DiagnosisGridRef { get; set; }

        #region Parent Relations
        public virtual DiagnosisDefinition Diagnose { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual DiagnosisGrid DiagnosisGrid { get; set; }
        #endregion Parent Relations
    }
}