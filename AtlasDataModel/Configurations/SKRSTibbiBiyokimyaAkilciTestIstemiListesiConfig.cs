using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSTibbiBiyokimyaAkilciTestIstemiListesiConfig : IEntityTypeConfiguration<AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi> builder)
        {
            builder.ToTable("SKRSTIBBIBIYOKIMYAAKILCITE");
            builder.HasKey(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.SUTKODU)).HasColumnName("SUTKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.ISTEMSURESI)).HasColumnName("ISTEMSURESI");
            builder.Property(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}