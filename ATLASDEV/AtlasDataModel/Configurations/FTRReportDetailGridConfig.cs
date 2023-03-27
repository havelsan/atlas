using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FTRReportDetailGridConfig : IEntityTypeConfiguration<AtlasModel.FTRReportDetailGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FTRReportDetailGrid> builder)
        {
            builder.ToTable("FTRREPORTDETAIL");
            builder.HasKey(nameof(AtlasModel.FTRReportDetailGrid.ObjectId));
            builder.Property(nameof(AtlasModel.FTRReportDetailGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FTRReportDetailGrid.NumberOfSessions)).HasColumnName("NUMBEROFSESSIONS");
            builder.Property(nameof(AtlasModel.FTRReportDetailGrid.FTRReportRef)).HasColumnName("FTRREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.FTRReportDetailGrid.TedaviRaporiIslemKodlariRef)).HasColumnName("TEDAVIRAPORIISLEMKODLARI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.FTRReportDetailGrid.TedaviTuruRef)).HasColumnName("TEDAVITURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.FTRReportDetailGrid.FTRVucutBolgesiRef)).HasColumnName("FTRVUCUTBOLGESI").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.FTRReport).WithOne().HasForeignKey<AtlasModel.FTRReportDetailGrid>(x => x.FTRReportRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}