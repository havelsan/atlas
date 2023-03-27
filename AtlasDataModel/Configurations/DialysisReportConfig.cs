using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DialysisReportConfig : IEntityTypeConfiguration<AtlasModel.DialysisReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DialysisReport> builder)
        {
            builder.ToTable("DIALYSISREPORT");
            builder.HasKey(nameof(AtlasModel.DialysisReport.ObjectId));
            builder.Property(nameof(AtlasModel.DialysisReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DialysisReport.NumberOfSessions)).HasColumnName("NUMBEROFSESSIONS");
            builder.Property(nameof(AtlasModel.DialysisReport.DialysisSessionsDay)).HasColumnName("DIALYSISSESSIONSDAY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DialysisReport.IsCompanion)).HasColumnName("ISCOMPANION");
            builder.Property(nameof(AtlasModel.DialysisReport.TedaviRaporiIslemKodlariRef)).HasColumnName("TEDAVIRAPORIISLEMKODLARI").HasMaxLength(36).IsFixedLength();
        }
    }
}