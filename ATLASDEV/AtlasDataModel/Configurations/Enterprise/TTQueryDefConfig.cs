using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTQueryDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTQueryDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTQueryDef> builder)
        {
            builder.HasKey(t => t.QueryDefId);
            builder.Property(t => t.QueryDefId).HasColumnName("QUERYDEFID").HasMaxLength(36);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.Nql).HasColumnName("NQL").HasMaxLength(2147483647);
            builder.Property(t => t.SubType).HasColumnName("SUBTYPE");
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Methods).HasColumnName("METHODS").HasMaxLength(2147483647);
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}