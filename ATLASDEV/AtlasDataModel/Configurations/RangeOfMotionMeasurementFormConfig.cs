using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RangeOfMotionMeasurementFormConfig : IEntityTypeConfiguration<AtlasModel.RangeOfMotionMeasurementForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RangeOfMotionMeasurementForm> builder)
        {
            builder.ToTable("RANGEOFMOTIONMEASUREMENT");
            builder.HasKey(nameof(AtlasModel.RangeOfMotionMeasurementForm.ObjectId));
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.ExtensionEHA)).HasColumnName("EXTENSIONEHA").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.ExtensionHABK)).HasColumnName("EXTENSIONHABK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.ExtensionHASK)).HasColumnName("EXTENSIONHASK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.ExtensionHAOK)).HasColumnName("EXTENSIONHAOK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.FlexionEHA)).HasColumnName("FLEXIONEHA").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.FlexionHABK)).HasColumnName("FLEXIONHABK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.FlexionHAOK)).HasColumnName("FLEXIONHAOK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.FlexionHASK)).HasColumnName("FLEXIONHASK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.AbductionEHA)).HasColumnName("ABDUCTIONEHA").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.AbductionHABK)).HasColumnName("ABDUCTIONHABK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.AbductionHAOK)).HasColumnName("ABDUCTIONHAOK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.AbductionHASK)).HasColumnName("ABDUCTIONHASK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.RotationEHA)).HasColumnName("ROTATIONEHA").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.RotationHABK)).HasColumnName("ROTATIONHABK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.RotationHAOK)).HasColumnName("ROTATIONHAOK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RangeOfMotionMeasurementForm.RotationHASK)).HasColumnName("ROTATIONHASK").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}