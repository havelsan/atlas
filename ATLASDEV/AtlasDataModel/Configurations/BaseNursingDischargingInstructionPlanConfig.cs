using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingDischargingInstructionPlanConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingDischargingInstructionPlan>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingDischargingInstructionPlan> builder)
        {
            builder.ToTable("BASENURSDISCHARGINGPLAN");
            builder.HasKey(nameof(AtlasModel.BaseNursingDischargingInstructionPlan.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingDischargingInstructionPlan.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}