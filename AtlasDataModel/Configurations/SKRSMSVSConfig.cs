using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSMSVSConfig : IEntityTypeConfiguration<AtlasModel.SKRSMSVS>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSMSVS> builder)
        {
            builder.ToTable("SKRSMSVS");
            builder.HasKey(nameof(AtlasModel.SKRSMSVS.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSMSVS.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSMSVS.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSMSVS.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}