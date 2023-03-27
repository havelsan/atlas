using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ENabizPackageDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ENabizPackageDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ENabizPackageDefinition> builder)
        {
            builder.ToTable("ENABIZPACKAGEDEFINITION");
            builder.HasKey(nameof(AtlasModel.ENabizPackageDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ENabizPackageDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ENabizPackageDefinition.PackageID)).HasColumnName("PACKAGEID");
            builder.Property(nameof(AtlasModel.ENabizPackageDefinition.PackageName)).HasColumnName("PACKAGENAME");
        }
    }
}