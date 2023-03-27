//$FB39466C
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
    public partial class PhysiotherapyRequestServiceController : Controller
{
    [HttpGet]
    public PhysiotherapyRequestFormViewModel PhysiotherapyRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PhysiotherapyRequestFormLoadInternal(input);
    }

    [HttpPost]
    public PhysiotherapyRequestFormViewModel PhysiotherapyRequestFormLoad(FormLoadInput input)
    {
        return PhysiotherapyRequestFormLoadInternal(input);
    }

    private PhysiotherapyRequestFormViewModel PhysiotherapyRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("f6541bd3-a0db-42a9-8a75-43db59243c92");
        var objectDefID = Guid.Parse("43225fba-1931-42a1-b745-23599ea82b65");
        var viewModel = new PhysiotherapyRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyRequest = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PhysiotherapyRequestForm(viewModel, viewModel._PhysiotherapyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyRequest = new PhysiotherapyRequest(objectContext);
                var entryStateID = Guid.Parse("efe2cd24-4e82-49d1-9c8e-f63afb60c804");
                viewModel._PhysiotherapyRequest.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysiotherapyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysiotherapyRequest);
                PreScript_PhysiotherapyRequestForm(viewModel, viewModel._PhysiotherapyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PhysiotherapyRequestForm(PhysiotherapyRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("f6541bd3-a0db-42a9-8a75-43db59243c92");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("efe2cd24-4e82-49d1-9c8e-f63afb60c804");
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyRequest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var physiotherapyRequest = (PhysiotherapyRequest)objectContext.GetLoadedObject(viewModel._PhysiotherapyRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(physiotherapyRequest);
            PostScript_PhysiotherapyRequestForm(viewModel, physiotherapyRequest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyRequest);
            AfterContextSaveScript_PhysiotherapyRequestForm(viewModel, physiotherapyRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PhysiotherapyRequestForm(PhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext);
    partial void PostScript_PhysiotherapyRequestForm(PhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PhysiotherapyRequestForm(PhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PhysiotherapyRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class PhysiotherapyRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest { get; set; }
    }
}
