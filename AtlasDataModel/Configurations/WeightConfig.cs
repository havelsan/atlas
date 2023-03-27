using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WeightConfig : IEntityTypeConfiguration<AtlasModel.Weight>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Weight> builder)
        {
            builder.ToTable("WEIGHT");
            builder.HasKey(nameof(AtlasModel.Weight.ObjectId));
            builder.Property(nameof(AtlasModel.Weight.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Weight.Value)).HasColumnName("VALUE").HasColumnType("FLOAT");
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.VitalSign>(p => p.ObjectId);
        }
    }
}