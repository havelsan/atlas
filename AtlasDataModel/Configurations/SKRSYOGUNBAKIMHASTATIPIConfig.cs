using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSYOGUNBAKIMHASTATIPIConfig : IEntityTypeConfiguration<AtlasModel.SKRSYOGUNBAKIMHASTATIPI>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSYOGUNBAKIMHASTATIPI> builder)
        {
            builder.ToTable("SKRSYOGUNBAKIMHASTATIPI");
            builder.HasKey(nameof(AtlasModel.SKRSYOGUNBAKIMHASTATIPI.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSYOGUNBAKIMHASTATIPI.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSYOGUNBAKIMHASTATIPI.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSYOGUNBAKIMHASTATIPI.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSYOGUNBAKIMHASTATIPI.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}