using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EyeExaminationConfig : IEntityTypeConfiguration<AtlasModel.EyeExamination>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EyeExamination> builder)
        {
            builder.ToTable("EYEEXAMINATION");
            builder.HasKey(nameof(AtlasModel.EyeExamination.ObjectId));
            builder.Property(nameof(AtlasModel.EyeExamination.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EyeExamination.RightEyeBiomicroscopy)).HasColumnName("RIGHTEYEBIOMICROSCOPY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpLeftNearAxis)).HasColumnName("GLASSVISSHARPLEFTNEARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpRightFarSPH)).HasColumnName("GLASSVISSHARPRIGHTFARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpRightFarCYL)).HasColumnName("GLASSVISSHARPRIGHTFARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpRightFarAxis)).HasColumnName("GLASSVISSHARPRIGHTFARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpRightNearSPH)).HasColumnName("GLASSVISSHARPRIGHTNEARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpRightNearCYL)).HasColumnName("GLASSVISSHARPRIGHTNEARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpRightNearAxis)).HasColumnName("GLASSVISSHARPRIGHTNEARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpLeftFarSPH)).HasColumnName("NOGLASSVISSHARPLEFTFARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpLeftFarCYL)).HasColumnName("NOGLASSVISSHARPLEFTFARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpLeftFarAxis)).HasColumnName("NOGLASSVISSHARPLEFTFARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpLeftNearSPH)).HasColumnName("NOGLASSVISSHARPLEFTNEARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpLeftNearCYL)).HasColumnName("NOGLASSVISSHARPLEFTNEARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpLeftNearAxis)).HasColumnName("NOGLASSVISSHARPLEFTNEARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.CyclAutorefRightMeasureCYL)).HasColumnName("CYCLAUTOREFRIGHTMEASURECYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.CyclAutorefRightMeasureAxis)).HasColumnName("CYCLAUTOREFRIGHTMEASUREAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpLeftFarSPH)).HasColumnName("GLASSVISSHARPLEFTFARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpLeftFarCYL)).HasColumnName("GLASSVISSHARPLEFTFARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpLeftFarAxis)).HasColumnName("GLASSVISSHARPLEFTFARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpLeftNearSPH)).HasColumnName("GLASSVISSHARPLEFTNEARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.GlassVisSharpLeftNearCYL)).HasColumnName("GLASSVISSHARPLEFTNEARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.LeftEyeBiomicroscopy)).HasColumnName("LEFTEYEBIOMICROSCOPY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EyeExamination.RightEyePressure)).HasColumnName("RIGHTEYEPRESSURE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.LeftEyePressure)).HasColumnName("LEFTEYEPRESSURE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.LeftEyeMovements)).HasColumnName("LEFTEYEMOVEMENTS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EyeExamination.RightEyeMovements)).HasColumnName("RIGHTEYEMOVEMENTS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EyeExamination.RightEyeFundus)).HasColumnName("RIGHTEYEFUNDUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EyeExamination.LeftEyeFundus)).HasColumnName("LEFTEYEFUNDUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EyeExamination.AutorefLeftEyeMeasureSPH)).HasColumnName("AUTOREFLEFTEYEMEASURESPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.AutorefLeftEyeMeasureCYL)).HasColumnName("AUTOREFLEFTEYEMEASURECYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.AutorefLeftEyeMeasureAxis)).HasColumnName("AUTOREFLEFTEYEMEASUREAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.AutorefRightEyeMeasureSPH)).HasColumnName("AUTOREFRIGHTEYEMEASURESPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.AutorefRightEyeMeasureCYL)).HasColumnName("AUTOREFRIGHTEYEMEASURECYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.AutorefRightEyeMeasureAxis)).HasColumnName("AUTOREFRIGHTEYEMEASUREAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.CyclAutorefLeftMeasureSPH)).HasColumnName("CYCLAUTOREFLEFTMEASURESPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.CyclAutorefLeftMeasureCYL)).HasColumnName("CYCLAUTOREFLEFTMEASURECYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.CyclAutorefLeftMeasureAxis)).HasColumnName("CYCLAUTOREFLEFTMEASUREAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.CyclAutorefRightMeasureSPH)).HasColumnName("CYCLAUTOREFRIGHTMEASURESPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpRightFarSPH)).HasColumnName("NOGLASSVISSHARPRIGHTFARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpRightFarCYL)).HasColumnName("NOGLASSVISSHARPRIGHTFARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpRightFarAxis)).HasColumnName("NOGLASSVISSHARPRIGHTFARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpRightNearSPH)).HasColumnName("NOGLASSVISSHARPRIGHTNEARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpRightNearCYL)).HasColumnName("NOGLASSVISSHARPRIGHTNEARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.NoGlassVisSharpRightNearAxis)).HasColumnName("NOGLASSVISSHARPRIGHTNEARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesRightFarSPH)).HasColumnName("PATIENTGLASSESRIGHTFARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesRightFarCYL)).HasColumnName("PATIENTGLASSESRIGHTFARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesRightFarAxis)).HasColumnName("PATIENTGLASSESRIGHTFARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesRightNearAxis)).HasColumnName("PATIENTGLASSESRIGHTNEARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesRightNearCYL)).HasColumnName("PATIENTGLASSESRIGHTNEARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesRightNearSPH)).HasColumnName("PATIENTGLASSESRIGHTNEARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesLeftNearSPH)).HasColumnName("PATIENTGLASSESLEFTNEARSPH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesLeftNearCYL)).HasColumnName("PATIENTGLASSESLEFTNEARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesLeftNearAxis)).HasColumnName("PATIENTGLASSESLEFTNEARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesLeftFarAxis)).HasColumnName("PATIENTGLASSESLEFTFARAXIS").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesLeftFarCYL)).HasColumnName("PATIENTGLASSESLEFTFARCYL").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.EyeExamination.PatientGlassesLeftFarSPH)).HasColumnName("PATIENTGLASSESLEFTFARSPH").HasColumnType("FLOAT");
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);
        }
    }
}