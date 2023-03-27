using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserTemplateConfig : IEntityTypeConfiguration<AtlasModel.UserTemplate>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserTemplate> builder)
        {
            builder.ToTable("USERTEMPLATE");
            builder.HasKey(nameof(AtlasModel.UserTemplate.ObjectId));
            builder.Property(nameof(AtlasModel.UserTemplate.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserTemplate.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.UserTemplate.TAObjectID)).HasColumnName("TAOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserTemplate.TAObjectDefID)).HasColumnName("TAOBJECTDEFID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserTemplate.FiliterData)).HasColumnName("FILITERDATA");
            builder.Property(nameof(AtlasModel.UserTemplate.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.UserTemplate>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}