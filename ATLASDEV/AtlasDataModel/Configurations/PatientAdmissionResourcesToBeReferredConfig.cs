using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientAdmissionResourcesToBeReferredConfig : IEntityTypeConfiguration<AtlasModel.PatientAdmissionResourcesToBeReferred>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientAdmissionResourcesToBeReferred> builder)
        {
            builder.ToTable("PARESOURCESTOBEREFERRED");
            builder.HasKey(nameof(AtlasModel.PatientAdmissionResourcesToBeReferred.ObjectId));
            builder.Property(nameof(AtlasModel.PatientAdmissionResourcesToBeReferred.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientAdmissionResourcesToBeReferred.AdmissionQueueNumber)).HasColumnName("ADMISSIONQUEUENUMBER");
            builder.Property(nameof(AtlasModel.PatientAdmissionResourcesToBeReferred.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmissionResourcesToBeReferred.PatientAdmissionRef)).HasColumnName("PATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferredRef)).HasColumnName("PROCEDUREDOCTORTOBEREFERRED").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResourcesToBeReferredGrid).WithOne().HasForeignKey<AtlasModel.ResourcesToBeReferredGrid>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PatientAdmission).WithOne().HasForeignKey<AtlasModel.PatientAdmissionResourcesToBeReferred>(x => x.PatientAdmissionRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctorToBeReferred).WithOne().HasForeignKey<AtlasModel.PatientAdmissionResourcesToBeReferred>(x => x.ProcedureDoctorToBeReferredRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}