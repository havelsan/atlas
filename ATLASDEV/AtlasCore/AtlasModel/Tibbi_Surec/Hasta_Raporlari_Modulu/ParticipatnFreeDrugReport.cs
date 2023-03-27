using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ParticipatnFreeDrugReport
    {
        public Guid ObjectId { get; set; }
        public string itno { get; set; }
        public string PatientApprovalFormNo { get; set; }
        public int? HeadDoctorApproval { get; set; }
        public string MedulaPassword { get; set; }
        public bool? IsRepeated { get; set; }
        public int? SecondDoctorApproval { get; set; }
        public int? ThirdDoctorApproval { get; set; }
        public ReportApproveTypeEnum? ReportApprovalType { get; set; }
        public Guid? Description { get; set; }
        public bool? CommitteeReport { get; set; }
        public long? ReportNo { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public long? ExamptionProtocolNo { get; set; }
        public string SocialInsurance { get; set; }
        public string Disease { get; set; }
        public string PatientEnterprise { get; set; }
        public string Duration1 { get; set; }
        public Guid? TestsAndSigns { get; set; }
        public DateTime? ReportEndDate { get; set; }
        public string ProtocolNumber { get; set; }
        public int? ReportDuration { get; set; }
        public PeriodUnitTypeWithUndefiniteEnum? ReportDurationType { get; set; }
        public bool? IsSecondDoctorApproved { get; set; }
        public bool? IsThirdDoctorApproved { get; set; }
        public Guid? SecondDoctorRef { get; set; }
        public Guid? ThirdDoctorRef { get; set; }
        public Guid? ParticipntFreeDrugReportTmpltRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser SecondDoctor { get; set; }
        public virtual ResUser ThirdDoctor { get; set; }
        #endregion Parent Relations
    }
}