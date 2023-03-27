using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectDef> builder)
        {
            builder.HasKey(t => t.ObjectDefId);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.GenerateDefaultConstructor).HasColumnName("GENERATEDEFAULTCONSTRUCTOR");
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.PreInsert).HasColumnName("PREINSERT").HasMaxLength(2147483647);
            builder.Property(t => t.PostInsert).HasColumnName("POSTINSERT").HasMaxLength(2147483647);
            builder.Property(t => t.PreUpdate).HasColumnName("PREUPDATE").HasMaxLength(2147483647);
            builder.Property(t => t.PostUpdate).HasColumnName("POSTUPDATE").HasMaxLength(2147483647);
            builder.Property(t => t.PreDelete).HasColumnName("PREDELETE").HasMaxLength(2147483647);
            builder.Property(t => t.PostDelete).HasColumnName("POSTDELETE").HasMaxLength(2147483647);
            builder.Property(t => t.ObjectTableName).HasColumnName("OBJECTTABLENAME").HasMaxLength(26);
            builder.Property(t => t.IsCentral).HasColumnName("ISCENTRAL");
            builder.Property(t => t.CacheDuration).HasColumnName("CACHEDURATION");
            builder.Property(t => t.AuditEnabled).HasColumnName("AUDITENABLED");
        }
    }
}