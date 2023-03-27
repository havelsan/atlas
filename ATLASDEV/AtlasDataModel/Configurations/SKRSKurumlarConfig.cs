using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSKurumlarConfig : IEntityTypeConfiguration<AtlasModel.SKRSKurumlar>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSKurumlar> builder)
        {
            builder.ToTable("SKRSKURUMLAR");
            builder.HasKey(nameof(AtlasModel.SKRSKurumlar.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSKurumlar.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSKurumlar.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSKurumlar.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.ILKODU)).HasColumnName("ILKODU");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.ILCEKODU)).HasColumnName("ILCEKODU");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.KURUMTIPI)).HasColumnName("KURUMTIPI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSKurumlar.KURUMTURKODU)).HasColumnName("KURUMTURKODU");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.BASAMAKSEVIYESI)).HasColumnName("BASAMAKSEVIYESI");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.Property(nameof(AtlasModel.SKRSKurumlar.TELETIPONEK)).HasColumnName("TELETIPONEK").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}