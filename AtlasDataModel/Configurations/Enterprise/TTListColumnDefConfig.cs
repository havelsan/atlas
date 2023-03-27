using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTListColumnDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTListColumnDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTListColumnDef> builder)
        {
            builder.HasKey(t => t.ListColumnDefId);
            builder.Property(t => t.ListColumnDefId).HasColumnName("LISTCOLUMNDEFID").HasMaxLength(36);
            builder.Property(t => t.ListDefId).HasColumnName("LISTDEFID").HasMaxLength(36);
            builder.Property(t => t.MemberName).HasColumnName("MEMBERNAME").HasMaxLength(255);
            builder.Property(t => t.Caption).HasColumnName("CAPTION").HasMaxLength(50);
            builder.Property(t => t.ColumnOrder).HasColumnName("COLUMNORDER");
            builder.Property(t => t.ColumnWidth).HasColumnName("COLUMNWIDTH");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}