using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRemoteMethodDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRemoteMethodDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRemoteMethodDef> builder)
        {
            builder.HasKey(t => t.RemoteMethodDefId);
            builder.Property(t => t.RemoteMethodDefId).HasColumnName("REMOTEMETHODDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.ReturnType).HasColumnName("RETURNTYPE").HasMaxLength(100);
            builder.Property(t => t.Body).HasColumnName("BODY").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.CallMode).HasColumnName("CALLMODE");
            builder.Property(t => t.Priority).HasColumnName("PRIORITY");
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.DisplayText).HasColumnName("DISPLAYTEXT").HasMaxLength(150);
            builder.Property(t => t.CallbackBody).HasColumnName("CALLBACKBODY").HasMaxLength(2147483647);
        }
    }
}