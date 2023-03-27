using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TreatmentDischargeConfig : IEntityTypeConfiguration<AtlasModel.TreatmentDischarge>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TreatmentDischarge> builder)
        {
            builder.ToTable("TREATMENTDISCHARGE");
            builder.HasKey(nameof(AtlasModel.TreatmentDischarge.ObjectId));
            builder.Property(nameof(AtlasModel.TreatmentDischarge.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TreatmentDischarge.Conclusion)).HasColumnName("CONCLUSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TreatmentDischarge.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.TreatmentDischarge.DischargeDate)).HasColumnName("DISCHARGEDATE");
            builder.Property(nameof(AtlasModel.TreatmentDischarge.DischargeTypeRef)).HasColumnName("DISCHARGETYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TreatmentDischarge.InPatientTreatmentClinicAppRef)).HasColumnName("INPATIENTTREATMENTCLINICAPP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TreatmentDischarge.DispatchedSpecialityRef)).HasColumnName("DISPATCHEDSPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TreatmentDischarge.TransferTreatmentClinicRef)).HasColumnName("TRANSFERTREATMENTCLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TreatmentDischarge.DispatchToOtherHospitalRef)).HasColumnName("DISPATCHTOOTHERHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.InPatientTreatmentClinicApp).WithOne().HasForeignKey<AtlasModel.TreatmentDischarge>(x => x.InPatientTreatmentClinicAppRef).IsRequired(false);
            builder.HasOne(t => t.TransferTreatmentClinic).WithOne().HasForeignKey<AtlasModel.TreatmentDischarge>(x => x.TransferTreatmentClinicRef).IsRequired(false);
            builder.HasOne(t => t.DispatchToOtherHospital).WithOne().HasForeignKey<AtlasModel.TreatmentDischarge>(x => x.DispatchToOtherHospitalRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}