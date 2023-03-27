using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSTibbiIslemPuanBilgisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSTibbiIslemPuanBilgisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSTibbiIslemPuanBilgisi> builder)
        {
            builder.ToTable("SKRSTIBBIISLEMPUANBILGISI");
            builder.HasKey(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.ACIKLAMA)).HasColumnName("ACIKLAMA").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.ISLEMPUANI)).HasColumnName("ISLEMPUANI");
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.AMELIYATGRUPLARI)).HasColumnName("AMELIYATGRUPLARI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSTibbiIslemPuanBilgisi.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}