using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSIlacConfig : IEntityTypeConfiguration<AtlasModel.SKRSIlac>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSIlac> builder)
        {
            builder.ToTable("SKRSILAC");
            builder.HasKey(nameof(AtlasModel.SKRSIlac.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSIlac.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSIlac.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSIlac.BARKODU)).HasColumnName("BARKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSIlac.FIYAT)).HasColumnName("FIYAT");
            builder.Property(nameof(AtlasModel.SKRSIlac.GERIODEME)).HasColumnName("GERIODEME");
            builder.Property(nameof(AtlasModel.SKRSIlac.RECETETURU)).HasColumnName("RECETETURU");
            builder.Property(nameof(AtlasModel.SKRSIlac.FIRMAADI)).HasColumnName("FIRMAADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSIlac.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSIlac.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.Property(nameof(AtlasModel.SKRSIlac.ATCKODU)).HasColumnName("ATCKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSIlac.ATCADI)).HasColumnName("ATCADI").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}