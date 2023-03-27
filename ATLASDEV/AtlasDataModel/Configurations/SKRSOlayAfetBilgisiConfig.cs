using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSOlayAfetBilgisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSOlayAfetBilgisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSOlayAfetBilgisi> builder)
        {
            builder.ToTable("SKRSOLAYAFETBILGISI");
            builder.HasKey(nameof(AtlasModel.SKRSOlayAfetBilgisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.OLAYNO)).HasColumnName("OLAYNO");
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.OLAYISMI)).HasColumnName("OLAYISMI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.OLAYILKODU)).HasColumnName("OLAYILKODU");
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.LOKASYON)).HasColumnName("LOKASYON").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.TARIHSAAT)).HasColumnName("TARIHSAAT").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.OLAYTIPI)).HasColumnName("OLAYTIPI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.BAGLIOLAYNO)).HasColumnName("BAGLIOLAYNO");
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.BILGINOTU)).HasColumnName("BILGINOTU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.ETKILENENILLER)).HasColumnName("ETKILENENILLER").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOlayAfetBilgisi.KAPATILMATARIHI)).HasColumnName("KAPATILMATARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}