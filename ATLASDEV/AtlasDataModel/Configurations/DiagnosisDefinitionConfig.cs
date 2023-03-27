using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DiagnosisDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DiagnosisDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DiagnosisDefinition> builder)
        {
            builder.ToTable("DIAGNOSISDEFINITION");
            builder.HasKey(nameof(AtlasModel.DiagnosisDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Type)).HasColumnName("TYPE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Level)).HasColumnName("LEVEL");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.SendBulasiciHastalikBildirim)).HasColumnName("SENDBULASICIHASTALIKBILDIRIM");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.CausesMotherDeath)).HasColumnName("CAUSESMOTHERDEATH");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Precision)).HasColumnName("PRECISION");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.IsLeaf)).HasColumnName("ISLEAF");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Code)).HasColumnName("CODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Code_Shadow)).HasColumnName("CODE_SHADOW");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.KamaStar)).HasColumnName("KAMASTAR").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.CausesDeath)).HasColumnName("CAUSESDEATH");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.ParentGroupCode)).HasColumnName("PARENTGROUPCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.DialysisReportNotMust)).HasColumnName("DIALYSISREPORTNOTMUST");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.InfectiousIllnesesInfoGroup)).HasColumnName("INFECTIOUSILLNESESINFOGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.FtrDiagnoseGroup)).HasColumnName("FTRDIAGNOSEGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.IsInfluenzaDiagnos)).HasColumnName("ISINFLUENZADIAGNOS");
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.ParentGroupRef)).HasColumnName("PARENTGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.EMClinicDecisionQuideDefRef)).HasColumnName("EMCLINICDECISIONQUIDEDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisDefinition.TeshisRef)).HasColumnName("TESHIS").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentGroup).WithOne().HasForeignKey<AtlasModel.DiagnosisDefinition>(x => x.ParentGroupRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}