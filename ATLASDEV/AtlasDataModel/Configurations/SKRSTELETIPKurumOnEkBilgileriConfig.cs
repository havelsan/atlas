using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSTELETIPKurumOnEkBilgileriConfig : IEntityTypeConfiguration<AtlasModel.SKRSTELETIPKurumOnEkBilgileri>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSTELETIPKurumOnEkBilgileri> builder)
        {
            builder.ToTable("SKRSTELETIPKURUMONEKBILGIL");
            builder.HasKey(nameof(AtlasModel.SKRSTELETIPKurumOnEkBilgileri.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSTELETIPKurumOnEkBilgileri.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSTELETIPKurumOnEkBilgileri.KURUMKODU)).HasColumnName("KURUMKODU");
            builder.Property(nameof(AtlasModel.SKRSTELETIPKurumOnEkBilgileri.KURUMADI)).HasColumnName("KURUMADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTELETIPKurumOnEkBilgileri.TELETIPONEK)).HasColumnName("TELETIPONEK").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTELETIPKurumOnEkBilgileri.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}