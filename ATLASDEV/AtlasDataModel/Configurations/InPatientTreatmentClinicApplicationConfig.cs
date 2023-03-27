using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InPatientTreatmentClinicApplicationConfig : IEntityTypeConfiguration<AtlasModel.InPatientTreatmentClinicApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InPatientTreatmentClinicApplication> builder)
        {
            builder.ToTable("INPATIENTTREATCLINICAPP");
            builder.HasKey(nameof(AtlasModel.InPatientTreatmentClinicApplication.ObjectId));
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.ClinicDischargeDate)).HasColumnName("CLINICDISCHARGEDATE");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.ClinicInpatientDate)).HasColumnName("CLINICINPATIENTDATE");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.MedulaHastaCikisKayitFailed)).HasColumnName("MEDULAHASTACIKISKAYITFAILED");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.IsDailyOperation)).HasColumnName("ISDAILYOPERATION");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.ShotInpatientReason)).HasColumnName("SHOTINPATIENTREASON").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.InpatientAcceptionType)).HasColumnName("INPATIENTACCEPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.LongInpatientReason)).HasColumnName("LONGINPATIENTREASON").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.ResponsibleNurseRef)).HasColumnName("RESPONSIBLENURSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.BaseInpatientAdmissionRef)).HasColumnName("BASEINPATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.TreatmentDischargeRef)).HasColumnName("TREATMENTDISCHARGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientTreatmentClinicApplication.FromInPatientTrtmentClinicAppRef)).HasColumnName("FROMINPATIENTTRTMENTCLINICAPP").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ResponsibleNurse).WithOne().HasForeignKey<AtlasModel.InPatientTreatmentClinicApplication>(x => x.ResponsibleNurseRef).IsRequired(false);
            builder.HasOne(t => t.BaseInpatientAdmission).WithOne().HasForeignKey<AtlasModel.InPatientTreatmentClinicApplication>(x => x.BaseInpatientAdmissionRef).IsRequired(false);
            builder.HasOne(t => t.TreatmentDischarge).WithOne().HasForeignKey<AtlasModel.InPatientTreatmentClinicApplication>(x => x.TreatmentDischargeRef).IsRequired(false);
            builder.HasOne(t => t.FromInPatientTrtmentClinicApp).WithOne().HasForeignKey<AtlasModel.InPatientTreatmentClinicApplication>(x => x.FromInPatientTrtmentClinicAppRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}