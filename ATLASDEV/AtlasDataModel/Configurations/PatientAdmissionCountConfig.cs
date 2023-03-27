using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientAdmissionCountConfig : IEntityTypeConfiguration<AtlasModel.PatientAdmissionCount>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientAdmissionCount> builder)
        {
            builder.ToTable("PACOUNTBYUSER");
            builder.HasKey(nameof(AtlasModel.PatientAdmissionCount.ObjectId));
            builder.Property(nameof(AtlasModel.PatientAdmissionCount.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientAdmissionCount.Counter)).HasColumnName("COUNTER");
            builder.Property(nameof(AtlasModel.PatientAdmissionCount.PatientAdmissionDate)).HasColumnName("PATIENTADMISSIONDATE");
            builder.Property(nameof(AtlasModel.PatientAdmissionCount.PoliclinicRef)).HasColumnName("POLICLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmissionCount.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Policlinic).WithOne().HasForeignKey<AtlasModel.PatientAdmissionCount>(x => x.PoliclinicRef).IsRequired(false);
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.PatientAdmissionCount>(x => x.DoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}