using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSAFETOLAYTIPIConfig : IEntityTypeConfiguration<AtlasModel.SKRSAFETOLAYTIPI>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSAFETOLAYTIPI> builder)
        {
            builder.ToTable("SKRSAFETOLAYTIPI");
            builder.HasKey(nameof(AtlasModel.SKRSAFETOLAYTIPI.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSAFETOLAYTIPI.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSAFETOLAYTIPI.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSAFETOLAYTIPI.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSAFETOLAYTIPI.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}