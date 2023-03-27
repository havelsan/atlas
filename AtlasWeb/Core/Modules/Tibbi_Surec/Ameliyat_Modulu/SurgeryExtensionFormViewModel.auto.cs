//$B38E703C
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
    public partial class SurgeryExtensionServiceController : Controller
    {
        [HttpGet]
        public SurgeryExtensionFormViewModel SurgeryExtensionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SurgeryExtensionFormLoadInternal(input);
        }

        [HttpPost]
        public SurgeryExtensionFormViewModel SurgeryExtensionFormLoad(FormLoadInput input)
        {
            return SurgeryExtensionFormLoadInternal(input);
        }

        private SurgeryExtensionFormViewModel SurgeryExtensionFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("931bb4cf-7dfb-4742-a4ba-361e79ee8f60");
            var objectDefID = Guid.Parse("612394a6-31cc-4582-a517-ce1c6d7c6690");
            var viewModel = new SurgeryExtensionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SurgeryExtension = objectContext.GetObject(id.Value, objectDefID) as SurgeryExtension;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryExtension, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryExtension, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SurgeryExtension);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SurgeryExtension);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_SurgeryExtensionForm(viewModel, viewModel._SurgeryExtension, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SurgeryExtension = new SurgeryExtension(objectContext);
                    var entryStateID = Guid.Parse("37f51ea0-1869-4a21-a3b0-1a211094bf03");
                    viewModel._SurgeryExtension.CurrentStateDefID = entryStateID;
                    viewModel.SurgeryExpendsSurgeryExpendGridList = new TTObjectClasses.SurgeryExpend[] { };
                    viewModel.GridSurgeryPersonnelsGridList = new TTObjectClasses.SurgeryPersonnel[] { };
                    viewModel.GridMainSurgeryProceduresGridList = new TTObjectClasses.MainSurgeryProcedure[] { };
                    viewModel.GridSurgeryExpendsGridList = new TTObjectClasses.SurgeryExpend[] { };
                    viewModel.DirectPurchaseGridsGridList = new TTObjectClasses.DirectPurchaseGrid[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryExtension, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryExtension, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SurgeryExtension);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SurgeryExtension);
                    PreScript_SurgeryExtensionForm(viewModel, viewModel._SurgeryExtension, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SurgeryExtensionForm(SurgeryExtensionFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("931bb4cf-7dfb-4742-a4ba-361e79ee8f60");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Surgerys);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.ResSurgeryRooms);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.ResSurgeryDesks);
                objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.SurgeryExpendsSurgeryExpendGridList);
                objectContext.AddToRawObjectList(viewModel.GridSurgeryPersonnelsGridList);
                objectContext.AddToRawObjectList(viewModel.GridMainSurgeryProceduresGridList);
                objectContext.AddToRawObjectList(viewModel.GridSurgeryExpendsGridList);
                objectContext.AddToRawObjectList(viewModel.DirectPurchaseGridsGridList);
                var entryStateID = Guid.Parse("37f51ea0-1869-4a21-a3b0-1a211094bf03");
                objectContext.AddToRawObjectList(viewModel._SurgeryExtension, entryStateID);
                objectContext.ProcessRawObjects(false);
                var surgeryExtension = (SurgeryExtension)objectContext.GetLoadedObject(viewModel._SurgeryExtension.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgeryExtension, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryExtension, formDefID);
                var mainSurgeryImported = surgeryExtension.MainSurgery;
                if (mainSurgeryImported != null)
                {
                    if (viewModel.SurgeryExpendsSurgeryExpendGridList != null)
                    {
                        foreach (var item in viewModel.SurgeryExpendsSurgeryExpendGridList)
                        {
                            var surgeryExpendsImported = (SurgeryExpend)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)surgeryExpendsImported).IsDeleted)
                                continue;
                            surgeryExpendsImported.EpisodeAction = mainSurgeryImported;
                        }
                    }

                    if (viewModel.GridSurgeryPersonnelsGridList != null)
                    {
                        foreach (var item in viewModel.GridSurgeryPersonnelsGridList)
                        {
                            var allSurgeryPersonnelsImported = (SurgeryPersonnel)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)allSurgeryPersonnelsImported).IsDeleted)
                                continue;
                            allSurgeryPersonnelsImported.Surgery = mainSurgeryImported;
                        }
                    }


                    if (viewModel.GridMainSurgeryProceduresGridList != null)
                    {
                        foreach (var item in viewModel.GridMainSurgeryProceduresGridList)
                        {
                            var mainSurgeryProceduresImported = (MainSurgeryProcedure)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)mainSurgeryProceduresImported).IsDeleted)
                                continue;
                            mainSurgeryProceduresImported.MainSurgery = mainSurgeryImported;
                        }
                    }
                }

                if (viewModel.GridSurgeryExpendsGridList != null)
                {
                    foreach (var item in viewModel.GridSurgeryExpendsGridList)
                    {
                        var surgeryExtensionExpendsImported = (SurgeryExpend)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)surgeryExtensionExpendsImported).IsDeleted)
                            continue;
                        surgeryExtensionExpendsImported.EpisodeAction = surgeryExtension;
                    }
                }

                if (viewModel.DirectPurchaseGridsGridList != null)
                {
                    foreach (var item in viewModel.DirectPurchaseGridsGridList)
                    {
                        var directPurchaseGridsImported = (DirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)directPurchaseGridsImported).IsDeleted)
                            continue;
                        directPurchaseGridsImported.EpisodeAction = surgeryExtension;
                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(surgeryExtension);
                PostScript_SurgeryExtensionForm(viewModel, surgeryExtension, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgeryExtension);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgeryExtension);
                AfterContextSaveScript_SurgeryExtensionForm(viewModel, surgeryExtension, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_SurgeryExtensionForm(SurgeryExtensionFormViewModel viewModel, SurgeryExtension surgeryExtension, TTObjectContext objectContext);
        partial void PostScript_SurgeryExtensionForm(SurgeryExtensionFormViewModel viewModel, SurgeryExtension surgeryExtension, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SurgeryExtensionForm(SurgeryExtensionFormViewModel viewModel, SurgeryExtension surgeryExtension, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(SurgeryExtensionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var mainSurgery = viewModel._SurgeryExtension.MainSurgery;
            if (mainSurgery != null)
            {
                viewModel.SurgeryExpendsSurgeryExpendGridList = mainSurgery.SurgeryExpends.OfType<SurgeryExpend>().ToArray();
                viewModel.GridMainSurgeryProceduresGridList = mainSurgery.MainSurgeryProcedures.OfType<MainSurgeryProcedure>().ToArray();
                viewModel.GridSurgeryPersonnelsGridList = mainSurgery.AllSurgeryPersonnels.OfType<SurgeryPersonnel>().ToArray();
            }

            viewModel.GridSurgeryExpendsGridList = viewModel._SurgeryExtension.SurgeryExtensionExpends.OfType<SurgeryExpend>().ToArray();
            viewModel.DirectPurchaseGridsGridList = viewModel._SurgeryExtension.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
            viewModel.Surgerys = objectContext.LocalQuery<Surgery>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSurgeryRooms = objectContext.LocalQuery<ResSurgeryRoom>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ResSurgeryDesks = objectContext.LocalQuery<ResSurgeryDesk>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRoomListDefinition", viewModel.ResSurgeryRooms);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryDeskListDefinition", viewModel.ResSurgeryDesks);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        }
    }
}


namespace Core.Models
{
    public partial class SurgeryExtensionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SurgeryExpend[] SurgeryExpendsSurgeryExpendGridList { get; set; }
        public TTObjectClasses.SurgeryExtension _SurgeryExtension { get; set; }
        public TTObjectClasses.SurgeryPersonnel[] GridSurgeryPersonnelsGridList { get; set; }
        public TTObjectClasses.MainSurgeryProcedure[] GridMainSurgeryProceduresGridList { get; set; }
        public TTObjectClasses.SurgeryExpend[] GridSurgeryExpendsGridList { get; set; }
        public TTObjectClasses.DirectPurchaseGrid[] DirectPurchaseGridsGridList { get; set; }
        public TTObjectClasses.Surgery[] Surgerys { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSurgeryRoom[] ResSurgeryRooms { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResSurgeryDesk[] ResSurgeryDesks { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
    }
}
