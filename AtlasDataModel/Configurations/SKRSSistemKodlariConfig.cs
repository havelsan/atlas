using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSSistemKodlariConfig : IEntityTypeConfiguration<AtlasModel.SKRSSistemKodlari>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSSistemKodlari> builder)
        {
            builder.ToTable("SKRSSISTEMKODLARI");
            builder.HasKey(nameof(AtlasModel.SKRSSistemKodlari.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSSistemKodlari.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSSistemKodlari.SKRSGuid)).HasColumnName("SKRSGUID");
            builder.Property(nameof(AtlasModel.SKRSSistemKodlari.Adi)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSistemKodlari.SqlFilter)).HasColumnName("SQLFILTER").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.SKRSSistemKodlari.AKTIF)).HasColumnName("AKTIF");
        }
    }
}