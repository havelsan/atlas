using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ActiveIngredientDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ActiveIngredientDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ActiveIngredientDefinition> builder)
        {
            builder.ToTable("ACTIVEINGREDIENTDEFINITION");
            builder.HasKey(nameof(AtlasModel.ActiveIngredientDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.QREF)).HasColumnName("QREF").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.NATOStockNO)).HasColumnName("NATOSTOCKNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.SPTSActiveIngredientID)).HasColumnName("SPTSACTIVEINGREDIENTID");
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.MaxDose)).HasColumnName("MAXDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ActiveIngredientDefinition.MaxDoseUnitRef)).HasColumnName("MAXDOSEUNIT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}