using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PsychologyBasedObjectConfig : IEntityTypeConfiguration<AtlasModel.PsychologyBasedObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PsychologyBasedObject> builder)
        {
            builder.ToTable("PSYCHOLOGYBASEDOBJECT");
            builder.HasKey(nameof(AtlasModel.PsychologyBasedObject.ObjectId));
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.DoctorStatement)).HasColumnName("DOCTORSTATEMENT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.TherapyReport)).HasColumnName("THERAPYREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.VisibleForProcedureDoctor)).HasColumnName("VISIBLEFORPROCEDUREDOCTOR");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.VisibleForProcAndRequestDoc)).HasColumnName("VISIBLEFORPROCANDREQUESTDOC");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.VisibleForPsychologyUnit)).HasColumnName("VISIBLEFORPSYCHOLOGYUNIT");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.VisibleForSelectedUsers)).HasColumnName("VISIBLEFORSELECTEDUSERS");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.BinetTermanTest)).HasColumnName("BINETTERMANTEST");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.CattelIntelligenceTest)).HasColumnName("CATTELINTELLIGENCETEST");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.GoodEnoughHarrisDrawingTest)).HasColumnName("GOODENOUGHHARRISDRAWINGTEST");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.KentEGYTest)).HasColumnName("KENTEGYTEST");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.LearnDifficultyDetermination)).HasColumnName("LEARNDIFFICULTYDETERMINATION");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.PeabodyPictureVocabularyTest)).HasColumnName("PEABODYPICTUREVOCABULARYTEST");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.ProteusMazeTest)).HasColumnName("PROTEUSMAZETEST");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.WISCR)).HasColumnName("WISCR");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.ImportantNoteAboutApplication)).HasColumnName("IMPORTANTNOTEABOUTAPPLICATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.InformationTakenFromParent)).HasColumnName("INFORMATIONTAKENFROMPARENT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.IQTestObjectiveResultIQLevel)).HasColumnName("IQTESTOBJECTIVERESULTIQLEVEL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.RequestDoctorRef)).HasColumnName("REQUESTDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PsychologyBasedObject.PsychologicExaminationRef)).HasColumnName("PSYCHOLOGICEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RequestDoctor).WithOne().HasForeignKey<AtlasModel.PsychologyBasedObject>(x => x.RequestDoctorRef).IsRequired(false);
            builder.HasOne(t => t.PsychologicExamination).WithOne().HasForeignKey<AtlasModel.PsychologyBasedObject>(x => x.PsychologicExaminationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}