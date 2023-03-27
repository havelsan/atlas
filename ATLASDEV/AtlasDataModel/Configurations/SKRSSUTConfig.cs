using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSSUTConfig : IEntityTypeConfiguration<AtlasModel.SKRSSUT>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSSUT> builder)
        {
            builder.ToTable("SKRSSUT");
            builder.HasKey(nameof(AtlasModel.SKRSSUT.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSSUT.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSSUT.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSUT.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSUT.FIYAT)).HasColumnName("FIYAT").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSUT.IDUSTNO)).HasColumnName("IDUSTNO");
            builder.Property(nameof(AtlasModel.SKRSSUT.TIP)).HasColumnName("TIP").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSUT.PUAN)).HasColumnName("PUAN");
            builder.Property(nameof(AtlasModel.SKRSSUT.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSSUT.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}