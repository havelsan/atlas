using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EquivalentConsMaterialConfig : IEntityTypeConfiguration<AtlasModel.EquivalentConsMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EquivalentConsMaterial> builder)
        {
            builder.ToTable("EQUIVALENTCONSMATERIAL");
            builder.HasKey(nameof(AtlasModel.EquivalentConsMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.EquivalentConsMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EquivalentConsMaterial.ConsumableMaterialDefinitionRef)).HasColumnName("CONSUMABLEMATERIALDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EquivalentConsMaterial.EquivalentMaterialRef)).HasColumnName("EQUIVALENTMATERIAL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ConsumableMaterialDefinition).WithOne().HasForeignKey<AtlasModel.EquivalentConsMaterial>(x => x.ConsumableMaterialDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.EquivalentMaterial).WithOne().HasForeignKey<AtlasModel.EquivalentConsMaterial>(x => x.EquivalentMaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}