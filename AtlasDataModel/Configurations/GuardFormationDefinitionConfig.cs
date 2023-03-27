using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GuardFormationDefinitionConfig : IEntityTypeConfiguration<AtlasModel.GuardFormationDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.GuardFormationDefinition> builder)
        {
            builder.ToTable("GUARDFORMATIONDEFINITION");
            builder.HasKey(nameof(AtlasModel.GuardFormationDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.GuardFormationDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.GuardFormationDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.GuardFormationDefinition.Date)).HasColumnName("DATE");
        }
    }
}