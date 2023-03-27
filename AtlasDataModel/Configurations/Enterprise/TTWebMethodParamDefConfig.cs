using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTWebMethodParamDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTWebMethodParamDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTWebMethodParamDef> builder)
        {
            builder.HasKey(t => t.WebMethodParamDefId);
            builder.Property(t => t.WebMethodParamDefId).HasColumnName("WEBMETHODPARAMDEFID").HasMaxLength(36);
            builder.Property(t => t.WebMethodDefId).HasColumnName("WEBMETHODDEFID").HasMaxLength(36);
            builder.Property(t => t.ParameterName).HasColumnName("PARAMETERNAME").HasMaxLength(100);
            builder.Property(t => t.ParameterType).HasColumnName("PARAMETERTYPE").HasMaxLength(100);
            builder.Property(t => t.OrderNo).HasColumnName("ORDERNO");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}