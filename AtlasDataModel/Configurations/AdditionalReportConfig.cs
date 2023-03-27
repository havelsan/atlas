using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AdditionalReportConfig : IEntityTypeConfiguration<AtlasModel.AdditionalReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AdditionalReport> builder)
        {
            builder.ToTable("ADDITIONALREPORT");
            builder.HasKey(nameof(AtlasModel.AdditionalReport.ObjectId));
            builder.Property(nameof(AtlasModel.AdditionalReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AdditionalReport.IsCompleted)).HasColumnName("ISCOMPLETED");
            builder.Property(nameof(AtlasModel.AdditionalReport.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}