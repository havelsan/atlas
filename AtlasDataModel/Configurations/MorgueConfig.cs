using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MorgueConfig : IEntityTypeConfiguration<AtlasModel.Morgue>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Morgue> builder)
        {
            builder.ToTable("MORGUE");
            builder.HasKey(nameof(AtlasModel.Morgue.ObjectId));
            builder.Property(nameof(AtlasModel.Morgue.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Morgue.ReasonofReturn)).HasColumnName("REASONOFRETURN").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.PhoneNumberOfAdmitted)).HasColumnName("PHONENUMBEROFADMITTED").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Morgue.CancelledByMasterAction)).HasColumnName("CANCELLEDBYMASTERACTION");
            builder.Property(nameof(AtlasModel.Morgue.IsOutRequest)).HasColumnName("ISOUTREQUEST");
            builder.Property(nameof(AtlasModel.Morgue.MorgueCupboardNo)).HasColumnName("MORGUECUPBOARDNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.GraveyardPlotNo)).HasColumnName("GRAVEYARDPLOTNO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Morgue.DiplomaNo)).HasColumnName("DIPLOMANO");
            builder.Property(nameof(AtlasModel.Morgue.DeathReportNo)).HasColumnName("DEATHREPORTNO");
            builder.Property(nameof(AtlasModel.Morgue.DateOfSentToGrave)).HasColumnName("DATEOFSENTTOGRAVE");
            builder.Property(nameof(AtlasModel.Morgue.CitizenshipNoOfAdmitted)).HasColumnName("CITIZENSHIPNOOFADMITTED").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Morgue.FoundationToFixDeath)).HasColumnName("FOUNDATIONTOFIXDEATH").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Morgue.PhoneNumberOfAdmittedFrom)).HasColumnName("PHONENUMBEROFADMITTEDFROM").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Morgue.ExternalDoctorFixed)).HasColumnName("EXTERNALDOCTORFIXED").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Morgue.DateOfDeathReport)).HasColumnName("DATEOFDEATHREPORT");
            builder.Property(nameof(AtlasModel.Morgue.AddressOfAdmittedFrom)).HasColumnName("ADDRESSOFADMITTEDFROM").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Morgue.DeathPlace)).HasColumnName("DEATHPLACE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Morgue.DeathBodyAdmittedFrom)).HasColumnName("DEATHBODYADMITTEDFROM").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.QuarantineCupboardNo)).HasColumnName("QUARANTINECUPBOARDNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.DeathOrderNo)).HasColumnName("DEATHORDERNO");
            builder.Property(nameof(AtlasModel.Morgue.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.Morgue.MaterialsAdmittedTo)).HasColumnName("MATERIALSADMITTEDTO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.AddresOfAdmitted)).HasColumnName("ADDRESOFADMITTED").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Morgue.OutDeathOrderNo)).HasColumnName("OUTDEATHORDERNO");
            builder.Property(nameof(AtlasModel.Morgue.DateTimeOfDeath)).HasColumnName("DATETIMEOFDEATH");
            builder.Property(nameof(AtlasModel.Morgue.DeathBodyAdmittedTo)).HasColumnName("DEATHBODYADMITTEDTO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.CitizenshipNoOfAdmittedFrom)).HasColumnName("CITIZENSHIPNOOFADMITTEDFROM").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Morgue.StatisticalDeathReason)).HasColumnName("STATISTICALDEATHREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Morgue.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.TombVillage)).HasColumnName("TOMBVILLAGE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.ObjectsFromPatient)).HasColumnName("OBJECTSFROMPATIENT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Morgue.ExternalDoctorFixedUniqueNo)).HasColumnName("EXTERNALDOCTORFIXEDUNIQUENO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.InjuryExisting)).HasColumnName("INJURYEXISTING");
            builder.Property(nameof(AtlasModel.Morgue.InjuryDate)).HasColumnName("INJURYDATE");
            builder.Property(nameof(AtlasModel.Morgue.DeathReasonEvaluation)).HasColumnName("DEATHREASONEVALUATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.Note)).HasColumnName("NOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.SendToMorgue)).HasColumnName("SENDTOMORGUE");
            builder.Property(nameof(AtlasModel.Morgue.AutopsyToDo)).HasColumnName("AUTOPSYTODO");
            builder.Property(nameof(AtlasModel.Morgue.PatientCameEx)).HasColumnName("PATIENTCAMEEX");
            builder.Property(nameof(AtlasModel.Morgue.ExternalSenderDoctorToMorgue)).HasColumnName("EXTERNALSENDERDOCTORTOMORGUE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Morgue.ExternalSenderDoctorMorgueUnR)).HasColumnName("EXTERNALSENDERDOCTORMORGUEUNR").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Morgue.SKRSDeathPlaceRef)).HasColumnName("SKRSDEATHPLACE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.SKRSDeathReasonRef)).HasColumnName("SKRSDEATHREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.SKRSInjuryPlaceRef)).HasColumnName("SKRSINJURYPLACE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.SenderDoctorRef)).HasColumnName("SENDERDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.ReasonForDeathRef)).HasColumnName("REASONFORDEATH").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.DoctorFixedRef)).HasColumnName("DOCTORFIXED").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.CupboardRef)).HasColumnName("CUPBOARD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.DiedClinicRef)).HasColumnName("DIEDCLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.DeliveredByRef)).HasColumnName("DELIVEREDBY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.NurseRef)).HasColumnName("NURSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.MernisDeathReasonsRef)).HasColumnName("MERNISDEATHREASONS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.MaterialsAdmittedFromRef)).HasColumnName("MATERIALSADMITTEDFROM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.SKRSTombCityRef)).HasColumnName("SKRSTOMBCITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Morgue.SKRSTombTownRef)).HasColumnName("SKRSTOMBTOWN").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SenderDoctor).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.SenderDoctorRef).IsRequired(false);
            builder.HasOne(t => t.DoctorFixed).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.DoctorFixedRef).IsRequired(false);
            builder.HasOne(t => t.DiedClinic).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.DiedClinicRef).IsRequired(false);
            builder.HasOne(t => t.DeliveredBy).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.DeliveredByRef).IsRequired(false);
            builder.HasOne(t => t.Nurse).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.NurseRef).IsRequired(false);
            builder.HasOne(t => t.MaterialsAdmittedFrom).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.MaterialsAdmittedFromRef).IsRequired(false);
            builder.HasOne(t => t.SKRSTombTown).WithOne().HasForeignKey<AtlasModel.Morgue>(x => x.SKRSTombTownRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}