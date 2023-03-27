//$DFE2607C
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Collections.Generic;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class EmergencySpecialityObjectServiceController
    {
        #region unused
        //[HttpPost]
        //public void EmergencySpecialityObjectForm([ModelBinder(typeof(NebulaModelBinder))]EmergencySpecialityObjectFormViewModel viewModel)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        var emergencySpecialityObject = (EmergencySpecialityObject)objectContext.AddObject(viewModel._EmergencySpecialityObject);
        //        objectContext.Save();
        //    }
        //}
        #endregion
        [HttpGet]
        public EmergencySpecialityObjectFormViewModel EmergencySpecialityObjectForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return EmergencySpecialityObjectFormLoadInternal(input);
        }

        [HttpPost]
        public EmergencySpecialityObjectFormViewModel EmergencySpecialityObjectFormLoad(FormLoadInput input)
        {
            return EmergencySpecialityObjectFormLoadInternal(input);
        }

        private EmergencySpecialityObjectFormViewModel EmergencySpecialityObjectFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("89b717c0-041d-4d7a-b6a9-2b2053c982ac");
            var objectDefID = Guid.Parse("17dc5dfb-6d41-419b-ac33-c90757bd68d4");
            var viewModel = new EmergencySpecialityObjectFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._EmergencySpecialityObject = objectContext.GetObject(id.Value, objectDefID) as EmergencySpecialityObject;
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    viewModel.EmergencyDefinitionsGridList = objectContext.LocalQuery<EmergencySurveyObject>().ToArray();
                    viewModel.SKRSTRIAJKODUs = objectContext.LocalQuery<SKRSTRIAJKODU>().ToArray();
                    viewModel.EmergencySurveyDefinitions = objectContext.LocalQuery<EmergencySurveyDefinition>().ToArray();
                    viewModel.GlaskowComaScaleDefinitions = objectContext.LocalQuery<GlaskowComaScaleDefinition>().ToArray();
                    viewModel.PainQualityDefinitions = objectContext.LocalQuery<PainQualityDefinition>().ToArray();
                    viewModel.PainFrequencyDefinitons = objectContext.LocalQuery<PainFrequencyDefiniton>().ToArray();
                    viewModel.PainPlaceDefitions = objectContext.LocalQuery<PainPlaceDefition>().ToArray();
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EmergencySpecialityObject);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EmergencySpecialityObject);
                    PreScript_EmergencySpecialityObjectForm(viewModel, viewModel._EmergencySpecialityObject, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._EmergencySpecialityObject = new EmergencySpecialityObject(objectContext);
                    viewModel.EmergencyDefinitionsGridList = objectContext.LocalQuery<EmergencySurveyObject>().ToArray();
                    viewModel.SKRSTRIAJKODUs = objectContext.LocalQuery<SKRSTRIAJKODU>().ToArray();
                    viewModel.EmergencySurveyDefinitions = objectContext.LocalQuery<EmergencySurveyDefinition>().ToArray();
                    viewModel.GlaskowComaScaleDefinitions = objectContext.LocalQuery<GlaskowComaScaleDefinition>().ToArray();
                    viewModel.PainQualityDefinitions = objectContext.LocalQuery<PainQualityDefinition>().ToArray();
                    viewModel.PainFrequencyDefinitons = objectContext.LocalQuery<PainFrequencyDefiniton>().ToArray();
                    viewModel.PainPlaceDefitions = objectContext.LocalQuery<PainPlaceDefition>().ToArray();
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EmergencySpecialityObject);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EmergencySpecialityObject);
                    PreScript_EmergencySpecialityObjectForm(viewModel, viewModel._EmergencySpecialityObject, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        partial void PreScript_EmergencySpecialityObjectForm(EmergencySpecialityObjectFormViewModel viewModel, EmergencySpecialityObject emergencySpecialityObject, TTObjectContext objectContext);
        partial void PreScript_EmergencySpecialityObjectForm(EmergencySpecialityObjectFormViewModel viewModel, EmergencySpecialityObject emergencySpecialityObject, TTObjectContext objectContext)
        {
            PatientAdmission patientAdmission = null;
            if (emergencySpecialityObject.PhysicianApplication != null)
            {
                //Konsültasyon ise PhysicianApplication.PatientAdmission null oluyordu ve Triyaj detayları boş geliyordu. Konsültsayonun istendiği işlemin PatientAdmissionına göre çalışsın diye eklendi.
                if (emergencySpecialityObject.PhysicianApplication is Consultation)
                {
                    Consultation consultation = (Consultation)emergencySpecialityObject.PhysicianApplication;
                    if (consultation.PhysicianApplication != null)
                        patientAdmission = consultation.PhysicianApplication.PatientAdmission;
                }
                else
                    patientAdmission = emergencySpecialityObject.PhysicianApplication.PatientAdmission;
            }

            if (emergencySpecialityObject.PhysicianApplication != null && patientAdmission != null && patientAdmission.EmergencyIntervention != null)
            {
                if (emergencySpecialityObject.Triage == null)
                {
                    if (patientAdmission.EmergencyIntervention.Triage == null && patientAdmission.Triage != null)
                        patientAdmission.EmergencyIntervention.Triage = patientAdmission.Triage;

                    if (emergencySpecialityObject.PhysicianApplication != null && emergencySpecialityObject.PhysicianApplication is PatientExamination
                        && ((PatientExamination)emergencySpecialityObject.PhysicianApplication).EmergencyIntervention != null && ((PatientExamination)emergencySpecialityObject.PhysicianApplication).EmergencyIntervention.Triage != null)
                        emergencySpecialityObject.Triage = ((PatientExamination)emergencySpecialityObject.PhysicianApplication).EmergencyIntervention.Triage;
                    else if (emergencySpecialityObject.PhysicianApplication != null && emergencySpecialityObject.PhysicianApplication is InPatientPhysicianApplication
                        && ((InPatientPhysicianApplication)emergencySpecialityObject.PhysicianApplication).EmergencyIntervention != null && ((InPatientPhysicianApplication)emergencySpecialityObject.PhysicianApplication).EmergencyIntervention.Triage != null)
                        emergencySpecialityObject.Triage = ((InPatientPhysicianApplication)emergencySpecialityObject.PhysicianApplication).EmergencyIntervention.Triage;
                    else
                        emergencySpecialityObject.Triage = patientAdmission.EmergencyIntervention.Triage;

                    viewModel.SKRSTRIAJKODUs = objectContext.LocalQuery<SKRSTRIAJKODU>().ToArray();
                }

                if (emergencySpecialityObject.PhysicianApplication.SPO2s.Count == 0)
                {
                    if (patientAdmission.EmergencyIntervention.SPO2s.Count > 0)
                        viewModel.SPO2_Value = patientAdmission.EmergencyIntervention.SPO2s[0].Value;
                }
                else
                    viewModel.SPO2_Value = emergencySpecialityObject.PhysicianApplication.SPO2s[0].Value;
                if (emergencySpecialityObject.PhysicianApplication.Pulses.Count == 0)
                {
                    if (patientAdmission.EmergencyIntervention.Pulses.Count > 0)
                        viewModel.Pulse_Value = patientAdmission.EmergencyIntervention.Pulses[0].Value;
                }
                else
                    viewModel.Pulse_Value = emergencySpecialityObject.PhysicianApplication.Pulses[0].Value;
                if (emergencySpecialityObject.PhysicianApplication.Temperatures.Count == 0)
                {
                    if (patientAdmission.EmergencyIntervention.Temperatures.Count > 0)
                        viewModel.Temperature_Value = patientAdmission.EmergencyIntervention.Temperatures[0].Value;
                }
                else
                    viewModel.Temperature_Value = emergencySpecialityObject.PhysicianApplication.Temperatures[0].Value;
                if (emergencySpecialityObject.PhysicianApplication.Respirations.Count == 0)
                {
                    if (patientAdmission.EmergencyIntervention.Respirations.Count > 0)
                        viewModel.Respiration_Value = patientAdmission.EmergencyIntervention.Respirations[0].Value;
                }
                else
                    viewModel.Respiration_Value = emergencySpecialityObject.PhysicianApplication.Respirations[0].Value;
                if (emergencySpecialityObject.PhysicianApplication.BloodPressures.Count == 0)
                {
                    if (patientAdmission.EmergencyIntervention.BloodPressures.Count > 0)
                    {
                        if (patientAdmission.EmergencyIntervention.BloodPressures[0].Diastolik != null)
                            viewModel.BloodPressure_Diastolik = patientAdmission.EmergencyIntervention.BloodPressures[0].Diastolik;
                        if (patientAdmission.EmergencyIntervention.BloodPressures[0].Sistolik != null)
                            viewModel.BloodPressure_Sistolik = patientAdmission.EmergencyIntervention.BloodPressures[0].Sistolik;
                    }
                }
                else
                {
                    if (emergencySpecialityObject.PhysicianApplication.BloodPressures[0].Diastolik != null)
                        viewModel.BloodPressure_Diastolik = emergencySpecialityObject.PhysicianApplication.BloodPressures[0].Diastolik.Value;
                    if (emergencySpecialityObject.PhysicianApplication.BloodPressures[0].Sistolik != null)
                        viewModel.BloodPressure_Sistolik = emergencySpecialityObject.PhysicianApplication.BloodPressures[0].Sistolik.Value;
                }

                if (emergencySpecialityObject.AlcoholPromile == null)
                {
                    if (patientAdmission.EmergencyIntervention.AlcoholPromile != null)
                        viewModel._EmergencySpecialityObject.AlcoholPromile = patientAdmission.EmergencyIntervention.AlcoholPromile;
                }

                if (emergencySpecialityObject.IsPregnant == null || emergencySpecialityObject.IsPregnant == false)
                {
                    if (patientAdmission.EmergencyIntervention.IsPregnant != null)
                        viewModel._EmergencySpecialityObject.IsPregnant = patientAdmission.EmergencyIntervention.IsPregnant;
                }

                if (emergencySpecialityObject.LastMenstrualPeriod == null)
                {
                    if (patientAdmission.EmergencyIntervention.LastMenstrualPeriod != null)
                        viewModel._EmergencySpecialityObject.LastMenstrualPeriod = patientAdmission.EmergencyIntervention.LastMenstrualPeriod;
                }

                if (emergencySpecialityObject.Complaint == null)
                {
                    if (patientAdmission.EmergencyIntervention.Complaint != null)
                        viewModel._EmergencySpecialityObject.Complaint = patientAdmission.EmergencyIntervention.Complaint;
                }

                if (emergencySpecialityObject.ComplaintDescription == null)
                {
                    if (patientAdmission.EmergencyIntervention.ComplaintDescription != null)
                        viewModel._EmergencySpecialityObject.ComplaintDescription = patientAdmission.EmergencyIntervention.ComplaintDescription;
                }

                if (emergencySpecialityObject.ComplaintDuration == null)
                {
                    if (patientAdmission.EmergencyIntervention.ComplaintDuration != null)
                        viewModel._EmergencySpecialityObject.ComplaintDuration = patientAdmission.EmergencyIntervention.ComplaintDuration;
                }

                if (emergencySpecialityObject.PatientHistoryDescription == null)
                {
                    if (patientAdmission.EmergencyIntervention.PatientHistoryDescription != null)
                        viewModel._EmergencySpecialityObject.PatientHistoryDescription = patientAdmission.EmergencyIntervention.PatientHistoryDescription;
                }

                if (emergencySpecialityObject.ContinuousDrugs == null)
                {
                    if (patientAdmission.EmergencyIntervention.ContinuousDrugs != null)
                        viewModel._EmergencySpecialityObject.ContinuousDrugs = patientAdmission.EmergencyIntervention.ContinuousDrugs;
                }

                if (emergencySpecialityObject.Habits == null)
                {
                    if (patientAdmission.EmergencyIntervention.Habits != null)
                        viewModel._EmergencySpecialityObject.Habits = patientAdmission.EmergencyIntervention.Habits;
                }

                if (emergencySpecialityObject.LastEatingInfo == null)
                {
                    if (patientAdmission.EmergencyIntervention.LastEatingInfo != null)
                        viewModel._EmergencySpecialityObject.LastEatingInfo = patientAdmission.EmergencyIntervention.LastEatingInfo;
                }

                if (emergencySpecialityObject.AllergyDescription == null)
                {
                    if (patientAdmission.EmergencyIntervention.AllergyDescription != null)
                        viewModel._EmergencySpecialityObject.AllergyDescription = patientAdmission.EmergencyIntervention.AllergyDescription;
                }

                if (emergencySpecialityObject.TetanusVaccine == null || emergencySpecialityObject.TetanusVaccine == false)
                {
                    if (patientAdmission.EmergencyIntervention.TetanusVaccine != null)
                        viewModel._EmergencySpecialityObject.TetanusVaccine = patientAdmission.EmergencyIntervention.TetanusVaccine;
                }

                if (emergencySpecialityObject.PhysicianApplication != null && emergencySpecialityObject.PhysicianApplication.Episode != null && emergencySpecialityObject.PhysicianApplication.Episode.Patient != null && emergencySpecialityObject.PhysicianApplication.Episode.Patient.Sex != null)
                {
                    if (emergencySpecialityObject.PhysicianApplication.Episode.Patient.Sex.KODU == "1")
                        viewModel.isFemale = false;
                    else
                        viewModel.isFemale = true;
                }

                viewModel.GlaskowEyeDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._EmergencySpecialityObject.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.Eyes).OrderBy(x => x.Score).ToArray();
                viewModel.GlaskowOralAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._EmergencySpecialityObject.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.OralAnswer).OrderBy(x => x.Score).ToArray();
                viewModel.GlaskowMotorAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._EmergencySpecialityObject.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.MotorAnswer).OrderBy(x => x.Score).ToArray();

                viewModel.anamnesisFormViewModel._PhysicianApplication = new PhysicianApplication();
                if (emergencySpecialityObject.PhysicianApplication != null)
                {
                    viewModel.anamnesisFormViewModel._PhysicianApplication = (PhysicianApplication)emergencySpecialityObject.PhysicianApplication;
                    viewModel.anamnesisFormViewModel.PatientID = emergencySpecialityObject.PhysicianApplication.Episode.Patient.ObjectID;
                }

                System.ComponentModel.BindingList<EmergencySurveyDefinition> AllEmergencySurveyDefinitionDefList = EmergencySurveyDefinition.GetAllEmergencySurveyDefList(objectContext);
                EmergencySpecialityObjectFormViewModel.EmergencySurveyDefinitionList_Class esd = new EmergencySpecialityObjectFormViewModel.EmergencySurveyDefinitionList_Class();
                string groupName = String.Empty;
                viewModel.EmergencySurveyDefinitionViewList = new List<EmergencySpecialityObjectFormViewModel.EmergencySurveyDefinitionList_Class>();
                int index = 0;
                foreach (EmergencySurveyDefinition item in AllEmergencySurveyDefinitionDefList)
                {
                    string _temp = Common.GetDisplayTextOfDataTypeEnum(item.ActivityGroup.Value);
                    if (groupName != _temp)
                    {
                        if (index != 0) //ilk girişinde atmasın tüm liste gelmemiş oluyor
                        {
                            viewModel.EmergencySurveyDefinitionViewList.Add(esd);
                            esd = new EmergencySpecialityObjectFormViewModel.EmergencySurveyDefinitionList_Class();
                        }

                        esd.GroupName = _temp;
                        groupName = _temp;
                        esd.EmergencySurveyDefinitionList = new List<EmergencySurveyDefinition>();
                        index++;
                    }

                    esd.EmergencySurveyDefinitionList.Add(item);
                }

                viewModel.EmergencySurveyDefinitionViewList.Add(esd); //son kayıt
                index = 0;
            }
        }
    }
}

