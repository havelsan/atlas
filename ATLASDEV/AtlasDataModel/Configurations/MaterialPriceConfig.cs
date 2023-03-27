using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MaterialPriceConfig : IEntityTypeConfiguration<AtlasModel.MaterialPrice>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MaterialPrice> builder)
        {
            builder.ToTable("MATERIALPRICE");
            builder.HasKey(nameof(AtlasModel.MaterialPrice.ObjectId));
            builder.Property(nameof(AtlasModel.MaterialPrice.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MaterialPrice.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MaterialPrice.PricingDetailRef)).HasColumnName("PRICINGDETAIL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.MaterialPrice>(x => x.MaterialRef).IsRequired(true);
            builder.HasOne(t => t.PricingDetail).WithOne().HasForeignKey<AtlasModel.MaterialPrice>(x => x.PricingDetailRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}