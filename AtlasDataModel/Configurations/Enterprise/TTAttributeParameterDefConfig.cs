using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTAttributeParameterDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTAttributeParameterDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTAttributeParameterDef> builder)
        {
            builder.HasKey(t => t.ParameterDefId);
            builder.Property(t => t.ParameterDefId).HasColumnName("PARAMETERDEFID").HasMaxLength(36);
            builder.Property(t => t.AttributeDefId).HasColumnName("ATTRIBUTEDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Target).HasColumnName("TARGET");
            builder.Property(t => t.IsRequired).HasColumnName("ISREQUIRED");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}