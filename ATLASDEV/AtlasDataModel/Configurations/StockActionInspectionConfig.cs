using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionInspectionConfig : IEntityTypeConfiguration<AtlasModel.StockActionInspection>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockActionInspection> builder)
        {
            builder.ToTable("STOCKACTIONINSPECTION");
            builder.HasKey(nameof(AtlasModel.StockActionInspection.ObjectId));
            builder.Property(nameof(AtlasModel.StockActionInspection.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockActionInspection.ReportNumberSeq)).HasColumnName("REPORTNUMBERSEQ");
            builder.Property(nameof(AtlasModel.StockActionInspection.InspectionDate)).HasColumnName("INSPECTIONDATE");
            builder.Property(nameof(AtlasModel.StockActionInspection.InspectionReport)).HasColumnName("INSPECTIONREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionInspection.ReportNumberNotSeq)).HasColumnName("REPORTNUMBERNOTSEQ");
        }
    }
}