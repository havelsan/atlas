using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectStateReportDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectStateReportDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectStateReportDef> builder)
        {
            builder.HasKey(t => t.StateDefId);
            builder.Property(t => t.StateDefId).HasColumnName("STATEDEFID").HasMaxLength(36);
            builder.Property(t => t.ReportDefId).HasColumnName("REPORTDEFID").HasMaxLength(36);
            builder.Property(t => t.DuplicateCount).HasColumnName("DUPLICATECOUNT");
            builder.Property(t => t.AskUser).HasColumnName("ASKUSER");
            builder.Property(t => t.IsDisplay).HasColumnName("ISDISPLAY");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}