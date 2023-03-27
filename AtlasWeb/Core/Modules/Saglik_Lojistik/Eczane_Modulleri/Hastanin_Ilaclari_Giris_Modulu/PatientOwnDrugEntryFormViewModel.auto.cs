//$01AFC554
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
    public partial class PatientOwnDrugEntryServiceController : Controller
    {
        [HttpGet]
        public PatientOwnDrugEntryFormViewModel PatientOwnDrugEntryForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PatientOwnDrugEntryFormLoadInternal(input);
        }

        [HttpPost]
        public PatientOwnDrugEntryFormViewModel PatientOwnDrugEntryFormLoad(FormLoadInput input)
        {
            return PatientOwnDrugEntryFormLoadInternal(input);
        }

        private PatientOwnDrugEntryFormViewModel PatientOwnDrugEntryFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("07862305-80fb-4e3b-a586-f5e0624dff27");
            var objectDefID = Guid.Parse("0fe703f4-0496-4e27-abfb-80992bfc6628");
            var viewModel = new PatientOwnDrugEntryFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientOwnDrugEntry = objectContext.GetObject(id.Value, objectDefID) as PatientOwnDrugEntry;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOwnDrugEntry, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugEntry, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PatientOwnDrugEntry);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PatientOwnDrugEntry);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_PatientOwnDrugEntryForm(viewModel, viewModel._PatientOwnDrugEntry, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientOwnDrugEntry = new PatientOwnDrugEntry(objectContext);
                    var entryStateID = Guid.Parse("065f9abd-7f5c-4083-a574-165464a083a7");
                    viewModel._PatientOwnDrugEntry.CurrentStateDefID = entryStateID;
                    viewModel.PatientOwnDrugEntryDetailsGridList = new TTObjectClasses.PatientOwnDrugEntryDetail[] { };
                    viewModel.PatientLastUseDrugs = new TTObjectClasses.PatientLastUseDrug[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOwnDrugEntry, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugEntry, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientOwnDrugEntry);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientOwnDrugEntry);
                    PreScript_PatientOwnDrugEntryForm(viewModel, viewModel._PatientOwnDrugEntry, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PatientOwnDrugEntryForm(PatientOwnDrugEntryFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PatientOwnDrugEntryFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PatientOwnDrugEntryFormInternal(PatientOwnDrugEntryFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("07862305-80fb-4e3b-a586-f5e0624dff27");
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.PatientOwnDrugEntryDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.PatientLastUseDrugs);
            var entryStateID = Guid.Parse("065f9abd-7f5c-4083-a574-165464a083a7");
            objectContext.AddToRawObjectList(viewModel._PatientOwnDrugEntry, entryStateID);
            objectContext.ProcessRawObjects(false);
            var patientOwnDrugEntry = (PatientOwnDrugEntry)objectContext.GetLoadedObject(viewModel._PatientOwnDrugEntry.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientOwnDrugEntry, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugEntry, formDefID);
            if (viewModel.PatientOwnDrugEntryDetailsGridList != null)
            {
                foreach (var item in viewModel.PatientOwnDrugEntryDetailsGridList)
                {
                    var patientOwnDrugEntryDetailsImported = (PatientOwnDrugEntryDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)patientOwnDrugEntryDetailsImported).IsDeleted)
                        continue;
                    patientOwnDrugEntryDetailsImported.PatientOwnDrugEntry = patientOwnDrugEntry;
                }
            }


            if (viewModel.PatientLastUseDrugs != null)
            {
                foreach (var item in viewModel.PatientLastUseDrugs)
                {
                    var patientLastUseDrugsImported = (PatientLastUseDrug)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)patientLastUseDrugsImported).IsDeleted)
                        continue;
                    patientLastUseDrugsImported.PatientOwnDrugEntry = patientOwnDrugEntry;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(patientOwnDrugEntry);
            PostScript_PatientOwnDrugEntryForm(viewModel, patientOwnDrugEntry, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientOwnDrugEntry);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientOwnDrugEntry);
            AfterContextSaveScript_PatientOwnDrugEntryForm(viewModel, patientOwnDrugEntry, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_PatientOwnDrugEntryForm(PatientOwnDrugEntryFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTObjectContext objectContext);
        partial void PostScript_PatientOwnDrugEntryForm(PatientOwnDrugEntryFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PatientOwnDrugEntryForm(PatientOwnDrugEntryFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(PatientOwnDrugEntryFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.PatientOwnDrugEntryDetailsGridList = viewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails.OfType<PatientOwnDrugEntryDetail>().ToArray();
            viewModel.PatientLastUseDrugs = viewModel._PatientOwnDrugEntry.PatientLastUseDrugs.OfType<PatientLastUseDrug>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        }
    }
}


namespace Core.Models
{
    public partial class PatientOwnDrugEntryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PatientOwnDrugEntry _PatientOwnDrugEntry { get; set; }
        public TTObjectClasses.PatientOwnDrugEntryDetail[] PatientOwnDrugEntryDetailsGridList { get; set; }
        public TTObjectClasses.PatientLastUseDrug[] PatientLastUseDrugs { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
    }
}
