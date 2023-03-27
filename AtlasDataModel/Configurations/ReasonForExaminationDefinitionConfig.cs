using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReasonForExaminationDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ReasonForExaminationDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReasonForExaminationDefinition> builder)
        {
            builder.ToTable("REASONFOREXAMINATIONDEF");
            builder.HasKey(nameof(AtlasModel.ReasonForExaminationDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.Reason)).HasColumnName("REASON").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.ReasonForExaminationType)).HasColumnName("REASONFOREXAMINATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.IsForcedDiagnosis)).HasColumnName("ISFORCEDDIAGNOSIS");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.IsPrintReportBeforeExam)).HasColumnName("ISPRINTREPORTBEFOREEXAM");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.IsPoliclinicAllowedReport)).HasColumnName("ISPOLICLINICALLOWEDREPORT");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.ControlTime)).HasColumnName("CONTROLTIME");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.ControlUnitOfTime)).HasColumnName("CONTROLUNITOFTIME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.PackageProcedureRef)).HasColumnName("PACKAGEPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.HCReportTypeDefinitionRef)).HasColumnName("HCREPORTTYPEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReasonForExaminationDefinition.MemberOfHealthCommitteeRef)).HasColumnName("MEMBEROFHEALTHCOMMITTEE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PackageProcedure).WithOne().HasForeignKey<AtlasModel.ReasonForExaminationDefinition>(x => x.PackageProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}