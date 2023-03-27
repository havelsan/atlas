using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryRobsonDefinitionConfig : IEntityTypeConfiguration<AtlasModel.SurgeryRobsonDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryRobsonDefinition> builder)
        {
            builder.ToTable("SURGERYROBSONDEFINITION");
            builder.HasKey(nameof(AtlasModel.SurgeryRobsonDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryRobsonDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryRobsonDefinition.Name)).HasColumnName("NAME").HasMaxLength(100);
        }
    }
}