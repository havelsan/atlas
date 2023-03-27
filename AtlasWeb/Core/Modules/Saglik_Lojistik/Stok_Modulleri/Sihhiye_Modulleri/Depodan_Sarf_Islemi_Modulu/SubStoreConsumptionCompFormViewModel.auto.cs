//$9E6DF4C7
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
    public partial class SubStoreConsumptionActionServiceController : Controller
{
    [HttpGet]
    public SubStoreConsumptionCompFormViewModel SubStoreConsumptionCompForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SubStoreConsumptionCompFormLoadInternal(input);
    }

    [HttpPost]
    public SubStoreConsumptionCompFormViewModel SubStoreConsumptionCompFormLoad(FormLoadInput input)
    {
        return SubStoreConsumptionCompFormLoadInternal(input);
    }

    private SubStoreConsumptionCompFormViewModel SubStoreConsumptionCompFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d4701edb-51ae-4ec7-ae2e-ac17b8ddd8d6");
        var objectDefID = Guid.Parse("7982a4b9-5630-4e52-990e-2d46491c0baf");
        var viewModel = new SubStoreConsumptionCompFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SubStoreConsumptionAction = objectContext.GetObject(id.Value, objectDefID) as SubStoreConsumptionAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SubStoreConsumptionAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubStoreConsumptionAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SubStoreConsumptionAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SubStoreConsumptionAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SubStoreConsumptionCompForm(viewModel, viewModel._SubStoreConsumptionAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SubStoreConsumptionCompForm(SubStoreConsumptionCompFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d4701edb-51ae-4ec7-ae2e-ac17b8ddd8d6");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.SubStoreConsumptionActionDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._SubStoreConsumptionAction);
            objectContext.ProcessRawObjects();
            var subStoreConsumptionAction = (SubStoreConsumptionAction)objectContext.GetLoadedObject(viewModel._SubStoreConsumptionAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(subStoreConsumptionAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubStoreConsumptionAction, formDefID);
            if (viewModel.SubStoreConsumptionActionDetailsGridList != null)
            {
                foreach (var item in viewModel.SubStoreConsumptionActionDetailsGridList)
                {
                    var subStoreConsumptionActionDetailsImported = (SubStoreConsumptionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)subStoreConsumptionActionDetailsImported).IsDeleted)
                        continue;
                    subStoreConsumptionActionDetailsImported.SubStoreConsumptionAction = subStoreConsumptionAction;
                }
            }

            var transDef = subStoreConsumptionAction.TransDef;
            PostScript_SubStoreConsumptionCompForm(viewModel, subStoreConsumptionAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(subStoreConsumptionAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(subStoreConsumptionAction);
            AfterContextSaveScript_SubStoreConsumptionCompForm(viewModel, subStoreConsumptionAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SubStoreConsumptionCompForm(SubStoreConsumptionCompFormViewModel viewModel, SubStoreConsumptionAction subStoreConsumptionAction, TTObjectContext objectContext);
    partial void PostScript_SubStoreConsumptionCompForm(SubStoreConsumptionCompFormViewModel viewModel, SubStoreConsumptionAction subStoreConsumptionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SubStoreConsumptionCompForm(SubStoreConsumptionCompFormViewModel viewModel, SubStoreConsumptionAction subStoreConsumptionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SubStoreConsumptionCompFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SubStoreConsumptionActionDetailsGridList = viewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails.OfType<SubStoreConsumptionDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class SubStoreConsumptionCompFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SubStoreConsumptionAction _SubStoreConsumptionAction { get; set; }
        public TTObjectClasses.SubStoreConsumptionDetail[] SubStoreConsumptionActionDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
