using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSMalnutrisyonTedaviPlaniConfig : IEntityTypeConfiguration<AtlasModel.SKRSMalnutrisyonTedaviPlani>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSMalnutrisyonTedaviPlani> builder)
        {
            builder.ToTable("SKRSMALNUTRISYONTEDAVIPLAN");
            builder.HasKey(nameof(AtlasModel.SKRSMalnutrisyonTedaviPlani.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonTedaviPlani.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonTedaviPlani.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonTedaviPlani.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSMalnutrisyonTedaviPlani.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}