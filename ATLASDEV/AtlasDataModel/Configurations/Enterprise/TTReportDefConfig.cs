using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTReportDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTReportDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTReportDef> builder)
        {
            builder.HasKey(t => t.ReportDefId);
            builder.Property(t => t.ReportDefId).HasColumnName("REPORTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.Caption).HasColumnName("CAPTION").HasMaxLength(255);
            builder.Property(t => t.ReportXml).HasColumnName("REPORTXML").HasMaxLength(2147483647);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.Methods).HasColumnName("METHODS").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.ReportNo).HasColumnName("REPORTNO").HasMaxLength(10);
            builder.Property(t => t.ExcelTemplate).HasColumnName("EXCELTEMPLATE");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}