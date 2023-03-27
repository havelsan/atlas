using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ScheduleAppointmentTypeConfig : IEntityTypeConfiguration<AtlasModel.ScheduleAppointmentType>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ScheduleAppointmentType> builder)
        {
            builder.ToTable("SCHEDULEAPPOINTMENTTYPE");
            builder.HasKey(nameof(AtlasModel.ScheduleAppointmentType.ObjectId));
            builder.Property(nameof(AtlasModel.ScheduleAppointmentType.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ScheduleAppointmentType.AppointmentType)).HasColumnName("APPOINTMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScheduleAppointmentType.ScheduleRef)).HasColumnName("SCHEDULE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Schedule).WithOne().HasForeignKey<AtlasModel.ScheduleAppointmentType>(x => x.ScheduleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}