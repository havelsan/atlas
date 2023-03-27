using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSKliniklerConfig : IEntityTypeConfiguration<AtlasModel.SKRSKlinikler>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSKlinikler> builder)
        {
            builder.ToTable("SKRSKLINIKLER");
            builder.HasKey(nameof(AtlasModel.SKRSKlinikler.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSKlinikler.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseSKRSCommonDef).WithOne().HasForeignKey<AtlasModel.BaseSKRSCommonDef>(p => p.ObjectId);
        }
    }
}