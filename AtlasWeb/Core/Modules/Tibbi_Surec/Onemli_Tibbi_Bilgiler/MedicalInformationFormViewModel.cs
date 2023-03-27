//$5F684092
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class MedicalInformationServiceController : Controller
    {
        partial void PreScript_MedicalInformationForm(MedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTObjectContext objectContext)
        {
            if (medicalInformation.MedicalInfoAllergies == null)
            {
                medicalInformation.MedicalInfoAllergies = new MedicalInfoAllergies(objectContext);
            }
            if (medicalInformation.MedicalInfoHabits == null)
            {
                medicalInformation.MedicalInfoHabits = new MedicalInfoHabits(objectContext);
            }
            if (medicalInformation.MedicalInfoDisabledGroup == null)
            {
                medicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup(objectContext);
            }

            ContextToViewModel(viewModel, objectContext);

        }

        partial void PostScript_MedicalInformationForm(MedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (medicalInformation.Patient == null || medicalInformation.Patient.Count() == 0)
            {
                Guid? activePatientObjectID = viewModel.GetSelectedPatientID();
                if (activePatientObjectID.HasValue)
                {
                    Patient activepatient = objectContext.GetObject<Patient>(activePatientObjectID.Value);
                    activepatient.MedicalInformation = medicalInformation;
                }
            }

            if(medicalInformation.HighRiskPregnancy != null && viewModel.changeHighRiskPregnancy == true)
            {
                medicalInformation.HighRiskPregnancyDate = Common.RecTime();
            }
        }
        partial void AfterContextSaveScript_MedicalInformationForm(MedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {


        }

    }
}

namespace Core.Models
{
    public partial class MedicalInformationFormViewModel
    {
        //public TTObjectClasses.MedicalInformation _MedicalInformation { get; set; }
        //public TTObjectClasses.MedicalInfoFoodAllergies[] MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList { get; set; }
        //public TTObjectClasses.MedicalInfoDrugAllergies[] MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList { get; set; }
        //public TTObjectClasses.MedicalInfoDisabledGroup[] MedicalInfoDisabledGroups { get; set; }
        //public TTObjectClasses.MedicalInfoHabits[] MedicalInfoHabitss { get; set; }
        //public TTObjectClasses.SKRSSigaraKullanimi[] SKRSSigaraKullanimis { get; set; }
        //public TTObjectClasses.SKRSAlkolKullanimi[] SKRSAlkolKullanimis { get; set; }
        //public TTObjectClasses.MedicalInfoAllergies[] MedicalInfoAllergiess { get; set; }
        //public TTObjectClasses.DietMaterialDefinition[] DietMaterialDefinitions { get; set; }
        //public TTObjectClasses.ActiveIngredientDefinition[] ActiveIngredientDefinitions { get; set; }
        public string _PatientID
        {
            get;
            set;
        }

        public object _selectedMedicalInfoFoodAllergyValue
        {
            get;
            set;
        }

        public object _selectedMedicalInfoDrugAllergyValue
        {
            get;
            set;
        }
        public bool checkBoxControl
        {
            get;
            set;
        }
        public bool buttonControl { get; set; }

        public bool allergyControl { get; set; }

        public bool changeHighRiskPregnancy { get; set; }
    }
}