using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientExaminationAdditionalApplicationConfig : IEntityTypeConfiguration<AtlasModel.PatientExaminationAdditionalApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientExaminationAdditionalApplication> builder)
        {
            builder.ToTable("PATIENTEXAMADDITIONALAPP");
            builder.HasKey(nameof(AtlasModel.PatientExaminationAdditionalApplication.ObjectId));
            builder.Property(nameof(AtlasModel.PatientExaminationAdditionalApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseAdditionalApplication).WithOne().HasForeignKey<AtlasModel.BaseAdditionalApplication>(p => p.ObjectId);
        }
    }
}