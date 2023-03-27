using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSICDConfig : IEntityTypeConfiguration<AtlasModel.SKRSICD>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSICD> builder)
        {
            builder.ToTable("SKRSICD");
            builder.HasKey(nameof(AtlasModel.SKRSICD.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSICD.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSICD.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICD.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICD.USTKODU)).HasColumnName("USTKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICD.USTIDNO)).HasColumnName("USTIDNO").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICD.SEVIYE)).HasColumnName("SEVIYE");
            builder.Property(nameof(AtlasModel.SKRSICD.ANNEOLUMU)).HasColumnName("ANNEOLUMU");
            builder.Property(nameof(AtlasModel.SKRSICD.BILDIRIMIZORUNLU)).HasColumnName("BILDIRIMIZORUNLU");
            builder.Property(nameof(AtlasModel.SKRSICD.OLUMNEDENI)).HasColumnName("OLUMNEDENI");
            builder.Property(nameof(AtlasModel.SKRSICD.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSICD.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICD.YUKSEKRISKLIGEBELIK)).HasColumnName("YUKSEKRISKLIGEBELIK");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}