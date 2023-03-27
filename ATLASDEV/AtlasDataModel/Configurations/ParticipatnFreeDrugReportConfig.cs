using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ParticipatnFreeDrugReportConfig : IEntityTypeConfiguration<AtlasModel.ParticipatnFreeDrugReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ParticipatnFreeDrugReport> builder)
        {
            builder.ToTable("PARTICIPATNFREEDRUGREPORT");
            builder.HasKey(nameof(AtlasModel.ParticipatnFreeDrugReport.ObjectId));
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.itno)).HasColumnName("ITNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.PatientApprovalFormNo)).HasColumnName("PATIENTAPPROVALFORMNO");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.HeadDoctorApproval)).HasColumnName("HEADDOCTORAPPROVAL");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.MedulaPassword)).HasColumnName("MEDULAPASSWORD").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.IsRepeated)).HasColumnName("ISREPEATED");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.SecondDoctorApproval)).HasColumnName("SECONDDOCTORAPPROVAL");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ThirdDoctorApproval)).HasColumnName("THIRDDOCTORAPPROVAL");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ReportApprovalType)).HasColumnName("REPORTAPPROVALTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.CommitteeReport)).HasColumnName("COMMITTEEREPORT");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ReportStartDate)).HasColumnName("REPORTSTARTDATE");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ExaminationDate)).HasColumnName("EXAMINATIONDATE");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ExamptionProtocolNo)).HasColumnName("EXAMPTIONPROTOCOLNO");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.SocialInsurance)).HasColumnName("SOCIALINSURANCE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.Disease)).HasColumnName("DISEASE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.PatientEnterprise)).HasColumnName("PATIENTENTERPRISE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.Duration1)).HasColumnName("DURATION1").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.TestsAndSigns)).HasColumnName("TESTSANDSIGNS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ReportEndDate)).HasColumnName("REPORTENDDATE");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ProtocolNumber)).HasColumnName("PROTOCOLNUMBER").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ReportDuration)).HasColumnName("REPORTDURATION");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ReportDurationType)).HasColumnName("REPORTDURATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.IsSecondDoctorApproved)).HasColumnName("ISSECONDDOCTORAPPROVED");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.IsThirdDoctorApproved)).HasColumnName("ISTHIRDDOCTORAPPROVED");
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.SecondDoctorRef)).HasColumnName("SECONDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ThirdDoctorRef)).HasColumnName("THIRDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmpltRef)).HasColumnName("PARTICIPNTFREEDRUGREPORTTMPLT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SecondDoctor).WithOne().HasForeignKey<AtlasModel.ParticipatnFreeDrugReport>(x => x.SecondDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ThirdDoctor).WithOne().HasForeignKey<AtlasModel.ParticipatnFreeDrugReport>(x => x.ThirdDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}