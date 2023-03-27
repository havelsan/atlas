using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchPatientExConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarchPatientEx>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarchPatientEx> builder)
        {
            builder.ToTable("MEDICALRESARCHPATIENTEX");
            builder.HasKey(nameof(AtlasModel.MedicalResarchPatientEx.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarchPatientEx.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalResarchPatientEx.MedicalResarchRef)).HasColumnName("MEDICALRESARCH").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MedicalResarch).WithOne().HasForeignKey<AtlasModel.MedicalResarchPatientEx>(x => x.MedicalResarchRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}