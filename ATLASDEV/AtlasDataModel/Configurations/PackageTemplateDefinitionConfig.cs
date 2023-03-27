using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PackageTemplateDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PackageTemplateDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PackageTemplateDefinition> builder)
        {
            builder.ToTable("PACKAGETEMPLATEDEF");
            builder.HasKey(nameof(AtlasModel.PackageTemplateDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PackageTemplateDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PackageTemplateDefinition.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.PackageTemplateDefinition.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.PackageTemplateDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
        }
    }
}