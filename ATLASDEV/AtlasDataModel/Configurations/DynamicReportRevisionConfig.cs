using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicReportRevisionConfig : IEntityTypeConfiguration<AtlasModel.DynamicReportRevision>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicReportRevision> builder)
        {
            builder.ToTable("DYNAMICREPORTREVISION");
            builder.HasKey(nameof(AtlasModel.DynamicReportRevision.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicReportRevision.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicReportRevision.IsMain)).HasColumnName("ISMAIN");
            builder.Property(nameof(AtlasModel.DynamicReportRevision.RevisionNumber)).HasColumnName("REVISIONNUMBER");
            builder.Property(nameof(AtlasModel.DynamicReportRevision.CreatedDate)).HasColumnName("CREATEDDATE");
            builder.Property(nameof(AtlasModel.DynamicReportRevision.ReportComment)).HasColumnName("REPORTCOMMENT");
            builder.Property(nameof(AtlasModel.DynamicReportRevision.ReportJSONContent)).HasColumnName("REPORTJSONCONTENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicReportRevision.Enabled)).HasColumnName("ENABLED");
            builder.Property(nameof(AtlasModel.DynamicReportRevision.CreatedByRef)).HasColumnName("CREATEDBY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DynamicReportRevision.DynamicReportRef)).HasColumnName("DYNAMICREPORT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.CreatedBy).WithOne().HasForeignKey<AtlasModel.DynamicReportRevision>(x => x.CreatedByRef).IsRequired(true);
            builder.HasOne(t => t.DynamicReport).WithOne().HasForeignKey<AtlasModel.DynamicReportRevision>(x => x.DynamicReportRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}