//$480A1306
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class NursingPatientPreAssessmentServiceController
    {
        partial void PreScript_NursingPatientPreAssessmentForm(NursingPatientPreAssessmentFormViewModel viewModel, NursingPatientPreAssessment nursingPatientPreAssessment, TTObjectContext objectContext)
        {
            if (nursingPatientPreAssessment.ApplicationUser == null)
                nursingPatientPreAssessment.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingPatientPreAssessment).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingPatientPreAssessment);
                }
            }
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                Episode episode = episodeAction.Episode;

                foreach (var item in episode.SubEpisodes)
                {
                    if (item.CurrentStateDefID != SubEpisode.States.Cancelled)
                    {
                        viewModel.ProtocolNo = item.ProtocolNo;
                        //TODO
                        viewModel.ClinicName = item.ResSection.GetMySKRSKlinikler().ADI;
                        break;
                    }
                }
                // Hasta Bilgileri
                viewModel.PatientName = episode.Patient.Name;
                viewModel.UniqueRefNo = episode.Patient.UniqueRefNo;
                viewModel.Sex = episode.Patient?.Sex;
                viewModel.Age = episode.Patient?.Age;
                viewModel.Occupation = episode.Patient?.Occupation;
                viewModel.EducationStatus = episode.Patient?.EducationStatus;
                viewModel.SKRSMaritalStatus = episode.Patient?.SKRSMaritalStatus;
                viewModel.BloodGroupType = episode.Patient?.BloodGroupType;

                //Refakatçi Bilgileri
                if(episodeAction is NursingApplication && nursingPatientPreAssessment.NursingApplication == null)
                {
                    nursingPatientPreAssessment.NursingApplication = (NursingApplication)episodeAction;
                }
           
                if (nursingPatientPreAssessment.NursingApplication != null && nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp != null)
                {
                    viewModel.RelativeNeed = ((InpatientAdmission) nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission).MedulaRefakatciDurumu;
                    var companionApplication = nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp.CompanionApplications.OrderByDescending(t => t.RequestDate).FirstOrDefault(dr => dr.CurrentStateDefID == CompanionApplication.States.Active);
                    if (companionApplication!= null)
                    {
                        viewModel.RelativeNeed = true;
                        viewModel.RelativeFullName = companionApplication.CompanionName;
                        viewModel.RelativeMobilePhone = episode.Patient.PatientAddress.RelativeMobilePhone;
                        viewModel.RelativeHomeAddress = companionApplication.CompanionAddress;
                        viewModel.RelativeRelationship = companionApplication.Relationship;
                    }
                    
                }


                //Týbbi Bilgiler
                if (episode.Patient.MedicalInformation != null)
                {
                    viewModel.DietMaterialList = DietMaterialDefinition.GetDietMaterialDefinitions(objectContext, "WHERE ISACTIVE = 1").ToList();
                    viewModel.ActiveIngredients = ActiveIngredientDefinition.GetAllActiveIngredientDefinitions(objectContext, "WHERE ISACTIVE = 1").ToList();
                    viewModel.ChronicDiseases = episode.Patient.MedicalInformation.ChronicDiseases;
                    if(episode.Patient.MedicalInformation.HasAllergy == VarYokGarantiEnum.V)
                    {
                        viewModel.HasAllergy = true;
                    }
                    else
                    {
                        viewModel.HasAllergy = false;
                    }
                    viewModel.OtherAllergies = episode.Patient.MedicalInformation.MedicalInfoAllergies?.OtherAllergies;
                    viewModel.DrugAllergies = new List<ActiveIngredientDefinition>();
                    viewModel.FoodAllergies = new List<DietMaterialDefinition>();
                    if (episode.Patient.MedicalInformation.MedicalInfoAllergies != null)
                    {
                        foreach (var drugAllergy in episode.Patient.MedicalInformation.MedicalInfoAllergies?.MedicalInfoDrugAllergies?.ToList())
                        {
                            viewModel.DrugAllergies.Add(drugAllergy.ActiveIngredient);
                        }
                        foreach (var foodAllergy in episode.Patient.MedicalInformation.MedicalInfoAllergies?.MedicalInfoFoodAllergies?.ToList())
                        {
                            viewModel.FoodAllergies.Add(foodAllergy.DietMaterial);
                        }
                    }

                    if (episode.Patient.MedicalInformation.HasContagiousDisease == VarYokGarantiEnum.V)
                    {
                        viewModel.HasContagiousDisease = true;
                    }
                    else
                    {
                        viewModel.HasContagiousDisease = false;
                    }

                    viewModel.ContagiousDisease = episode.Patient.MedicalInformation.ContagiousDisease;
                    viewModel.Cigarette = episode.Patient.MedicalInformation?.MedicalInfoHabits?.Cigarette;
                    viewModel.CigaretteUsageFrequency = episode.Patient.MedicalInformation?.MedicalInfoHabits?.CigaretteUsageFrequency;
                    viewModel.Alcohol = episode.Patient.MedicalInformation?.MedicalInfoHabits?.Alcohol;
                    viewModel.AlcoholUsageFrequency = episode.Patient.MedicalInformation?.MedicalInfoHabits?.AlcoholUsageFrequency;
                    viewModel.Drug = episode.Patient.MedicalInformation?.MedicalInfoHabits?.Drug;
                    viewModel.DrugUsageFrequency = episode.Patient.MedicalInformation?.MedicalInfoHabits?.DrugUsageFrequency;
                }
                viewModel.Diagnosis = "";
                int a = episodeAction.SubEpisode.Diagnosis.Count;
                for (int i = 0; i < a; i++)
                {
                    viewModel.Diagnosis = viewModel.Diagnosis + episodeAction.SubEpisode.Diagnosis[i].Diagnose.Name.ToString() + " ,";
                }
                if (nursingPatientPreAssessment.NursingApplication != null)
                {
                    if (nursingPatientPreAssessment.NursingApplication.Temperatures.Count > 0)
                    {
                        viewModel.ANT = "Ateþ: " + nursingPatientPreAssessment.NursingApplication.Temperatures.FirstOrDefault()?.Value.ToString() + " ";
                    }
                    if (nursingPatientPreAssessment.NursingApplication.Pulses.Count > 0)
                    {
                        viewModel.ANT = "Nabýz: " + nursingPatientPreAssessment.NursingApplication.Pulses.FirstOrDefault()?.Value.ToString() + " ";
                    }
                    if (nursingPatientPreAssessment.NursingApplication.BloodPressures.Count > 0)
                    {
                        viewModel.ANT = "Tansiyon(Diastolik): " + nursingPatientPreAssessment.NursingApplication.BloodPressures.FirstOrDefault()?.Diastolik.ToString()
                                                + " Tansiyon(Sistolik): " + nursingPatientPreAssessment.NursingApplication.BloodPressures.FirstOrDefault()?.Sistolik.ToString();
                    }
                }
            }
            viewModel.SKRSKanGrubus = objectContext.LocalQuery<SKRSKanGrubu>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKanGrubuList", viewModel.SKRSKanGrubus);

        }
        partial void PostScript_NursingPatientPreAssessmentForm(NursingPatientPreAssessmentFormViewModel viewModel, NursingPatientPreAssessment nursingPatientPreAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                Episode episode = objectContext.GetObject<Episode>(episodeAction.Episode.ObjectID);
                //Hasta Bilgileri
                episode.Patient.EducationStatus = viewModel.EducationStatus;
                episode.Patient.Occupation = viewModel.Occupation;
                episode.Patient.SKRSMaritalStatus = viewModel.SKRSMaritalStatus;
                episode.Patient.BloodGroupType = viewModel.BloodGroupType;

                //Refakatçi Bilgileri
                if (nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp != null)
                {
                    ((InpatientAdmission)nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission).MedulaRefakatciDurumu = viewModel.RelativeNeed;
                    if (viewModel.RelativeNeed == true)
                    {
                        CompanionApplication companionApplication = nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp.CompanionApplications.OrderByDescending(t => t.RequestDate).FirstOrDefault(dr => dr.CurrentStateDefID == CompanionApplication.States.Active);
                        if (companionApplication == null)
                        {
                            companionApplication = new CompanionApplication(objectContext);
                            companionApplication.SetMandatoryEpisodeActionProperties(nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp, nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp.MasterResource, true);
                            companionApplication.InpatientAdmission = (InpatientAdmission)nursingPatientPreAssessment.NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission;
                            companionApplication.CurrentStateDefID = CompanionApplication.States.Active;

                        }

                        companionApplication.CompanionName = viewModel.RelativeFullName;
                        companionApplication.CompanionAddress = viewModel.RelativeHomeAddress;
                        companionApplication.Relationship = viewModel.RelativeRelationship;
                    }
                }
                episode.Patient.PatientAddress.RelativeMobilePhone = viewModel.RelativeMobilePhone;
                MedicalInformation medicalInformation;
                //Týbbi Bilgiler
                if (episode.Patient.MedicalInformation == null)
                {
                    medicalInformation = new MedicalInformation(objectContext);
                    episode.Patient.MedicalInformation = medicalInformation;
                }
                else
                    medicalInformation = objectContext.GetObject<MedicalInformation>(episode.Patient.MedicalInformation.ObjectID);
                medicalInformation.ChronicDiseases = viewModel.ChronicDiseases;
                if(viewModel.HasAllergy == true)
                {
                    medicalInformation.HasAllergy = VarYokGarantiEnum.V;
                }
                else
                {
                    medicalInformation.HasAllergy = VarYokGarantiEnum.Y;
                }
                if (medicalInformation.MedicalInfoAllergies == null)
                {
                    medicalInformation.MedicalInfoAllergies = new MedicalInfoAllergies(objectContext);
                    episode.Patient.MedicalInformation.MedicalInfoAllergies = medicalInformation.MedicalInfoAllergies;
                }
                else
                    medicalInformation.MedicalInfoAllergies = objectContext.GetObject<MedicalInfoAllergies>(episode.Patient.MedicalInformation.MedicalInfoAllergies.ObjectID);

                medicalInformation.MedicalInfoAllergies.OtherAllergies = viewModel.OtherAllergies;
                if (viewModel.DrugAllergies == null)
                    viewModel.DrugAllergies = new List<ActiveIngredientDefinition>();
                if (viewModel.FoodAllergies == null)
                    viewModel.FoodAllergies = new List<DietMaterialDefinition>();
                while (viewModel?.FoodAllergies?.Count != medicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count)
                {
                    if (viewModel.FoodAllergies?.Count < medicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count)
                        ((ITTObject)medicalInformation?.MedicalInfoAllergies?.MedicalInfoFoodAllergies[0])?.Delete();
                    else
                    {
                        var medicalInfoFoodAllergies = new MedicalInfoFoodAllergies(objectContext);
                        medicalInformation?.MedicalInfoAllergies?.MedicalInfoFoodAllergies?.Add(medicalInfoFoodAllergies);
                    }
                }

                while (viewModel?.DrugAllergies.Count != medicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies?.Count)
                {
                    if (viewModel?.DrugAllergies.Count < medicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies?.Count)
                        ((ITTObject)medicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies[0]).Delete();
                    else
                    {
                        var medicalInfoDrugAllergies = new MedicalInfoDrugAllergies(objectContext);
                        medicalInformation?.MedicalInfoAllergies?.MedicalInfoDrugAllergies?.Add(medicalInfoDrugAllergies);
                    }
                }
                var i = 0;
                foreach (var item in viewModel.FoodAllergies)
                {
                    medicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies[i++].DietMaterial = item;
                }

                i = 0;
                foreach (var item in viewModel.DrugAllergies)
                {
                    medicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies[i++].ActiveIngredient = item;
                }

                //if (viewModel.HasContagiousDisease != null)
                //{
                //    medicalInformation.HasContagiousDisease = viewModel.HasContagiousDisease.Value;
                //    medicalInformation.ContagiousDisease = viewModel.ContagiousDisease;
                //}

                if (viewModel.HasContagiousDisease == true)
                {
                    medicalInformation.HasContagiousDisease = VarYokGarantiEnum.V;
                    medicalInformation.ContagiousDisease = viewModel.ContagiousDisease;
                }
                else
                {
                    medicalInformation.HasContagiousDisease = VarYokGarantiEnum.Y;
                    medicalInformation.ContagiousDisease = viewModel.ContagiousDisease;
                }

                if (medicalInformation.MedicalInfoHabits == null)
                    medicalInformation.MedicalInfoHabits = new MedicalInfoHabits(objectContext);
                medicalInformation.MedicalInfoHabits.Cigarette = viewModel.Cigarette;
                medicalInformation.MedicalInfoHabits.CigaretteUsageFrequency = viewModel.CigaretteUsageFrequency;
                medicalInformation.MedicalInfoHabits.Alcohol = viewModel.Alcohol;
                medicalInformation.MedicalInfoHabits.AlcoholUsageFrequency = viewModel.AlcoholUsageFrequency;
                medicalInformation.MedicalInfoHabits.Drug = viewModel.Drug;
                medicalInformation.MedicalInfoHabits.DrugUsageFrequency = viewModel.DrugUsageFrequency;


            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsire,TTRoleNames.Tabip,TTRoleNames.Sekreter)]
        public string[] CheckMernisNumber(long TC)
        {
            string[] mernisInfo = new string[2];

            //mernisInfo[0] = "ismailþ ra";
            //mernisInfo[1] = "sadasd asda d a";
            if (TC != 0)
            {
                try
                {
                    //KPSV2.KpsServisSonucuBilesikKisiBilgisi response = KPSV2.WebMethods.BilesikKisiveAdresSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(TC));
                    KPSServis.KPSServisSonucuKisiTemelBilgisi response = KPSServis.WebMethods.TcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(TC));
                    mernisInfo[0] = response.Sonuc.Ad + " " + response.Sonuc.Soyad;

                    KPSServis.KPSServisSonucuKisiAdresBilgisi _kisiAdresbilgisi = KPSServis.WebMethods.TcKimlikNoIleAdresBilgisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(TC));
                    var acikAdres = _kisiAdresbilgisi.Sonuc.BinaBlokAdi + " " + _kisiAdresbilgisi.Sonuc.DisKapiNo + " " + _kisiAdresbilgisi.Sonuc.IcKapiNo + " " + _kisiAdresbilgisi.Sonuc.Csbm + " " + _kisiAdresbilgisi.Sonuc.Mahalle + " " + _kisiAdresbilgisi.Sonuc.Ilce + " " + _kisiAdresbilgisi.Sonuc.Il;

                    if (!string.IsNullOrEmpty(_kisiAdresbilgisi.Sonuc.YabanciAdres))
                    {
                        acikAdres = _kisiAdresbilgisi.Sonuc.YabanciAdres;
                    }
                    mernisInfo[1] = acikAdres;
                }
                catch (Exception ex)
                {
                    throw new Exception("Mernis bilgileri çekilirken bir sorunla karþýlaþýldý./n bilgileri manuel olarak girebilirsiniz");
                }
                
            }
            return mernisInfo;
        }
    }
}

