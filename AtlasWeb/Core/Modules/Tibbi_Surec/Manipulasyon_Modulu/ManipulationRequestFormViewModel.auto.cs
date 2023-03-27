//$F3DF35AF
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
    public partial class ManipulationRequestServiceController : Controller
{
    [HttpGet]
    public ManipulationRequestFormViewModel ManipulationRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ManipulationRequestFormLoadInternal(input);
    }

    [HttpPost]
    public ManipulationRequestFormViewModel ManipulationRequestFormLoad(FormLoadInput input)
    {
        return ManipulationRequestFormLoadInternal(input);
    }

    private ManipulationRequestFormViewModel ManipulationRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("386e8ade-c655-4a46-a12d-ef45b1fedf75");
        var objectDefID = Guid.Parse("0f84f410-9e6b-4a8a-bb98-be2a07e3186a");
        var viewModel = new ManipulationRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManipulationRequest = objectContext.GetObject(id.Value, objectDefID) as ManipulationRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManipulationRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ManipulationRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ManipulationRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ManipulationRequestForm(viewModel, viewModel._ManipulationRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManipulationRequest = new ManipulationRequest(objectContext);
                var entryStateID = Guid.Parse("55a6468f-5bec-47a2-8617-e59e04a03b15");
                viewModel._ManipulationRequest.CurrentStateDefID = entryStateID;
                viewModel.GridManipulationProceduresGridList = new TTObjectClasses.ManipulationProcedure[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManipulationRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ManipulationRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ManipulationRequest);
                PreScript_ManipulationRequestForm(viewModel, viewModel._ManipulationRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ManipulationRequestForm(ManipulationRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("386e8ade-c655-4a46-a12d-ef45b1fedf75");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.GridManipulationProceduresGridList);
            var entryStateID = Guid.Parse("55a6468f-5bec-47a2-8617-e59e04a03b15");
            objectContext.AddToRawObjectList(viewModel._ManipulationRequest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var manipulationRequest = (ManipulationRequest)objectContext.GetLoadedObject(viewModel._ManipulationRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulationRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationRequest, formDefID);
            if (viewModel.GridManipulationProceduresGridList != null)
            {
                foreach (var item in viewModel.GridManipulationProceduresGridList)
                {
                    var manipulationProceduresImported = (ManipulationProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationProceduresImported).IsDeleted)
                        continue;
                    manipulationProceduresImported.ManipulationRequest = manipulationRequest;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(manipulationRequest);
            PostScript_ManipulationRequestForm(viewModel, manipulationRequest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manipulationRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manipulationRequest);
            AfterContextSaveScript_ManipulationRequestForm(viewModel, manipulationRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ManipulationRequestForm(ManipulationRequestFormViewModel viewModel, ManipulationRequest manipulationRequest, TTObjectContext objectContext);
    partial void PostScript_ManipulationRequestForm(ManipulationRequestFormViewModel viewModel, ManipulationRequest manipulationRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ManipulationRequestForm(ManipulationRequestFormViewModel viewModel, ManipulationRequest manipulationRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ManipulationRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridManipulationProceduresGridList = viewModel._ManipulationRequest.ManipulationProcedures.OfType<ManipulationProcedure>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ManiplationListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
    }
}
}


namespace Core.Models
{
    public partial class ManipulationRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ManipulationRequest _ManipulationRequest { get; set; }
        public TTObjectClasses.ManipulationProcedure[] GridManipulationProceduresGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
    }
}
