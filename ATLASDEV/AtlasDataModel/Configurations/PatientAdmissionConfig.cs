using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientAdmissionConfig : IEntityTypeConfiguration<AtlasModel.PatientAdmission>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientAdmission> builder)
        {
            builder.ToTable("PATIENTADMISSION");
            builder.HasKey(nameof(AtlasModel.PatientAdmission.ObjectId));
            builder.Property(nameof(AtlasModel.PatientAdmission.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientAdmission.Email)).HasColumnName("EMAIL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientAdmission.DispatchType)).HasColumnName("DISPATCHTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmission.IsFiresFromPACorrection)).HasColumnName("ISFIRESFROMPACORRECTION");
            builder.Property(nameof(AtlasModel.PatientAdmission.IsCorrected)).HasColumnName("ISCORRECTED");
            builder.Property(nameof(AtlasModel.PatientAdmission.ProvisionNo)).HasColumnName("PROVISIONNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientAdmission.DocumentNumber)).HasColumnName("DOCUMENTNUMBER").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.PatientAdmission.Arrested)).HasColumnName("ARRESTED");
            builder.Property(nameof(AtlasModel.PatientAdmission.DocumentDate)).HasColumnName("DOCUMENTDATE");
            builder.Property(nameof(AtlasModel.PatientAdmission.AdmissionStatus)).HasColumnName("ADMISSIONSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmission.HCModeOfPayment)).HasColumnName("HCMODEOFPAYMENT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmission.RealDisabled)).HasColumnName("REALDISABLED");
            builder.Property(nameof(AtlasModel.PatientAdmission.Sevkli)).HasColumnName("SEVKLI");
            builder.Property(nameof(AtlasModel.PatientAdmission.takipAlCevap)).HasColumnName("TAKIPALCEVAP");
            builder.Property(nameof(AtlasModel.PatientAdmission.takipAlHataMesaji)).HasColumnName("TAKIPALHATAMESAJI");
            builder.Property(nameof(AtlasModel.PatientAdmission.MedulaESevkNo)).HasColumnName("MEDULAESEVKNO");
            builder.Property(nameof(AtlasModel.PatientAdmission.RelatedProvision)).HasColumnName("RELATEDPROVISION");
            builder.Property(nameof(AtlasModel.PatientAdmission.Donor)).HasColumnName("DONOR");
            builder.Property(nameof(AtlasModel.PatientAdmission.DispatchedConsultationDef)).HasColumnName("DISPATCHEDCONSULTATIONDEF").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PatientAdmission.PAStatus)).HasColumnName("PASTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmission.IsNewBorn)).HasColumnName("ISNEWBORN");
            builder.Property(nameof(AtlasModel.PatientAdmission.Sevkli112)).HasColumnName("SEVKLI112");
            builder.Property(nameof(AtlasModel.PatientAdmission.Emergency112RefNo)).HasColumnName("EMERGENCY112REFNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientAdmission.ImportantPAInfo)).HasColumnName("IMPORTANTPAINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.ResultQueueNumber)).HasColumnName("RESULTQUEUENUMBER");
            builder.Property(nameof(AtlasModel.PatientAdmission.DispatchEmergencyCons)).HasColumnName("DISPATCHEMERGENCYCONS");
            builder.Property(nameof(AtlasModel.PatientAdmission.BeneficiaryName)).HasColumnName("BENEFICIARYNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientAdmission.BeneficiaryUniqueRefNo)).HasColumnName("BENEFICIARYUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.PatientAdmission.DeathApplication)).HasColumnName("DEATHAPPLICATION");
            builder.Property(nameof(AtlasModel.PatientAdmission.AdmissionQueueNumber)).HasColumnName("ADMISSIONQUEUENUMBER");
            builder.Property(nameof(AtlasModel.PatientAdmission.PatientClassGroup)).HasColumnName("PATIENTCLASSGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmission.ApplicationReason)).HasColumnName("APPLICATIONREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmission.MedulaVakaTarihi)).HasColumnName("MEDULAVAKATARIHI");
            builder.Property(nameof(AtlasModel.PatientAdmission.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.PatientAdmission.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.RecordUserIDRef)).HasColumnName("RECORDUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.ProtocolRef)).HasColumnName("PROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.HCRequestReasonRef)).HasColumnName("HCREQUESTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.PayerRef)).HasColumnName("PAYER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.SKRSOlayAfetBilgisiRef)).HasColumnName("SKRSOLAYAFETBILGISI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.SKRSVatandasTipiRef)).HasColumnName("SKRSVATANDASTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.PriorityStatusRef)).HasColumnName("PRIORITYSTATUS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.MedulaSigortaliTuruRef)).HasColumnName("MEDULASIGORTALITURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.PA_AddressRef)).HasColumnName("PA_ADDRESS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.AdmissionAppointmentRef)).HasColumnName("ADMISSIONAPPOINTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.BuildingRef)).HasColumnName("BUILDING").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.PoliclinicRef)).HasColumnName("POLICLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.PatientMedulaHastaKabulRef)).HasColumnName("PATIENTMEDULAHASTAKABUL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.ProvisionRequestRef)).HasColumnName("PROVISIONREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.SKRSVakaTuruRef)).HasColumnName("SKRSVAKATURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.EmergencyInterventionRef)).HasColumnName("EMERGENCYINTERVENTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.OldTriageRef)).HasColumnName("OLDTRIAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.TriageRef)).HasColumnName("TRIAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.MedulaIstisnaiHalRef)).HasColumnName("MEDULAISTISNAIHAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.SKRSAdliVakaRef)).HasColumnName("SKRSADLIVAKA").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.EDisabledReportRef)).HasColumnName("EDISABLEDREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAdmission.EStatusNotRepCommitteeObjRef)).HasColumnName("ESTATUSNOTREPCOMMITTEEOBJ").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.RecordUserID).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.RecordUserIDRef).IsRequired(false);
            builder.HasOne(t => t.HCRequestReason).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.HCRequestReasonRef).IsRequired(false);
            builder.HasOne(t => t.Payer).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.PayerRef).IsRequired(false);
            builder.HasOne(t => t.SKRSOlayAfetBilgisi).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.SKRSOlayAfetBilgisiRef).IsRequired(false);
            builder.HasOne(t => t.PA_Address).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.PA_AddressRef).IsRequired(false);
            builder.HasOne(t => t.AdmissionAppointment).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.AdmissionAppointmentRef).IsRequired(false);
            builder.HasOne(t => t.Policlinic).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.PoliclinicRef).IsRequired(false);
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.DepartmentRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.ProcedureDoctorRef).IsRequired(false);
            builder.HasOne(t => t.EmergencyIntervention).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.EmergencyInterventionRef).IsRequired(false);
            builder.HasOne(t => t.EDisabledReport).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.EDisabledReportRef).IsRequired(false);
            builder.HasOne(t => t.EStatusNotRepCommitteeObj).WithOne().HasForeignKey<AtlasModel.PatientAdmission>(x => x.EStatusNotRepCommitteeObjRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}