using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AppointmentConfig : IEntityTypeConfiguration<AtlasModel.Appointment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Appointment> builder)
        {
            builder.ToTable("APPOINTMENT");
            builder.HasKey(nameof(AtlasModel.Appointment.ObjectId));
            builder.Property(nameof(AtlasModel.Appointment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Appointment.StateID)).HasColumnName("STATEID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Appointment.AppointmentID)).HasColumnName("APPOINTMENTID");
            builder.Property(nameof(AtlasModel.Appointment.Notes)).HasColumnName("NOTES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Appointment.EndTime)).HasColumnName("ENDTIME");
            builder.Property(nameof(AtlasModel.Appointment.StartTime)).HasColumnName("STARTTIME");
            builder.Property(nameof(AtlasModel.Appointment.AppDate)).HasColumnName("APPDATE");
            builder.Property(nameof(AtlasModel.Appointment.BreakAppointment)).HasColumnName("BREAKAPPOINTMENT");
            builder.Property(nameof(AtlasModel.Appointment.AppointmentType)).HasColumnName("APPOINTMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Appointment.GivingType)).HasColumnName("GIVINGTYPE");
            builder.Property(nameof(AtlasModel.Appointment.IsNumarator)).HasColumnName("ISNUMARATOR");
            builder.Property(nameof(AtlasModel.Appointment.MHRSRandevuHrn)).HasColumnName("MHRSRANDEVUHRN").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Appointment.IsCancelledByMHRSIstisna)).HasColumnName("ISCANCELLEDBYMHRSISTISNA");
            builder.Property(nameof(AtlasModel.Appointment.AppointmentUpdate)).HasColumnName("APPOINTMENTUPDATE");
            builder.Property(nameof(AtlasModel.Appointment.MHRSHastaGeldi)).HasColumnName("MHRSHASTAGELDI");
            builder.Property(nameof(AtlasModel.Appointment.CancelledMHRS)).HasColumnName("CANCELLEDMHRS");
            builder.Property(nameof(AtlasModel.Appointment.AppViewerState)).HasColumnName("APPVIEWERSTATE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.Appointment.InitialObjectID)).HasColumnName("INITIALOBJECTID");
            builder.Property(nameof(AtlasModel.Appointment.ExternalAppointmentID)).HasColumnName("EXTERNALAPPOINTMENTID");
            builder.Property(nameof(AtlasModel.Appointment.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.AppointmentDefinitionRef)).HasColumnName("APPOINTMENTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.AppointmentCarrierRef)).HasColumnName("APPOINTMENTCARRIER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.ActionRef)).HasColumnName("ACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.MasterResourceRef)).HasColumnName("MASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.MasterAppointmentsRef)).HasColumnName("MASTERAPPOINTMENTS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.ScheduleRef)).HasColumnName("SCHEDULE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.GivenByRef)).HasColumnName("GIVENBY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Appointment.ResEquipmentAppointmentRef)).HasColumnName("RESEQUIPMENTAPPOINTMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.SubActionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.AppointmentDefinition).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.AppointmentDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.AppointmentCarrier).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.AppointmentCarrierRef).IsRequired(false);
            builder.HasOne(t => t.Action).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.ActionRef).IsRequired(false);
            builder.HasOne(t => t.MasterResource).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.MasterResourceRef).IsRequired(false);
            builder.HasOne(t => t.MasterAppointments).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.MasterAppointmentsRef).IsRequired(false);
            builder.HasOne(t => t.Schedule).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.ScheduleRef).IsRequired(false);
            builder.HasOne(t => t.GivenBy).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.GivenByRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.PatientRef).IsRequired(false);
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.ResourceRef).IsRequired(true);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.Appointment>(x => x.EpisodeActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}