using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedulaReportResultConfig : IEntityTypeConfiguration<AtlasModel.MedulaReportResult>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedulaReportResult> builder)
        {
            builder.ToTable("MEDULAREPORTRESULT");
            builder.HasKey(nameof(AtlasModel.MedulaReportResult.ObjectId));
            builder.Property(nameof(AtlasModel.MedulaReportResult.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedulaReportResult.SendReportDate)).HasColumnName("SENDREPORTDATE");
            builder.Property(nameof(AtlasModel.MedulaReportResult.ReportChasingNo)).HasColumnName("REPORTCHASINGNO");
            builder.Property(nameof(AtlasModel.MedulaReportResult.ResultCode)).HasColumnName("RESULTCODE");
            builder.Property(nameof(AtlasModel.MedulaReportResult.ResultExplanation)).HasColumnName("RESULTEXPLANATION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedulaReportResult.ReportRowNumber)).HasColumnName("REPORTROWNUMBER");
            builder.Property(nameof(AtlasModel.MedulaReportResult.ReportNumber)).HasColumnName("REPORTNUMBER");
            builder.Property(nameof(AtlasModel.MedulaReportResult.StoneBreakUpRequestRef)).HasColumnName("STONEBREAKUPREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaReportResult.PhysiotherapyOrderRef)).HasColumnName("PHYSIOTHERAPYORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaReportResult.HOTOrderRef)).HasColumnName("HOTORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaReportResult.ManipulationRef)).HasColumnName("MANIPULATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaReportResult.DialysisOrderRef)).HasColumnName("DIALYSISORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedulaReportResult.ParticipatnFreeDrugReportRef)).HasColumnName("PARTICIPATNFREEDRUGREPORT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PhysiotherapyOrder).WithOne().HasForeignKey<AtlasModel.MedulaReportResult>(x => x.PhysiotherapyOrderRef).IsRequired(false);
            builder.HasOne(t => t.Manipulation).WithOne().HasForeignKey<AtlasModel.MedulaReportResult>(x => x.ManipulationRef).IsRequired(false);
            builder.HasOne(t => t.ParticipatnFreeDrugReport).WithOne().HasForeignKey<AtlasModel.MedulaReportResult>(x => x.ParticipatnFreeDrugReportRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}