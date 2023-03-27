using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingCareDefinitionConfig : IEntityTypeConfiguration<AtlasModel.NursingCareDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingCareDefinition> builder)
        {
            builder.ToTable("NURSINGCAREDEFINITION");
            builder.HasKey(nameof(AtlasModel.NursingCareDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.NursingCareDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingCareDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.NursingCareDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}