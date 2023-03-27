using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PulseConfig : IEntityTypeConfiguration<AtlasModel.Pulse>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Pulse> builder)
        {
            builder.ToTable("PULSE");
            builder.HasKey(nameof(AtlasModel.Pulse.ObjectId));
            builder.Property(nameof(AtlasModel.Pulse.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Pulse.Value)).HasColumnName("VALUE");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}