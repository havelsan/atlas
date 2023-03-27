using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TemplateGroupConfig : IEntityTypeConfiguration<AtlasModel.TemplateGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TemplateGroup> builder)
        {
            builder.ToTable("TEMPLATEGROUP");
            builder.HasKey(nameof(AtlasModel.TemplateGroup.ObjectId));
            builder.Property(nameof(AtlasModel.TemplateGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TemplateGroup.OldGroupName)).HasColumnName("OLDGROUPNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.TemplateGroup.GroupName)).HasColumnName("GROUPNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.TemplateGroup.GroupName_Shadow)).HasColumnName("GROUPNAME_SHADOW");
        }
    }
}