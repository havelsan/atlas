using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugFoodInteractionConfig : IEntityTypeConfiguration<AtlasModel.DrugFoodInteraction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugFoodInteraction> builder)
        {
            builder.ToTable("DRUGFOODINTERACTION");
            builder.HasKey(nameof(AtlasModel.DrugFoodInteraction.ObjectId));
            builder.Property(nameof(AtlasModel.DrugFoodInteraction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugFoodInteraction.InteractionLevelType)).HasColumnName("INTERACTIONLEVELTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugFoodInteraction.Message)).HasColumnName("MESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DrugFoodInteraction.DietMaterialDefinitionRef)).HasColumnName("DIETMATERIALDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugFoodInteraction.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DietMaterialDefinition).WithOne().HasForeignKey<AtlasModel.DrugFoodInteraction>(x => x.DietMaterialDefinitionRef).IsRequired(true);
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.DrugFoodInteraction>(x => x.DrugDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}