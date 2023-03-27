using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSEnfeksiyonEtkeniConfig : IEntityTypeConfiguration<AtlasModel.SKRSEnfeksiyonEtkeni>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSEnfeksiyonEtkeni> builder)
        {
            builder.ToTable("SKRSENFEKSIYONETKENI");
            builder.HasKey(nameof(AtlasModel.SKRSEnfeksiyonEtkeni.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSEnfeksiyonEtkeni.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSEnfeksiyonEtkeni.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSEnfeksiyonEtkeni.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSEnfeksiyonEtkeni.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}