using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RespirationConfig : IEntityTypeConfiguration<AtlasModel.Respiration>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Respiration> builder)
        {
            builder.ToTable("RESPIRATION");
            builder.HasKey(nameof(AtlasModel.Respiration.ObjectId));
            builder.Property(nameof(AtlasModel.Respiration.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Respiration.Value)).HasColumnName("VALUE");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}