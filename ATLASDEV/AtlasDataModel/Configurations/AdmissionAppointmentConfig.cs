using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AdmissionAppointmentConfig : IEntityTypeConfiguration<AtlasModel.AdmissionAppointment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AdmissionAppointment> builder)
        {
            builder.ToTable("ADMISSIONAPPOINTMENT");
            builder.HasKey(nameof(AtlasModel.AdmissionAppointment.ObjectId));
            builder.Property(nameof(AtlasModel.AdmissionAppointment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AdmissionAppointment.PatientName)).HasColumnName("PATIENTNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AdmissionAppointment.SelectedPatientFiltered)).HasColumnName("SELECTEDPATIENTFILTERED").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AdmissionAppointment.PatientSurname)).HasColumnName("PATIENTSURNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AdmissionAppointment.PatientUniqueRefNo)).HasColumnName("PATIENTUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.AdmissionAppointment.PatientPhone)).HasColumnName("PATIENTPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AdmissionAppointment.PhoneType)).HasColumnName("PHONETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AdmissionAppointment.NotRequiredQuota)).HasColumnName("NOTREQUIREDQUOTA");
            builder.Property(nameof(AtlasModel.AdmissionAppointment.SelectedPatientRef)).HasColumnName("SELECTEDPATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AdmissionAppointment.MasterResourceRef)).HasColumnName("MASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AdmissionAppointment.AppointmentDefinitionRef)).HasColumnName("APPOINTMENTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SelectedPatient).WithOne().HasForeignKey<AtlasModel.AdmissionAppointment>(x => x.SelectedPatientRef).IsRequired(false);
            builder.HasOne(t => t.MasterResource).WithOne().HasForeignKey<AtlasModel.AdmissionAppointment>(x => x.MasterResourceRef).IsRequired(false);
            builder.HasOne(t => t.AppointmentDefinition).WithOne().HasForeignKey<AtlasModel.AdmissionAppointment>(x => x.AppointmentDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}