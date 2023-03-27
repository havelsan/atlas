using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSSHMAltBirimConfig : IEntityTypeConfiguration<AtlasModel.SKRSSHMAltBirim>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSSHMAltBirim> builder)
        {
            builder.ToTable("SKRSSHMALTBIRIM");
            builder.HasKey(nameof(AtlasModel.SKRSSHMAltBirim.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSSHMAltBirim.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSSHMAltBirim.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSHMAltBirim.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSHMAltBirim.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}