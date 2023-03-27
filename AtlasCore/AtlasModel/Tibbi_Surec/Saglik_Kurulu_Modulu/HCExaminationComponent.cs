using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HCExaminationComponent
    {
        public Guid ObjectId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string TreatmentInfo { get; set; }
        public string ClinicalInfo { get; set; }
        public string LaboratoryInfo { get; set; }
        public string RadiologicalInfo { get; set; }
        public int? NumberOfProcess { get; set; }
        public string OfferOfDecision { get; set; }
        public Guid? Report { get; set; }
        public double? DisabledRatio { get; set; }
        public bool? IsHealthy { get; set; }
        public string EngelliRaporuMuayeneId { get; set; }
        public Guid? ReasonForExaminationRef { get; set; }
        public Guid? EDisabledReportRef { get; set; }
        public Guid? CozgerSpecReqAreaRef { get; set; }
        public Guid? CozgerSpecReqLevelRef { get; set; }

        #region Parent Relations
        public virtual ReasonForExaminationDefinition ReasonForExamination { get; set; }
        public virtual EDisabledReport EDisabledReport { get; set; }
        #endregion Parent Relations
    }
}