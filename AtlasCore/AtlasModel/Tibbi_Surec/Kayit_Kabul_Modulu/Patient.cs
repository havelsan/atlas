using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Patient
    {
        public Guid ObjectId { get; set; }
        public string Length { get; set; }
        public Guid? PatientHistory { get; set; }
        public EyeColorEnum? EyeColor { get; set; }
        public string SpecialStatus { get; set; }
        public BeneficiaryEnum? Beneficiary { get; set; }
        public Guid? ImportantPatientInfo { get; set; }
        public DateTime? BeneficiaryDate { get; set; }
        public YesNoEnum? Deleted { get; set; }
        public long? OldID { get; set; }
        public Guid? Photo { get; set; }
        public bool? UnIdentified { get; set; }
        public bool? Alive { get; set; }
        public long? ID { get; set; }
        public string EMail { get; set; }
        public string Note { get; set; }
        public bool? NotRequiredQuota { get; set; }
        public bool? Foreign { get; set; }
        public string Religion { get; set; }
        public bool? Privacy { get; set; }
        public DateTime? PrivacyEndDate { get; set; }
        public string PrivacyReason { get; set; }
        public int? YUPASSNO { get; set; }
        public bool? SecurePerson { get; set; }
        public Guid? PatientFamilyHistory { get; set; }
        public double? Heigth { get; set; }
        public double? Weight { get; set; }
        public double? ChestCircumference { get; set; }
        public double? HeadCircumference { get; set; }
        public bool? IsTrusted { get; set; }
        public string PrivacyName { get; set; }
        public string PrivacySurname { get; set; }
        public bool? Death { get; set; }
        public long? DonorUniqueRefNo { get; set; }
        public DateTime? KPSUpdateDate { get; set; }
        public string BeneficiaryName { get; set; }
        public long? BeneficiaryUniqueRefNo { get; set; }
        public string PrivacyHomeAddress { get; set; }
        public string PrivacyMobilePhone { get; set; }
        public string VemHastaKodu { get; set; }
        public Guid? ServiceRef { get; set; }
        public Guid? RecordUserIDRef { get; set; }
        public Guid? RelationshipRef { get; set; }
        public Guid? FoundationRef { get; set; }
        public Guid? MedicalInformationRef { get; set; }
        public Guid? InpatientEpisodeRef { get; set; }
        public Guid? FoundationCityRef { get; set; }
        public Guid? MergedToPatientRef { get; set; }
        public Guid? PatientFolderRef { get; set; }
        public Guid? PatientAddressRef { get; set; }
        public Guid? ImportantMedicalInformationRef { get; set; }
        public Guid? ActivePregnancyRef { get; set; }
        public Guid? InsuranceTypeRef { get; set; }
        public Guid? MotherRef { get; set; }
        public Guid? EducationStatusRef { get; set; }
        public Guid? ProtocolRef { get; set; }
        public Guid? InfertilityPatientInformationRef { get; set; }
        public Guid? PrivacyPatientRef { get; set; }
        public Guid? OccupationRef { get; set; }
        public Guid? BloodGroupTypeRef { get; set; }
        public Guid? BirthOrderRef { get; set; }
        public Guid? SKRSYabanciHastaRef { get; set; }
        public Guid? SKRSOzurlulukDurumuRef { get; set; }

        #region Base Object Navigation Property
        public virtual Person Person { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser RecordUserID { get; set; }
        public virtual PayerDefinition Foundation { get; set; }
        public virtual MedicalInformation MedicalInformation { get; set; }
        public virtual Episode InpatientEpisode { get; set; }
        public virtual Patient MergedToPatient { get; set; }
        public virtual PatientFolder PatientFolder { get; set; }
        public virtual PatientIdentityAndAddress PatientAddress { get; set; }
        public virtual Patient Mother { get; set; }
        public virtual SKRSKanGrubu BloodGroupType { get; set; }
        #endregion Parent Relations
    }
}