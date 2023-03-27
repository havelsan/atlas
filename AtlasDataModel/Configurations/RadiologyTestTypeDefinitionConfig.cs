using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyTestTypeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.RadiologyTestTypeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiologyTestTypeDefinition> builder)
        {
            builder.ToTable("RADIOLOGYTESTTYPEDEF");
            builder.HasKey(nameof(AtlasModel.RadiologyTestTypeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.Name)).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.Id)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.EstimatedAppointmentTime)).HasColumnName("ESTIMATEDAPPOINTMENTTIME");
            builder.Property(nameof(AtlasModel.RadiologyTestTypeDefinition.EstimatedCompletionTime)).HasColumnName("ESTIMATEDCOMPLETIONTIME");
        }
    }
}