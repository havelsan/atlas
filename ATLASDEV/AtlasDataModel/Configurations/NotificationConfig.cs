using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NotificationConfig : IEntityTypeConfiguration<AtlasModel.Notification>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Notification> builder)
        {
            builder.ToTable("NOTIFICATION");
            builder.HasKey(nameof(AtlasModel.Notification.ObjectId));
            builder.Property(nameof(AtlasModel.Notification.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Notification.ActionData)).HasColumnName("ACTIONDATA").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.Notification.Content)).HasColumnName("CONTENT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.Notification.ContentType)).HasColumnName("CONTENTTYPE");
            builder.Property(nameof(AtlasModel.Notification.CreateTime)).HasColumnName("CREATETIME");
            builder.Property(nameof(AtlasModel.Notification.HeaderDefinition)).HasColumnName("HEADERDEFINITION");
            builder.Property(nameof(AtlasModel.Notification.SourceType)).HasColumnName("SOURCETYPE");
            builder.Property(nameof(AtlasModel.Notification.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.Notification>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}