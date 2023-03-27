using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingPatientAndFamilyInstructionConfig : IEntityTypeConfiguration<AtlasModel.NursingPatientAndFamilyInstruction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingPatientAndFamilyInstruction> builder)
        {
            builder.ToTable("NURPATIEFAMILYINSTRUCTION");
            builder.HasKey(nameof(AtlasModel.NursingPatientAndFamilyInstruction.ObjectId));
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.Note)).HasColumnName("NOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.PatientGetInstruction)).HasColumnName("PATIENTGETINSTRUCTION");
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.CompanionGetInstruction)).HasColumnName("COMPANIONGETINSTRUCTION");
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.PatientAndFamilyInstructionRef)).HasColumnName("PATIENTANDFAMILYINSTRUCTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingPatientAndFamilyInstruction.BasePatAndFamInstructionRef)).HasColumnName("BASEPATANDFAMINSTRUCTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.BasePatAndFamInstruction).WithOne().HasForeignKey<AtlasModel.NursingPatientAndFamilyInstruction>(x => x.BasePatAndFamInstructionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}