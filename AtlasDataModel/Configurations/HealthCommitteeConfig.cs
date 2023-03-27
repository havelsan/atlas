using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HealthCommitteeConfig : IEntityTypeConfiguration<AtlasModel.HealthCommittee>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HealthCommittee> builder)
        {
            builder.ToTable("HEALTHCOMMITTEE");
            builder.HasKey(nameof(AtlasModel.HealthCommittee.ObjectId));
            builder.Property(nameof(AtlasModel.HealthCommittee.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HealthCommittee.HealthCommitteeStartDate)).HasColumnName("HEALTHCOMMITTEESTARTDATE");
            builder.Property(nameof(AtlasModel.HealthCommittee.AutomaticallyCreated)).HasColumnName("AUTOMATICALLYCREATED");
            builder.Property(nameof(AtlasModel.HealthCommittee.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.HealthCommittee.BodyMassIndex)).HasColumnName("BODYMASSINDEX").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.HealthCommittee.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.HealthCommittee.BookNumber)).HasColumnName("BOOKNUMBER");
            builder.Property(nameof(AtlasModel.HealthCommittee.ClinicWeight)).HasColumnName("CLINICWEIGHT");
            builder.Property(nameof(AtlasModel.HealthCommittee.Unanimity)).HasColumnName("UNANIMITY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.BookCategory)).HasColumnName("BOOKCATEGORY").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.HealthCommittee.HCHeight)).HasColumnName("HCHEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.HealthCommittee.ClinicHeight)).HasColumnName("CLINICHEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.HealthCommittee.ReportDate)).HasColumnName("REPORTDATE");
            builder.Property(nameof(AtlasModel.HealthCommittee.DocumentNumber)).HasColumnName("DOCUMENTNUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.HealthCommittee.NumberOfProcedure)).HasColumnName("NUMBEROFPROCEDURE");
            builder.Property(nameof(AtlasModel.HealthCommittee.DocumentDate)).HasColumnName("DOCUMENTDATE");
            builder.Property(nameof(AtlasModel.HealthCommittee.TargetObjectID)).HasColumnName("TARGETOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.SourceObjectID)).HasColumnName("SOURCEOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.MessageID)).HasColumnName("MESSAGEID");
            builder.Property(nameof(AtlasModel.HealthCommittee.AppointmentInfo)).HasColumnName("APPOINTMENTINFO").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.HealthCommittee.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.Ration)).HasColumnName("RATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.PreDiagnosis)).HasColumnName("PREDIAGNOSIS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.HealthCommittee.NasbiTarihi)).HasColumnName("NASBITARIHI");
            builder.Property(nameof(AtlasModel.HealthCommittee.WhoPays)).HasColumnName("WHOPAYS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.HCDecisionTime)).HasColumnName("HCDECISIONTIME");
            builder.Property(nameof(AtlasModel.HealthCommittee.HCDecisionUnitOfTime)).HasColumnName("HCDECISIONUNITOFTIME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.DecisionOffer)).HasColumnName("DECISIONOFFER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.CommitteeAcceptanceStatus)).HasColumnName("COMMITTEEACCEPTANCESTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.DateOfExit)).HasColumnName("DATEOFEXIT");
            builder.Property(nameof(AtlasModel.HealthCommittee.HCWeight)).HasColumnName("HCWEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.HealthCommittee.UnsuitableForMilitaryService)).HasColumnName("UNSUITABLEFORMILITARYSERVICE");
            builder.Property(nameof(AtlasModel.HealthCommittee.FunctionRatio)).HasColumnName("FUNCTIONRATIO").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.HealthCommittee.IncomingDocumentDate)).HasColumnName("INCOMINGDOCUMENTDATE");
            builder.Property(nameof(AtlasModel.HealthCommittee.IncomingDocumentNo)).HasColumnName("INCOMINGDOCUMENTNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.HealthCommittee.IncomingReportNo)).HasColumnName("INCOMINGREPORTNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.HealthCommittee.Definition)).HasColumnName("DEFINITION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HealthCommittee.UnworkField)).HasColumnName("UNWORKFIELD").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HealthCommittee.ReportDiagnose)).HasColumnName("REPORTDIAGNOSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.QulityOfUnemployableWorks)).HasColumnName("QULITYOFUNEMPLOYABLEWORKS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HealthCommittee.IsHeavyDisabled)).HasColumnName("ISHEAVYDISABLED");
            builder.Property(nameof(AtlasModel.HealthCommittee.SendExamination)).HasColumnName("SENDEXAMINATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.HCReoprtDecision)).HasColumnName("HCREOPRTDECISION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.HealthCommitteeDecision)).HasColumnName("HEALTHCOMMITTEEDECISION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.ClinicalFindings)).HasColumnName("CLINICALFINDINGS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HealthCommittee.DegreeOfBloodRelatives)).HasColumnName("DEGREEOFBLOODRELATIVES").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HealthCommittee.UniqueRefReceiveReport)).HasColumnName("UNIQUEREFRECEIVEREPORT");
            builder.Property(nameof(AtlasModel.HealthCommittee.NameSurnameReceiveReport)).HasColumnName("NAMESURNAMERECEIVEREPORT").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.HealthCommittee.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.ExaminationUnitsHospitalsRef)).HasColumnName("EXAMINATIONUNITSHOSPITALS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.GroupNoRef)).HasColumnName("GROUPNO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.RequesterRef)).HasColumnName("REQUESTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.IntendedUseOfDisabledReportRef)).HasColumnName("INTENDEDUSEOFDISABLEDREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.HCDutyTypeRef)).HasColumnName("HCDUTYTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.AircraftTypeRef)).HasColumnName("AIRCRAFTTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HealthCommittee.HCRequestReasonRef)).HasColumnName("HCREQUESTREASON").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseHealthCommittee).WithOne().HasForeignKey<AtlasModel.BaseHealthCommittee>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.HealthCommittee>(x => x.DepartmentRef).IsRequired(false);
            builder.HasOne(t => t.ExaminationUnitsHospitals).WithOne().HasForeignKey<AtlasModel.HealthCommittee>(x => x.ExaminationUnitsHospitalsRef).IsRequired(false);
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.HealthCommittee>(x => x.DoctorRef).IsRequired(false);
            builder.HasOne(t => t.Requester).WithOne().HasForeignKey<AtlasModel.HealthCommittee>(x => x.RequesterRef).IsRequired(false);
            builder.HasOne(t => t.IntendedUseOfDisabledReport).WithOne().HasForeignKey<AtlasModel.HealthCommittee>(x => x.IntendedUseOfDisabledReportRef).IsRequired(false);
            builder.HasOne(t => t.HCRequestReason).WithOne().HasForeignKey<AtlasModel.HealthCommittee>(x => x.HCRequestReasonRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}