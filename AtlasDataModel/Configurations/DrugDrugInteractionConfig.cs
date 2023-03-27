using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugDrugInteractionConfig : IEntityTypeConfiguration<AtlasModel.DrugDrugInteraction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugDrugInteraction> builder)
        {
            builder.ToTable("DRUGDRUGINTERACTION");
            builder.HasKey(nameof(AtlasModel.DrugDrugInteraction.ObjectId));
            builder.Property(nameof(AtlasModel.DrugDrugInteraction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugDrugInteraction.Message)).HasColumnName("MESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DrugDrugInteraction.InteractionLevelType)).HasColumnName("INTERACTIONLEVELTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDrugInteraction.InteractionDrugRef)).HasColumnName("INTERACTIONDRUG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDrugInteraction.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InteractionDrug).WithOne().HasForeignKey<AtlasModel.DrugDrugInteraction>(x => x.InteractionDrugRef).IsRequired(true);
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.DrugDrugInteraction>(x => x.DrugDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}