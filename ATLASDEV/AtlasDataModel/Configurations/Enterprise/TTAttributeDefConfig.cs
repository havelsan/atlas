using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTAttributeDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTAttributeDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTAttributeDef> builder)
        {
            builder.HasKey(t => t.AttributeDefId);
            builder.Property(t => t.AttributeDefId).HasColumnName("ATTRIBUTEDEFID").HasMaxLength(36);
            builder.Property(t => t.InterfaceDefId).HasColumnName("INTERFACEDEFID").HasMaxLength(36);
            builder.Property(t => t.Body).HasColumnName("BODY").HasMaxLength(2147483647);
            builder.Property(t => t.CheckBody).HasColumnName("CHECKBODY").HasMaxLength(2147483647);
            builder.Property(t => t.Target).HasColumnName("TARGET");
            builder.Property(t => t.EventType).HasColumnName("EVENTTYPE");
            builder.Property(t => t.When).HasColumnName("WHEN");
        }
    }
}