using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BloodPressureConfig : IEntityTypeConfiguration<AtlasModel.BloodPressure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BloodPressure> builder)
        {
            builder.ToTable("BLOODPRESSURE");
            builder.HasKey(nameof(AtlasModel.BloodPressure.ObjectId));
            builder.Property(nameof(AtlasModel.BloodPressure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BloodPressure.Sistolik)).HasColumnName("SISTOLIK");
            builder.Property(nameof(AtlasModel.BloodPressure.Diastolik)).HasColumnName("DIASTOLIK");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}