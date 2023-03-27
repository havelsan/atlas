using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientExaminationProcedureConfig : IEntityTypeConfiguration<AtlasModel.PatientExaminationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientExaminationProcedure> builder)
        {
            builder.ToTable("PATIENTEXAMPROCEDURE");
            builder.HasKey(nameof(AtlasModel.PatientExaminationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.PatientExaminationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}