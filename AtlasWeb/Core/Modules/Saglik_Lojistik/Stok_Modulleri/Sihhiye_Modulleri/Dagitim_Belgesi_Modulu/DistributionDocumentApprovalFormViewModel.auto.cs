//$35A15E7A
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
    public partial class DistributionDocumentServiceController : Controller
    {
        [HttpGet]
        public DistributionDocumentApprovalFormViewModel DistributionDocumentApprovalForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return DistributionDocumentApprovalFormLoadInternal(input);
        }

        [HttpPost]
        public DistributionDocumentApprovalFormViewModel DistributionDocumentApprovalFormLoad(FormLoadInput input)
        {
            return DistributionDocumentApprovalFormLoadInternal(input);
        }

        private DistributionDocumentApprovalFormViewModel DistributionDocumentApprovalFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("f3bee024-d6f0-41bb-92d5-9b010865dea3");
            var objectDefID = Guid.Parse("a06d6465-0fe8-4fb1-a0df-a62373fef8de");
            var viewModel = new DistributionDocumentApprovalFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DistributionDocument = objectContext.GetObject(id.Value, objectDefID) as DistributionDocument;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DistributionDocument, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DistributionDocument, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DistributionDocument);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DistributionDocument);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_DistributionDocumentApprovalForm(viewModel, viewModel._DistributionDocument, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel DistributionDocumentApprovalForm(DistributionDocumentApprovalFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("f3bee024-d6f0-41bb-92d5-9b010865dea3");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.DistributionDocumentMaterialsGridList);
                objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
                objectContext.AddToRawObjectList(viewModel._DistributionDocument);
                objectContext.ProcessRawObjects();
                var distributionDocument = (DistributionDocument)objectContext.GetLoadedObject(viewModel._DistributionDocument.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(distributionDocument, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DistributionDocument, formDefID);
                if (viewModel.DistributionDocumentMaterialsGridList != null)
                {
                    foreach (var item in viewModel.DistributionDocumentMaterialsGridList)
                    {
                        var distributionDocumentMaterialsImported = (DistributionDocumentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)distributionDocumentMaterialsImported).IsDeleted)
                            continue;
                        distributionDocumentMaterialsImported.DistributionDocument = distributionDocument;
                        if (distributionDocumentMaterialsImported.OuttableLots.Count > 0 && viewModel.OuttableLotList.Count() > 0)
                        {
                            foreach (OuttableLot oldOutableLot in distributionDocumentMaterialsImported.OuttableLots)
                            {
                                oldOutableLot.isUse = false;
                            }
                        }

                        if (distributionDocumentMaterialsImported.UserSelectedOutableTrx.HasValue && distributionDocumentMaterialsImported.UserSelectedOutableTrx.Value)
                        {
                            foreach (OuttableLotDTO outtable in viewModel.OuttableLotList.Where(x => x.StockActionDetailOrderNo == distributionDocumentMaterialsImported.ChattelDocDetailOrderNo))
                            {
                                OuttableLot outtableLot = new OuttableLot(objectContext);
                                outtableLot.Amount = outtable.Amount;
                                outtableLot.BudgetTypeName = outtable.BudgetTypeName;
                                outtableLot.ExpirationDate = outtable.ExpirationDate;
                                outtableLot.isUse = true;
                                outtableLot.LotNo = outtable.LotNo;
                                outtableLot.RestAmount = outtable.RestAmount;
                                outtableLot.SerialNo = outtable.SerialNo;
                                outtableLot.StockActionDetailOut = distributionDocumentMaterialsImported;
                                outtableLot.TrxObjectID = outtable.TrxObjectID;
                            }
                        }
                    }
                }

                if (viewModel.StockActionSignDetailsGridList != null)
                {
                    foreach (var item in viewModel.StockActionSignDetailsGridList)
                    {
                        var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                            continue;
                        stockActionSignDetailsImported.StockAction = distributionDocument;

                    }
                }

                var transDef = distributionDocument.TransDef;
                PostScript_DistributionDocumentApprovalForm(viewModel, distributionDocument, transDef, objectContext);
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(distributionDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(distributionDocument);
                AfterContextSaveScript_DistributionDocumentApprovalForm(viewModel, distributionDocument, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_DistributionDocumentApprovalForm(DistributionDocumentApprovalFormViewModel viewModel, DistributionDocument distributionDocument, TTObjectContext objectContext);
        partial void PostScript_DistributionDocumentApprovalForm(DistributionDocumentApprovalFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_DistributionDocumentApprovalForm(DistributionDocumentApprovalFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(DistributionDocumentApprovalFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.DistributionDocumentMaterialsGridList = viewModel._DistributionDocument.DistributionDocumentMaterials.OfType<DistributionDocumentMaterial>().ToArray();
            viewModel.StockActionSignDetailsGridList = viewModel._DistributionDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class DistributionDocumentApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DistributionDocument _DistributionDocument { get; set; }
        public TTObjectClasses.DistributionDocumentMaterial[] DistributionDocumentMaterialsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
