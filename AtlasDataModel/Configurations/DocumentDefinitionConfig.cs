using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DocumentDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DocumentDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DocumentDefinition> builder)
        {
            builder.ToTable("DOCUMENTDEFINITION");
            builder.HasKey(nameof(AtlasModel.DocumentDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DocumentDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DocumentDefinition.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.DocumentDefinition.Name)).HasColumnName("NAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DocumentDefinition.IsGroup)).HasColumnName("ISGROUP");
            builder.Property(nameof(AtlasModel.DocumentDefinition.IsMainGroup)).HasColumnName("ISMAINGROUP");
            builder.Property(nameof(AtlasModel.DocumentDefinition.File)).HasColumnName("FILE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DocumentDefinition.FileExtension)).HasColumnName("FILEEXTENSION");
            builder.Property(nameof(AtlasModel.DocumentDefinition.ParentDocumentDefinitionRef)).HasColumnName("PARENTDOCUMENTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentDocumentDefinition).WithOne().HasForeignKey<AtlasModel.DocumentDefinition>(x => x.ParentDocumentDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}