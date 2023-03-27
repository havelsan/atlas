using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormRevisionConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormRevision>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormRevision> builder)
        {
            builder.ToTable("DYNAMICFORMREVISION");
            builder.HasKey(nameof(AtlasModel.DynamicFormRevision.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormRevision.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormRevision.Comment)).HasColumnName("COMMENT").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.DynamicFormRevision.RevisionNumber)).HasColumnName("REVISIONNUMBER");
            builder.Property(nameof(AtlasModel.DynamicFormRevision.IsMain)).HasColumnName("ISMAIN");
            builder.Property(nameof(AtlasModel.DynamicFormRevision.JsonTemplate)).HasColumnName("JSONTEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormRevision.UpdateDate)).HasColumnName("UPDATEDATE");
            builder.Property(nameof(AtlasModel.DynamicFormRevision.DynamicFormIdRef)).HasColumnName("DYNAMICFORMID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormRevision.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicFormId).WithOne().HasForeignKey<AtlasModel.DynamicFormRevision>(x => x.DynamicFormIdRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.DynamicFormRevision>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}