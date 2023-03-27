using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchPatientAdConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarchPatientAd>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarchPatientAd> builder)
        {
            builder.ToTable("MEDICALRESARCHPATIENAD");
            builder.HasKey(nameof(AtlasModel.MedicalResarchPatientAd.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarchPatientAd.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalResarchPatientAd.MedicalResarchRef)).HasColumnName("MEDICALRESARCH").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PatientAdmission).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MedicalResarch).WithOne().HasForeignKey<AtlasModel.MedicalResarchPatientAd>(x => x.MedicalResarchRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}