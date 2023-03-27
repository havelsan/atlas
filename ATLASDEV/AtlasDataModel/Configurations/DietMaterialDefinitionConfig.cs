using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DietMaterialDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DietMaterialDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DietMaterialDefinition> builder)
        {
            builder.ToTable("DIETMATERIALDEFINITION");
            builder.HasKey(nameof(AtlasModel.DietMaterialDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DietMaterialDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DietMaterialDefinition.MaterialName)).HasColumnName("MATERIALNAME").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.DietMaterialDefinition.Vitamins)).HasColumnName("VITAMINS").HasMaxLength(2000);
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}