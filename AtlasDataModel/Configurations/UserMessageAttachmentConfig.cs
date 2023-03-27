using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserMessageAttachmentConfig : IEntityTypeConfiguration<AtlasModel.UserMessageAttachment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserMessageAttachment> builder)
        {
            builder.ToTable("USERMESSAGEATTACHMENT");
            builder.HasKey(nameof(AtlasModel.UserMessageAttachment.ObjectId));
            builder.Property(nameof(AtlasModel.UserMessageAttachment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserMessageAttachment.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.UserMessageAttachment.Attachment)).HasColumnName("ATTACHMENT").HasMaxLength(36).IsFixedLength();
        }
    }
}