using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormSubmissionConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormSubmission>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormSubmission> builder)
        {
            builder.ToTable("DYNAMICFORMSUBMISSION");
            builder.HasKey(nameof(AtlasModel.DynamicFormSubmission.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormSubmission.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormSubmission.UpdateDate)).HasColumnName("UPDATEDATE");
            builder.Property(nameof(AtlasModel.DynamicFormSubmission.IsEnable)).HasColumnName("ISENABLE");
            builder.Property(nameof(AtlasModel.DynamicFormSubmission.DynamicFormRevisionRef)).HasColumnName("DYNAMICFORMREVISION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormSubmission.CreatedByRef)).HasColumnName("CREATEDBY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicFormRevision).WithOne().HasForeignKey<AtlasModel.DynamicFormSubmission>(x => x.DynamicFormRevisionRef).IsRequired(false);
            builder.HasOne(t => t.CreatedBy).WithOne().HasForeignKey<AtlasModel.DynamicFormSubmission>(x => x.CreatedByRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}