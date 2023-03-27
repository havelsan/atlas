using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EmergencySurveyDefinitionConfig : IEntityTypeConfiguration<AtlasModel.EmergencySurveyDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EmergencySurveyDefinition> builder)
        {
            builder.ToTable("EMERGENCYSURVEYDEFINITION");
            builder.HasKey(nameof(AtlasModel.EmergencySurveyDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.EmergencySurveyDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EmergencySurveyDefinition.ActivityGroup)).HasColumnName("ACTIVITYGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EmergencySurveyDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EmergencySurveyDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
        }
    }
}