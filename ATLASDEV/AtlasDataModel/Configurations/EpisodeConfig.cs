using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeConfig : IEntityTypeConfiguration<AtlasModel.Episode>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Episode> builder)
        {
            builder.ToTable("EPISODE");
            builder.HasKey(nameof(AtlasModel.Episode.ObjectId));
            builder.Property(nameof(AtlasModel.Episode.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Episode.DentalExaminationFile)).HasColumnName("DENTALEXAMINATIONFILE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.DocumentDate)).HasColumnName("DOCUMENTDATE");
            builder.Property(nameof(AtlasModel.Episode.PatientFolder)).HasColumnName("PATIENTFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ContinuousDrugs)).HasColumnName("CONTINUOUSDRUGS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.OpeningDate)).HasColumnName("OPENINGDATE");
            builder.Property(nameof(AtlasModel.Episode.Heigth)).HasColumnName("HEIGTH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Episode.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Episode.Complaint)).HasColumnName("COMPLAINT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.Episode.ClosedByMorgue)).HasColumnName("CLOSEDBYMORGUE");
            builder.Property(nameof(AtlasModel.Episode.ClosingDate)).HasColumnName("CLOSINGDATE");
            builder.Property(nameof(AtlasModel.Episode.DocumentNumber)).HasColumnName("DOCUMENTNUMBER").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.Episode.PatientFamilyHistory)).HasColumnName("PATIENTFAMILYHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.Priority)).HasColumnName("PRIORITY");
            builder.Property(nameof(AtlasModel.Episode.Habits)).HasColumnName("HABITS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.PatientHistory)).HasColumnName("PATIENTHISTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.PatientStatus)).HasColumnName("PATIENTSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Episode.HealthCommitteeStartDate)).HasColumnName("HEALTHCOMMITTEESTARTDATE");
            builder.Property(nameof(AtlasModel.Episode.HospitalProtocolNo)).HasColumnName("HOSPITALPROTOCOLNO");
            builder.Property(nameof(AtlasModel.Episode.sourceDispatchObjID)).HasColumnName("SOURCEDISPATCHOBJID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.SystemQuery)).HasColumnName("SYSTEMQUERY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ImportantPatientInfo)).HasColumnName("IMPORTANTPATIENTINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.PhysicalExamination)).HasColumnName("PHYSICALEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ExaminationSummary)).HasColumnName("EXAMINATIONSUMMARY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.AdmissionResource)).HasColumnName("ADMISSIONRESOURCE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Episode.IsQuotaUsed)).HasColumnName("ISQUOTAUSED");
            builder.Property(nameof(AtlasModel.Episode.DecisionAndAction)).HasColumnName("DECISIONANDACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.PatientStory)).HasColumnName("PATIENTSTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.IsNewBorn)).HasColumnName("ISNEWBORN");
            builder.Property(nameof(AtlasModel.Episode.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.PayerRef)).HasColumnName("PAYER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.MainDiagnoseRef)).HasColumnName("MAINDIAGNOSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.FoundationCityRef)).HasColumnName("FOUNDATIONCITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.OldPatientRef)).HasColumnName("OLDPATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.MainSpecialityRef)).HasColumnName("MAINSPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.RelationshipRef)).HasColumnName("RELATIONSHIP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.BedRef)).HasColumnName("BED").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ReasonForExaminationRef)).HasColumnName("REASONFOREXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ParticipationTypeRef)).HasColumnName("PARTICIPATIONTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.EmergencyPatientStatusInfoRef)).HasColumnName("EMERGENCYPATIENTSTATUSINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.MedulaSigortaliTuruRef)).HasColumnName("MEDULASIGORTALITURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Episode.ProtocolRef)).HasColumnName("PROTOCOL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.PatientRef).IsRequired(true);
            builder.HasOne(t => t.Payer).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.PayerRef).IsRequired(false);
            builder.HasOne(t => t.MainDiagnose).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.MainDiagnoseRef).IsRequired(false);
            builder.HasOne(t => t.OldPatient).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.OldPatientRef).IsRequired(false);
            builder.HasOne(t => t.Bed).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.BedRef).IsRequired(false);
            builder.HasOne(t => t.ReasonForExamination).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.ReasonForExaminationRef).IsRequired(false);
            builder.HasOne(t => t.EmergencyPatientStatusInfo).WithOne().HasForeignKey<AtlasModel.Episode>(x => x.EmergencyPatientStatusInfoRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.SubActionProcedures).WithOne(x => x.Episode).HasForeignKey(x => x.EpisodeRef);
            builder.HasMany(t => t.SubActionMaterials).WithOne(x => x.Episode).HasForeignKey(x => x.EpisodeRef);
            builder.HasMany(t => t.EpisodeActions).WithOne(x => x.Episode).HasForeignKey(x => x.EpisodeRef);
            #endregion Child Relations
        }
    }
}