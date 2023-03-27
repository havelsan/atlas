using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ESWTReportConfig : IEntityTypeConfiguration<AtlasModel.ESWTReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ESWTReport> builder)
        {
            builder.ToTable("ESWTREPORT");
            builder.HasKey(nameof(AtlasModel.ESWTReport.ObjectId));
            builder.Property(nameof(AtlasModel.ESWTReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
        }
    }
}