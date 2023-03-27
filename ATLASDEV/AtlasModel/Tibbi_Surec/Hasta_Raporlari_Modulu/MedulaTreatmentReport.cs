using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedulaTreatmentReport
    {
        public Guid ObjectId { get; set; }
        public string RaporTakipNo { get; set; }
        public string SonucAciklamasi { get; set; }
        public DateTime? RaporGonderimTarihi { get; set; }
        public string SonucKodu { get; set; }
        public TedaviRaporTuruEnum? TedaviRaporTuru { get; set; }
        public string RaporGidenXML { get; set; }
        public string RaporGelenXML { get; set; }
        public Guid? PatientObjectID { get; set; }
        public Guid? SEPObjectID { get; set; }
        public string ReportNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public PeriodUnitTypeEnum? DurationType { get; set; }
        public bool? CommitteeReport { get; set; }
        public Guid? Description { get; set; }
        public bool? IsSendedMedula { get; set; }
        public Guid? SecondDoctorRef { get; set; }
        public Guid? FTRReportRef { get; set; }
        public Guid? ESWTReportRef { get; set; }
        public Guid? ESWLReportRef { get; set; }
        public Guid? HBTReportRef { get; set; }
        public Guid? DialysisReportRef { get; set; }
        public Guid? HomeHemodialysisReportRef { get; set; }
        public Guid? TubeBabyReportRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser SecondDoctor { get; set; }
        public virtual FTRReport FTRReport { get; set; }
        public virtual ESWTReport ESWTReport { get; set; }
        public virtual ESWLReport ESWLReport { get; set; }
        public virtual HBTReport HBTReport { get; set; }
        public virtual DialysisReport DialysisReport { get; set; }
        public virtual HomeHemodialysisReport HomeHemodialysisReport { get; set; }
        public virtual TubeBabyReport TubeBabyReport { get; set; }
        #endregion Parent Relations
    }
}