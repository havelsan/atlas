using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EmergencySpecialityObjectConfig : IEntityTypeConfiguration<AtlasModel.EmergencySpecialityObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EmergencySpecialityObject> builder)
        {
            builder.ToTable("EMERGENCYSPECIALITYOBJECT");
            builder.HasKey(nameof(AtlasModel.EmergencySpecialityObject.ObjectId));
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.TetanusVaccine)).HasColumnName("TETANUSVACCINE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationGood)).HasColumnName("GENERALEVALUATIONGOOD");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationMedium)).HasColumnName("GENERALEVALUATIONMEDIUM");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationBad)).HasColumnName("GENERALEVALUATIONBAD");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationPainly)).HasColumnName("GENERALEVALUATIONPAINLY");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationDispneic)).HasColumnName("GENERALEVALUATIONDISPNEIC");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationDehidrate)).HasColumnName("GENERALEVALUATIONDEHIDRATE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationSweaty)).HasColumnName("GENERALEVALUATIONSWEATY");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.GeneralEvaluationCold)).HasColumnName("GENERALEVALUATIONCOLD");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PsychologicalEvaluationNormal)).HasColumnName("PSYCHOLOGICALEVALUATIONNORMAL");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PsychologicalEvaluationAngry)).HasColumnName("PSYCHOLOGICALEVALUATIONANGRY");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PsychologicalEvaluationSad)).HasColumnName("PSYCHOLOGICALEVALUATIONSAD");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PsychologicalEvalWorried)).HasColumnName("PSYCHOLOGICALEVALWORRIED");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PsychologicalEvalIrrelevant)).HasColumnName("PSYCHOLOGICALEVALIRRELEVANT");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PsychologicalEvaluationOther)).HasColumnName("PSYCHOLOGICALEVALUATIONOTHER").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.HeadAche)).HasColumnName("HEADACHE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainPlace)).HasColumnName("PAINPLACE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainDegree)).HasColumnName("PAINDEGREE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainPeriod)).HasColumnName("PAINPERIOD").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.FaceScala)).HasColumnName("FACESCALA");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.BehaviourLoss)).HasColumnName("BEHAVIOURLOSS");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.Note)).HasColumnName("NOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.Complaint)).HasColumnName("COMPLAINT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.ComplaintDescription)).HasColumnName("COMPLAINTDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.ComplaintDuration)).HasColumnName("COMPLAINTDURATION");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.ContinuousDrugs)).HasColumnName("CONTINUOUSDRUGS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.LastEatingInfo)).HasColumnName("LASTEATINGINFO").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PatientHistory)).HasColumnName("PATIENTHISTORY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PatientHistoryDescription)).HasColumnName("PATIENTHISTORYDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.AlcoholPromile)).HasColumnName("ALCOHOLPROMILE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.IsPregnant)).HasColumnName("ISPREGNANT");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.LastMenstrualPeriod)).HasColumnName("LASTMENSTRUALPERIOD");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.ApplicationDate)).HasColumnName("APPLICATIONDATE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainQualityDescription)).HasColumnName("PAINQUALITYDESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.AchingSide)).HasColumnName("ACHINGSIDE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainDetail)).HasColumnName("PAINDETAIL").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainTime)).HasColumnName("PAINTIME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.DurationofPain)).HasColumnName("DURATIONOFPAIN").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainFaceScale)).HasColumnName("PAINFACESCALE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.TotalScore)).HasColumnName("TOTALSCORE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.AllergyDescription)).HasColumnName("ALLERGYDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.Habits)).HasColumnName("HABITS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.EyesRef)).HasColumnName("EYES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.MotorAnswerRef)).HasColumnName("MOTORANSWER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.OralAnswerRef)).HasColumnName("ORALANSWER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.TriageRef)).HasColumnName("TRIAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainQualityRef)).HasColumnName("PAINQUALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainFrequencyRef)).HasColumnName("PAINFREQUENCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencySpecialityObject.PainPlacesRef)).HasColumnName("PAINPLACES").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);
        }
    }
}