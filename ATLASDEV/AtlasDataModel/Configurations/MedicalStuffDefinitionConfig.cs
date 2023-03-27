using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalStuffDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MedicalStuffDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalStuffDefinition> builder)
        {
            builder.ToTable("MEDICALSTUFFDEFINITION");
            builder.HasKey(nameof(AtlasModel.MedicalStuffDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalStuffDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalStuffDefinition.Code)).HasColumnName("CODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MedicalStuffDefinition.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.MedicalStuffDefinition.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.MedicalStuffDefinition.Name)).HasColumnName("NAME").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MedicalStuffDefinition.MedicalStuffGroupRef)).HasColumnName("MEDICALSTUFFGROUP").HasMaxLength(36).IsFixedLength();
        }
    }
}