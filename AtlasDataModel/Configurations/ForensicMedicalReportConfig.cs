using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ForensicMedicalReportConfig : IEntityTypeConfiguration<AtlasModel.ForensicMedicalReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ForensicMedicalReport> builder)
        {
            builder.ToTable("FORENSICMEDICALREPORT");
            builder.HasKey(nameof(AtlasModel.ForensicMedicalReport.ObjectId));
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.DocumentDate)).HasColumnName("DOCUMENTDATE");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.DocumentNumber)).HasColumnName("DOCUMENTNUMBER").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches5)).HasColumnName("ATTACHES5").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches3)).HasColumnName("ATTACHES3");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches4)).HasColumnName("ATTACHES4");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.NoNeed)).HasColumnName("NONEED");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Need)).HasColumnName("NEED");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ReasonExaminationReportType)).HasColumnName("REASONEXAMINATIONREPORTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PsychiatricConsultation)).HasColumnName("PSYCHIATRICCONSULTATION");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches1)).HasColumnName("ATTACHES1");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches2)).HasColumnName("ATTACHES2");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ArterialBloodPresure)).HasColumnName("ARTERIALBLOODPRESURE");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Pulse)).HasColumnName("PULSE");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.HeadNeck)).HasColumnName("HEADNECK");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Chest)).HasColumnName("CHEST");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Abdominal)).HasColumnName("ABDOMINAL");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Back)).HasColumnName("BACK");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.UpperExtrimity)).HasColumnName("UPPEREXTRIMITY");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.LowerExtremity)).HasColumnName("LOWEREXTREMITY");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.GenitalArea)).HasColumnName("GENITALAREA");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PermissionDepartment)).HasColumnName("PERMISSIONDEPARTMENT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Sex)).HasColumnName("SEX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ResonOfDispatch)).HasColumnName("RESONOFDISPATCH").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Explanation1)).HasColumnName("EXPLANATION1").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Explanation2)).HasColumnName("EXPLANATION2").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PropertiesOfLesions)).HasColumnName("PROPERTIESOFLESIONS").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.SystemFindings)).HasColumnName("SYSTEMFINDINGS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.OtherReasonExamination)).HasColumnName("OTHERREASONEXAMINATION").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PatientIdentity)).HasColumnName("PATIENTIDENTITY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.HistoryOfEvent)).HasColumnName("HISTORYOFEVENT").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PatientComplaints)).HasColumnName("PATIENTCOMPLAINTS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.MedicalHistory)).HasColumnName("MEDICALHISTORY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ConsultationRequested)).HasColumnName("CONSULTATIONREQUESTED").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ReportImage)).HasColumnName("REPORTIMAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Respitory)).HasColumnName("RESPITORY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.CentralNervousSystem)).HasColumnName("CENTRALNERVOUSSYSTEM");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.CardiovascularSystem)).HasColumnName("CARDIOVASCULARSYSTEM");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.RespiratorySys)).HasColumnName("RESPIRATORYSYS");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.UrogenitalSys)).HasColumnName("UROGENITALSYS");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.SkeletalSys)).HasColumnName("SKELETALSYS");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.SensoryOrgansSys)).HasColumnName("SENSORYORGANSSYS");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.DigestiveSys)).HasColumnName("DIGESTIVESYS");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.GeneralConditionOfPatient)).HasColumnName("GENERALCONDITIONOFPATIENT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.LaboratoryProcedures)).HasColumnName("LABORATORYPROCEDURES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Awareness)).HasColumnName("AWARENESS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PupilProperties)).HasColumnName("PUPILPROPERTIES").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.LightReflex)).HasColumnName("LIGHTREFLEX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.TendonReflexes)).HasColumnName("TENDONREFLEXES").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.NoEvidancePsycho)).HasColumnName("NOEVIDANCEPSYCHO");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PyschiatricExamination)).HasColumnName("PYSCHIATRICEXAMINATION");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ExaminationDate)).HasColumnName("EXAMINATIONDATE");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.AttendantNameSurname)).HasColumnName("ATTENDANTNAMESURNAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.SuitableEnvironment1)).HasColumnName("SUITABLEENVIRONMENT1");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.SuitableEnvironment2)).HasColumnName("SUITABLEENVIRONMENT2");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PeopleInExamination1)).HasColumnName("PEOPLEINEXAMINATION1");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PeopleInExamination2)).HasColumnName("PEOPLEINEXAMINATION2");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PeopleInExamination3)).HasColumnName("PEOPLEINEXAMINATION3");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.PeopleInExamination4)).HasColumnName("PEOPLEINEXAMINATION4");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ClothesOfPatient1)).HasColumnName("CLOTHESOFPATIENT1");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ClothesOfPatient2)).HasColumnName("CLOTHESOFPATIENT2");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ClothesOfPatient3)).HasColumnName("CLOTHESOFPATIENT3");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ChkLabProcedures)).HasColumnName("CHKLABPROCEDURES");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ChkDirectGraph)).HasColumnName("CHKDIRECTGRAPH");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ChkBTMR)).HasColumnName("CHKBTMR");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ChkUltrasonography)).HasColumnName("CHKULTRASONOGRAPHY");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ChkBiopsy)).HasColumnName("CHKBIOPSY");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ChkOther)).HasColumnName("CHKOTHER");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches2Text)).HasColumnName("ATTACHES2TEXT").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches3Text1)).HasColumnName("ATTACHES3TEXT1").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.Attaches3Text2)).HasColumnName("ATTACHES3TEXT2").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.UncertainReport)).HasColumnName("UNCERTAINREPORT");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.CertainReport)).HasColumnName("CERTAINREPORT");
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.SenderChairRef)).HasColumnName("SENDERCHAIR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ForensicMedicalReport.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.ForensicMedicalReport>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}