using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingWoundAssessmentScaleConfig : IEntityTypeConfiguration<AtlasModel.NursingWoundAssessmentScale>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingWoundAssessmentScale> builder)
        {
            builder.ToTable("NURWOUNDASSESSMENTSCALE");
            builder.HasKey(nameof(AtlasModel.NursingWoundAssessmentScale.ObjectId));
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.NursingAppDoneDate)).HasColumnName("NURSINGAPPDONEDATE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.TotalRisk)).HasColumnName("TOTALRISK");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.BodyType)).HasColumnName("BODYTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.Continence)).HasColumnName("CONTINENCE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.Mobility)).HasColumnName("MOBILITY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.NeurologicalDisorders)).HasColumnName("NEUROLOGICALDISORDERS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinHealthy)).HasColumnName("SKINHEALTHY");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinThin)).HasColumnName("SKINTHIN");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinDry)).HasColumnName("SKINDRY");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinDropsy)).HasColumnName("SKINDROPSY");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinColdAndMoist)).HasColumnName("SKINCOLDANDMOIST");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinDiscolored)).HasColumnName("SKINDISCOLORED");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SkinIntegrityBroken)).HasColumnName("SKININTEGRITYBROKEN");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.MedicineUsage)).HasColumnName("MEDICINEUSAGE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.AppetiteAverage)).HasColumnName("APPETITEAVERAGE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.AppetiteOnlyLiquid)).HasColumnName("APPETITEONLYLIQUID");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.AppetitePoor)).HasColumnName("APPETITEPOOR");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.AppetiteNg)).HasColumnName("APPETITENG");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.AppetiteAnorexia)).HasColumnName("APPETITEANOREXIA");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.DMTerminalCachexia)).HasColumnName("DMTERMINALCACHEXIA");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.DMHeartFailure)).HasColumnName("DMHEARTFAILURE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.DMPeripheralVascularDisease)).HasColumnName("DMPERIPHERALVASCULARDISEASE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.DMAnemia)).HasColumnName("DMANEMIA");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.DMCigaretteUsage)).HasColumnName("DMCIGARETTEUSAGE");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SurgeryOrthopedic)).HasColumnName("SURGERYORTHOPEDIC");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.SurgeryLongerThan2Hours)).HasColumnName("SURGERYLONGERTHAN2HOURS");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.NursingWoundTime)).HasColumnName("NURSINGWOUNDTIME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingWoundAssessmentScale.GradeDistribution)).HasColumnName("GRADEDISTRIBUTION").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}