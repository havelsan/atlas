using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BudgetTypeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.BudgetTypeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BudgetTypeDefinition> builder)
        {
            builder.ToTable("BUDGETTYPEDEFINITION");
            builder.HasKey(nameof(AtlasModel.BudgetTypeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.BudgetTypeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BudgetTypeDefinition.MKYS_Butce)).HasColumnName("MKYS_BUTCE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BudgetTypeDefinition.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.BudgetTypeDefinition.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}