using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingNutritionalRiskAssessmentConfig : IEntityTypeConfiguration<AtlasModel.NursingNutritionalRiskAssessment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingNutritionalRiskAssessment> builder)
        {
            builder.ToTable("NURSINGNUTRITIONALRISK");
            builder.HasKey(nameof(AtlasModel.NursingNutritionalRiskAssessment.ObjectId));
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.SevereDiseaseInfo)).HasColumnName("SEVEREDISEASEINFO");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.BMI)).HasColumnName("BMI");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.ThreeMonthWeightLoss)).HasColumnName("THREEMONTHWEIGHTLOSS");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.WeeklyIntakeDecrease)).HasColumnName("WEEKLYINTAKEDECREASE");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.TotalScore)).HasColumnName("TOTALSCORE");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.NutritionIntake)).HasColumnName("NUTRITIONINTAKE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.DiseaseLevelNormal)).HasColumnName("DISEASELEVELNORMAL");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.DiseaseLevelLow)).HasColumnName("DISEASELEVELLOW");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.DiseaseLevelMedium)).HasColumnName("DISEASELEVELMEDIUM");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.DiseaseLevelHigh)).HasColumnName("DISEASELEVELHIGH");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.Height)).HasColumnName("HEIGHT");
            builder.Property(nameof(AtlasModel.NursingNutritionalRiskAssessment.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}