namespace Core.Models
{
    public partial class NursingPatientPreAssessmentFormViewModel : BaseViewModel
    {
        public string PatientName
        {
            get;
            set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }
        public long? UniqueRefNo
        {
            get;
            set;
        }

        public SKRSCinsiyet Sex
        {
            get;
            set;
        }
        public int? Age
        {
            get;
            set;
        }
        public SKRSMeslekler Occupation
        {
            get;
            set;
        }
        public SKRSOgrenimDurumu EducationStatus
        {
            get;
            set;
        }
        public SKRSMedeniHali SKRSMaritalStatus
        {
            get;
            set;
        }
        public bool? RelativeNeed
        {
            get;
            set;
        }
        public string RelativeFullName
        {
            get;
            set;
        }
        public string RelativeMobilePhone
        {
            get;
            set;
        }
        public string RelativeHomeAddress
        {
            get;
            set;
        }
        public RelationshipType? RelativeRelationship
        {
            get;
            set;
        }
        public string ChronicDiseases
        {
            get;
            set;
        }
        public bool? HasAllergy
        {
            get;
            set;
        }
        public string OtherAllergies
        {
            get;
            set;
        }
        public List<ActiveIngredientDefinition> ActiveIngredients
        {
            get;
            set;
        }
        public List<ActiveIngredientDefinition> DrugAllergies
        {
            get;
            set;
        }

        public List<DietMaterialDefinition> DietMaterialList
        {
            get;
            set;
        }
        public List<DietMaterialDefinition> FoodAllergies
        {
            get;
            set;
        }
        public bool? HasContagiousDisease
        {
            get;
            set;
        }
        public string ContagiousDisease
        {
            get;
            set;
        }

        public bool? Cigarette
        {
            get;
            set;
        }

        public SKRSSigaraKullanimi CigaretteUsageFrequency
        {
            get;
            set;
        }

        public bool? Alcohol
        {
            get;
            set;
        }

        public SKRSAlkolKullanimi AlcoholUsageFrequency
        {
            get;
            set;
        }
        public SKRSKanGrubu BloodGroupType
        {
            get;
            set;
        }
        public bool? Drug
        {
            get;
            set;
        }

        public SKRSMaddeKullanimi DrugUsageFrequency
        {
            get;
            set;
        }
        public string ClinicName
        {
            get;
            set;
        }

        public string Diagnosis
        {
            get;
            set;
        }

        public string ANT
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKanGrubu[] SKRSKanGrubus
        {
            get;
            set;
        }
    }
}
