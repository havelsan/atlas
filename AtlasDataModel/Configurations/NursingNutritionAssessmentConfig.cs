using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingNutritionAssessmentConfig : IEntityTypeConfiguration<AtlasModel.NursingNutritionAssessment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingNutritionAssessment> builder)
        {
            builder.ToTable("NURSINGNUTRITIONASSESSMENT");
            builder.HasKey(nameof(AtlasModel.NursingNutritionAssessment.ObjectId));
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.Height)).HasColumnName("HEIGHT");
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.WeightChange)).HasColumnName("WEIGHTCHANGE").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.WeightChangeNote)).HasColumnName("WEIGHTCHANGENOTE").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.AbdominalCircle)).HasColumnName("ABDOMINALCIRCLE");
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.Gastronomy)).HasColumnName("GASTRONOMY");
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.LeftLegCircle)).HasColumnName("LEFTLEGCIRCLE");
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.RightLegCircle)).HasColumnName("RIGHTLEGCIRCLE");
            builder.Property(nameof(AtlasModel.NursingNutritionAssessment.NasogastricTube)).HasColumnName("NASOGASTRICTUBE");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}