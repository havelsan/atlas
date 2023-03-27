using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRoleConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRole>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRole> builder)
        {
            builder.HasKey(t => t.RoleId);
            builder.Property(t => t.RoleId).HasColumnName("ROLEID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(t => t.SubType).HasColumnName("SUBTYPE");
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}