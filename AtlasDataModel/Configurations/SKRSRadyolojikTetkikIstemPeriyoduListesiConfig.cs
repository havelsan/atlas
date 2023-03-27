using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSRadyolojikTetkikIstemPeriyoduListesiConfig : IEntityTypeConfiguration<AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi> builder)
        {
            builder.ToTable("SKRSRADYOLOJIKTETKIKISTEMP");
            builder.HasKey(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.SUTKODU)).HasColumnName("SUTKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.ISTEMSURESI)).HasColumnName("ISTEMSURESI");
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.ACIKLAMA)).HasColumnName("ACIKLAMA").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}