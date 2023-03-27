
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Acil Muayene Hasta Değerlendirme Objesi
    /// </summary>
    public  partial class EmergencySpecialityObject : SpecialityBasedObject
    {
        public EmergencySpecialityObject(PhysicianApplication physicianApplication) :this(physicianApplication.ObjectContext)
        {
            var context = physicianApplication.ObjectContext;
 
            PhysicianApplication = physicianApplication;
            
            #region oldEmergencySpecialityObjectList
            /*
            var emergencySpecialityObjectList = EmergencySpecialityObject.GetEmergencySpecialityObjectByPatient(context, physicianApplication.Episode.Patient.ObjectID);
            if (emergencySpecialityObjectList.Count > 0)
            {
                var oldEmergencySpecialityObjectList = emergencySpecialityObjectList[0];
                this.AbdominalPain = oldEmergencySpecialityObjectList.AbdominalPain;
                this.AlcoholPromile = oldEmergencySpecialityObjectList.AlcoholPromile;
                this.AllergyDescription = oldEmergencySpecialityObjectList.AllergyDescription;       
                this.Anorexia = oldEmergencySpecialityObjectList.Anorexia;
                this.Attack = oldEmergencySpecialityObjectList.Attack;
                this.BackPain = oldEmergencySpecialityObjectList.BackPain;
                this.BehaviourLoss = oldEmergencySpecialityObjectList.BehaviourLoss;
                this.BreastDrainage = oldEmergencySpecialityObjectList.BreastDrainage;
                this.BreastMass = oldEmergencySpecialityObjectList.BreastMass;
                this.BreastPain = oldEmergencySpecialityObjectList.BreastPain;
                this.ChestPain = oldEmergencySpecialityObjectList.ChestPain;
                this.Complaint = oldEmergencySpecialityObjectList.Complaint;
                this.ComplaintDescription = oldEmergencySpecialityObjectList.ComplaintDescription;
                this.ComplaintDuration = oldEmergencySpecialityObjectList.ComplaintDuration;
                this.ConsciousnessLoss = oldEmergencySpecialityObjectList.ConsciousnessLoss;
                this.Constipation = oldEmergencySpecialityObjectList.Constipation;
                this.ContinuousDrugs = oldEmergencySpecialityObjectList.ContinuousDrugs;
                this.Contraction = oldEmergencySpecialityObjectList.Contraction;
                this.Cough = oldEmergencySpecialityObjectList.Cough;
                this.Cyanosis = oldEmergencySpecialityObjectList.Cyanosis;
                this.Diarrhea = oldEmergencySpecialityObjectList.Diarrhea;
                this.Dismenore = oldEmergencySpecialityObjectList.Dismenore;
                this.Dizziness = oldEmergencySpecialityObjectList.Dizziness;
                this.DoubleVision = oldEmergencySpecialityObjectList.DoubleVision;
                this.EarDrainage = oldEmergencySpecialityObjectList.EarDrainage;
                this.EarPain = oldEmergencySpecialityObjectList.EarPain;
                this.Edema = oldEmergencySpecialityObjectList.Edema;
                this.EyePain = oldEmergencySpecialityObjectList.EyePain;
                this.FaceScala = oldEmergencySpecialityObjectList.FaceScala;
                this.Galactore = oldEmergencySpecialityObjectList.Galactore;
                this.GeneralEvaluationBad = oldEmergencySpecialityObjectList.GeneralEvaluationBad;
                this.GeneralEvaluationCold = oldEmergencySpecialityObjectList.GeneralEvaluationCold;
                this.GeneralEvaluationDehidrate = oldEmergencySpecialityObjectList.GeneralEvaluationDehidrate;
                this.GeneralEvaluationDispneic = oldEmergencySpecialityObjectList.GeneralEvaluationDispneic;
                this.GeneralEvaluationGood = oldEmergencySpecialityObjectList.GeneralEvaluationGood;
                this.GeneralEvaluationMedium = oldEmergencySpecialityObjectList.GeneralEvaluationMedium;
                this.GeneralEvaluationPainly = oldEmergencySpecialityObjectList.GeneralEvaluationPainly;
                this.GeneralEvaluationSweaty = oldEmergencySpecialityObjectList.GeneralEvaluationSweaty;
                this.Habits = oldEmergencySpecialityObjectList.Habits;
                this.Hallucination = oldEmergencySpecialityObjectList.Hallucination;
                this.HeadAche = oldEmergencySpecialityObjectList.HeadAche;
                this.Hemoptysis = oldEmergencySpecialityObjectList.Hemoptysis;
                this.Hirsutusmus = oldEmergencySpecialityObjectList.Hirsutusmus;
                this.Hoarseness = oldEmergencySpecialityObjectList.Hoarseness;
                this.Imbalance = oldEmergencySpecialityObjectList.Imbalance;
                this.IsPregnant = oldEmergencySpecialityObjectList.IsPregnant;
                this.JointPain = oldEmergencySpecialityObjectList.JointPain;
                this.JointSwelling = oldEmergencySpecialityObjectList.JointSwelling;
                this.LaboredBreathing = oldEmergencySpecialityObjectList.LaboredBreathing;
                this.LastEatingInfo = oldEmergencySpecialityObjectList.LastEatingInfo;
                this.LastMenstrualPeriod = oldEmergencySpecialityObjectList.LastMenstrualPeriod;
                this.LumbarPain = oldEmergencySpecialityObjectList.LumbarPain;
                this.Melena = oldEmergencySpecialityObjectList.Melena;
                this.MorningMovementLoss = oldEmergencySpecialityObjectList.MorningMovementLoss;
                this.MovementLoss = oldEmergencySpecialityObjectList.MovementLoss;
                this.NasalDrainage = oldEmergencySpecialityObjectList.NasalDrainage;
                this.Nausea = oldEmergencySpecialityObjectList.Nausea;
                this.NeckMass = oldEmergencySpecialityObjectList.NeckMass;
                this.NeckPain = oldEmergencySpecialityObjectList.NeckPain;
                this.NightSweating = oldEmergencySpecialityObjectList.NightSweating;
                this.NoInfoForHormon = oldEmergencySpecialityObjectList.NoInfoForHormon;
                this.NoInfoForMan = oldEmergencySpecialityObjectList.NoInfoForMan;
                this.NoInfoForPhysocology = oldEmergencySpecialityObjectList.NoInfoForPhysocology;
                this.Orthopnea = oldEmergencySpecialityObjectList.Orthopnea;
                this.PainDegree = oldEmergencySpecialityObjectList.PainDegree;
                this.PainPeriod = oldEmergencySpecialityObjectList.PainPeriod;
                this.PainPlace = oldEmergencySpecialityObjectList.PainPlace;
                this.Paresthaesia = oldEmergencySpecialityObjectList.Paresthaesia;
                this.PatientHistory = oldEmergencySpecialityObjectList.PatientHistory;
                this.PatientHistoryDescription = oldEmergencySpecialityObjectList.PatientHistoryDescription;
                this.PenileDischarge = oldEmergencySpecialityObjectList.PenileDischarge;
                this.PhysicianApplication = oldEmergencySpecialityObjectList.PhysicianApplication;
                this.PND = oldEmergencySpecialityObjectList.PND;
                this.Prostration = oldEmergencySpecialityObjectList.Prostration;
                this.Pruritus = oldEmergencySpecialityObjectList.Pruritus;
                this.PsychologicalEvalIrrelevant = oldEmergencySpecialityObjectList.PsychologicalEvalIrrelevant;
                this.PsychologicalEvaluationAngry = oldEmergencySpecialityObjectList.PsychologicalEvaluationAngry;
                this.PsychologicalEvaluationNormal = oldEmergencySpecialityObjectList.PsychologicalEvaluationNormal;
                this.PsychologicalEvaluationOther = oldEmergencySpecialityObjectList.PsychologicalEvaluationOther;
                this.PsychologicalEvaluationSad = oldEmergencySpecialityObjectList.PsychologicalEvaluationSad;
                this.PsychologicalEvalWorried = oldEmergencySpecialityObjectList.PsychologicalEvalWorried;
                this.RhythmDisorder = oldEmergencySpecialityObjectList.RhythmDisorder;
                this.Sputum = oldEmergencySpecialityObjectList.Sputum;
                this.StomachPain = oldEmergencySpecialityObjectList.StomachPain;
                this.Sweating = oldEmergencySpecialityObjectList.Sweating;
                this.Tachycardia = oldEmergencySpecialityObjectList.Tachycardia;
                this.Temperature = oldEmergencySpecialityObjectList.Temperature;
                this.TestisPain = oldEmergencySpecialityObjectList.TestisPain;
                this.ThroatPain = oldEmergencySpecialityObjectList.ThroatPain;
                this.ThrowingUp = oldEmergencySpecialityObjectList.ThrowingUp;
                this.Tinnitus = oldEmergencySpecialityObjectList.Tinnitus;
                this.TriajCode = oldEmergencySpecialityObjectList.TriajCode;               
                this.VaginalBleeding = oldEmergencySpecialityObjectList.VaginalBleeding;
                this.VaginalDrainage = oldEmergencySpecialityObjectList.VaginalDrainage;
                this.VisionDefect = oldEmergencySpecialityObjectList.VisionDefect;
                this.Weakness = oldEmergencySpecialityObjectList.Weakness;
                this.WeightGain = oldEmergencySpecialityObjectList.WeightGain;
                this.WeightLoss = oldEmergencySpecialityObjectList.WeightLoss;
                this.Wheezing = oldEmergencySpecialityObjectList.Wheezing;
            }*/
            #endregion

        }

        public void SetTriage(SKRSTRIAJKODU triaj)
        {
            if (Triage == null || Triage.ObjectID.Equals(triaj.ObjectID) == false)
                Triage = triaj;
        }

    }
}