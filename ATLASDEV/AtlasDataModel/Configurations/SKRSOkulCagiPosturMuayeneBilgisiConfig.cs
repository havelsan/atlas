using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSOkulCagiPosturMuayeneBilgisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi> builder)
        {
            builder.ToTable("SKRSOKULCAGIPOSTURMUAYENEB");
            builder.HasKey(nameof(AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}