using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSMalnutrisyonDegerlendirmeBilgisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi> builder)
        {
            builder.ToTable("SKRSMALNUTRISYONDEGERLENDI");
            builder.HasKey(nameof(AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}