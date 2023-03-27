using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseScheduledTaskConfig : IEntityTypeConfiguration<AtlasModel.BaseScheduledTask>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseScheduledTask> builder)
        {
            builder.ToTable("BASESCHEDULEDTASK");
            builder.HasKey(nameof(AtlasModel.BaseScheduledTask.ObjectId));
            builder.Property(nameof(AtlasModel.BaseScheduledTask.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseScheduledTask.WorkHour)).HasColumnName("WORKHOUR");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.Recurrency)).HasColumnName("RECURRENCY");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.LastExecutionDate)).HasColumnName("LASTEXECUTIONDATE");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.NoEndDate)).HasColumnName("NOENDDATE");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.TaskName)).HasColumnName("TASKNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.BaseScheduledTask.Period)).HasColumnName("PERIOD").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.ExecutionCount)).HasColumnName("EXECUTIONCOUNT");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.CronExpression)).HasColumnName("CRONEXPRESSION");
            builder.Property(nameof(AtlasModel.BaseScheduledTask.WorkMinute)).HasColumnName("WORKMINUTE");
        }
    }
}