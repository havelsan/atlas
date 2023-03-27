using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTPermissionParameterDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTPermissionParameterDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTPermissionParameterDef> builder)
        {
            builder.HasKey(t => t.ParameterDefId);
            builder.Property(t => t.ParameterDefId).HasColumnName("PARAMETERDEFID").HasMaxLength(36);
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.OrderNo).HasColumnName("ORDERNO");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}