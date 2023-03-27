using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedulaTreatmentReportConfig : IEntityTypeConfiguration<AtlasModel.MedulaTreatmentReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedulaTreatmentReport> builder)
        {
            builder.ToTable("MEDULATREATMENTREPORT");
            builder.HasKey(nameof(AtlasModel.MedulaTreatmentReport.ObjectId));
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.RaporTakipNo)).HasColumnName("RAPORTAKIPNO");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.SonucAciklamasi)).HasColumnName("SONUCACIKLAMASI").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.RaporGonderimTarihi)).HasColumnName("RAPORGONDERIMTARIHI");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.SonucKodu)).HasColumnName("SONUCKODU");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.TedaviRaporTuru)).HasColumnName("TEDAVIRAPORTURU").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.RaporGidenXML)).HasColumnName("RAPORGIDENXML").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.RaporGelenXML)).HasColumnName("RAPORGELENXML").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.PatientObjectID)).HasColumnName("PATIENTOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.SEPObjectID)).HasColumnName("SEPOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.ReportNo)).HasColumnName("REPORTNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.Duration)).HasColumnName("DURATION");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.DurationType)).HasColumnName("DURATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.CommitteeReport)).HasColumnName("COMMITTEEREPORT");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.IsSendedMedula)).HasColumnName("ISSENDEDMEDULA");
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.SecondDoctorRef)).HasColumnName("SECONDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.FTRReportRef)).HasColumnName("FTRREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.ESWTReportRef)).HasColumnName("ESWTREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.ESWLReportRef)).HasColumnName("ESWLREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.HBTReportRef)).HasColumnName("HBTREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.DialysisReportRef)).HasColumnName("DIALYSISREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.HomeHemodialysisReportRef)).HasColumnName("HOMEHEMODIALYSISREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaTreatmentReport.TubeBabyReportRef)).HasColumnName("TUBEBABYREPORT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SecondDoctor).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.SecondDoctorRef).IsRequired(false);
            builder.HasOne(t => t.FTRReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.FTRReportRef).IsRequired(false);
            builder.HasOne(t => t.ESWTReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.ESWTReportRef).IsRequired(false);
            builder.HasOne(t => t.ESWLReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.ESWLReportRef).IsRequired(false);
            builder.HasOne(t => t.HBTReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.HBTReportRef).IsRequired(false);
            builder.HasOne(t => t.DialysisReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.DialysisReportRef).IsRequired(false);
            builder.HasOne(t => t.HomeHemodialysisReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.HomeHemodialysisReportRef).IsRequired(false);
            builder.HasOne(t => t.TubeBabyReport).WithOne().HasForeignKey<AtlasModel.MedulaTreatmentReport>(x => x.TubeBabyReportRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}