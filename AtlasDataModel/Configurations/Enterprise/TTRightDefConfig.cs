using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRightDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRightDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRightDef> builder)
        {
            builder.HasKey(t => t.RightDefId);
            builder.Property(t => t.RightDefId).HasColumnName("RIGHTDEFID");
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.Target).HasColumnName("TARGET");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}