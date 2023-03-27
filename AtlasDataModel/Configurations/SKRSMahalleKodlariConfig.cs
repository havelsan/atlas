using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSMahalleKodlariConfig : IEntityTypeConfiguration<AtlasModel.SKRSMahalleKodlari>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSMahalleKodlari> builder)
        {
            builder.ToTable("SKRSMAHALLEKODLARI");
            builder.HasKey(nameof(AtlasModel.SKRSMahalleKodlari.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.KOYKODU)).HasColumnName("KOYKODU");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.TANITIMKODU)).HasColumnName("TANITIMKODU");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.TIPI)).HasColumnName("TIPI");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.YETKILIIDAREKODU)).HasColumnName("YETKILIIDAREKODU");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.Property(nameof(AtlasModel.SKRSMahalleKodlari.SKRSKoyKodlariRef)).HasColumnName("SKRSKOYKODLARI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}