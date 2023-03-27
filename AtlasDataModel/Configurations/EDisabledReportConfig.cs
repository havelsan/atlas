using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EDisabledReportConfig : IEntityTypeConfiguration<AtlasModel.EDisabledReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EDisabledReport> builder)
        {
            builder.ToTable("EDISABLEDREPORT");
            builder.HasKey(nameof(AtlasModel.EDisabledReport.ObjectId));
            builder.Property(nameof(AtlasModel.EDisabledReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EDisabledReport.ApplicationExplanation)).HasColumnName("APPLICATIONEXPLANATION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.EDisabledReport.PatientAppId)).HasColumnName("PATIENTAPPID").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.EDisabledReport.ApplicationReason)).HasColumnName("APPLICATIONREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.ApplicationType)).HasColumnName("APPLICATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.CorporateApplicationType)).HasColumnName("CORPORATEAPPLICATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.PersonalApplicationType)).HasColumnName("PERSONALAPPLICATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.TerrorAccidentInjuryAppType)).HasColumnName("TERRORACCIDENTINJURYAPPTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.TerrorAccidentInjuryAppReason)).HasColumnName("TERRORACCIDENTINJURYAPPREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.ApplicationCouncilSituation)).HasColumnName("APPLICATIONCOUNCILSITUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EDisabledReport.IsCozgerReport)).HasColumnName("ISCOZGERREPORT");
        }
    }
}