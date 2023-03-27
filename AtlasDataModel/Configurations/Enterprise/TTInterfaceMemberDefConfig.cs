using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTInterfaceMemberDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTInterfaceMemberDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTInterfaceMemberDef> builder)
        {
            builder.HasKey(t => t.InterfaceDefId);
            builder.Property(t => t.InterfaceDefId).HasColumnName("INTERFACEDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.CodeType).HasColumnName("CODETYPE").HasMaxLength(250);
            builder.Property(t => t.IsReadOnly).HasColumnName("ISREADONLY");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}