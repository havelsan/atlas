using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingPatientPreAssessmentConfig : IEntityTypeConfiguration<AtlasModel.NursingPatientPreAssessment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingPatientPreAssessment> builder)
        {
            builder.ToTable("NURSINGPATIENTPREASSESS");
            builder.HasKey(nameof(AtlasModel.NursingPatientPreAssessment.ObjectId));
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.PatientLanguage)).HasColumnName("PATIENTLANGUAGE");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.ChildCount)).HasColumnName("CHILDCOUNT");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.CauseOfInjury)).HasColumnName("CAUSEOFINJURY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.RehabHistory)).HasColumnName("REHABHISTORY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.LastRehabDate)).HasColumnName("LASTREHABDATE");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.WhereThePatientCameFrom)).HasColumnName("WHERETHEPATIENTCAMEFROM");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.TheWayThePatientArrive)).HasColumnName("THEWAYTHEPATIENTARRIVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.HereditaryDiseases)).HasColumnName("HEREDITARYDISEASES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.PastIllnessesAndOperations)).HasColumnName("PASTILLNESSESANDOPERATIONS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.AssistiveDevices)).HasColumnName("ASSISTIVEDEVICES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.BloodTransfusionPracticed)).HasColumnName("BLOODTRANSFUSIONPRACTICED").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.BloodTransfusionReaction)).HasColumnName("BLOODTRANSFUSIONREACTION").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.Height)).HasColumnName("HEIGHT");
            builder.Property(nameof(AtlasModel.NursingPatientPreAssessment.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}