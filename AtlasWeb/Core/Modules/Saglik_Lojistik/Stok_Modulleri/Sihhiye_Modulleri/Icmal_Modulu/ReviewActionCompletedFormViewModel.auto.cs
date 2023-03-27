//$37F3A184
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
    public partial class ReviewActionServiceController : Controller
{
    [HttpGet]
    public ReviewActionCompletedFormViewModel ReviewActionCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ReviewActionCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public ReviewActionCompletedFormViewModel ReviewActionCompletedFormLoad(FormLoadInput input)
    {
        return ReviewActionCompletedFormLoadInternal(input);
    }

    private ReviewActionCompletedFormViewModel ReviewActionCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("eb2fa94d-d2ce-4d7c-922b-202fe63bc4a9");
        var objectDefID = Guid.Parse("858c4027-ad89-4a4f-97e0-740dcd48a1d4");
        var viewModel = new ReviewActionCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ReviewAction = objectContext.GetObject(id.Value, objectDefID) as ReviewAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ReviewAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReviewAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ReviewAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ReviewAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ReviewActionCompletedForm(viewModel, viewModel._ReviewAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ReviewActionCompletedForm(ReviewActionCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("eb2fa94d-d2ce-4d7c-922b-202fe63bc4a9");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.ReviewActionDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.ReviewActionPatientDetsGridList);
            objectContext.AddToRawObjectList(viewModel._ReviewAction);
            objectContext.ProcessRawObjects();
            var reviewAction = (ReviewAction)objectContext.GetLoadedObject(viewModel._ReviewAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(reviewAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReviewAction, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = reviewAction;
                }
            }

            if (viewModel.ReviewActionDetailsGridList != null)
            {
                foreach (var item in viewModel.ReviewActionDetailsGridList)
                {
                    var reviewActionDetailsImported = (ReviewActionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)reviewActionDetailsImported).IsDeleted)
                        continue;
                    reviewActionDetailsImported.StockAction = reviewAction;
                }
            }

            if (viewModel.ReviewActionPatientDetsGridList != null)
            {
                foreach (var item in viewModel.ReviewActionPatientDetsGridList)
                {
                    var reviewActionPatientDetsImported = (ReviewActionPatientDet)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)reviewActionPatientDetsImported).IsDeleted)
                        continue;
                    reviewActionPatientDetsImported.ReviewAction = reviewAction;
                }
            }

            var transDef = reviewAction.TransDef;
            PostScript_ReviewActionCompletedForm(viewModel, reviewAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(reviewAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(reviewAction);
            AfterContextSaveScript_ReviewActionCompletedForm(viewModel, reviewAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ReviewActionCompletedForm(ReviewActionCompletedFormViewModel viewModel, ReviewAction reviewAction, TTObjectContext objectContext);
    partial void PostScript_ReviewActionCompletedForm(ReviewActionCompletedFormViewModel viewModel, ReviewAction reviewAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ReviewActionCompletedForm(ReviewActionCompletedFormViewModel viewModel, ReviewAction reviewAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ReviewActionCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._ReviewAction.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.ReviewActionDetailsGridList = viewModel._ReviewAction.ReviewActionDetails.OfType<ReviewActionDetail>().ToArray();
        viewModel.ReviewActionPatientDetsGridList = viewModel._ReviewAction.ReviewActionPatientDets.OfType<ReviewActionPatientDet>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PharmacyStoreList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class ReviewActionCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ReviewAction _ReviewAction { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.ReviewActionDetail[] ReviewActionDetailsGridList { get; set; }
        public TTObjectClasses.ReviewActionPatientDet[] ReviewActionPatientDetsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
