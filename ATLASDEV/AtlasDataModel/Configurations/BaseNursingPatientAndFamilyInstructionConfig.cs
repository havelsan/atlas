using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingPatientAndFamilyInstructionConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingPatientAndFamilyInstruction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingPatientAndFamilyInstruction> builder)
        {
            builder.ToTable("BASENURPATIEFAMINSTRUCTION");
            builder.HasKey(nameof(AtlasModel.BaseNursingPatientAndFamilyInstruction.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingPatientAndFamilyInstruction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseNursingPatientAndFamilyInstruction.InstructionNote)).HasColumnName("INSTRUCTIONNOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseNursingPatientAndFamilyInstruction.CompanionInstruction)).HasColumnName("COMPANIONINSTRUCTION");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}