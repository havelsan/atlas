//$98909262
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
    public partial class ReturningDocumentServiceController : Controller
    {
        [HttpGet]
        public ReturningDocumentFormViewModel ReturningDocumentForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ReturningDocumentFormLoadInternal(input);
        }

        [HttpPost]
        public ReturningDocumentFormViewModel ReturningDocumentFormLoad(FormLoadInput input)
        {
            return ReturningDocumentFormLoadInternal(input);
        }

        private ReturningDocumentFormViewModel ReturningDocumentFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("e2a6ef19-861c-4876-a74c-50ec761adabe");
            var objectDefID = Guid.Parse("ca3f49f3-f0ed-449c-a31a-32534effc1d0");
            var viewModel = new ReturningDocumentFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ReturningDocument = objectContext.GetObject(id.Value, objectDefID) as ReturningDocument;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ReturningDocument, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReturningDocument, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ReturningDocument);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ReturningDocument);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_ReturningDocumentForm(viewModel, viewModel._ReturningDocument, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ReturningDocument = new ReturningDocument(objectContext);
                    var entryStateID = Guid.Parse("222d9836-85ef-4b63-ac5d-1a2e2b61f599");
                    viewModel._ReturningDocument.CurrentStateDefID = entryStateID;
                    viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[] { };
                    viewModel.StockActionOutDetailsGridList = new TTObjectClasses.ReturningDocumentMaterial[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ReturningDocument, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReturningDocument, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ReturningDocument);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ReturningDocument);
                    PreScript_ReturningDocumentForm(viewModel, viewModel._ReturningDocument, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ReturningDocumentForm(ReturningDocumentFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("e2a6ef19-861c-4876-a74c-50ec761adabe");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
                objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
                var entryStateID = Guid.Parse("222d9836-85ef-4b63-ac5d-1a2e2b61f599");
                objectContext.AddToRawObjectList(viewModel._ReturningDocument, entryStateID);
                objectContext.ProcessRawObjects(false);
                var returningDocument = (ReturningDocument)objectContext.GetLoadedObject(viewModel._ReturningDocument.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(returningDocument, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReturningDocument, formDefID);
                if (viewModel.StockActionSignDetailsGridList != null)
                {
                    foreach (var item in viewModel.StockActionSignDetailsGridList)
                    {
                        var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                            continue;
                        stockActionSignDetailsImported.StockAction = returningDocument;
                    }
                }

                if (viewModel.StockActionOutDetailsGridList != null)
                {
                    foreach (var item in viewModel.StockActionOutDetailsGridList)
                    {
                        var returningDocumentMaterialsImported = (ReturningDocumentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)returningDocumentMaterialsImported).IsDeleted)
                            continue;
                        returningDocumentMaterialsImported.StockAction = returningDocument;
                        if (returningDocumentMaterialsImported.UserSelectedOutableTrx.HasValue && returningDocumentMaterialsImported.UserSelectedOutableTrx.Value)
                        {
                            foreach (OuttableLotDTO outtable in viewModel.OuttableLotList.Where(x => x.StockActionDetailOrderNo == returningDocumentMaterialsImported.ChattelDocDetailOrderNo))
                            {
                                OuttableLot outtableLot = new OuttableLot(objectContext);
                                outtableLot.Amount = outtable.Amount;
                                outtableLot.BudgetTypeName = outtable.BudgetTypeName;
                                outtableLot.ExpirationDate = outtable.ExpirationDate;
                                outtableLot.isUse = true;
                                outtableLot.LotNo = outtable.LotNo;
                                outtableLot.RestAmount = outtable.RestAmount;
                                outtableLot.SerialNo = outtable.SerialNo;
                                outtableLot.StockActionDetailOut = returningDocumentMaterialsImported;
                                outtableLot.TrxObjectID = outtable.TrxObjectID;
                            }
                        }
                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(returningDocument);
                PostScript_ReturningDocumentForm(viewModel, returningDocument, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(returningDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(returningDocument);
                AfterContextSaveScript_ReturningDocumentForm(viewModel, returningDocument, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_ReturningDocumentForm(ReturningDocumentFormViewModel viewModel, ReturningDocument returningDocument, TTObjectContext objectContext);
        partial void PostScript_ReturningDocumentForm(ReturningDocumentFormViewModel viewModel, ReturningDocument returningDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ReturningDocumentForm(ReturningDocumentFormViewModel viewModel, ReturningDocument returningDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ReturningDocumentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.StockActionSignDetailsGridList = viewModel._ReturningDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
            viewModel.StockActionOutDetailsGridList = viewModel._ReturningDocument.ReturningDocumentMaterials.OfType<ReturningDocumentMaterial>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        }
    }
}


namespace Core.Models
{
    public partial class ReturningDocumentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ReturningDocument _ReturningDocument { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.ReturningDocumentMaterial[] StockActionOutDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
    }
}
