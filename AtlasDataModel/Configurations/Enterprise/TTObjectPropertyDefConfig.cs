using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectPropertyDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectPropertyDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectPropertyDef> builder)
        {
            builder.HasKey(t => t.PropertyDefId);
            builder.Property(t => t.PropertyDefId).HasColumnName("PROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(29);
            builder.Property(t => t.Caption).HasColumnName("CAPTION").HasMaxLength(50);
            builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
            builder.Property(t => t.DefaultValueType).HasColumnName("DEFAULTVALUETYPE");
            builder.Property(t => t.DefaultValue).HasColumnName("DEFAULTVALUE").HasMaxLength(2147483647);
            builder.Property(t => t.IsDynamic).HasColumnName("ISDYNAMIC");
            builder.Property(t => t.IsRequired).HasColumnName("ISREQUIRED");
            builder.Property(t => t.IsProtected).HasColumnName("ISPROTECTED");
            builder.Property(t => t.SetScript).HasColumnName("SETSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.IsIndexed).HasColumnName("ISINDEXED");
            builder.Property(t => t.ShadowOfPropertyDefId).HasColumnName("SHADOWOFPROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.IsNoLock).HasColumnName("ISNOLOCK");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.AllowUpdateProtected).HasColumnName("ALLOWUPDATEPROTECTED");
        }
    }
}