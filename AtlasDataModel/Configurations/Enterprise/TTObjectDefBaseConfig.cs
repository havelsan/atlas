using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectDefBaseConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectDefBase>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectDefBase> builder)
        {
            builder.HasKey(t => t.ObjectDefId);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.BaseObjectDefId).HasColumnName("BASEOBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.IsAbstract).HasColumnName("ISABSTRACT");
            builder.Property(t => t.SubType).HasColumnName("SUBTYPE");
            builder.Property(t => t.Methods).HasColumnName("METHODS").HasMaxLength(2147483647);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.DisplayText).HasColumnName("DISPLAYTEXT").HasMaxLength(100);
            builder.Property(t => t.HelpNamespace).HasColumnName("HELPNAMESPACE").HasMaxLength(255);
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.ObjectDefName).HasColumnName("OBJECTDEFNAME").HasMaxLength(100);
        }
    }
}