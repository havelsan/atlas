//$B51EE22F
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
    public partial class SubSurgeryServiceController : Controller
{
    [HttpGet]
    public SubSurgeryFormViewModel SubSurgeryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SubSurgeryFormLoadInternal(input);
    }

    [HttpPost]
    public SubSurgeryFormViewModel SubSurgeryFormLoad(FormLoadInput input)
    {
        return SubSurgeryFormLoadInternal(input);
    }

    private SubSurgeryFormViewModel SubSurgeryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("68f230d6-7bdd-43cf-8adb-c212c0aacd8b");
        var objectDefID = Guid.Parse("66b5df2e-3ab6-46e7-88d5-a93c2523497e");
        var viewModel = new SubSurgeryFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SubSurgery = objectContext.GetObject(id.Value, objectDefID) as SubSurgery;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SubSurgery, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubSurgery, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SubSurgery);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SubSurgery);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SubSurgeryForm(viewModel, viewModel._SubSurgery, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SubSurgery = new SubSurgery(objectContext);
                var entryStateID = Guid.Parse("de622b90-9607-4e1b-9a5e-89230e2340b3");
                viewModel._SubSurgery.CurrentStateDefID = entryStateID;
                viewModel.GridSurgeryPersonnelsGridList = new TTObjectClasses.SurgeryPersonnel[]{};
                viewModel.GridSurgeryExpendsGridList = new TTObjectClasses.SurgeryExpend[]{};
                viewModel.DirectPurchaseGridsGridList = new TTObjectClasses.DirectPurchaseGrid[]{};
                viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SubSurgery, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubSurgery, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SubSurgery);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SubSurgery);
                PreScript_SubSurgeryForm(viewModel, viewModel._SubSurgery, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SubSurgeryForm(SubSurgeryFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("68f230d6-7bdd-43cf-8adb-c212c0aacd8b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Surgerys);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryRooms);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryDesks);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.GridSurgeryPersonnelsGridList);
            objectContext.AddToRawObjectList(viewModel.GridSurgeryExpendsGridList);
            objectContext.AddToRawObjectList(viewModel.DirectPurchaseGridsGridList);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            var entryStateID = Guid.Parse("de622b90-9607-4e1b-9a5e-89230e2340b3");
            objectContext.AddToRawObjectList(viewModel._SubSurgery, entryStateID);
            objectContext.ProcessRawObjects(false);
            var subSurgery = (SubSurgery)objectContext.GetLoadedObject(viewModel._SubSurgery.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(subSurgery, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubSurgery, formDefID);
            var surgeryImported = subSurgery.Surgery;
            if (surgeryImported != null)
            {
                if (viewModel.GridSurgeryPersonnelsGridList != null)
                {
                    foreach (var item in viewModel.GridSurgeryPersonnelsGridList)
                    {
                        var allSurgeryPersonnelsImported = (SurgeryPersonnel)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)allSurgeryPersonnelsImported).IsDeleted)
                            continue;
                        allSurgeryPersonnelsImported.Surgery = surgeryImported;
                    }
                }
            }

            if (viewModel.GridSurgeryExpendsGridList != null)
            {
                foreach (var item in viewModel.GridSurgeryExpendsGridList)
                {
                    var subSurgeryExpendsImported = (SurgeryExpend)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)subSurgeryExpendsImported).IsDeleted)
                        continue;
                    subSurgeryExpendsImported.EpisodeAction = subSurgery;
                }
            }

            if (viewModel.DirectPurchaseGridsGridList != null)
            {
                foreach (var item in viewModel.DirectPurchaseGridsGridList)
                {
                    var directPurchaseGridsImported = (DirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)directPurchaseGridsImported).IsDeleted)
                        continue;
                    directPurchaseGridsImported.EpisodeAction = subSurgery;
                }
            }

            var episodeImported = subSurgery.Episode;
            if (episodeImported != null)
            {
                if (viewModel.GridEpisodeDiagnosisGridList != null)
                {
                    foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                    {
                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episodeImported;
                    }
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(subSurgery);
            PostScript_SubSurgeryForm(viewModel, subSurgery, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(subSurgery);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(subSurgery);
            AfterContextSaveScript_SubSurgeryForm(viewModel, subSurgery, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SubSurgeryForm(SubSurgeryFormViewModel viewModel, SubSurgery subSurgery, TTObjectContext objectContext);
    partial void PostScript_SubSurgeryForm(SubSurgeryFormViewModel viewModel, SubSurgery subSurgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SubSurgeryForm(SubSurgeryFormViewModel viewModel, SubSurgery subSurgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SubSurgeryFormViewModel viewModel, TTObjectContext objectContext)
    {
        var surgery = viewModel._SubSurgery.Surgery;
        if (surgery != null)
        {
            viewModel.GridSurgeryPersonnelsGridList = surgery.AllSurgeryPersonnels.OfType<SurgeryPersonnel>().ToArray();
        }

        viewModel.GridSurgeryExpendsGridList = viewModel._SubSurgery.SubSurgeryExpends.OfType<SurgeryExpend>().ToArray();
        viewModel.DirectPurchaseGridsGridList = viewModel._SubSurgery.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
        var episode = viewModel._SubSurgery.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.Surgerys = objectContext.LocalQuery<Surgery>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResSurgeryRooms = objectContext.LocalQuery<ResSurgeryRoom>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResSurgeryDesks = objectContext.LocalQuery<ResSurgeryDesk>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryTeamListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRoomListDefinition", viewModel.ResSurgeryRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryDeskListDefinition", viewModel.ResSurgeryDesks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class SubSurgeryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SubSurgery _SubSurgery { get; set; }
        public TTObjectClasses.SurgeryPersonnel[] GridSurgeryPersonnelsGridList { get; set; }
        public TTObjectClasses.SurgeryExpend[] GridSurgeryExpendsGridList { get; set; }
        public TTObjectClasses.DirectPurchaseGrid[] DirectPurchaseGridsGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.Surgery[] Surgerys { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSurgeryRoom[] ResSurgeryRooms { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResSurgeryDesk[] ResSurgeryDesks { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
    }
}
