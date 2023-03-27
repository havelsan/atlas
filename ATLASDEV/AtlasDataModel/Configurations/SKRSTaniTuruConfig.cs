using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSTaniTuruConfig : IEntityTypeConfiguration<AtlasModel.SKRSTaniTuru>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSTaniTuru> builder)
        {
            builder.ToTable("SKRSTANITURU");
            builder.HasKey(nameof(AtlasModel.SKRSTaniTuru.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSTaniTuru.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSTaniTuru.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTaniTuru.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTaniTuru.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}