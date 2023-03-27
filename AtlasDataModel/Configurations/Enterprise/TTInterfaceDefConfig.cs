using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTInterfaceDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTInterfaceDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTInterfaceDef> builder)
        {
            builder.HasKey(t => t.InterfaceDefId);
            builder.Property(t => t.InterfaceDefId).HasColumnName("INTERFACEDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.Methods).HasColumnName("METHODS").HasMaxLength(2147483647);
            builder.Property(t => t.BaseInterfaceDefId).HasColumnName("BASEINTERFACEDEFID").HasMaxLength(36);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.IsBuiltIn).HasColumnName("ISBUILTIN");
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}