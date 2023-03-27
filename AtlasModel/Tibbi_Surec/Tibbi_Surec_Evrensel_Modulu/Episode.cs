using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Episode
    {
        public Guid ObjectId { get; set; }
        public Guid? DentalExaminationFile { get; set; }
        public DateTime? DocumentDate { get; set; }
        public Guid? PatientFolder { get; set; }
        public Guid? ContinuousDrugs { get; set; }
        public DateTime? OpeningDate { get; set; }
        public double? Heigth { get; set; }
        public double? Weight { get; set; }
        public Guid? Complaint { get; set; }
        public long? ID { get; set; }
        public bool? ClosedByMorgue { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string DocumentNumber { get; set; }
        public Guid? PatientFamilyHistory { get; set; }
        public int? Priority { get; set; }
        public Guid? Habits { get; set; }
        public Guid? PatientHistory { get; set; }
        public PatientStatusEnum? PatientStatus { get; set; }
        public DateTime? HealthCommitteeStartDate { get; set; }
        public long? HospitalProtocolNo { get; set; }
        public Guid? sourceDispatchObjID { get; set; }
        public Guid? SystemQuery { get; set; }
        public Guid? ImportantPatientInfo { get; set; }
        public Guid? PhysicalExamination { get; set; }
        public Guid? ExaminationSummary { get; set; }
        public string AdmissionResource { get; set; }
        public bool? IsQuotaUsed { get; set; }
        public Guid? DecisionAndAction { get; set; }
        public Guid? PatientStory { get; set; }
        public bool? IsNewBorn { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? PayerRef { get; set; }
        public Guid? MainDiagnoseRef { get; set; }
        public Guid? FoundationCityRef { get; set; }
        public Guid? OldPatientRef { get; set; }
        public Guid? MainSpecialityRef { get; set; }
        public Guid? RelationshipRef { get; set; }
        public Guid? BedRef { get; set; }
        public Guid? ReasonForExaminationRef { get; set; }
        public Guid? ParticipationTypeRef { get; set; }
        public Guid? EmergencyPatientStatusInfoRef { get; set; }
        public Guid? MedulaSigortaliTuruRef { get; set; }
        public Guid? ProtocolRef { get; set; }

        #region Parent Relations
        public virtual Patient Patient { get; set; }
        public virtual PayerDefinition Payer { get; set; }
        public virtual DiagnosisGrid MainDiagnose { get; set; }
        public virtual Patient OldPatient { get; set; }
        public virtual ResBed Bed { get; set; }
        public virtual ReasonForExaminationDefinition ReasonForExamination { get; set; }
        public virtual EmergencyPatientStatusInfo EmergencyPatientStatusInfo { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<SubActionProcedure> SubActionProcedures { get; set; }
        public virtual ICollection<SubActionMaterial> SubActionMaterials { get; set; }
        public virtual ICollection<EpisodeAction> EpisodeActions { get; set; }
        #endregion Child Relations
    }
}