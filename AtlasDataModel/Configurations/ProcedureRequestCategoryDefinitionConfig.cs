using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureRequestCategoryDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedureRequestCategoryDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureRequestCategoryDefinition> builder)
        {
            builder.ToTable("PROCEDUREREQCATEGORYDEF");
            builder.HasKey(nameof(AtlasModel.ProcedureRequestCategoryDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureRequestCategoryDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureRequestCategoryDefinition.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.ProcedureRequestCategoryDefinition.CategoryName)).HasColumnName("CATEGORYNAME");
            builder.Property(nameof(AtlasModel.ProcedureRequestCategoryDefinition.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.ProcedureRequestCategoryDefinition.ProcedureRequestFormRef)).HasColumnName("PROCEDUREREQUESTFORM").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ProcedureRequestForm).WithOne().HasForeignKey<AtlasModel.ProcedureRequestCategoryDefinition>(x => x.ProcedureRequestFormRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}