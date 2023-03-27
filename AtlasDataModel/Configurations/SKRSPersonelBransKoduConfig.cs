using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSPersonelBransKoduConfig : IEntityTypeConfiguration<AtlasModel.SKRSPersonelBransKodu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSPersonelBransKodu> builder)
        {
            builder.ToTable("SKRSPERSONELBRANSKODU");
            builder.HasKey(nameof(AtlasModel.SKRSPersonelBransKodu.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSPersonelBransKodu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSPersonelBransKodu.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSPersonelBransKodu.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSPersonelBransKodu.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}