using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StatusNotificationReport
    {
        public Guid ObjectId { get; set; }
        public string ReportDescription { get; set; }
        public int? ReportDuration { get; set; }
        public PeriodUnitTypeWithUndefiniteEnum? ReportDurationType { get; set; }
        public string DiagnosisDetail { get; set; }
        public Guid? Description { get; set; }
        public Guid? ReportDecision { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? ReportNo { get; set; }
        public bool? CommitteeReport { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public bool? Appropriate { get; set; }
        public bool? InAppropriate { get; set; }
        public StatusNotificationReasonEnum? ReportReason { get; set; }
        public Guid? HCRequestReasonRef { get; set; }
        public Guid? SecondDoctorRef { get; set; }
        public Guid? ThirdDoctorRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual HCRequestReason HCRequestReason { get; set; }
        public virtual ResUser SecondDoctor { get; set; }
        public virtual ResUser ThirdDoctor { get; set; }
        #endregion Parent Relations
    }
}