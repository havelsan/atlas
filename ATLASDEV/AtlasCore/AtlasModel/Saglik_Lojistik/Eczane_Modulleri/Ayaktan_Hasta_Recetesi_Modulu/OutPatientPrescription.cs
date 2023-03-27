using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OutPatientPrescription
    {
        public Guid ObjectId { get; set; }
        public PatientGroupEnum? PatientGroup { get; set; }
        public Guid? SPTSMessageID { get; set; }
        public bool? SendOutPharmacy { get; set; }
        public long? SPTSProvisionID { get; set; }
        public string ReceiptNO { get; set; }
        public string FreeDiagnosis { get; set; }
        public string SPTSProvisionDesc { get; set; }
        public DiagnosisTypeEnum? AddDiagnosisType { get; set; }
        public bool? IsDischargePrescripiton { get; set; }
        public string DiscriptionOfPharmacist { get; set; }
        public Guid? ExternalPharmacyRef { get; set; }
        public Guid? DiagnosisDefinitionRef { get; set; }
        public Guid? SpecialityDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual Prescription Prescription { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DiagnosisDefinition DiagnosisDefinition { get; set; }
        #endregion Parent Relations
    }
}