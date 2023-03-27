//$125D4BE5
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class MedicalInformationServiceController : Controller
    {
        [HttpGet]
        public MedicalInformationFormViewModel MedicalInformationForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return MedicalInformationFormLoadInternal(input);
        }

        [HttpPost]
        public MedicalInformationFormViewModel MedicalInformationFormLoad(FormLoadInput input)
        {
            return MedicalInformationFormLoadInternal(input);
        }

        private MedicalInformationFormViewModel MedicalInformationFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("0a75467e-5e15-480c-9e42-91c33b72871f");
            var objectDefID = Guid.Parse("4c1a03ca-db04-4414-90f7-4e353a44cbf2");
            var viewModel = new MedicalInformationFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalInformation = objectContext.GetObject(id.Value, objectDefID) as MedicalInformation;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalInformation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalInformation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedicalInformation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedicalInformation);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_MedicalInformationForm(viewModel, viewModel._MedicalInformation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalInformation = new MedicalInformation(objectContext);
                    viewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList = new TTObjectClasses.MedicalInfoFoodAllergies[] { };
                    viewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList = new TTObjectClasses.MedicalInfoDrugAllergies[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalInformation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalInformation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalInformation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalInformation);
                    PreScript_MedicalInformationForm(viewModel, viewModel._MedicalInformation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel MedicalInformationForm(MedicalInformationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return MedicalInformationFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel MedicalInformationFormInternal(MedicalInformationFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("0a75467e-5e15-480c-9e42-91c33b72871f");
            objectContext.AddToRawObjectList(viewModel.MedicalInfoDisabledGroups);
            objectContext.AddToRawObjectList(viewModel.MedicalInfoHabitss);
            objectContext.AddToRawObjectList(viewModel.SKRSSigaraKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSAlkolKullanimis);
            objectContext.AddToRawObjectList(viewModel.MedicalInfoAllergiess);
            objectContext.AddToRawObjectList(viewModel.DietMaterialDefinitions);
            objectContext.AddToRawObjectList(viewModel.ActiveIngredientDefinitions);
            objectContext.AddToRawObjectList(viewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList);
            objectContext.AddToRawObjectList(viewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList);
            objectContext.AddToRawObjectList(viewModel._MedicalInformation);
            objectContext.ProcessRawObjects();

            var medicalInformation = (MedicalInformation)objectContext.GetLoadedObject(viewModel._MedicalInformation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(medicalInformation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalInformation, formDefID);

            var medicalInfoAllergiesImported = medicalInformation.MedicalInfoAllergies;
            if (medicalInfoAllergiesImported != null)
            {
                if (viewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList != null)
                {
                    foreach (var item in viewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList)
                    {
                        var medicalInfoFoodAllergiesImported = (MedicalInfoFoodAllergies)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)medicalInfoFoodAllergiesImported).IsDeleted)
                            continue;
                        medicalInfoFoodAllergiesImported.MedicalInfoAllergies = medicalInfoAllergiesImported;
                    }
                }

                if (viewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList != null)
                {
                    foreach (var item in viewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList)
                    {
                        var medicalInfoDrugAllergiesImported = (MedicalInfoDrugAllergies)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)medicalInfoDrugAllergiesImported).IsDeleted)
                            continue;
                        medicalInfoDrugAllergiesImported.MedicalInfoAllergies = medicalInfoAllergiesImported;
                    }
                }
            }
            var transDef = medicalInformation.TransDef;
            PostScript_MedicalInformationForm(viewModel, medicalInformation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(medicalInformation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(medicalInformation);
            AfterContextSaveScript_MedicalInformationForm(viewModel, medicalInformation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_MedicalInformationForm(MedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTObjectContext objectContext);
        partial void PostScript_MedicalInformationForm(MedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_MedicalInformationForm(MedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(MedicalInformationFormViewModel viewModel, TTObjectContext objectContext)
        {
            var medicalInfoAllergies = viewModel._MedicalInformation.MedicalInfoAllergies;
            if (medicalInfoAllergies != null)
            {
                viewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList = medicalInfoAllergies.MedicalInfoFoodAllergies.OfType<MedicalInfoFoodAllergies>().ToArray();
                viewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList = medicalInfoAllergies.MedicalInfoDrugAllergies.OfType<MedicalInfoDrugAllergies>().ToArray();
            }
            viewModel.MedicalInfoDisabledGroups = objectContext.LocalQuery<MedicalInfoDisabledGroup>().ToArray();
            viewModel.MedicalInfoHabitss = objectContext.LocalQuery<MedicalInfoHabits>().ToArray();
            viewModel.SKRSSigaraKullanimis = objectContext.LocalQuery<SKRSSigaraKullanimi>().ToArray();
            viewModel.SKRSAlkolKullanimis = objectContext.LocalQuery<SKRSAlkolKullanimi>().ToArray();
            viewModel.MedicalInfoAllergiess = objectContext.LocalQuery<MedicalInfoAllergies>().ToArray();
            viewModel.DietMaterialDefinitions = objectContext.LocalQuery<DietMaterialDefinition>().ToArray();
            viewModel.ActiveIngredientDefinitions = objectContext.LocalQuery<ActiveIngredientDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigaraKullanimiList", viewModel.SKRSSigaraKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAlkolKullanimiList", viewModel.SKRSAlkolKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DietMaterialListDefinition", viewModel.DietMaterialDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ActiveIngredientList", viewModel.ActiveIngredientDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class MedicalInformationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MedicalInformation _MedicalInformation
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalInfoFoodAllergies[] MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalInfoDrugAllergies[] MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalInfoDisabledGroup[] MedicalInfoDisabledGroups
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalInfoHabits[] MedicalInfoHabitss
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSigaraKullanimi[] SKRSSigaraKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAlkolKullanimi[] SKRSAlkolKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalInfoAllergies[] MedicalInfoAllergiess
        {
            get;
            set;
        }

        public TTObjectClasses.DietMaterialDefinition[] DietMaterialDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ActiveIngredientDefinition[] ActiveIngredientDefinitions
        {
            get;
            set;
        }
    }
}
