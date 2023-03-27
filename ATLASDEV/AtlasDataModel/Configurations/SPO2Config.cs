using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SPO2Config : IEntityTypeConfiguration<AtlasModel.SPO2>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SPO2> builder)
        {
            builder.ToTable("SPO2");
            builder.HasKey(nameof(AtlasModel.SPO2.ObjectId));
            builder.Property(nameof(AtlasModel.SPO2.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SPO2.Value)).HasColumnName("VALUE");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}