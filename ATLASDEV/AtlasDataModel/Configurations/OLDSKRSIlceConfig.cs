using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OLDSKRSIlceConfig : IEntityTypeConfiguration<AtlasModel.OLDSKRSIlce>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OLDSKRSIlce> builder)
        {
            builder.ToTable("OLDSKRSILCE");
            builder.HasKey(nameof(AtlasModel.OLDSKRSIlce.ObjectId));
            builder.Property(nameof(AtlasModel.OLDSKRSIlce.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OLDSKRSIlce.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.OLDSKRSIlce.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.OLDSKRSIlce.ILKODU)).HasColumnName("ILKODU");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}