using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StatusNotificationReportConfig : IEntityTypeConfiguration<AtlasModel.StatusNotificationReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StatusNotificationReport> builder)
        {
            builder.ToTable("STATUSNOTIFICATIONREPORT");
            builder.HasKey(nameof(AtlasModel.StatusNotificationReport.ObjectId));
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ReportDescription)).HasColumnName("REPORTDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ReportDuration)).HasColumnName("REPORTDURATION");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ReportDurationType)).HasColumnName("REPORTDURATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.DiagnosisDetail)).HasColumnName("DIAGNOSISDETAIL").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.StatusNotificationReport.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ReportDecision)).HasColumnName("REPORTDECISION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StatusNotificationReport.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.CommitteeReport)).HasColumnName("COMMITTEEREPORT");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ExaminationDate)).HasColumnName("EXAMINATIONDATE");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.Appropriate)).HasColumnName("APPROPRIATE");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.InAppropriate)).HasColumnName("INAPPROPRIATE");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ReportReason)).HasColumnName("REPORTREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StatusNotificationReport.HCRequestReasonRef)).HasColumnName("HCREQUESTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StatusNotificationReport.SecondDoctorRef)).HasColumnName("SECONDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StatusNotificationReport.ThirdDoctorRef)).HasColumnName("THIRDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.HCRequestReason).WithOne().HasForeignKey<AtlasModel.StatusNotificationReport>(x => x.HCRequestReasonRef).IsRequired(false);
            builder.HasOne(t => t.SecondDoctor).WithOne().HasForeignKey<AtlasModel.StatusNotificationReport>(x => x.SecondDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ThirdDoctor).WithOne().HasForeignKey<AtlasModel.StatusNotificationReport>(x => x.ThirdDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}