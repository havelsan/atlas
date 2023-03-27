using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSEgitimMateryaliConfig : IEntityTypeConfiguration<AtlasModel.SKRSEgitimMateryali>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSEgitimMateryali> builder)
        {
            builder.ToTable("SKRSEGITIMMATERYALI");
            builder.HasKey(nameof(AtlasModel.SKRSEgitimMateryali.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSEgitimMateryali.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSEgitimMateryali.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSEgitimMateryali.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSEgitimMateryali.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}