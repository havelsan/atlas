using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedureDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureDefinition> builder)
        {
            builder.ToTable("PROCEDUREDEFINITION");
            builder.HasKey(nameof(AtlasModel.ProcedureDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.Code)).HasColumnName("CODE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.Chargable)).HasColumnName("CHARGABLE");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.EnglishName)).HasColumnName("ENGLISHNAME").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.Qref)).HasColumnName("QREF").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.SUTAppendix)).HasColumnName("SUTAPPENDIX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.OnamFormuIste)).HasColumnName("ONAMFORMUISTE");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.CreateInMedulaDontSendState)).HasColumnName("CREATEINMEDULADONTSENDSTATE");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.PreProcedureEntryNecessity)).HasColumnName("PREPROCEDUREENTRYNECESSITY");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.MedulaProcedureType)).HasColumnName("MEDULAPROCEDURETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.MedulaReportNecessity)).HasColumnName("MEDULAREPORTNECESSITY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.DailyMedulaProvisionNecessity)).HasColumnName("DAILYMEDULAPROVISIONNECESSITY");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.GILCode)).HasColumnName("GILCODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.GILPoint)).HasColumnName("GILPOINT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.DontBlockInvoice)).HasColumnName("DONTBLOCKINVOICE");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.SUTCode)).HasColumnName("SUTCODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.QuickEntryAllowed)).HasColumnName("QUICKENTRYALLOWED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ReportSelectionRequired)).HasColumnName("REPORTSELECTIONREQUIRED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ExternalId)).HasColumnName("EXTERNALID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.IsDescriptionNeeded)).HasColumnName("ISDESCRIPTIONNEEDED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ParticipationProcedure)).HasColumnName("PARTICIPATIONPROCEDURE");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.GILName)).HasColumnName("GILNAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.RepetitionQueryNeeded)).HasColumnName("REPETITIONQUERYNEEDED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.IsResultNeeded)).HasColumnName("ISRESULTNEEDED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ProcedureType)).HasColumnName("PROCEDURETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.RightLeftInfoNeeded)).HasColumnName("RIGHTLEFTINFONEEDED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.IsVisible)).HasColumnName("ISVISIBLE");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ControlDayCount)).HasColumnName("CONTROLDAYCOUNT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.DailyDayCount)).HasColumnName("DAILYDAYCOUNT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.EmergencyDayCount)).HasColumnName("EMERGENCYDAYCOUNT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ExaminationDayCount)).HasColumnName("EXAMINATIONDAYCOUNT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ForbiddenForControl)).HasColumnName("FORBIDDENFORCONTROL");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ForbiddenForDaily)).HasColumnName("FORBIDDENFORDAILY");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ForbiddenForEmergency)).HasColumnName("FORBIDDENFOREMERGENCY");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ForbiddenForExamination)).HasColumnName("FORBIDDENFOREXAMINATION");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ForbiddenForInpatient)).HasColumnName("FORBIDDENFORINPATIENT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.HUVCode)).HasColumnName("HUVCODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ProcedureDefinition.HUVPoint)).HasColumnName("HUVPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.SUTPoint)).HasColumnName("SUTPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ExternalOperation)).HasColumnName("EXTERNALOPERATION");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.PathologyOperationNeeded)).HasColumnName("PATHOLOGYOPERATIONNEEDED");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.QualifiedMedicalProcess)).HasColumnName("QUALIFIEDMEDICALPROCESS");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.InpatientDayCount)).HasColumnName("INPATIENTDAYCOUNT");
            builder.Property(nameof(AtlasModel.ProcedureDefinition.MedulaProvisionTedaviTipiRef)).HasColumnName("MEDULAPROVISIONTEDAVITIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.RevenueSubAccountCodeRef)).HasColumnName("REVENUESUBACCOUNTCODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ProcedureTreeRef)).HasColumnName("PROCEDURETREE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.TedaviTipiRef)).HasColumnName("TEDAVITIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.ProvizyonTipiRef)).HasColumnName("PROVIZYONTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.TakipTipiRef)).HasColumnName("TAKIPTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.PackageProcedureRef)).HasColumnName("PACKAGEPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.SKRSLoincKoduRef)).HasColumnName("SKRSLOINCKODU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureDefinition.GILDefinitionRef)).HasColumnName("GILDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RevenueSubAccountCode).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(x => x.RevenueSubAccountCodeRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureTree).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(x => x.ProcedureTreeRef).IsRequired(true);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.PackageProcedure).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(x => x.PackageProcedureRef).IsRequired(false);
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(x => x.DoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}