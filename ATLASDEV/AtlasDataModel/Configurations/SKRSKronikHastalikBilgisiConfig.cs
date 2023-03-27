using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSKronikHastalikBilgisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSKronikHastalikBilgisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSKronikHastalikBilgisi> builder)
        {
            builder.ToTable("SKRSKRONIKHASTALIKBILGISI");
            builder.HasKey(nameof(AtlasModel.SKRSKronikHastalikBilgisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSKronikHastalikBilgisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSKronikHastalikBilgisi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSKronikHastalikBilgisi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSKronikHastalikBilgisi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}