using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GuideBookDefinitionConfig : IEntityTypeConfiguration<AtlasModel.GuideBookDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.GuideBookDefinition> builder)
        {
            builder.ToTable("GUIDEBOOKDEFINITION");
            builder.HasKey(nameof(AtlasModel.GuideBookDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.GuideBookDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.GuideBookDefinition.Code)).HasColumnName("CODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.GuideBookDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.GuideBookDefinition.PhoneNumber)).HasColumnName("PHONENUMBER").HasMaxLength(50);
        }
    }
}