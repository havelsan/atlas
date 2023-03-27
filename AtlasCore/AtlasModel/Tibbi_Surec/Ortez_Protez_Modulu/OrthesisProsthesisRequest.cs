using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OrthesisProsthesisRequest
    {
        public Guid ObjectId { get; set; }
        public Guid? Image { get; set; }
        public Guid? TotalDescription { get; set; }
        public long? ProtocolNo { get; set; }
        public string FinancialDepartmentNot { get; set; }
        public string Description { get; set; }
        public string ChiefTechnicianNote { get; set; }
        public string TechnicianNote { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool? IsInRequest { get; set; }
        public Guid? RequestReason { get; set; }
        public string WarrantyNote { get; set; }
        public Guid? RequesterUsr { get; set; }
        public Guid? ReasonForExaminationRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ReasonForExaminationDefinition ReasonForExamination { get; set; }
        #endregion Parent Relations
    }
}