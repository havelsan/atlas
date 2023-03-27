using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PsychologyBasedObject
    {
        public Guid ObjectId { get; set; }
        public string DoctorStatement { get; set; }
        public Guid? TherapyReport { get; set; }
        public bool? VisibleForProcedureDoctor { get; set; }
        public bool? VisibleForProcAndRequestDoc { get; set; }
        public bool? VisibleForPsychologyUnit { get; set; }
        public bool? VisibleForSelectedUsers { get; set; }
        public bool? BinetTermanTest { get; set; }
        public bool? CattelIntelligenceTest { get; set; }
        public bool? GoodEnoughHarrisDrawingTest { get; set; }
        public bool? KentEGYTest { get; set; }
        public bool? LearnDifficultyDetermination { get; set; }
        public bool? PeabodyPictureVocabularyTest { get; set; }
        public bool? ProteusMazeTest { get; set; }
        public bool? WISCR { get; set; }
        public ImportantNoteAboutApplicationEnum? ImportantNoteAboutApplication { get; set; }
        public string InformationTakenFromParent { get; set; }
        public IQTestResultsAndIQLevelEnum? IQTestObjectiveResultIQLevel { get; set; }
        public Guid? RequestDoctorRef { get; set; }
        public Guid? PsychologicExaminationRef { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser RequestDoctor { get; set; }
        public virtual PsychologicExamination PsychologicExamination { get; set; }
        #endregion Parent Relations
    }
}