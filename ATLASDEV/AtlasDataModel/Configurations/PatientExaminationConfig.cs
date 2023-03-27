using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientExaminationConfig : IEntityTypeConfiguration<AtlasModel.PatientExamination>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientExamination> builder)
        {
            builder.ToTable("PATIENTEXAMINATION");
            builder.HasKey(nameof(AtlasModel.PatientExamination.ObjectId));
            builder.Property(nameof(AtlasModel.PatientExamination.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientExamination.IsObservationTaken)).HasColumnName("ISOBSERVATIONTAKEN");
            builder.Property(nameof(AtlasModel.PatientExamination.IsReportMHRSGreenList)).HasColumnName("ISREPORTMHRSGREENLIST");
            builder.Property(nameof(AtlasModel.PatientExamination.ReportedMHRSGreenList)).HasColumnName("REPORTEDMHRSGREENLIST");
            builder.Property(nameof(AtlasModel.PatientExamination.IsApproveMHRSGreenList)).HasColumnName("ISAPPROVEMHRSGREENLIST");
            builder.Property(nameof(AtlasModel.PatientExamination.ApprovedMHRSGreenList)).HasColumnName("APPROVEDMHRSGREENLIST");
            builder.Property(nameof(AtlasModel.PatientExamination.MTSDischargeType)).HasColumnName("MTSDISCHARGETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientExamination.MTSDischargeToPlace)).HasColumnName("MTSDISCHARGETOPLACE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientExamination.MedulaESevkNo)).HasColumnName("MEDULAESEVKNO");
            builder.Property(nameof(AtlasModel.PatientExamination.MedulaMutatDisiAracRaporNo)).HasColumnName("MEDULAMUTATDISIARACRAPORNO");
            builder.Property(nameof(AtlasModel.PatientExamination.MutatDisiAracRaporTarihi)).HasColumnName("MUTATDISIARACRAPORTARIHI");
            builder.Property(nameof(AtlasModel.PatientExamination.MutatDisiAracBaslangicTarihi)).HasColumnName("MUTATDISIARACBASLANGICTARIHI");
            builder.Property(nameof(AtlasModel.PatientExamination.MutatDisiAracBitisTarihi)).HasColumnName("MUTATDISIARACBITISTARIHI");
            builder.Property(nameof(AtlasModel.PatientExamination.MutatDisiGerekcesi)).HasColumnName("MUTATDISIGEREKCESI");
            builder.Property(nameof(AtlasModel.PatientExamination.MedulaRefakatciGerekcesi)).HasColumnName("MEDULAREFAKATCIGEREKCESI");
            builder.Property(nameof(AtlasModel.PatientExamination.MedulaRefakatciDurumu)).HasColumnName("MEDULAREFAKATCIDURUMU");
            builder.Property(nameof(AtlasModel.PatientExamination.MutatDisiAracRaporId)).HasColumnName("MUTATDISIARACRAPORID");
            builder.Property(nameof(AtlasModel.PatientExamination.PatientExaminationType)).HasColumnName("PATIENTEXAMINATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientExamination.TreatmentResultRef)).HasColumnName("TREATMENTRESULT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.MuayeneGirisRef)).HasColumnName("MUAYENEGIRIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.MedulaSevkDonusVasitasiRef)).HasColumnName("MEDULASEVKDONUSVASITASI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.MTSHospitalSendingToRef)).HasColumnName("MTSHOSPITALSENDINGTO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.DispatchedSpecialityRef)).HasColumnName("DISPATCHEDSPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.EmergencyInterventionRef)).HasColumnName("EMERGENCYINTERVENTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExamination.HCExaminationComponentRef)).HasColumnName("HCEXAMINATIONCOMPONENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MTSHospitalSendingTo).WithOne().HasForeignKey<AtlasModel.PatientExamination>(x => x.MTSHospitalSendingToRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.PatientExamination>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.EmergencyIntervention).WithOne().HasForeignKey<AtlasModel.PatientExamination>(x => x.EmergencyInterventionRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.PatientExamination>(x => x.ResponsibleDoctorRef).IsRequired(false);
            builder.HasOne(t => t.HCExaminationComponent).WithOne().HasForeignKey<AtlasModel.PatientExamination>(x => x.HCExaminationComponentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}