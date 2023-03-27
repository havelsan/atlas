using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TemperatureConfig : IEntityTypeConfiguration<AtlasModel.Temperature>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Temperature> builder)
        {
            builder.ToTable("TEMPERATURE");
            builder.HasKey(nameof(AtlasModel.Temperature.ObjectId));
            builder.Property(nameof(AtlasModel.Temperature.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Temperature.Value)).HasColumnName("VALUE").HasColumnType("FLOAT");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}