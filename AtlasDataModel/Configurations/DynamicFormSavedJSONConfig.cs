using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormSavedJSONConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormSavedJSON>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormSavedJSON> builder)
        {
            builder.ToTable("DYNAMICFORMSAVEDJSON");
            builder.HasKey(nameof(AtlasModel.DynamicFormSavedJSON.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormSavedJSON.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormSavedJSON.Value)).HasColumnName("VALUE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedJSON.DynamicFormIDRef)).HasColumnName("DYNAMICFORMID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedJSON.DynamicFormRevisionIDRef)).HasColumnName("DYNAMICFORMREVISIONID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedJSON.DynamicFormSubmissionRef)).HasColumnName("DYNAMICFORMSUBMISSION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicFormID).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedJSON>(x => x.DynamicFormIDRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormRevisionID).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedJSON>(x => x.DynamicFormRevisionIDRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormSubmission).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedJSON>(x => x.DynamicFormSubmissionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}