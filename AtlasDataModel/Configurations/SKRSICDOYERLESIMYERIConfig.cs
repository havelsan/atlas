using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSICDOYERLESIMYERIConfig : IEntityTypeConfiguration<AtlasModel.SKRSICDOYERLESIMYERI>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSICDOYERLESIMYERI> builder)
        {
            builder.ToTable("SKRSICDOYERLESIMYERI");
            builder.HasKey(nameof(AtlasModel.SKRSICDOYERLESIMYERI.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSICDOYERLESIMYERI.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSICDOYERLESIMYERI.SKRSKODU)).HasColumnName("SKRSKODU");
            builder.Property(nameof(AtlasModel.SKRSICDOYERLESIMYERI.TOPOGRAFIKODU)).HasColumnName("TOPOGRAFIKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDOYERLESIMYERI.KODTANIMI)).HasColumnName("KODTANIMI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDOYERLESIMYERI.KODACIKLAMA)).HasColumnName("KODACIKLAMA").HasMaxLength(2000);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}