using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UTSNotificationDetailConfig : IEntityTypeConfiguration<AtlasModel.UTSNotificationDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UTSNotificationDetail> builder)
        {
            builder.ToTable("UTSNOTIFICATIONDETAIL");
            builder.HasKey(nameof(AtlasModel.UTSNotificationDetail.ObjectId));
            builder.Property(nameof(AtlasModel.UTSNotificationDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UTSNotificationDetail.Amount)).HasColumnName("AMOUNT");
            builder.Property(nameof(AtlasModel.UTSNotificationDetail.NotificationID)).HasColumnName("NOTIFICATIONID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.UTSNotificationDetail.NotificationType)).HasColumnName("NOTIFICATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UTSNotificationDetail.NotificationDate)).HasColumnName("NOTIFICATIONDATE");
            builder.Property(nameof(AtlasModel.UTSNotificationDetail.StockTransactionRef)).HasColumnName("STOCKTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockTransaction).WithOne().HasForeignKey<AtlasModel.UTSNotificationDetail>(x => x.StockTransactionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}