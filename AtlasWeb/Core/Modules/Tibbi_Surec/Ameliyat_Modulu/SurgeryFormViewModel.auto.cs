//$036F8BBC
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
    public partial class SurgeryServiceController : Controller
    {
        [HttpGet]
        public SurgeryFormViewModel SurgeryForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SurgeryFormLoadInternal(input);
        }

        [HttpPost]
        public SurgeryFormViewModel SurgeryFormLoad(FormLoadInput input)
        {
            return SurgeryFormLoadInternal(input);
        }

        private SurgeryFormViewModel SurgeryFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("235dcd7c-a038-42df-bc95-f05c291279a7");
            var objectDefID = Guid.Parse("8dc586f0-14a5-42a3-a7c6-51e1be031ee0");
            var viewModel = new SurgeryFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Surgery = objectContext.GetObject(id.Value, objectDefID) as Surgery;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Surgery, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Surgery);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Surgery);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_SurgeryForm(viewModel, viewModel._Surgery, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SurgeryForm(SurgeryFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("235dcd7c-a038-42df-bc95-f05c291279a7");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.SurgeryResultDefinitions);
                objectContext.AddToRawObjectList(viewModel.SurgeryRobsonDefinitions);
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.ResSurgeryRooms);
                objectContext.AddToRawObjectList(viewModel.SurgeryRejectReasons);
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.AnesthesiaAndReanimations);
                objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.ResSurgeryDesks);
                objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
                objectContext.AddToRawObjectList(viewModel.GridSurgeryPersonnelsGridList);
                objectContext.AddToRawObjectList(viewModel.GridSurgeryExpendsGridList);
                objectContext.AddToRawObjectList(viewModel.DirectPurchaseGridsGridList);
                objectContext.AddToRawObjectList(viewModel.GridAnesthesiaProceduresGridList);
                objectContext.AddToRawObjectList(viewModel.GridAnesthesiaPersonnelsGridList);
                objectContext.AddToRawObjectList(viewModel._Surgery);
                objectContext.ProcessRawObjects();
                var surgery = (Surgery)objectContext.GetLoadedObject(viewModel._Surgery.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgery, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
                var episodeImported = surgery.Episode;
                if (episodeImported != null)
                {
                    if (viewModel.GridDiagnosisGridList != null)
                    {
                        foreach (var item in viewModel.GridDiagnosisGridList)
                        {
                            var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)diagnosisImported).IsDeleted)
                                continue;
                            diagnosisImported.Episode = episodeImported;
                        }
                    }
                }

                if (viewModel.GridSurgeryPersonnelsGridList != null)
                {
                    foreach (var item in viewModel.GridSurgeryPersonnelsGridList)
                    {
                        var allSurgeryPersonnelsImported = (SurgeryPersonnel)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)allSurgeryPersonnelsImported).IsDeleted)
                            continue;
                        allSurgeryPersonnelsImported.Surgery = surgery;
                    }
                }

                if (viewModel.GridSurgeryExpendsGridList != null)
                {
                    foreach (var item in viewModel.GridSurgeryExpendsGridList)
                    {
                        var surgeryExpendsImported = (SurgeryExpend)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)surgeryExpendsImported).IsDeleted)
                            continue;
                        surgeryExpendsImported.EpisodeAction = surgery;
                    }
                }

                if (viewModel.DirectPurchaseGridsGridList != null)
                {
                    foreach (var item in viewModel.DirectPurchaseGridsGridList)
                    {
                        var directPurchaseGridsImported = (DirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)directPurchaseGridsImported).IsDeleted)
                            continue;
                        directPurchaseGridsImported.EpisodeAction = surgery;
                    }
                }

                var anesthesiaAndReanimationImported = surgery.AnesthesiaAndReanimation;
                if (anesthesiaAndReanimationImported != null)
                {
                    if (viewModel.GridAnesthesiaProceduresGridList != null)
                    {
                        foreach (var item in viewModel.GridAnesthesiaProceduresGridList)
                        {
                            var anaesthesiaAndReanimationAnesthesiaProceduresImported = (AnesthesiaProcedure)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)anaesthesiaAndReanimationAnesthesiaProceduresImported).IsDeleted)
                                continue;
                            anaesthesiaAndReanimationAnesthesiaProceduresImported.AnaesthesiaAndReanimation = anesthesiaAndReanimationImported;
                        }
                    }

                    if (viewModel.GridAnesthesiaPersonnelsGridList != null)
                    {
                        foreach (var item in viewModel.GridAnesthesiaPersonnelsGridList)
                        {
                            var anesthesiaPersonnelsImported = (AnesthesiaPersonnel)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)anesthesiaPersonnelsImported).IsDeleted)
                                continue;
                            anesthesiaPersonnelsImported.AnesthesiaAndReanimation = anesthesiaAndReanimationImported;
                        }
                    }
                }

                var transDef = surgery.TransDef;
                PostScript_SurgeryForm(viewModel, surgery, transDef, objectContext);
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgery);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgery);
                AfterContextSaveScript_SurgeryForm(viewModel, surgery, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_SurgeryForm(SurgeryFormViewModel viewModel, Surgery surgery, TTObjectContext objectContext);
        partial void PostScript_SurgeryForm(SurgeryFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SurgeryForm(SurgeryFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(SurgeryFormViewModel viewModel, TTObjectContext objectContext)
        {
            var episode = viewModel._Surgery.Episode;
            if (episode != null)
            {
                viewModel.GridDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
            }

            viewModel.GridSurgeryPersonnelsGridList = viewModel._Surgery.AllSurgeryPersonnels.OfType<SurgeryPersonnel>().ToArray();
            viewModel.GridSurgeryExpendsGridList = viewModel._Surgery.SurgeryExpends.OfType<SurgeryExpend>().ToArray();
            viewModel.DirectPurchaseGridsGridList = viewModel._Surgery.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
            var anesthesiaAndReanimation = viewModel._Surgery.AnesthesiaAndReanimation;
            if (anesthesiaAndReanimation != null)
            {
                viewModel.GridAnesthesiaProceduresGridList = anesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures.OfType<AnesthesiaProcedure>().ToArray();
                viewModel.GridAnesthesiaPersonnelsGridList = anesthesiaAndReanimation.AnesthesiaPersonnels.OfType<AnesthesiaPersonnel>().ToArray();
            }
            viewModel.SurgeryResultDefinitions = objectContext.LocalQuery<SurgeryResultDefinition>().ToArray();
            viewModel.SurgeryRobsonDefinitions = objectContext.LocalQuery<SurgeryRobsonDefinition>().ToArray();

            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSurgeryRooms = objectContext.LocalQuery<ResSurgeryRoom>().ToArray();
            viewModel.SurgeryRejectReasons = objectContext.LocalQuery<SurgeryRejectReason>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.AnesthesiaAndReanimations = objectContext.LocalQuery<AnesthesiaAndReanimation>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ResSurgeryDesks = objectContext.LocalQuery<ResSurgeryDesk>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryResultDefList", viewModel.SurgeryResultDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRobsonDefinitionList", viewModel.SurgeryRobsonDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRoomListDefinition", viewModel.ResSurgeryRooms);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryTeamListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AnesthesiaListDefinition", viewModel.ProcedureDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AnaesthesiaTeamListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryDeskListDefinition", viewModel.ResSurgeryDesks);
        }
    }
}


namespace Core.Models
{
    public partial class SurgeryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Surgery _Surgery { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public TTObjectClasses.SurgeryPersonnel[] GridSurgeryPersonnelsGridList { get; set; }
        public TTObjectClasses.SurgeryExpend[] GridSurgeryExpendsGridList { get; set; }
        public TTObjectClasses.DirectPurchaseGrid[] DirectPurchaseGridsGridList { get; set; }
        public TTObjectClasses.AnesthesiaProcedure[] GridAnesthesiaProceduresGridList { get; set; }
        public TTObjectClasses.AnesthesiaPersonnel[] GridAnesthesiaPersonnelsGridList { get; set; }

        public TTObjectClasses.SurgeryResultDefinition[] SurgeryResultDefinitions{get;set; }
        public TTObjectClasses.SurgeryRobsonDefinition[] SurgeryRobsonDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSurgeryRoom[] ResSurgeryRooms { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.AnesthesiaAndReanimation[] AnesthesiaAndReanimations { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResSurgeryDesk[] ResSurgeryDesks { get; set; }
        public TTObjectClasses.SurgeryRejectReason[] SurgeryRejectReasons { get; set; }
    }
}
