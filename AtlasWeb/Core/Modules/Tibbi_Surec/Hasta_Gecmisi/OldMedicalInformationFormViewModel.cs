//$6F2747D9
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class MedicalInformationServiceController
    {
        partial void PreScript_OldMedicalInformationForm(OldMedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTObjectContext objectContext)
        {
            if (viewModel._MedicalInformation.MedicalInfoAllergies != null)
            {
                viewModel.OtherAllergies = isNullOrEmpty(viewModel._MedicalInformation.MedicalInfoAllergies.OtherAllergies);
                if (viewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies != null)
                {
                    StringBuilder _drugs = new StringBuilder();
                    int drugcount = 0;
                    foreach (var item in viewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies)
                    {
                        _drugs.Append(item.ActiveIngredient.Name);
                        drugcount++;
                        if (drugcount < viewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Count)
                        {
                            _drugs.Append(" , ");
                        }
                    }

                    viewModel.DrugAllergies = _drugs.ToString();
                }

                if (viewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies != null)
                {
                    StringBuilder _foods = new StringBuilder();
                    int foodcount = 0;
                    foreach (var item in viewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies)
                    {
                        _foods.Append(item.DietMaterial.MaterialName);
                        foodcount++;
                        if (foodcount < viewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count)
                        {
                            _foods.Append(" , ");
                        }
                    }

                    viewModel.FoodAllergies = _foods.ToString();
                }
            }

            if (viewModel._MedicalInformation.MedicalInfoHabits != null)
            {
                StringBuilder _habits = new StringBuilder();
                if (viewModel._MedicalInformation.MedicalInfoHabits.Alcohol == true)
                {
                    _habits.Append(viewModel._MedicalInformation.MedicalInfoHabits.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Alcohol").FirstOrDefault().Caption);
                    _habits.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoHabits.Cigarette == true)
                {
                    _habits.Append(viewModel._MedicalInformation.MedicalInfoHabits.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Cigarette").FirstOrDefault().Caption);
                    _habits.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoHabits.Coffee == true)
                {
                    _habits.Append(viewModel._MedicalInformation.MedicalInfoHabits.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Coffee").FirstOrDefault().Caption);
                    _habits.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoHabits.Tea == true)
                {
                    _habits.Append(viewModel._MedicalInformation.MedicalInfoHabits.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Tea").FirstOrDefault().Caption);
                    _habits.Append(" ");
                }

                viewModel.Habits = _habits.ToString();
                if (viewModel._MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency != null)
                {
                    viewModel.CigaretteUsageFrequency = viewModel._MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency.ADI;
                }

                if (viewModel._MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency != null)
                {
                    viewModel.AlcoholUsageFrequency = viewModel._MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency.ADI;
                }

                if (viewModel._MedicalInformation.MedicalInfoHabits.Description != null)
                {
                    viewModel.HabitDescription = viewModel._MedicalInformation.MedicalInfoHabits.Description;
                }
            }

            if (viewModel._MedicalInformation.MedicalInfoDisabledGroup != null)
            {
                StringBuilder _medicalDisabledGroup = new StringBuilder();
                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Nonexistence == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Nonexistence").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Chronic == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Chronic").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Hearing == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Hearing").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Mental == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Mental").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Orthopedic == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Orthopedic").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "PsychicAndEmotional").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "SpeechAndLanguage").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Vision == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Vision").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                if (viewModel._MedicalInformation.MedicalInfoDisabledGroup.Unclassified == true)
                {
                    _medicalDisabledGroup.Append(viewModel._MedicalInformation.MedicalInfoDisabledGroup.ObjectDef.PropertyDefs.Values.Where(p => p.CodeName == "Unclassified").FirstOrDefault().Caption);
                    _medicalDisabledGroup.Append(" ");
                }

                viewModel.MedicalDisabledGroup = _medicalDisabledGroup.ToString();
            }
        }

        private string isNullOrEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                return input;
            }
        }
    }
}

namespace Core.Models
{
    public partial class OldMedicalInformationFormViewModel
    {
        public string OtherAllergies
        {
            get;
            set;
        }

        public string DrugAllergies
        {
            get;
            set;
        }

        public string FoodAllergies
        {
            get;
            set;
        }

        public string Habits
        {
            get;
            set;
        }

        public string CigaretteUsageFrequency
        {
            get;
            set;
        }

        public string AlcoholUsageFrequency
        {
            get;
            set;
        }

        public string HabitDescription
        {
            get;
            set;
        }

        public string MedicalDisabledGroup
        {
            get;
            set;
        }
    }
}