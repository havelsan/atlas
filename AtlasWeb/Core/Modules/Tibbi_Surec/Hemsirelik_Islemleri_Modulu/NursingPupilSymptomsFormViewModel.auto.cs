//$27724DAC
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
    public partial class NursingPupilSymptomsServiceController : Controller
{
    [HttpGet]
    public NursingPupilSymptomsFormViewModel NursingPupilSymptomsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingPupilSymptomsFormLoadInternal(input);
    }

    [HttpPost]
    public NursingPupilSymptomsFormViewModel NursingPupilSymptomsFormLoad(FormLoadInput input)
    {
        return NursingPupilSymptomsFormLoadInternal(input);
    }

    private NursingPupilSymptomsFormViewModel NursingPupilSymptomsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d43612b4-6aad-4d92-9b82-73ca529210cd");
        var objectDefID = Guid.Parse("2409bafa-2fe7-4839-a9b8-b855fb528ba4");
        var viewModel = new NursingPupilSymptomsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingPupilSymptoms = objectContext.GetObject(id.Value, objectDefID) as NursingPupilSymptoms;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingPupilSymptoms, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPupilSymptoms, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingPupilSymptoms);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingPupilSymptoms);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingPupilSymptomsForm(viewModel, viewModel._NursingPupilSymptoms, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingPupilSymptoms = new NursingPupilSymptoms(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingPupilSymptoms.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingPupilSymptoms, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPupilSymptoms, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingPupilSymptoms);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingPupilSymptoms);
                PreScript_NursingPupilSymptomsForm(viewModel, viewModel._NursingPupilSymptoms, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingPupilSymptomsForm(NursingPupilSymptomsFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d43612b4-6aad-4d92-9b82-73ca529210cd");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingPupilSymptoms, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingPupilSymptoms = (NursingPupilSymptoms)objectContext.GetLoadedObject(viewModel._NursingPupilSymptoms.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingPupilSymptoms, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPupilSymptoms, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingPupilSymptoms);
            PostScript_NursingPupilSymptomsForm(viewModel, nursingPupilSymptoms, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingPupilSymptoms);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingPupilSymptoms);
            AfterContextSaveScript_NursingPupilSymptomsForm(viewModel, nursingPupilSymptoms, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingPupilSymptomsForm(NursingPupilSymptomsFormViewModel viewModel, NursingPupilSymptoms nursingPupilSymptoms, TTObjectContext objectContext);
    partial void PostScript_NursingPupilSymptomsForm(NursingPupilSymptomsFormViewModel viewModel, NursingPupilSymptoms nursingPupilSymptoms, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingPupilSymptomsForm(NursingPupilSymptomsFormViewModel viewModel, NursingPupilSymptoms nursingPupilSymptoms, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingPupilSymptomsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingPupilSymptomsFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingPupilSymptoms _NursingPupilSymptoms { get; set; }
    }
}
