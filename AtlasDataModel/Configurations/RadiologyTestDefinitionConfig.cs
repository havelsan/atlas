using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyTestDefinitionConfig : IEntityTypeConfiguration<AtlasModel.RadiologyTestDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiologyTestDefinition> builder)
        {
            builder.ToTable("RADIOLOGYTESTDEFINITION");
            builder.HasKey(nameof(AtlasModel.RadiologyTestDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnMonday)).HasColumnName("ONMONDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TabDescription)).HasColumnName("TABDESCRIPTION").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnTuesday)).HasColumnName("ONTUESDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnWednesday)).HasColumnName("ONWEDNESDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.ProcedureTime)).HasColumnName("PROCEDURETIME");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.IsRestrictedTest)).HasColumnName("ISRESTRICTEDTEST");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TimeLimit)).HasColumnName("TIMELIMIT");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnThursday)).HasColumnName("ONTHURSDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnSaturday)).HasColumnName("ONSATURDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.IsHeader)).HasColumnName("ISHEADER");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TabRow)).HasColumnName("TABROW");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnSunday)).HasColumnName("ONSUNDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TabName)).HasColumnName("TABNAME").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.BodyPart)).HasColumnName("BODYPART").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.OnFriday)).HasColumnName("ONFRIDAY");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.SexControl)).HasColumnName("SEXCONTROL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.AccessionModalityRequires)).HasColumnName("ACCESSIONMODALITYREQUIRES");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.IsPassiveNow)).HasColumnName("ISPASSIVENOW");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TestID)).HasColumnName("TESTID");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.ReasonForPassive)).HasColumnName("REASONFORPASSIVE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.IsRISEntegratedTest)).HasColumnName("ISRISENTEGRATEDTEST");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.PreInformation)).HasColumnName("PREINFORMATION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.EstimatedCompletionTime)).HasColumnName("ESTIMATEDCOMPLETIONTIME");
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TMRadTestRef)).HasColumnName("TMRADTEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TestSubTypeRef)).HasColumnName("TESTSUBTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TestTabRef)).HasColumnName("TESTTAB").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTestDefinition.TestTypeRef)).HasColumnName("TESTTYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.TestSubType).WithOne().HasForeignKey<AtlasModel.RadiologyTestDefinition>(x => x.TestSubTypeRef).IsRequired(false);
            builder.HasOne(t => t.TestType).WithOne().HasForeignKey<AtlasModel.RadiologyTestDefinition>(x => x.TestTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}