using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientResponsibleDoctorConfig : IEntityTypeConfiguration<AtlasModel.InpatientResponsibleDoctor>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientResponsibleDoctor> builder)
        {
            builder.ToTable("INPATIENTRESPONSIBLEDOCTOR");
            builder.HasKey(nameof(AtlasModel.InpatientResponsibleDoctor.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientResponsibleDoctor.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InpatientResponsibleDoctor.SDateTime)).HasColumnName("SDATETIME");
            builder.Property(nameof(AtlasModel.InpatientResponsibleDoctor.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientResponsibleDoctor.InPatientTreatmentClinicAppRef)).HasColumnName("INPATIENTTREATMENTCLINICAPP").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.InpatientResponsibleDoctor>(x => x.DoctorRef).IsRequired(false);
            builder.HasOne(t => t.InPatientTreatmentClinicApp).WithOne().HasForeignKey<AtlasModel.InpatientResponsibleDoctor>(x => x.InPatientTreatmentClinicAppRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}