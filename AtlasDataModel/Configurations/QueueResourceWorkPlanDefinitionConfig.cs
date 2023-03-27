using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class QueueResourceWorkPlanDefinitionConfig : IEntityTypeConfiguration<AtlasModel.QueueResourceWorkPlanDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.QueueResourceWorkPlanDefinition> builder)
        {
            builder.ToTable("QUEUERESOURCEWORKPLANDEF");
            builder.HasKey(nameof(AtlasModel.QueueResourceWorkPlanDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.QueueResourceWorkPlanDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.QueueResourceWorkPlanDefinition.LastCallTime)).HasColumnName("LASTCALLTIME");
            builder.Property(nameof(AtlasModel.QueueResourceWorkPlanDefinition.WorkDate)).HasColumnName("WORKDATE");
            builder.Property(nameof(AtlasModel.QueueResourceWorkPlanDefinition.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.QueueResourceWorkPlanDefinition.QueueRef)).HasColumnName("QUEUE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.QueueResourceWorkPlanDefinition.LCDNotificationRef)).HasColumnName("LCDNOTIFICATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.QueueResourceWorkPlanDefinition>(x => x.ResourceRef).IsRequired(false);
            builder.HasOne(t => t.Queue).WithOne().HasForeignKey<AtlasModel.QueueResourceWorkPlanDefinition>(x => x.QueueRef).IsRequired(false);
            builder.HasOne(t => t.LCDNotification).WithOne().HasForeignKey<AtlasModel.QueueResourceWorkPlanDefinition>(x => x.LCDNotificationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}