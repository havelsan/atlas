using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Radiology
    {
        public Guid ObjectId { get; set; }
        public string TechnicianNote { get; set; }
        public Guid? PreDiagnosis { get; set; }
        public ToothNumberEnum? ToothNumber { get; set; }
        public DentalPositionEnum? DentalPosition { get; set; }
        public int? DisTaahhutNo { get; set; }
        public bool? Anomali { get; set; }
        public bool? AllCheck { get; set; }
        public string Description { get; set; }
        public Guid? SourceObjectID { get; set; }
        public Guid? TargetObjectID { get; set; }
        public Guid? RejectReasonRef { get; set; }
        public Guid? RequestDoctorRef { get; set; }
        public Guid? RadiologyRequestTemplateRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser RequestDoctor { get; set; }
        #endregion Parent Relations
    }
}