//$03D678A5
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
    public partial class NursingApplicationServiceController : Controller
{
    [HttpGet]
    public NursingApplicationMainFormViewModel NursingApplicationMainForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingApplicationMainFormLoadInternal(input);
    }

    [HttpPost]
    public NursingApplicationMainFormViewModel NursingApplicationMainFormLoad(FormLoadInput input)
    {
        return NursingApplicationMainFormLoadInternal(input);
    }

    private NursingApplicationMainFormViewModel NursingApplicationMainFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("db7d954d-0b81-48a9-a56f-bc7bfd23f2c7");
        var objectDefID = Guid.Parse("eb1d324d-9956-438f-8056-e4177421ad56");
        var viewModel = new NursingApplicationMainFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingApplication = objectContext.GetObject(id.Value, objectDefID) as NursingApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingApplication);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingApplicationMainForm(viewModel, viewModel._NursingApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingApplication = new NursingApplication(objectContext);
                var entryStateID = Guid.Parse("9431b925-023e-41cf-8681-e558c8e337ef");
                viewModel._NursingApplication.CurrentStateDefID = entryStateID;
                viewModel.GridDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.NewTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingApplication);
                PreScript_NursingApplicationMainForm(viewModel, viewModel._NursingApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("db7d954d-0b81-48a9-a56f-bc7bfd23f2c7");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.InPatientTreatmentClinicApplications);
            objectContext.AddToRawObjectList(viewModel.BaseInpatientAdmissions);
            objectContext.AddToRawObjectList(viewModel.ResBeds);
            objectContext.AddToRawObjectList(viewModel.ResRooms);
            objectContext.AddToRawObjectList(viewModel.ResRoomGroups);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.EmergencyInterventions);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.NewTreatmentMaterialsGridList);
            var entryStateID = Guid.Parse("9431b925-023e-41cf-8681-e558c8e337ef");
            objectContext.AddToRawObjectList(viewModel._NursingApplication, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingApplication = (NursingApplication)objectContext.GetLoadedObject(viewModel._NursingApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingApplication, formDefID);
            var episodeImported = nursingApplication.Episode;
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

            if (viewModel.NewTreatmentMaterialsGridList != null)
            {
                foreach (var item in viewModel.NewTreatmentMaterialsGridList)
                {
                    var nursingApplicationTreatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)nursingApplicationTreatmentMaterialsImported).IsDeleted || nursingApplicationTreatmentMaterialsImported.EpisodeAction != null)
                        continue;
                    nursingApplicationTreatmentMaterialsImported.EpisodeAction = nursingApplication;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingApplication);
            PostScript_NursingApplicationMainForm(viewModel, nursingApplication, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingApplication);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingApplication);
            AfterContextSaveScript_NursingApplicationMainForm(viewModel, nursingApplication, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel, NursingApplication nursingApplication, TTObjectContext objectContext);
    partial void PostScript_NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel, NursingApplication nursingApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel, NursingApplication nursingApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingApplicationMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._NursingApplication.Episode;
        if (episode != null)
        {
            viewModel.GridDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        if(viewModel._NursingApplication.InPatientTreatmentClinicApp?.IsDailyOperation == true)
            {
                viewModel.NewTreatmentMaterialsGridList = viewModel._NursingApplication.Episode.SubActionMaterials.OfType<BaseTreatmentMaterial>().ToArray();
            }
        else
            {
                viewModel.NewTreatmentMaterialsGridList = viewModel._NursingApplication.NursingApplicationTreatmentMaterials.OfType<NursingApplicationTreatmentMaterial>().ToArray();
            }
            viewModel.InPatientTreatmentClinicApplications = objectContext.LocalQuery<InPatientTreatmentClinicApplication>().ToArray();
        viewModel.BaseInpatientAdmissions = objectContext.LocalQuery<BaseInpatientAdmission>().ToArray();
        viewModel.ResBeds = objectContext.LocalQuery<ResBed>().ToArray();
        viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
        viewModel.ResRoomGroups = objectContext.LocalQuery<ResRoomGroup>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.EmergencyInterventions = objectContext.LocalQuery<EmergencyIntervention>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BedListDefinition", viewModel.ResBeds);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomListDefinition", viewModel.ResRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomGroupListDefinition", viewModel.ResRoomGroups);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicNurseListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class NursingApplicationMainFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingApplication _NursingApplication { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public TTObjectClasses.NursingApplicationTreatmentMaterial[] TreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.InPatientTreatmentClinicApplication[] InPatientTreatmentClinicApplications { get; set; }
        public TTObjectClasses.BaseInpatientAdmission[] BaseInpatientAdmissions { get; set; }
        public TTObjectClasses.ResBed[] ResBeds { get; set; }
        public TTObjectClasses.ResRoom[] ResRooms { get; set; }
        public TTObjectClasses.ResRoomGroup[] ResRoomGroups { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.EmergencyIntervention[] EmergencyInterventions { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
    }
}
