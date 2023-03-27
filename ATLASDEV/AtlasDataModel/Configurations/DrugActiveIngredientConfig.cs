using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugActiveIngredientConfig : IEntityTypeConfiguration<AtlasModel.DrugActiveIngredient>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugActiveIngredient> builder)
        {
            builder.ToTable("DRUGACTIVEINGREDIENT");
            builder.HasKey(nameof(AtlasModel.DrugActiveIngredient.ObjectId));
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.MaxDose)).HasColumnName("MAXDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.OldDrugDefinition)).HasColumnName("OLDDRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.Value)).HasColumnName("VALUE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.IsParentIngredient)).HasColumnName("ISPARENTINGREDIENT");
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.UnitRef)).HasColumnName("UNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.ActiveIngredientRef)).HasColumnName("ACTIVEINGREDIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugActiveIngredient.MaxDoseUnitRef)).HasColumnName("MAXDOSEUNIT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.DrugActiveIngredient>(x => x.DrugDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.ActiveIngredient).WithOne().HasForeignKey<AtlasModel.DrugActiveIngredient>(x => x.ActiveIngredientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}