namespace Core.Models
{
    public partial class EmergencySpecialityObjectFormViewModel : BaseViewModel, ISpecialityBasedObjectViewModel
    {
        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            var emergencySpecialityObject = (EmergencySpecialityObject)objectContext.AddObject(this._EmergencySpecialityObject);
            if (emergencySpecialityObject.Triage == null)
                throw new TTUtils.TTException("'Triaj kodu' alanını seçiniz.");

            if (emergencySpecialityObject.IsPregnant != true)
                emergencySpecialityObject.LastMenstrualPeriod = null;

            if (emergencySpecialityObject.PhysicianApplication != null && emergencySpecialityObject.PhysicianApplication.Episode.Patient.Sex != null && emergencySpecialityObject.PhysicianApplication.Episode.Patient.Sex.KODU == "1" && (emergencySpecialityObject.IsPregnant == true || emergencySpecialityObject.LastMenstrualPeriod != null))
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25602", "Erkek hastalar için Gebelik ya da son adet tarihi bilgisi girilemez."));
            }

            if (emergencySpecialityObject.IsPregnant == true && emergencySpecialityObject.LastMenstrualPeriod == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26913", "Son adet tarihi bilgisi giriniz."));
            //if ((emergencySpecialityObject.IsPregnant == null || emergencySpecialityObject.IsPregnant == false) && emergencySpecialityObject.LastMenstrualPeriod != null)
            //    emergencySpecialityObject.IsPregnant = true;
            #region VitalSign
            if (this.BloodPressure_Sistolik != null && this.BloodPressure_Diastolik != null)
            {
                BloodPressure bloodPressure;
                if (emergencySpecialityObject.PhysicianApplication.BloodPressures.Count == 0)
                {
                    bloodPressure = new BloodPressure(objectContext);
                    bloodPressure.ExecutionDate = Common.RecTime();
                }
                else
                {
                    bloodPressure = emergencySpecialityObject.PhysicianApplication.BloodPressures[0];
                }

                if (this.BloodPressure_Diastolik != null)
                    bloodPressure.Diastolik = Convert.ToInt32(this.BloodPressure_Diastolik);
                if (this.BloodPressure_Sistolik != null)
                    bloodPressure.Sistolik = Convert.ToInt32(this.BloodPressure_Sistolik);
                bloodPressure.EpisodeAction = emergencySpecialityObject.PhysicianApplication;
            }

            if (this.Pulse_Value != null)
            {
                Pulse pulse;
                if (emergencySpecialityObject.PhysicianApplication.Pulses.Count == 0)
                {
                    pulse = new Pulse(objectContext);
                    pulse.ExecutionDate = Common.RecTime();
                }
                else
                {
                    pulse = emergencySpecialityObject.PhysicianApplication.Pulses[0];
                }

                pulse.Value = this.Pulse_Value;
                pulse.EpisodeAction = emergencySpecialityObject.PhysicianApplication;
            }

            if (this.Respiration_Value != null)
            {
                Respiration respiration;
                if (emergencySpecialityObject.PhysicianApplication.Respirations.Count == 0)
                {
                    respiration = new Respiration(objectContext);
                    respiration.ExecutionDate = Common.RecTime();
                }
                else
                {
                    respiration = emergencySpecialityObject.PhysicianApplication.Respirations[0];
                }

                respiration.Value = this.Respiration_Value;
                respiration.EpisodeAction = emergencySpecialityObject.PhysicianApplication;
            }

            if (this.Temperature_Value != null)
            {
                Temperature temperature;
                if (emergencySpecialityObject.PhysicianApplication.Temperatures.Count == 0)
                {
                    temperature = new Temperature(objectContext);
                    temperature.ExecutionDate = Common.RecTime();
                }
                else
                {
                    temperature = emergencySpecialityObject.PhysicianApplication.Temperatures[0];
                }

                temperature.Value = this.Temperature_Value;
                temperature.EpisodeAction = emergencySpecialityObject.PhysicianApplication;
            }

            if (this.SPO2_Value != null)
            {
                SPO2 spo;
                if (emergencySpecialityObject.PhysicianApplication.SPO2s.Count == 0)
                {
                    spo = new SPO2(objectContext);
                    spo.ExecutionDate = Common.RecTime();
                }
                else
                {
                    spo = emergencySpecialityObject.PhysicianApplication.SPO2s[0];
                }

                spo.Value = this.SPO2_Value;
                spo.EpisodeAction = emergencySpecialityObject.PhysicianApplication;
            }

            #endregion
            //kayıt kabulde girilen triaj kodunu güncelle
            if (emergencySpecialityObject.PhysicianApplication.PatientAdmission != null) //Acilden istenen konsültasyonda null oluyor çünkü
            {
                if (emergencySpecialityObject.PhysicianApplication.PatientAdmission.Triage != null && emergencySpecialityObject.PhysicianApplication.PatientAdmission.Triage != emergencySpecialityObject.Triage)
                {
                    emergencySpecialityObject.PhysicianApplication.PatientAdmission.OldTriage = emergencySpecialityObject.PhysicianApplication.PatientAdmission.Triage;
                }

                emergencySpecialityObject.PhysicianApplication.PatientAdmission.Triage = emergencySpecialityObject.Triage;
                emergencySpecialityObject.PhysicianApplication.PatientAdmission.Triage.CurrentStateDefID = emergencySpecialityObject.Triage.CurrentStateDefID;
                //triaj ekranından girilen bilgileri güncelle     
                if (emergencySpecialityObject.PhysicianApplication.PatientAdmission.EmergencyIntervention.Triage != null && emergencySpecialityObject.PhysicianApplication.PatientAdmission.EmergencyIntervention.Triage != emergencySpecialityObject.Triage)
                {
                    emergencySpecialityObject.PhysicianApplication.PatientAdmission.EmergencyIntervention.OldTriage = emergencySpecialityObject.PhysicianApplication.PatientAdmission.EmergencyIntervention.Triage;
                }

                emergencySpecialityObject.PhysicianApplication.PatientAdmission.EmergencyIntervention.Triage = emergencySpecialityObject.Triage;
                emergencySpecialityObject.PhysicianApplication.PatientAdmission.EmergencyIntervention.Triage.CurrentStateDefID = emergencySpecialityObject.Triage.CurrentStateDefID;

                emergencySpecialityObject.PhysicianApplication.Complaint = this.anamnesisFormViewModel._PhysicianApplication.Complaint;
                emergencySpecialityObject.PhysicianApplication.PatientHistory = this.anamnesisFormViewModel._PhysicianApplication.PatientHistory;
                emergencySpecialityObject.PhysicianApplication.PhysicalExamination = this.anamnesisFormViewModel._PhysicianApplication.PhysicalExamination;
                emergencySpecialityObject.PhysicianApplication.MTSConclusion = this.anamnesisFormViewModel._PhysicianApplication.MTSConclusion;
            }
            objectContext.AddToRawObjectList(this.EmergencyDefinitionsGridList);
            objectContext.ProcessRawObjects();

            if (this.EmergencyDefinitionsGridList != null)
            {
                foreach (var item in this.EmergencyDefinitionsGridList)
                {
                    var emergencySurveyObject = (EmergencySurveyObject)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)emergencySurveyObject).IsDeleted)
                        continue;
                    emergencySurveyObject.EmergencySpecialityObject = emergencySpecialityObject;
                }
            }
        }
    }

    public partial class EmergencySpecialityObjectFormViewModel : ISpecialityBasedObjectViewModel
    {
        public TTObjectClasses.EmergencySpecialityObject _EmergencySpecialityObject
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowComaScaleDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowEyeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowOralAnswerDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowMotorAnswerDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSTRIAJKODU[] SKRSTRIAJKODUs
        {
            get;
            set;
        }
        public TTObjectClasses.EmergencySurveyObject[] EmergencyDefinitionsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.EmergencySurveyDefinition[] EmergencySurveyDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.PainQualityDefinition[] PainQualityDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.PainFrequencyDefiniton[] PainFrequencyDefinitons
        {
            get;
            set;
        }
        public TTObjectClasses.PainPlaceDefition[] PainPlaceDefitions
        {
            get;
            set;
        }
        public List<EmergencySurveyDefinitionList_Class> EmergencySurveyDefinitionViewList
        {
            get;
            set;
        }
        public class EmergencySurveyDefinitionList_Class
        {
            public string GroupName
            {
                get;
                set;
            }

            public List<TTObjectClasses.EmergencySurveyDefinition> EmergencySurveyDefinitionList
            {
                get;
                set;
            }

            public EmergencySurveyDefinitionList_Class()
            {
                EmergencySurveyDefinitionList = new List<EmergencySurveyDefinition>();
            }
        }
        public AnamnesisFormViewModel anamnesisFormViewModel = new AnamnesisFormViewModel();
        public int? BloodPressure_Sistolik;
        public int? BloodPressure_Diastolik;
        public int? Pulse_Value;
        public int? Respiration_Value;
        public double? Temperature_Value;
        public int? SPO2_Value;
        public bool? isFemale;
    }
}