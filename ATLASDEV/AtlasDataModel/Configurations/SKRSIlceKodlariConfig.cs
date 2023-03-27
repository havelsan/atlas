using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSIlceKodlariConfig : IEntityTypeConfiguration<AtlasModel.SKRSIlceKodlari>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSIlceKodlari> builder)
        {
            builder.ToTable("SKRSILCEKODLARI");
            builder.HasKey(nameof(AtlasModel.SKRSIlceKodlari.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSIlceKodlari.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSIlceKodlari.ILKODU)).HasColumnName("ILKODU");
            builder.Property(nameof(AtlasModel.SKRSIlceKodlari.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSIlceKodlari.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.SKRSIlceKodlari.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSIlceKodlari.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}