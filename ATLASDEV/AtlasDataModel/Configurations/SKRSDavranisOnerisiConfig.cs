using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSDavranisOnerisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSDavranisOnerisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSDavranisOnerisi> builder)
        {
            builder.ToTable("SKRSDAVRANISONERISI");
            builder.HasKey(nameof(AtlasModel.SKRSDavranisOnerisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSDavranisOnerisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSDavranisOnerisi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSDavranisOnerisi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSDavranisOnerisi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}