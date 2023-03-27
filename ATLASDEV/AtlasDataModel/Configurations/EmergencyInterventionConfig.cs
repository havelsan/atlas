using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EmergencyInterventionConfig : IEntityTypeConfiguration<AtlasModel.EmergencyIntervention>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EmergencyIntervention> builder)
        {
            builder.ToTable("EMERGENCYINTERVENTION");
            builder.HasKey(nameof(AtlasModel.EmergencyIntervention.ObjectId));
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.PatientHistoryDescription)).HasColumnName("PATIENTHISTORYDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.BringerAddress)).HasColumnName("BRINGERADDRESS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EmergencyIntervention.BringerPhone)).HasColumnName("BRINGERPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ContinuousDrugs)).HasColumnName("CONTINUOUSDRUGS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.Habits)).HasColumnName("HABITS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.PatientHistory)).HasColumnName("PATIENTHISTORY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EmergencyIntervention.BringerName)).HasColumnName("BRINGERNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.EmergencyIntervention.Picture)).HasColumnName("PICTURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.IsTraumaticPatient)).HasColumnName("ISTRAUMATICPATIENT");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.EnteranceTime)).HasColumnName("ENTERANCETIME");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.InPatientFolder)).HasColumnName("INPATIENTFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.IsEmergencyInjured)).HasColumnName("ISEMERGENCYINJURED");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.IsEmergencyDispatched)).HasColumnName("ISEMERGENCYDISPATCHED");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.DischargeTime)).HasColumnName("DISCHARGETIME");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.LastEatingInfo)).HasColumnName("LASTEATINGINFO").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.AlcoholPromile)).HasColumnName("ALCOHOLPROMILE");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.TetanusVaccine)).HasColumnName("TETANUSVACCINE");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.Complaint)).HasColumnName("COMPLAINT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ComplaintDescription)).HasColumnName("COMPLAINTDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ComplaintDuration)).HasColumnName("COMPLAINTDURATION");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.InpatientObservationTime)).HasColumnName("INPATIENTOBSERVATIONTIME");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.IsPregnant)).HasColumnName("ISPREGNANT");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.LastMenstrualPeriod)).HasColumnName("LASTMENSTRUALPERIOD");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.AllergyDescription)).HasColumnName("ALLERGYDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.InterventionStartTime)).HasColumnName("INTERVENTIONSTARTTIME");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.InterventionEndTime)).HasColumnName("INTERVENTIONENDTIME");
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ResponsibleNurseRef)).HasColumnName("RESPONSIBLENURSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.MuayeneGirisRef)).HasColumnName("MUAYENEGIRIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyIntervention.ImportantMedicalInformationRef)).HasColumnName("IMPORTANTMEDICALINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ResponsibleNurse).WithOne().HasForeignKey<AtlasModel.EmergencyIntervention>(x => x.ResponsibleNurseRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.EmergencyIntervention>(x => x.ResponsibleDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}