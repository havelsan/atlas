using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FTRReportConfig : IEntityTypeConfiguration<AtlasModel.FTRReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FTRReport> builder)
        {
            builder.ToTable("FTRREPORT");
            builder.HasKey(nameof(AtlasModel.FTRReport.ObjectId));
            builder.Property(nameof(AtlasModel.FTRReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FTRReport.SpacialCase)).HasColumnName("SPACIALCASE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.FTRReport.IsTrafficAccident)).HasColumnName("ISTRAFFICACCIDENT");
        }
    }
}