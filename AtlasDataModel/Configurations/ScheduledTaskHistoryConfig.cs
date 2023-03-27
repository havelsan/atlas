using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ScheduledTaskHistoryConfig : IEntityTypeConfiguration<AtlasModel.ScheduledTaskHistory>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ScheduledTaskHistory> builder)
        {
            builder.ToTable("SCHEDULEDTASKHISTORY");
            builder.HasKey(nameof(AtlasModel.ScheduledTaskHistory.ObjectId));
            builder.Property(nameof(AtlasModel.ScheduledTaskHistory.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ScheduledTaskHistory.Log)).HasColumnName("LOG").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.ScheduledTaskHistory.LogDate)).HasColumnName("LOGDATE");
            builder.Property(nameof(AtlasModel.ScheduledTaskHistory.BaseScheduledTaskRef)).HasColumnName("BASESCHEDULEDTASK").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.ScheduledTaskHistory>(x => x.BaseScheduledTaskRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}