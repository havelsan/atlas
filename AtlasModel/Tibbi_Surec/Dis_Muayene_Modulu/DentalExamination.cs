using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalExamination
    {
        public Guid ObjectId { get; set; }
        public string LeftLowerJaw { get; set; }
        public string RightUpperJaw { get; set; }
        public DateTime? ProcessTime { get; set; }
        public string RightLowerJaw { get; set; }
        public string LeftUpperJaw { get; set; }
        public Guid? DentalExaminationFile { get; set; }
        public bool? GeneralAnesthesia { get; set; }
        public TriajCode? TriajCode { get; set; }
        public bool? IsFollowUpExam { get; set; }
        public string DrAnesteziTescilNo { get; set; }
        public PatientExaminationEnum? DentalExaminationType { get; set; }
        public bool? IsConsultation { get; set; }
        public Guid? ConsultationResultAndOffers { get; set; }
        public Guid? RequestDescription { get; set; }
        public Guid? ProcedureDepartmentRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? RequesterDoctorRef { get; set; }
        public Guid? ConsultationRequestResourceRef { get; set; }
        public Guid? DentalCommitmentRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDentalEpisodeAction BaseDentalEpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection ProcedureDepartment { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual ResUser RequesterDoctor { get; set; }
        public virtual ResSection ConsultationRequestResource { get; set; }
        public virtual DentalCommitment DentalCommitment { get; set; }
        #endregion Parent Relations
    }
}