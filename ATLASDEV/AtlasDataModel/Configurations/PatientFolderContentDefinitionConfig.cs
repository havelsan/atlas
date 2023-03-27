using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientFolderContentDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PatientFolderContentDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientFolderContentDefinition> builder)
        {
            builder.ToTable("PATIENTFOLDERCONTENTDEF");
            builder.HasKey(nameof(AtlasModel.PatientFolderContentDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PatientFolderContentDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientFolderContentDefinition.FileName)).HasColumnName("FILENAME").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientFolderContentDefinition.Active)).HasColumnName("ACTIVE");
        }
    }
}