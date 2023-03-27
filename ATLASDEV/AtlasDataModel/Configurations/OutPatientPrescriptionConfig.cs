using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OutPatientPrescriptionConfig : IEntityTypeConfiguration<AtlasModel.OutPatientPrescription>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OutPatientPrescription> builder)
        {
            builder.ToTable("OUTPATIENTPRESCRIPTION");
            builder.HasKey(nameof(AtlasModel.OutPatientPrescription.ObjectId));
            builder.Property(nameof(AtlasModel.OutPatientPrescription.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OutPatientPrescription.PatientGroup)).HasColumnName("PATIENTGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OutPatientPrescription.SPTSMessageID)).HasColumnName("SPTSMESSAGEID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OutPatientPrescription.SendOutPharmacy)).HasColumnName("SENDOUTPHARMACY");
            builder.Property(nameof(AtlasModel.OutPatientPrescription.SPTSProvisionID)).HasColumnName("SPTSPROVISIONID");
            builder.Property(nameof(AtlasModel.OutPatientPrescription.ReceiptNO)).HasColumnName("RECEIPTNO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.OutPatientPrescription.FreeDiagnosis)).HasColumnName("FREEDIAGNOSIS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OutPatientPrescription.SPTSProvisionDesc)).HasColumnName("SPTSPROVISIONDESC").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.OutPatientPrescription.AddDiagnosisType)).HasColumnName("ADDDIAGNOSISTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OutPatientPrescription.IsDischargePrescripiton)).HasColumnName("ISDISCHARGEPRESCRIPITON");
            builder.Property(nameof(AtlasModel.OutPatientPrescription.DiscriptionOfPharmacist)).HasColumnName("DISCRIPTIONOFPHARMACIST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OutPatientPrescription.ExternalPharmacyRef)).HasColumnName("EXTERNALPHARMACY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OutPatientPrescription.DiagnosisDefinitionRef)).HasColumnName("DIAGNOSISDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OutPatientPrescription.SpecialityDefinitionRef)).HasColumnName("SPECIALITYDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Prescription).WithOne().HasForeignKey<AtlasModel.Prescription>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DiagnosisDefinition).WithOne().HasForeignKey<AtlasModel.OutPatientPrescription>(x => x.DiagnosisDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}