using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysicianApplication
    {
        public Guid ObjectId { get; set; }
        public DateTime? ProcessEndDate { get; set; }
        public Guid? Complaint { get; set; }
        public Guid? ContinuousDrugs { get; set; }
        public Guid? DecisionAndAction { get; set; }
        public Guid? ExaminationSummary { get; set; }
        public Guid? Habits { get; set; }
        public Guid? Image { get; set; }
        public bool? IsTreatmentMaterialEmpty { get; set; }
        public Guid? PatientFamilyHistory { get; set; }
        public Guid? PatientFolder { get; set; }
        public Guid? PatientHistory { get; set; }
        public Guid? PatientStory { get; set; }
        public Guid? PhysicalExamination { get; set; }
        public DateTime? ProcessDate { get; set; }
        public long? ProtocolNo { get; set; }
        public Guid? SystemQuery { get; set; }
        public Guid? MTSConclusion { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? MasterPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual EpisodeAction MasterPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}