using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientExaminationTreatmentMaterialConfig : IEntityTypeConfiguration<AtlasModel.PatientExaminationTreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientExaminationTreatmentMaterial> builder)
        {
            builder.ToTable("PATIENTEXAMINATIONTREATMAT");
            builder.HasKey(nameof(AtlasModel.PatientExaminationTreatmentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.PatientExaminationTreatmentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}