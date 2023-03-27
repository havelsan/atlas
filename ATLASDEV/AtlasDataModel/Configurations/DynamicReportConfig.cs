using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicReportConfig : IEntityTypeConfiguration<AtlasModel.DynamicReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicReport> builder)
        {
            builder.ToTable("DYNAMICREPORT");
            builder.HasKey(nameof(AtlasModel.DynamicReport.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicReport.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.DynamicReport.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.DynamicReport.ReportClassName)).HasColumnName("REPORTCLASSNAME");
            builder.Property(nameof(AtlasModel.DynamicReport.CreatedDate)).HasColumnName("CREATEDDATE");
            builder.Property(nameof(AtlasModel.DynamicReport.Enabled)).HasColumnName("ENABLED");
        }
    }
}