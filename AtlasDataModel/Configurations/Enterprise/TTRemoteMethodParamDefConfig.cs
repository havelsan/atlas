using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRemoteMethodParamDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRemoteMethodParamDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRemoteMethodParamDef> builder)
        {
            builder.HasKey(t => t.RemoteMethodParamDefId);
            builder.Property(t => t.RemoteMethodParamDefId).HasColumnName("REMOTEMETHODPARAMDEFID").HasMaxLength(36);
            builder.Property(t => t.RemoteMethodDefId).HasColumnName("REMOTEMETHODDEFID").HasMaxLength(36);
            builder.Property(t => t.ParameterName).HasColumnName("PARAMETERNAME").HasMaxLength(100);
            builder.Property(t => t.ParameterType).HasColumnName("PARAMETERTYPE").HasMaxLength(100);
            builder.Property(t => t.OrderNo).HasColumnName("ORDERNO");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}