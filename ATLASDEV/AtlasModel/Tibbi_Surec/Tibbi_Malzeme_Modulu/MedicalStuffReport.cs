using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalStuffReport
    {
        public Guid ObjectId { get; set; }
        public int? Duration { get; set; }
        public PeriodUnitTypeEnum? DurationType { get; set; }
        public bool? CommitteeReport { get; set; }
        public string MedulaDescription { get; set; }
        public DateTime? RaporGonderimTarihi { get; set; }
        public string RaporTakipNo { get; set; }
        public bool? IsSendedMedula { get; set; }
        public string RaporGelenXML { get; set; }
        public string RaporGidenXML { get; set; }
        public Guid? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ReportDecision { get; set; }
        public long? ReportNo { get; set; }
        public string DiagnosisDetail { get; set; }
        public Guid? SignedData { get; set; }
        public bool? IsSecondDoctorApproved { get; set; }
        public bool? IsThirdDoctorApproved { get; set; }
        public Guid? MedicalStuffDefRef { get; set; }
        public Guid? SecondDoctorRef { get; set; }
        public Guid? ThirdDoctorRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MedicalStuffDefinition MedicalStuffDef { get; set; }
        public virtual ResUser SecondDoctor { get; set; }
        public virtual ResUser ThirdDoctor { get; set; }
        #endregion Parent Relations
    }
}