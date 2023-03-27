using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTPermissionDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTPermissionDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTPermissionDef> builder)
        {
            builder.HasKey(t => t.PermissionDefId);
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.BasePermissionDefId).HasColumnName("BASEPERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.InterfaceDefId).HasColumnName("INTERFACEDEFID").HasMaxLength(36);
            builder.Property(t => t.Body).HasColumnName("BODY").HasMaxLength(2147483647);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}