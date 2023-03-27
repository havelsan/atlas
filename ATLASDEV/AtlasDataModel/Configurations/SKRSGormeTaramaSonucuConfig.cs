using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSGormeTaramaSonucuConfig : IEntityTypeConfiguration<AtlasModel.SKRSGormeTaramaSonucu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSGormeTaramaSonucu> builder)
        {
            builder.ToTable("SKRSGORMETARAMASONUCU");
            builder.HasKey(nameof(AtlasModel.SKRSGormeTaramaSonucu.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSGormeTaramaSonucu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSGormeTaramaSonucu.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSGormeTaramaSonucu.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSGormeTaramaSonucu.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}