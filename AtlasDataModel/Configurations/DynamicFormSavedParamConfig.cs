using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormSavedParamConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormSavedParam>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormSavedParam> builder)
        {
            builder.ToTable("DYNAMICFORMSAVEDPARAM");
            builder.HasKey(nameof(AtlasModel.DynamicFormSavedParam.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormSavedParam.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormSavedParam.Value)).HasColumnName("VALUE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DynamicFormSavedParam.DynamicFormRevisionParamRef)).HasColumnName("DYNAMICFORMREVISIONPARAM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSavedParam.DynamicFormSubmissionRef)).HasColumnName("DYNAMICFORMSUBMISSION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicFormRevisionParam).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedParam>(x => x.DynamicFormRevisionParamRef).IsRequired(false);
            builder.HasOne(t => t.DynamicFormSubmission).WithOne().HasForeignKey<AtlasModel.DynamicFormSavedParam>(x => x.DynamicFormSubmissionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}