using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseSKRSCommonDefConfig : IEntityTypeConfiguration<AtlasModel.BaseSKRSCommonDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseSKRSCommonDef> builder)
        {
            builder.ToTable("BASESKRSCOMMONDEF");
            builder.HasKey(nameof(AtlasModel.BaseSKRSCommonDef.ObjectId));
            builder.Property(nameof(AtlasModel.BaseSKRSCommonDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseSKRSCommonDef.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.BaseSKRSCommonDef.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.BaseSKRSCommonDef.KODU)).HasColumnName("KODU").HasMaxLength(255);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}