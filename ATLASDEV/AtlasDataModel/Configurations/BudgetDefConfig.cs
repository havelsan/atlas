using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BudgetDefConfig : IEntityTypeConfiguration<AtlasModel.BudgetDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BudgetDef> builder)
        {
            builder.ToTable("BUDGETDEF");
            builder.HasKey(nameof(AtlasModel.BudgetDef.ObjectId));
            builder.Property(nameof(AtlasModel.BudgetDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BudgetDef.Definition)).HasColumnName("DEFINITION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.BudgetDef.Code1)).HasColumnName("CODE1").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.BudgetDef.Code2)).HasColumnName("CODE2").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.BudgetDef.Code3)).HasColumnName("CODE3").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.BudgetDef.Code4)).HasColumnName("CODE4").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.BudgetDef.BudgetItemType)).HasColumnName("BUDGETITEMTYPE").HasColumnType("NUMBER(10)");
        }
    }
}