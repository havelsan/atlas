using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchPatientExProConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarchPatientExPro>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarchPatientExPro> builder)
        {
            builder.ToTable("MEDICALRESARCHPATIENTEXPRO");
            builder.HasKey(nameof(AtlasModel.MedicalResarchPatientExPro.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarchPatientExPro.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}