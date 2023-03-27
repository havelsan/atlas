using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MaterialTreeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MaterialTreeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MaterialTreeDefinition> builder)
        {
            builder.ToTable("MATERIALTREEDEFINITION");
            builder.HasKey(nameof(AtlasModel.MaterialTreeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MaterialTreeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MaterialTreeDefinition.IsGroup)).HasColumnName("ISGROUP");
            builder.Property(nameof(AtlasModel.MaterialTreeDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MaterialTreeDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.MaterialTreeDefinition.GroupCode)).HasColumnName("GROUPCODE");
            builder.Property(nameof(AtlasModel.MaterialTreeDefinition.ParentMaterialTreeRef)).HasColumnName("PARENTMATERIALTREE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentMaterialTree).WithOne().HasForeignKey<AtlasModel.MaterialTreeDefinition>(x => x.ParentMaterialTreeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}