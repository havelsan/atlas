using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSUCUMConfig : IEntityTypeConfiguration<AtlasModel.SKRSUCUM>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSUCUM> builder)
        {
            builder.ToTable("SKRSUCUM");
            builder.HasKey(nameof(AtlasModel.SKRSUCUM.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSUCUM.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSUCUM.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSUCUM.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSUCUM.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}