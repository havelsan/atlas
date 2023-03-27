using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysiotherapyReportsConfig : IEntityTypeConfiguration<AtlasModel.PhysiotherapyReports>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysiotherapyReports> builder)
        {
            builder.ToTable("PHYSIOTHERAPYREPORTS");
            builder.HasKey(nameof(AtlasModel.PhysiotherapyReports.ObjectId));
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.LocalReportId)).HasColumnName("LOCALREPORTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.PackageProcedureInfo)).HasColumnName("PACKAGEPROCEDUREINFO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.TreatmentProcessType)).HasColumnName("TREATMENTPROCESSTYPE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.SessionLimit)).HasColumnName("SESSIONLIMIT");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportType)).HasColumnName("REPORTTYPE");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportInfo)).HasColumnName("REPORTINFO");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportTime)).HasColumnName("REPORTTIME");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportEndDate)).HasColumnName("REPORTENDDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportStartDate)).HasColumnName("REPORTSTARTDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.TreatmentType)).HasColumnName("TREATMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.DiagnosisGroup)).HasColumnName("DIAGNOSISGROUP");
            builder.Property(nameof(AtlasModel.PhysiotherapyReports.ReportDate)).HasColumnName("REPORTDATE");
        }
    }
}