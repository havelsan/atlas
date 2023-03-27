using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ESWLReportConfig : IEntityTypeConfiguration<AtlasModel.ESWLReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ESWLReport> builder)
        {
            builder.ToTable("ESWLREPORT");
            builder.HasKey(nameof(AtlasModel.ESWLReport.ObjectId));
            builder.Property(nameof(AtlasModel.ESWLReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ESWLReport.NumberOfStone)).HasColumnName("NUMBEROFSTONE");
            builder.Property(nameof(AtlasModel.ESWLReport.NumberOfSessions)).HasColumnName("NUMBEROFSESSIONS");
            builder.Property(nameof(AtlasModel.ESWLReport.TedaviRaporiIslemKodlariRef)).HasColumnName("TEDAVIRAPORIISLEMKODLARI").HasMaxLength(36).IsFixedLength();
        }
    }
}