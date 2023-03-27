using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HBTReportConfig : IEntityTypeConfiguration<AtlasModel.HBTReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HBTReport> builder)
        {
            builder.ToTable("HBTREPORT");
            builder.HasKey(nameof(AtlasModel.HBTReport.ObjectId));
            builder.Property(nameof(AtlasModel.HBTReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HBTReport.NumberOfSessions)).HasColumnName("NUMBEROFSESSIONS");
            builder.Property(nameof(AtlasModel.HBTReport.TreatmenDuration)).HasColumnName("TREATMENDURATION");
        }
    }
}