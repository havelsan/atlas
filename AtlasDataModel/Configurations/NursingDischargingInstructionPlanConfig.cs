using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingDischargingInstructionPlanConfig : IEntityTypeConfiguration<AtlasModel.NursingDischargingInstructionPlan>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingDischargingInstructionPlan> builder)
        {
            builder.ToTable("NURDISCHARGINSTRUCTIONPLAN");
            builder.HasKey(nameof(AtlasModel.NursingDischargingInstructionPlan.ObjectId));
            builder.Property(nameof(AtlasModel.NursingDischargingInstructionPlan.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingDischargingInstructionPlan.Note)).HasColumnName("NOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NursingDischargingInstructionPlan.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.NursingDischargingInstructionPlan.PatientGetInstruction)).HasColumnName("PATIENTGETINSTRUCTION");
            builder.Property(nameof(AtlasModel.NursingDischargingInstructionPlan.DischargingInstructionPlanRef)).HasColumnName("DISCHARGINGINSTRUCTIONPLAN").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingDischargingInstructionPlan.BaseDischargingPlanRef)).HasColumnName("BASEDISCHARGINGPLAN").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.BaseDischargingPlan).WithOne().HasForeignKey<AtlasModel.NursingDischargingInstructionPlan>(x => x.BaseDischargingPlanRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}