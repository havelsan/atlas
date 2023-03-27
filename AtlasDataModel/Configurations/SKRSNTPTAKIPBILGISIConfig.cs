using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSNTPTAKIPBILGISIConfig : IEntityTypeConfiguration<AtlasModel.SKRSNTPTAKIPBILGISI>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSNTPTAKIPBILGISI> builder)
        {
            builder.ToTable("SKRSNTPTAKIPBILGISI");
            builder.HasKey(nameof(AtlasModel.SKRSNTPTAKIPBILGISI.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSNTPTAKIPBILGISI.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSNTPTAKIPBILGISI.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSNTPTAKIPBILGISI.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSNTPTAKIPBILGISI.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}