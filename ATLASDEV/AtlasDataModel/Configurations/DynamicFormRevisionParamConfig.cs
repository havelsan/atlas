using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormRevisionParamConfig : IEntityTypeConfiguration<AtlasModel.DynamicFormRevisionParam>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicFormRevisionParam> builder)
        {
            builder.ToTable("DYNAMICFORMREVISIONPARAM");
            builder.HasKey(nameof(AtlasModel.DynamicFormRevisionParam.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicFormRevisionParam.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicFormRevisionParam.DynamicFormRevisionRef)).HasColumnName("DYNAMICFORMREVISION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicFormRevisionParam.FormParamRef)).HasColumnName("FORMPARAM").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicFormRevision).WithOne().HasForeignKey<AtlasModel.DynamicFormRevisionParam>(x => x.DynamicFormRevisionRef).IsRequired(false);
            builder.HasOne(t => t.FormParam).WithOne().HasForeignKey<AtlasModel.DynamicFormRevisionParam>(x => x.FormParamRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}