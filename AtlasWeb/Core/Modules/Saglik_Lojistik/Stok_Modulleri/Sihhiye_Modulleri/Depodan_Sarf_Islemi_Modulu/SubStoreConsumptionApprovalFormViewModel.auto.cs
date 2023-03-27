//$F6047A60
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
    public SubStoreConsumptionApprovalFormViewModel SubStoreConsumptionApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SubStoreConsumptionApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public SubStoreConsumptionApprovalFormViewModel SubStoreConsumptionApprovalFormLoad(FormLoadInput input)
    {
        return SubStoreConsumptionApprovalFormLoadInternal(input);
    }

    private SubStoreConsumptionApprovalFormViewModel SubStoreConsumptionApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1fe2c1ba-6f6e-41f7-8062-ba3be5c71f7f");
        var objectDefID = Guid.Parse("7982a4b9-5630-4e52-990e-2d46491c0baf");
        var viewModel = new SubStoreConsumptionApprovalFormViewModel();
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
                PreScript_SubStoreConsumptionApprovalForm(viewModel, viewModel._SubStoreConsumptionAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SubStoreConsumptionApprovalForm(SubStoreConsumptionApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1fe2c1ba-6f6e-41f7-8062-ba3be5c71f7f");
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
            PostScript_SubStoreConsumptionApprovalForm(viewModel, subStoreConsumptionAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(subStoreConsumptionAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(subStoreConsumptionAction);
            AfterContextSaveScript_SubStoreConsumptionApprovalForm(viewModel, subStoreConsumptionAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SubStoreConsumptionApprovalForm(SubStoreConsumptionApprovalFormViewModel viewModel, SubStoreConsumptionAction subStoreConsumptionAction, TTObjectContext objectContext);
    partial void PostScript_SubStoreConsumptionApprovalForm(SubStoreConsumptionApprovalFormViewModel viewModel, SubStoreConsumptionAction subStoreConsumptionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SubStoreConsumptionApprovalForm(SubStoreConsumptionApprovalFormViewModel viewModel, SubStoreConsumptionAction subStoreConsumptionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SubStoreConsumptionApprovalFormViewModel viewModel, TTObjectContext objectContext)
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
    public partial class SubStoreConsumptionApprovalFormViewModel : BaseViewModel
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
