using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryTestDefinitionConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryTestDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryTestDefinition> builder)
        {
            builder.ToTable("LABTESTDEF");
            builder.HasKey(nameof(AtlasModel.LaboratoryTestDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsMicrobiologyTest)).HasColumnName("ISMICROBIOLOGYTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.ResultType)).HasColumnName("RESULTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsRestrictedTest)).HasColumnName("ISRESTRICTEDTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsSexControl)).HasColumnName("ISSEXCONTROL");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsPanel)).HasColumnName("ISPANEL");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsSat)).HasColumnName("ISSAT");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsSubTest)).HasColumnName("ISSUBTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsPrintEveryPage)).HasColumnName("ISPRINTEVERYPAGE");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.RoundValue)).HasColumnName("ROUNDVALUE");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsMoleculerTest)).HasColumnName("ISMOLECULERTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.SexControl)).HasColumnName("SEXCONTROL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.ResultUnit)).HasColumnName("RESULTUNIT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsHeader)).HasColumnName("ISHEADER");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsMultiReference)).HasColumnName("ISMULTIREFERENCE");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsLoad)).HasColumnName("ISLOAD");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.ReasonForPassive)).HasColumnName("REASONFORPASSIVE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TabOrder)).HasColumnName("TABORDER");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsPassiveNow)).HasColumnName("ISPASSIVENOW");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.DurationValue)).HasColumnName("DURATIONVALUE");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsDurationControl)).HasColumnName("ISDURATIONCONTROL");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsBoundedTest)).HasColumnName("ISBOUNDEDTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.Is24HourTest)).HasColumnName("IS24HOURTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.PriceCoefficient)).HasColumnName("PRICECOEFFICIENT");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.PrintInOneReport)).HasColumnName("PRINTINONEREPORT");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.SendByRequestDoctor)).HasColumnName("SENDBYREQUESTDOCTOR");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.RequiresDiabetesForm)).HasColumnName("REQUIRESDIABETESFORM");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.NotLISTest)).HasColumnName("NOTLISTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.RequiresBinaryScanForm)).HasColumnName("REQUIRESBINARYSCANFORM");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.RequiresTripleTestForm)).HasColumnName("REQUIRESTRIPLETESTFORM");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.RequiresUreaBreathTestReport)).HasColumnName("REQUIRESUREABREATHTESTREPORT");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TabDescription)).HasColumnName("TABDESCRIPTION").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.SendOtherResultsToMedula)).HasColumnName("SENDOTHERRESULTSTOMEDULA");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.FreeLOINCCode)).HasColumnName("FREELOINCCODE");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.IsGroupTest)).HasColumnName("ISGROUPTEST");
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TestDescription)).HasColumnName("TESTDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TestUnitRef)).HasColumnName("TESTUNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.EnvironmentRef)).HasColumnName("ENVIRONMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TestTubeRef)).HasColumnName("TESTTUBE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TestTypeRef)).HasColumnName("TESTTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TestSubTypeRef)).HasColumnName("TESTSUBTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.RequestFormTabRef)).HasColumnName("REQUESTFORMTAB").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.BranchRef)).HasColumnName("BRANCH").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.TahlilTipiRef)).HasColumnName("TAHLILTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryTestDefinition.SexRef)).HasColumnName("SEX").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}