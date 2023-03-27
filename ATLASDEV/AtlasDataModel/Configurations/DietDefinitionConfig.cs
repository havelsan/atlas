using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DietDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DietDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DietDefinition> builder)
        {
            builder.ToTable("DIETDEFINITION");
            builder.HasKey(nameof(AtlasModel.DietDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DietDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DietDefinition.Breakfast)).HasColumnName("BREAKFAST");
            builder.Property(nameof(AtlasModel.DietDefinition.Lunch)).HasColumnName("LUNCH");
            builder.Property(nameof(AtlasModel.DietDefinition.Dinner)).HasColumnName("DINNER");
            builder.Property(nameof(AtlasModel.DietDefinition.Snack2)).HasColumnName("SNACK2");
            builder.Property(nameof(AtlasModel.DietDefinition.NightBreakfast)).HasColumnName("NIGHTBREAKFAST");
            builder.Property(nameof(AtlasModel.DietDefinition.Snack1)).HasColumnName("SNACK1");
            builder.Property(nameof(AtlasModel.DietDefinition.Snack3)).HasColumnName("SNACK3");
            builder.Property(nameof(AtlasModel.DietDefinition.PatientType)).HasColumnName("PATIENTTYPE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}