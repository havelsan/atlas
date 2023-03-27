using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HomeHemodialysisReportConfig : IEntityTypeConfiguration<AtlasModel.HomeHemodialysisReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HomeHemodialysisReport> builder)
        {
            builder.ToTable("HEMODIALYSISREPORT");
            builder.HasKey(nameof(AtlasModel.HomeHemodialysisReport.ObjectId));
            builder.Property(nameof(AtlasModel.HomeHemodialysisReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HomeHemodialysisReport.NumberOfSessions)).HasColumnName("NUMBEROFSESSIONS");
            builder.Property(nameof(AtlasModel.HomeHemodialysisReport.TreatmenDuration)).HasColumnName("TREATMENDURATION");
            builder.Property(nameof(AtlasModel.HomeHemodialysisReport.DialysisSessionsDay)).HasColumnName("DIALYSISSESSIONSDAY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HomeHemodialysisReport.TedaviRaporiIslemKodlariRef)).HasColumnName("TEDAVIRAPORIISLEMKODLARI").HasMaxLength(36).IsFixedLength();
        }
    }
}