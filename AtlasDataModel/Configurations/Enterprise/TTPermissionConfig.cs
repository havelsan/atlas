using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTPermissionConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTPermission>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTPermission> builder)
        {
            builder.HasKey(t => t.PermissionId);
            builder.Property(t => t.PermissionId).HasColumnName("PERMISSIONID").HasMaxLength(36);
            builder.Property(t => t.SecurityId).HasColumnName("SECURITYID").HasMaxLength(36);
            builder.Property(t => t.SubSecurityId).HasColumnName("SUBSECURITYID").HasMaxLength(36);
            builder.Property(t => t.RoleId).HasColumnName("ROLEID").HasMaxLength(36);
            builder.Property(t => t.RightDefId).HasColumnName("RIGHTDEFID");
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.Parameters).HasColumnName("PARAMETERS").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}