using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSOgrenciMuayeneIzlemIslemiConfig : IEntityTypeConfiguration<AtlasModel.SKRSOgrenciMuayeneIzlemIslemi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSOgrenciMuayeneIzlemIslemi> builder)
        {
            builder.ToTable("SKRSOGRENCIMUAYENEIZLEMISL");
            builder.HasKey(nameof(AtlasModel.SKRSOgrenciMuayeneIzlemIslemi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSOgrenciMuayeneIzlemIslemi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSOgrenciMuayeneIzlemIslemi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOgrenciMuayeneIzlemIslemi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOgrenciMuayeneIzlemIslemi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}