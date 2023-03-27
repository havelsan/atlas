using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NotificationUserConfig : IEntityTypeConfiguration<AtlasModel.NotificationUser>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NotificationUser> builder)
        {
            builder.ToTable("NOTIFICATIONUSER");
            builder.HasKey(nameof(AtlasModel.NotificationUser.ObjectId));
            builder.Property(nameof(AtlasModel.NotificationUser.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NotificationUser.IsRead)).HasColumnName("ISREAD");
            builder.Property(nameof(AtlasModel.NotificationUser.ReadTime)).HasColumnName("READTIME");
            builder.Property(nameof(AtlasModel.NotificationUser.NotificationRef)).HasColumnName("NOTIFICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NotificationUser.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Notification).WithOne().HasForeignKey<AtlasModel.NotificationUser>(x => x.NotificationRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.NotificationUser>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}