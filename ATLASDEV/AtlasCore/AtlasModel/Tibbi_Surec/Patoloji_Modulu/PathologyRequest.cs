using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PathologyRequest
    {
        public Guid ObjectId { get; set; }
        public string AcceptionNote { get; set; }
        public DateTime? AcceptionDate { get; set; }
        public string MaterialResponsible { get; set; }
        public string Description { get; set; }
        public long? RequestMaterialNumber { get; set; }
        public Guid? SpecialDoctorRef { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? RequestDoctorRef { get; set; }
        public Guid? AssistantDoctorRef { get; set; }
        public Guid? ReasonForPathologyRejectionRef { get; set; }
        public Guid? RequesterReferableHospitalRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser SpecialDoctor { get; set; }
        public virtual ResUser ResponsibleDoctor { get; set; }
        public virtual ResUser RequestDoctor { get; set; }
        public virtual ResUser AssistantDoctor { get; set; }
        #endregion Parent Relations
    }
}