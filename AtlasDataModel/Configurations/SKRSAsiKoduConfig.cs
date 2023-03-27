using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSAsiKoduConfig : IEntityTypeConfiguration<AtlasModel.SKRSAsiKodu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSAsiKodu> builder)
        {
            builder.ToTable("SKRSASIKODU");
            builder.HasKey(nameof(AtlasModel.SKRSAsiKodu.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.HLKODU)).HasColumnName("HLKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.HLADI)).HasColumnName("HLADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSAsiKodu.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}