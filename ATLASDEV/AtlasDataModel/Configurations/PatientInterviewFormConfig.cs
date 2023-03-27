using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientInterviewFormConfig : IEntityTypeConfiguration<AtlasModel.PatientInterviewForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientInterviewForm> builder)
        {
            builder.ToTable("PATIENTINTERVIEWFORM");
            builder.HasKey(nameof(AtlasModel.PatientInterviewForm.ObjectId));
            builder.Property(nameof(AtlasModel.PatientInterviewForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientInterviewForm.InterviewPlace)).HasColumnName("INTERVIEWPLACE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.InterviewedContacts)).HasColumnName("INTERVIEWEDCONTACTS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.ProblemDefinition)).HasColumnName("PROBLEMDEFINITION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.MeetingReason)).HasColumnName("MEETINGREASON").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientHealthPhysicalCond)).HasColumnName("PATIENTHEALTHPHYSICALCOND").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientPhoneNum)).HasColumnName("PATIENTPHONENUM").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientAddress)).HasColumnName("PATIENTADDRESS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientPsychosocialFamilyCond)).HasColumnName("PATIENTPSYCHOSOCIALFAMILYCOND").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientAccomodationEcoCon)).HasColumnName("PATIENTACCOMODATIONECOCON").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.Evaluation)).HasColumnName("EVALUATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.ResultsAndRecommendations)).HasColumnName("RESULTSANDRECOMMENDATIONS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PatientInterviewForm.TypeOfService)).HasColumnName("TYPEOFSERVICE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.ExaminationDate)).HasColumnName("EXAMINATIONDATE");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientType)).HasColumnName("PATIENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PsychosocialStudyWithPatient)).HasColumnName("PSYCHOSOCIALSTUDYWITHPATIENT");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PsychosocialStudyPatFamily)).HasColumnName("PSYCHOSOCIALSTUDYPATFAMILY");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.SocialReviewAndEvolution)).HasColumnName("SOCIALREVIEWANDEVOLUTION");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.HomeOrOrganizationVisit)).HasColumnName("HOMEORORGANIZATIONVISIT");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.WorkplaceVisit)).HasColumnName("WORKPLACEVISIT");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.SchoolVisit)).HasColumnName("SCHOOLVISIT");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.InstutionalCarePlacement)).HasColumnName("INSTUTIONALCAREPLACEMENT");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PlacementInTemporaryShelters)).HasColumnName("PLACEMENTINTEMPORARYSHELTERS");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.GoodsAndMoneyHelp)).HasColumnName("GOODSANDMONEYHELP");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.TreatmentExpenseResourceRoute)).HasColumnName("TREATMENTEXPENSERESOURCEROUTE");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientsGroupStudy)).HasColumnName("PATIENTSGROUPSTUDY");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.GroupStudyWithPatientFamily)).HasColumnName("GROUPSTUDYWITHPATIENTFAMILY");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientEducationAndWorkStudy)).HasColumnName("PATIENTEDUCATIONANDWORKSTUDY");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PatientTransferervice)).HasColumnName("PATIENTTRANSFERERVICE");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PsychosocialEduPatientFamily)).HasColumnName("PSYCHOSOCIALEDUPATIENTFAMILY");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.SocialActivity)).HasColumnName("SOCIALACTIVITY");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.OtherVocationalInterventions)).HasColumnName("OTHERVOCATIONALINTERVENTIONS");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.MaritalStatus)).HasColumnName("MARITALSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientInterviewForm.PhysicianApplicationRef)).HasColumnName("PHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientInterviewForm.RequestedByRef)).HasColumnName("REQUESTEDBY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.PatientInterviewForm>(x => x.PhysicianApplicationRef).IsRequired(false);
            builder.HasOne(t => t.RequestedBy).WithOne().HasForeignKey<AtlasModel.PatientInterviewForm>(x => x.RequestedByRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}