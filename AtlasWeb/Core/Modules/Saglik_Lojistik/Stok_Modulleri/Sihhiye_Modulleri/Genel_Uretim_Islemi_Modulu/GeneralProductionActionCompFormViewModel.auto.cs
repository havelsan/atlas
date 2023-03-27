//$6000D5C3
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
    public partial class GeneralProductionActionServiceController : Controller
{
    [HttpGet]
    public GeneralProductionActionCompFormViewModel GeneralProductionActionCompForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return GeneralProductionActionCompFormLoadInternal(input);
    }

    [HttpPost]
    public GeneralProductionActionCompFormViewModel GeneralProductionActionCompFormLoad(FormLoadInput input)
    {
        return GeneralProductionActionCompFormLoadInternal(input);
    }

    private GeneralProductionActionCompFormViewModel GeneralProductionActionCompFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6a364c7d-6343-4929-91bd-502ceb43b396");
        var objectDefID = Guid.Parse("58925ebf-d9b2-4678-b187-037ac3b0ba20");
        var viewModel = new GeneralProductionActionCompFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GeneralProductionAction = objectContext.GetObject(id.Value, objectDefID) as GeneralProductionAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GeneralProductionAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GeneralProductionAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GeneralProductionAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GeneralProductionAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_GeneralProductionActionCompForm(viewModel, viewModel._GeneralProductionAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel GeneralProductionActionCompForm(GeneralProductionActionCompFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6a364c7d-6343-4929-91bd-502ceb43b396");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.GeneralProductionOutDetsGridList);
            objectContext.AddToRawObjectList(viewModel._GeneralProductionAction);
            objectContext.ProcessRawObjects();
            var generalProductionAction = (GeneralProductionAction)objectContext.GetLoadedObject(viewModel._GeneralProductionAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(generalProductionAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GeneralProductionAction, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = generalProductionAction;
                }
            }

            if (viewModel.GeneralProductionOutDetsGridList != null)
            {
                foreach (var item in viewModel.GeneralProductionOutDetsGridList)
                {
                    var generalProductionOutDetsImported = (GeneralProductionOutDet)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)generalProductionOutDetsImported).IsDeleted)
                        continue;
                    generalProductionOutDetsImported.GeneralProductionAction = generalProductionAction;
                }
            }

            var transDef = generalProductionAction.TransDef;
            PostScript_GeneralProductionActionCompForm(viewModel, generalProductionAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(generalProductionAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(generalProductionAction);
            AfterContextSaveScript_GeneralProductionActionCompForm(viewModel, generalProductionAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_GeneralProductionActionCompForm(GeneralProductionActionCompFormViewModel viewModel, GeneralProductionAction generalProductionAction, TTObjectContext objectContext);
    partial void PostScript_GeneralProductionActionCompForm(GeneralProductionActionCompFormViewModel viewModel, GeneralProductionAction generalProductionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_GeneralProductionActionCompForm(GeneralProductionActionCompFormViewModel viewModel, GeneralProductionAction generalProductionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(GeneralProductionActionCompFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._GeneralProductionAction.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.GeneralProductionOutDetsGridList = viewModel._GeneralProductionAction.GeneralProductionOutDets.OfType<GeneralProductionOutDet>().ToArray();
        viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialDefinitionList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class GeneralProductionActionCompFormViewModel : BaseViewModel
    {
        public TTObjectClasses.GeneralProductionAction _GeneralProductionAction { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.GeneralProductionOutDet[] GeneralProductionOutDetsGridList { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
    }
}
