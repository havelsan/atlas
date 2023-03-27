using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientConfig : IEntityTypeConfiguration<AtlasModel.Patient>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Patient> builder)
        {
            builder.ToTable("PATIENT");
            builder.HasKey(nameof(AtlasModel.Patient.ObjectId));
            builder.Property(nameof(AtlasModel.Patient.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Patient.Length)).HasColumnName("LENGTH").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.Patient.PatientHistory)).HasColumnName("PATIENTHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.EyeColor)).HasColumnName("EYECOLOR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Patient.SpecialStatus)).HasColumnName("SPECIALSTATUS").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Patient.Beneficiary)).HasColumnName("BENEFICIARY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Patient.ImportantPatientInfo)).HasColumnName("IMPORTANTPATIENTINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.BeneficiaryDate)).HasColumnName("BENEFICIARYDATE");
            builder.Property(nameof(AtlasModel.Patient.Deleted)).HasColumnName("DELETED").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Patient.OldID)).HasColumnName("OLDID");
            builder.Property(nameof(AtlasModel.Patient.Photo)).HasColumnName("PHOTO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.UnIdentified)).HasColumnName("UNIDENTIFIED");
            builder.Property(nameof(AtlasModel.Patient.Alive)).HasColumnName("ALIVE");
            builder.Property(nameof(AtlasModel.Patient.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.Patient.EMail)).HasColumnName("EMAIL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Patient.Note)).HasColumnName("NOTE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Patient.NotRequiredQuota)).HasColumnName("NOTREQUIREDQUOTA");
            builder.Property(nameof(AtlasModel.Patient.Foreign)).HasColumnName("FOREIGN");
            builder.Property(nameof(AtlasModel.Patient.Religion)).HasColumnName("RELIGION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Patient.Privacy)).HasColumnName("PRIVACY");
            builder.Property(nameof(AtlasModel.Patient.PrivacyEndDate)).HasColumnName("PRIVACYENDDATE");
            builder.Property(nameof(AtlasModel.Patient.PrivacyReason)).HasColumnName("PRIVACYREASON").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Patient.YUPASSNO)).HasColumnName("YUPASSNO");
            builder.Property(nameof(AtlasModel.Patient.SecurePerson)).HasColumnName("SECUREPERSON");
            builder.Property(nameof(AtlasModel.Patient.PatientFamilyHistory)).HasColumnName("PATIENTFAMILYHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.Heigth)).HasColumnName("HEIGTH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Patient.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Patient.ChestCircumference)).HasColumnName("CHESTCIRCUMFERENCE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Patient.HeadCircumference)).HasColumnName("HEADCIRCUMFERENCE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Patient.IsTrusted)).HasColumnName("ISTRUSTED");
            builder.Property(nameof(AtlasModel.Patient.PrivacyName)).HasColumnName("PRIVACYNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Patient.PrivacySurname)).HasColumnName("PRIVACYSURNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Patient.Death)).HasColumnName("DEATH");
            builder.Property(nameof(AtlasModel.Patient.DonorUniqueRefNo)).HasColumnName("DONORUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.Patient.KPSUpdateDate)).HasColumnName("KPSUPDATEDATE");
            builder.Property(nameof(AtlasModel.Patient.BeneficiaryName)).HasColumnName("BENEFICIARYNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Patient.BeneficiaryUniqueRefNo)).HasColumnName("BENEFICIARYUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.Patient.PrivacyHomeAddress)).HasColumnName("PRIVACYHOMEADDRESS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Patient.PrivacyMobilePhone)).HasColumnName("PRIVACYMOBILEPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Patient.VemHastaKodu)).HasColumnName("VEMHASTAKODU").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Patient.ServiceRef)).HasColumnName("SERVICE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.RecordUserIDRef)).HasColumnName("RECORDUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.RelationshipRef)).HasColumnName("RELATIONSHIP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.FoundationRef)).HasColumnName("FOUNDATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.MedicalInformationRef)).HasColumnName("MEDICALINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.InpatientEpisodeRef)).HasColumnName("INPATIENTEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.FoundationCityRef)).HasColumnName("FOUNDATIONCITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.MergedToPatientRef)).HasColumnName("MERGEDTOPATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.PatientFolderRef)).HasColumnName("PATIENTFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.PatientAddressRef)).HasColumnName("PATIENTADDRESS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.ImportantMedicalInformationRef)).HasColumnName("IMPORTANTMEDICALINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.ActivePregnancyRef)).HasColumnName("ACTIVEPREGNANCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.InsuranceTypeRef)).HasColumnName("INSURANCETYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.MotherRef)).HasColumnName("MOTHER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.EducationStatusRef)).HasColumnName("EDUCATIONSTATUS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.ProtocolRef)).HasColumnName("PROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.InfertilityPatientInformationRef)).HasColumnName("INFERTILITYPATIENTINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.PrivacyPatientRef)).HasColumnName("PRIVACYPATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.OccupationRef)).HasColumnName("OCCUPATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.BloodGroupTypeRef)).HasColumnName("BLOODGROUPTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.BirthOrderRef)).HasColumnName("BIRTHORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.SKRSYabanciHastaRef)).HasColumnName("SKRSYABANCIHASTA").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Patient.SKRSOzurlulukDurumuRef)).HasColumnName("SKRSOZURLULUKDURUMU").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Person).WithOne().HasForeignKey<AtlasModel.Person>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RecordUserID).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.RecordUserIDRef).IsRequired(false);
            builder.HasOne(t => t.Foundation).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.FoundationRef).IsRequired(false);
            builder.HasOne(t => t.MedicalInformation).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.MedicalInformationRef).IsRequired(false);
            builder.HasOne(t => t.InpatientEpisode).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.InpatientEpisodeRef).IsRequired(false);
            builder.HasOne(t => t.MergedToPatient).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.MergedToPatientRef).IsRequired(false);
            builder.HasOne(t => t.PatientFolder).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.PatientFolderRef).IsRequired(false);
            builder.HasOne(t => t.PatientAddress).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.PatientAddressRef).IsRequired(false);
            builder.HasOne(t => t.Mother).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.MotherRef).IsRequired(false);
            builder.HasOne(t => t.BloodGroupType).WithOne().HasForeignKey<AtlasModel.Patient>(x => x.BloodGroupTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}