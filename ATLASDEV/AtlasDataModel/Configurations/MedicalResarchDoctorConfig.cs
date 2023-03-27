using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchDoctorConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarchDoctor>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarchDoctor> builder)
        {
            builder.ToTable("MEDICALRESARCHDOCTOR");
            builder.HasKey(nameof(AtlasModel.MedicalResarchDoctor.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarchDoctor.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalResarchDoctor.MedicalResarchRef)).HasColumnName("MEDICALRESARCH").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalResarchDoctor.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MedicalResarch).WithOne().HasForeignKey<AtlasModel.MedicalResarchDoctor>(x => x.MedicalResarchRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.MedicalResarchDoctor>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}