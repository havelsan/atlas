using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FormFieldConfig : IEntityTypeConfiguration<AtlasModel.FormField>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FormField> builder)
        {
            builder.ToTable("FORMFIELD");
            builder.HasKey(nameof(AtlasModel.FormField.ObjectId));
            builder.Property(nameof(AtlasModel.FormField.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FormField.Label)).HasColumnName("LABEL").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.FormField.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.FormField.DynamicFormIDRef)).HasColumnName("DYNAMICFORMID").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicFormID).WithOne().HasForeignKey<AtlasModel.FormField>(x => x.DynamicFormIDRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}