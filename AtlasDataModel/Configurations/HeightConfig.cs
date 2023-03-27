using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HeightConfig : IEntityTypeConfiguration<AtlasModel.Height>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Height> builder)
        {
            builder.ToTable("HEIGHT");
            builder.HasKey(nameof(AtlasModel.Height.ObjectId));
            builder.Property(nameof(AtlasModel.Height.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Height.Value)).HasColumnName("VALUE");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}