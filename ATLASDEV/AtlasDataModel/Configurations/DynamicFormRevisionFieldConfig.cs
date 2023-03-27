using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormRevisionFieldConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormRevisionField>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormRevisionField> builder)
        {
            builder.ToTable("DYNAMICFORMREVISIONFIELD");
            builder.HasKey(nameof(AtlasModel.DynamicFormRevisionField.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormRevisionField.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormRevisionField.FormFieldIDRef)).HasColumnName("FORMFIELDID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormRevisionField.DynamicFormRevisionIDRef)).HasColumnName("DYNAMICFORMREVISIONID").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.FormFieldID).WithOne().HasForeignKey<AtlasModel.DynamicFormRevisionField>(x => x.FormFieldIDRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormRevisionID).WithOne().HasForeignKey<AtlasModel.DynamicFormRevisionField>(x => x.DynamicFormRevisionIDRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}