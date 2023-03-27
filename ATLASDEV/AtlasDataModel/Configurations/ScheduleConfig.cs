using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ScheduleConfig : IEntityTypeConfiguration<AtlasModel.Schedule>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Schedule> builder)
        {
            builder.ToTable("SCHEDULE");
            builder.HasKey(nameof(AtlasModel.Schedule.ObjectId));
            builder.Property(nameof(AtlasModel.Schedule.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Schedule.Duration)).HasColumnName("DURATION");
            builder.Property(nameof(AtlasModel.Schedule.ScheduleType)).HasColumnName("SCHEDULETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Schedule.Notes)).HasColumnName("NOTES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Schedule.RecurrenceID)).HasColumnName("RECURRENCEID").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Schedule.CountLimit)).HasColumnName("COUNTLIMIT");
            builder.Property(nameof(AtlasModel.Schedule.IsWorkHour)).HasColumnName("ISWORKHOUR");
            builder.Property(nameof(AtlasModel.Schedule.EndTime)).HasColumnName("ENDTIME");
            builder.Property(nameof(AtlasModel.Schedule.ScheduleDate)).HasColumnName("SCHEDULEDATE");
            builder.Property(nameof(AtlasModel.Schedule.StartTime)).HasColumnName("STARTTIME");
            builder.Property(nameof(AtlasModel.Schedule.MHRSTaslakCetvelID)).HasColumnName("MHRSTASLAKCETVELID");
            builder.Property(nameof(AtlasModel.Schedule.MHRSKesinCetvelID)).HasColumnName("MHRSKESINCETVELID");
            builder.Property(nameof(AtlasModel.Schedule.SentToMHRS)).HasColumnName("SENTTOMHRS");
            builder.Property(nameof(AtlasModel.Schedule.MHRSIstisnaID)).HasColumnName("MHRSISTISNAID");
            builder.Property(nameof(AtlasModel.Schedule.MHRSScheduleType)).HasColumnName("MHRSSCHEDULETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Schedule.ErrorOfMHRSApprove)).HasColumnName("ERROROFMHRSAPPROVE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Schedule.MasterScheduleRef)).HasColumnName("MASTERSCHEDULE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Schedule.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Schedule.AppointmentDefinitionRef)).HasColumnName("APPOINTMENTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Schedule.MasterResourceRef)).HasColumnName("MASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Schedule.MHRSActionTypeDefinitionRef)).HasColumnName("MHRSACTIONTYPEDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MasterSchedule).WithOne().HasForeignKey<AtlasModel.Schedule>(x => x.MasterScheduleRef).IsRequired(false);
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.Schedule>(x => x.ResourceRef).IsRequired(false);
            builder.HasOne(t => t.AppointmentDefinition).WithOne().HasForeignKey<AtlasModel.Schedule>(x => x.AppointmentDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.MasterResource).WithOne().HasForeignKey<AtlasModel.Schedule>(x => x.MasterResourceRef).IsRequired(false);
            builder.HasOne(t => t.MHRSActionTypeDefinition).WithOne().HasForeignKey<AtlasModel.Schedule>(x => x.MHRSActionTypeDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}