using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyTestConfig : IEntityTypeConfiguration<AtlasModel.RadiologyTest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiologyTest> builder)
        {
            builder.ToTable("RADIOLOGYTEST");
            builder.HasKey(nameof(AtlasModel.RadiologyTest.ObjectId));
            builder.Property(nameof(AtlasModel.RadiologyTest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiologyTest.AdditionalRequest)).HasColumnName("ADDITIONALREQUEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.OwnerType)).HasColumnName("OWNERTYPE").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.RadiologyTest.TestDate)).HasColumnName("TESTDATE");
            builder.Property(nameof(AtlasModel.RadiologyTest.IsMessageInPACS)).HasColumnName("ISMESSAGEINPACS");
            builder.Property(nameof(AtlasModel.RadiologyTest.TestToothNumber)).HasColumnName("TESTTOOTHNUMBER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.DisTaahhutNo)).HasColumnName("DISTAAHHUTNO");
            builder.Property(nameof(AtlasModel.RadiologyTest.IsGunubirlikTakip)).HasColumnName("ISGUNUBIRLIKTAKIP");
            builder.Property(nameof(AtlasModel.RadiologyTest.BodyPosition)).HasColumnName("BODYPOSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.BodySite)).HasColumnName("BODYSITE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.Check)).HasColumnName("CHECK");
            builder.Property(nameof(AtlasModel.RadiologyTest.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.ReportTxt)).HasColumnName("REPORTTXT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.RadiologyTest.ReportDate)).HasColumnName("REPORTDATE");
            builder.Property(nameof(AtlasModel.RadiologyTest.RequestDate)).HasColumnName("REQUESTDATE");
            builder.Property(nameof(AtlasModel.RadiologyTest.TechnicianNote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.DentalPosition)).HasColumnName("DENTALPOSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.Anomali)).HasColumnName("ANOMALI");
            builder.Property(nameof(AtlasModel.RadiologyTest.IsProcedureRepeated)).HasColumnName("ISPROCEDUREREPEATED");
            builder.Property(nameof(AtlasModel.RadiologyTest.ToothNumber)).HasColumnName("TOOTHNUMBER");
            builder.Property(nameof(AtlasModel.RadiologyTest.AccessionNo)).HasColumnName("ACCESSIONNO");
            builder.Property(nameof(AtlasModel.RadiologyTest.birim)).HasColumnName("BIRIM");
            builder.Property(nameof(AtlasModel.RadiologyTest.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.IsResultSeen)).HasColumnName("ISRESULTSEEN");
            builder.Property(nameof(AtlasModel.RadiologyTest.PreDiagnosis)).HasColumnName("PREDIAGNOSIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.GeneralDescription)).HasColumnName("GENERALDESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.PhysicalExamination)).HasColumnName("PHYSICALEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.PatientHistory)).HasColumnName("PATIENTHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.Complaint)).HasColumnName("COMPLAINT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.MTSConclusion)).HasColumnName("MTSCONCLUSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.IsMessageInTELETIP)).HasColumnName("ISMESSAGEINTELETIP");
            builder.Property(nameof(AtlasModel.RadiologyTest.ACKMessagePACS)).HasColumnName("ACKMESSAGEPACS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.ACKMessageTELETIP)).HasColumnName("ACKMESSAGETELETIP").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.ImageQualityAssesment)).HasColumnName("IMAGEQUALITYASSESMENT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.RadiographyTechnique)).HasColumnName("RADIOGRAPHYTECHNIQUE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.ComparisonInfo)).HasColumnName("COMPARISONINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.Results)).HasColumnName("RESULTS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.IsMessageInExternalHIS)).HasColumnName("ISMESSAGEINEXTERNALHIS");
            builder.Property(nameof(AtlasModel.RadiologyTest.ACKMessageExternalHIS)).HasColumnName("ACKMESSAGEEXTERNALHIS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.RadiologyTest.RequestReasonAssesment)).HasColumnName("REQUESTREASONASSESMENT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.ContrastType)).HasColumnName("CONTRASTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RadiologyTest.ReportedByRef)).HasColumnName("REPORTEDBY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.ApprovedByRef)).HasColumnName("APPROVEDBY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.RejectReasonRef)).HasColumnName("REJECTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.RepeatReasonRef)).HasColumnName("REPEATREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.EquipmentRef)).HasColumnName("EQUIPMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.SagSolRef)).HasColumnName("SAGSOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyTest.RadiologyAdditionalReportRef)).HasColumnName("RADIOLOGYADDITIONALREPORT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ReportedBy).WithOne().HasForeignKey<AtlasModel.RadiologyTest>(x => x.ReportedByRef).IsRequired(false);
            builder.HasOne(t => t.ApprovedBy).WithOne().HasForeignKey<AtlasModel.RadiologyTest>(x => x.ApprovedByRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.RadiologyTest>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.RadiologyTest>(x => x.OzelDurumRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}