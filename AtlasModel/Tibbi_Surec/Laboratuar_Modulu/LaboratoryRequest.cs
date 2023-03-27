using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryRequest
    {
        public Guid ObjectId { get; set; }
        public string Prediagnosis { get; set; }
        public bool? Urgent { get; set; }
        public SexEnum? PatientSex { get; set; }
        public string Notes { get; set; }
        public DateTime? LastMensturationDate { get; set; }
        public long? ProtocolNo { get; set; }
        public int? BarcodeID { get; set; }
        public string PatientAge { get; set; }
        public DateTime? LabRequestAcceptionDate { get; set; }
        public LaboratoryPregnancyEnum? Pregnancy { get; set; }
        public string MessageID { get; set; }
        public Guid? TargetObjectID { get; set; }
        public Guid? SourceObjectID { get; set; }
        public bool? IsRequestSent { get; set; }
        public Guid? LaboratoryRequestTemplateRef { get; set; }
        public Guid? RequestDoctorRef { get; set; }
        public Guid? MasterTestDefinitionRef { get; set; }
        public Guid? ApprovedByRef { get; set; }
        public Guid? LaboratoryTripleTestInfoRef { get; set; }
        public Guid? LaboratoryBinaryScanInfoRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser RequestDoctor { get; set; }
        public virtual LaboratoryTestDefinition MasterTestDefinition { get; set; }
        public virtual ResUser ApprovedBy { get; set; }
        #endregion Parent Relations
    }
}