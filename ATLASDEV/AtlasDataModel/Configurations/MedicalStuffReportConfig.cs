using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalStuffReportConfig : IEntityTypeConfiguration<AtlasModel.MedicalStuffReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalStuffReport> builder)
        {
            builder.ToTable("MEDICALSTUFFREPORT");
            builder.HasKey(nameof(AtlasModel.MedicalStuffReport.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalStuffReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalStuffReport.Duration)).HasColumnName("DURATION");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.DurationType)).HasColumnName("DURATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.CommitteeReport)).HasColumnName("COMMITTEEREPORT");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.MedulaDescription)).HasColumnName("MEDULADESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.MedicalStuffReport.RaporGonderimTarihi)).HasColumnName("RAPORGONDERIMTARIHI");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.RaporTakipNo)).HasColumnName("RAPORTAKIPNO");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.IsSendedMedula)).HasColumnName("ISSENDEDMEDULA");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.RaporGelenXML)).HasColumnName("RAPORGELENXML").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.RaporGidenXML)).HasColumnName("RAPORGIDENXML").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuffReport.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.ReportDecision)).HasColumnName("REPORTDECISION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuffReport.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.DiagnosisDetail)).HasColumnName("DIAGNOSISDETAIL").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.MedicalStuffReport.SignedData)).HasColumnName("SIGNEDDATA").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuffReport.IsSecondDoctorApproved)).HasColumnName("ISSECONDDOCTORAPPROVED");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.IsThirdDoctorApproved)).HasColumnName("ISTHIRDDOCTORAPPROVED");
            builder.Property(nameof(AtlasModel.MedicalStuffReport.MedicalStuffDefRef)).HasColumnName("MEDICALSTUFFDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuffReport.SecondDoctorRef)).HasColumnName("SECONDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuffReport.ThirdDoctorRef)).HasColumnName("THIRDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MedicalStuffDef).WithOne().HasForeignKey<AtlasModel.MedicalStuffReport>(x => x.MedicalStuffDefRef).IsRequired(false);
            builder.HasOne(t => t.SecondDoctor).WithOne().HasForeignKey<AtlasModel.MedicalStuffReport>(x => x.SecondDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ThirdDoctor).WithOne().HasForeignKey<AtlasModel.MedicalStuffReport>(x => x.ThirdDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}