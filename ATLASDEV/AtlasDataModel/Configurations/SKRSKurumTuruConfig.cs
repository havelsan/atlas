using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSKurumTuruConfig : IEntityTypeConfiguration<AtlasModel.SKRSKurumTuru>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSKurumTuru> builder)
        {
            builder.ToTable("SKRSKURUMTURU");
            builder.HasKey(nameof(AtlasModel.SKRSKurumTuru.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSKurumTuru.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseSKRSCommonDef).WithOne().HasForeignKey<AtlasModel.BaseSKRSCommonDef>(p => p.ObjectId);
        }
    }
}