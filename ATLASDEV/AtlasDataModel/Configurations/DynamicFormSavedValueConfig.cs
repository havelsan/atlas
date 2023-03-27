using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormSavedValueConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormSavedValue>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormSavedValue> builder)
        {
            builder.ToTable("DYNAMICFORMSAVEDVALUE");
            builder.HasKey(nameof(AtlasModel.DynamicFormSavedValue.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.Value)).HasColumnName("VALUE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.RelatedObjectID)).HasColumnName("RELATEDOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.FormFieldIDRef)).HasColumnName("FORMFIELDID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.DynamicFormIDRef)).HasColumnName("DYNAMICFORMID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.DynamicFormRevisionIDRef)).HasColumnName("DYNAMICFORMREVISIONID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.DynamicFormSubmissionRef)).HasColumnName("DYNAMICFORMSUBMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedValue.DynamicFormRevisionFieldIDRef)).HasColumnName("DYNAMICFORMREVISIONFIELDID").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.FormFieldID).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedValue>(x => x.FormFieldIDRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormID).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedValue>(x => x.DynamicFormIDRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormRevisionID).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedValue>(x => x.DynamicFormRevisionIDRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormSubmission).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedValue>(x => x.DynamicFormSubmissionRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormRevisionFieldID).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedValue>(x => x.DynamicFormRevisionFieldIDRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}