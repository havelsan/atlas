using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingLegMeasurementConfig : IEntityTypeConfiguration<AtlasModel.NursingLegMeasurement>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingLegMeasurement> builder)
        {
            builder.ToTable("NURSINGLEGMEASUREMENT");
            builder.HasKey(nameof(AtlasModel.NursingLegMeasurement.ObjectId));
            builder.Property(nameof(AtlasModel.NursingLegMeasurement.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingLegMeasurement.LowerRightLeg)).HasColumnName("LOWERRIGHTLEG").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.NursingLegMeasurement.UpperRightLeg)).HasColumnName("UPPERRIGHTLEG").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.NursingLegMeasurement.LowerLeftLeg)).HasColumnName("LOWERLEFTLEG").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.NursingLegMeasurement.UpperLeftLeg)).HasColumnName("UPPERLEFTLEG").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.NursingLegMeasurement.ActionDate)).HasColumnName("ACTIONDATE");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}