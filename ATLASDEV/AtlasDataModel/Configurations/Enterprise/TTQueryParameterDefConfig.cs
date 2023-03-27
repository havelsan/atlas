using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTQueryParameterDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTQueryParameterDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTQueryParameterDef> builder)
        {
            builder.HasKey(t => t.ParameterDefId);
            builder.Property(t => t.ParameterDefId).HasColumnName("PARAMETERDEFID").HasMaxLength(36);
            builder.Property(t => t.QueryDefId).HasColumnName("QUERYDEFID").HasMaxLength(36);
            builder.Property(t => t.OrderNo).HasColumnName("ORDERNO");
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
            builder.Property(t => t.IsArray).HasColumnName("ISARRAY");
            builder.Property(t => t.SqlTestValue).HasColumnName("SQLTESTVALUE").HasMaxLength(255);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}