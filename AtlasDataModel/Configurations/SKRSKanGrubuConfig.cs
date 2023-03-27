using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSKanGrubuConfig : IEntityTypeConfiguration<AtlasModel.SKRSKanGrubu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSKanGrubu> builder)
        {
            builder.ToTable("SKRSKANGRUBU");
            builder.HasKey(nameof(AtlasModel.SKRSKanGrubu.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSKanGrubu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseSKRSCommonDef).WithOne().HasForeignKey<AtlasModel.BaseSKRSCommonDef>(p => p.ObjectId);
        }
    }
}