using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSTakipTipiConfig : IEntityTypeConfiguration<AtlasModel.SKRSTakipTipi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSTakipTipi> builder)
        {
            builder.ToTable("SKRSTAKIPTIPI");
            builder.HasKey(nameof(AtlasModel.SKRSTakipTipi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSTakipTipi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSTakipTipi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTakipTipi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTakipTipi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}