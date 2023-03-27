//$D70CAA61
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
    public partial class ManipulationServiceController : Controller
{
    [HttpGet]
    public ManipulationRequestAcceptionFormViewModel ManipulationRequestAcceptionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ManipulationRequestAcceptionFormLoadInternal(input);
    }

    [HttpPost]
    public ManipulationRequestAcceptionFormViewModel ManipulationRequestAcceptionFormLoad(FormLoadInput input)
    {
        return ManipulationRequestAcceptionFormLoadInternal(input);
    }

    private ManipulationRequestAcceptionFormViewModel ManipulationRequestAcceptionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("858d2530-a9de-4adb-a400-ddb9a5ed7ed0");
        var objectDefID = Guid.Parse("528f1264-6f0b-41ab-b8a3-a8eda6d9134a");
        var viewModel = new ManipulationRequestAcceptionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Manipulation = objectContext.GetObject(id.Value, objectDefID) as Manipulation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Manipulation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Manipulation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Manipulation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ManipulationRequestAcceptionForm(viewModel, viewModel._Manipulation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Manipulation = new Manipulation(objectContext);
                var entryStateID = Guid.Parse("c81c378c-a99d-4c1f-bba1-06cf1325960e");
                viewModel._Manipulation.CurrentStateDefID = entryStateID;
                viewModel.GridManipulationsGridList = new TTObjectClasses.ManipulationProcedure[]{};
                viewModel.MedulaReportResultsGridList = new TTObjectClasses.MedulaReportResult[]{};
                viewModel.GridReturnReasonsGridList = new TTObjectClasses.ManipulationReturnReasonsGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Manipulation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Manipulation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Manipulation);
                PreScript_ManipulationRequestAcceptionForm(viewModel, viewModel._Manipulation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ManipulationRequestAcceptionForm(ManipulationRequestAcceptionFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("858d2530-a9de-4adb-a400-ddb9a5ed7ed0");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.ManipulationRequests);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.GridManipulationsGridList);
            objectContext.AddToRawObjectList(viewModel.MedulaReportResultsGridList);
            objectContext.AddToRawObjectList(viewModel.GridReturnReasonsGridList);
            var entryStateID = Guid.Parse("c81c378c-a99d-4c1f-bba1-06cf1325960e");
            objectContext.AddToRawObjectList(viewModel._Manipulation, entryStateID);
            objectContext.ProcessRawObjects(false);
            var manipulation = (Manipulation)objectContext.GetLoadedObject(viewModel._Manipulation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
            if (viewModel.GridManipulationsGridList != null)
            {
                foreach (var item in viewModel.GridManipulationsGridList)
                {
                    var manipulationProceduresImported = (ManipulationProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationProceduresImported).IsDeleted)
                        continue;
                    manipulationProceduresImported.Manipulation = manipulation;
                }
            }

            if (viewModel.MedulaReportResultsGridList != null)
            {
                foreach (var item in viewModel.MedulaReportResultsGridList)
                {
                    var medulaReportResultsImported = (MedulaReportResult)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)medulaReportResultsImported).IsDeleted)
                        continue;
                    medulaReportResultsImported.Manipulation = manipulation;
                }
            }

            if (viewModel.GridReturnReasonsGridList != null)
            {
                foreach (var item in viewModel.GridReturnReasonsGridList)
                {
                    var manipulationReturnReasonsImported = (ManipulationReturnReasonsGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationReturnReasonsImported).IsDeleted)
                        continue;
                    manipulationReturnReasonsImported.Manipulation = manipulation;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(manipulation);
            PostScript_ManipulationRequestAcceptionForm(viewModel, manipulation, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manipulation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manipulation);
            AfterContextSaveScript_ManipulationRequestAcceptionForm(viewModel, manipulation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ManipulationRequestAcceptionForm(ManipulationRequestAcceptionFormViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext);
    partial void PostScript_ManipulationRequestAcceptionForm(ManipulationRequestAcceptionFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ManipulationRequestAcceptionForm(ManipulationRequestAcceptionFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ManipulationRequestAcceptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridManipulationsGridList = viewModel._Manipulation.ManipulationProcedures.OfType<ManipulationProcedure>().ToArray();
        viewModel.MedulaReportResultsGridList = viewModel._Manipulation.MedulaReportResults.OfType<MedulaReportResult>().ToArray();
        viewModel.GridReturnReasonsGridList = viewModel._Manipulation.ManipulationReturnReasons.OfType<ManipulationReturnReasonsGrid>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.ManipulationRequests = objectContext.LocalQuery<ManipulationRequest>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ManiplationListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ManipulationRequestAcceptionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Manipulation _Manipulation { get; set; }
        public TTObjectClasses.ManipulationProcedure[] GridManipulationsGridList { get; set; }
        public TTObjectClasses.MedulaReportResult[] MedulaReportResultsGridList { get; set; }
        public TTObjectClasses.ManipulationReturnReasonsGrid[] GridReturnReasonsGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.ManipulationRequest[] ManipulationRequests { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
    }
}
