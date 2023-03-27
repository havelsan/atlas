using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TubeBabyReportConfig : IEntityTypeConfiguration<AtlasModel.TubeBabyReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TubeBabyReport> builder)
        {
            builder.ToTable("TUBEBABYREPORT");
            builder.HasKey(nameof(AtlasModel.TubeBabyReport.ObjectId));
            builder.Property(nameof(AtlasModel.TubeBabyReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TubeBabyReport.TubeBabyReportType)).HasColumnName("TUBEBABYREPORTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.TubeBabyReport.TedaviRaporiIslemKodlariRef)).HasColumnName("TEDAVIRAPORIISLEMKODLARI").HasMaxLength(36).IsFixedLength();
        }
    }
}