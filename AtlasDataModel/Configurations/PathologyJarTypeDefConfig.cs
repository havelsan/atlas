using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PathologyJarTypeDefConfig : IEntityTypeConfiguration<AtlasModel.PathologyJarTypeDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PathologyJarTypeDef> builder)
        {
            builder.ToTable("PATHOLOGYJARTYPEDEF");
            builder.HasKey(nameof(AtlasModel.PathologyJarTypeDef.ObjectId));
            builder.Property(nameof(AtlasModel.PathologyJarTypeDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PathologyJarTypeDef.JarType)).HasColumnName("JARTYPE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PathologyJarTypeDef.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}