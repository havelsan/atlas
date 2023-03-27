using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EmergencySpecialityObject
    {
        public Guid ObjectId { get; set; }
        public bool? TetanusVaccine { get; set; }
        public bool? GeneralEvaluationGood { get; set; }
        public bool? GeneralEvaluationMedium { get; set; }
        public bool? GeneralEvaluationBad { get; set; }
        public bool? GeneralEvaluationPainly { get; set; }
        public bool? GeneralEvaluationDispneic { get; set; }
        public bool? GeneralEvaluationDehidrate { get; set; }
        public bool? GeneralEvaluationSweaty { get; set; }
        public bool? GeneralEvaluationCold { get; set; }
        public bool? PsychologicalEvaluationNormal { get; set; }
        public bool? PsychologicalEvaluationAngry { get; set; }
        public bool? PsychologicalEvaluationSad { get; set; }
        public bool? PsychologicalEvalWorried { get; set; }
        public bool? PsychologicalEvalIrrelevant { get; set; }
        public string PsychologicalEvaluationOther { get; set; }
        public bool? HeadAche { get; set; }
        public string PainPlace { get; set; }
        public string PainDegree { get; set; }
        public string PainPeriod { get; set; }
        public int? FaceScala { get; set; }
        public bool? BehaviourLoss { get; set; }
        public Guid? Note { get; set; }
        public string Complaint { get; set; }
        public Guid? ComplaintDescription { get; set; }
        public string ComplaintDuration { get; set; }
        public Guid? ContinuousDrugs { get; set; }
        public string LastEatingInfo { get; set; }
        public string PatientHistory { get; set; }
        public Guid? PatientHistoryDescription { get; set; }
        public int? AlcoholPromile { get; set; }
        public bool? IsPregnant { get; set; }
        public DateTime? LastMenstrualPeriod { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string PainQualityDescription { get; set; }
        public string AchingSide { get; set; }
        public string PainDetail { get; set; }
        public string PainTime { get; set; }
        public string DurationofPain { get; set; }
        public PainFaceScaleEnum? PainFaceScale { get; set; }
        public GlaskowComaScaleScoreEnum? TotalScore { get; set; }
        public DateTime? ActionDate { get; set; }
        public Guid? AllergyDescription { get; set; }
        public Guid? Habits { get; set; }
        public Guid? EyesRef { get; set; }
        public Guid? MotorAnswerRef { get; set; }
        public Guid? OralAnswerRef { get; set; }
        public Guid? TriageRef { get; set; }
        public Guid? PainQualityRef { get; set; }
        public Guid? PainFrequencyRef { get; set; }
        public Guid? PainPlacesRef { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property
    }
}