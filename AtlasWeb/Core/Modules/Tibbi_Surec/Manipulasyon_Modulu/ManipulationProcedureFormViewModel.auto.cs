//$64B6D508
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
    public partial class ManipulationServiceController : Controller
{
    [HttpGet]
    public ManipulationProcedureFormViewModel ManipulationProcedureForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ManipulationProcedureFormLoadInternal(input);
    }

    [HttpPost]
    public ManipulationProcedureFormViewModel ManipulationProcedureFormLoad(FormLoadInput input)
    {
        return ManipulationProcedureFormLoadInternal(input);
    }

    private ManipulationProcedureFormViewModel ManipulationProcedureFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("efcdf88e-82e2-4051-b064-42a634c4d801");
        var objectDefID = Guid.Parse("528f1264-6f0b-41ab-b8a3-a8eda6d9134a");
        var viewModel = new ManipulationProcedureFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Manipulation = objectContext.GetObject(id.Value, objectDefID) as Manipulation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Manipulation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Manipulation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Manipulation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ManipulationProcedureForm(viewModel, viewModel._Manipulation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("efcdf88e-82e2-4051-b064-42a634c4d801");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SagSols);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ManipulationRequests);
            objectContext.AddToRawObjectList(viewModel.GridManipulationsGridList);
            objectContext.AddToRawObjectList(viewModel.GridPersonnelGridList);
            objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.GridAdditionalApplicationsGridList);
            objectContext.AddToRawObjectList(viewModel.DirectPurchaseGridsGridList);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.GridReturnReasonsGridList);
            objectContext.AddToRawObjectList(viewModel._Manipulation); 
            objectContext.ProcessRawObjects();
            var manipulation = (Manipulation)objectContext.GetLoadedObject(viewModel._Manipulation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
            if (viewModel.GridManipulationsGridList != null)
            {
                foreach (var item in viewModel.GridManipulationsGridList)
                {
                    var manipulationProceduresImported = (ManipulationProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationProceduresImported).IsDeleted)
                        continue;
                    manipulationProceduresImported.Manipulation = manipulation;
                }
            }

            if (viewModel.GridPersonnelGridList != null)
            {
                foreach (var item in viewModel.GridPersonnelGridList)
                {
                    var manipulationPersonnelImported = (ManipulationPersonnel)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationPersonnelImported).IsDeleted)
                        continue;
                    manipulationPersonnelImported.Manipulation = manipulation;
                }
            }

            if (viewModel.GridTreatmentMaterialsGridList != null)
            {
                foreach (var item in viewModel.GridTreatmentMaterialsGridList)
                {
                    var manipulationTreatmentMaterialsImported = (ManipulationTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationTreatmentMaterialsImported).IsDeleted)
                        continue;
                    manipulationTreatmentMaterialsImported.EpisodeAction = manipulation;
                }
            }

            if (viewModel.GridAdditionalApplicationsGridList != null)
            {
                foreach (var item in viewModel.GridAdditionalApplicationsGridList)
                {
                    var manipulationAdditionalApplicationsImported = (ManipulationAdditionalApplication)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationAdditionalApplicationsImported).IsDeleted)
                        continue;
                    manipulationAdditionalApplicationsImported.Manipulation = manipulation;
                }
            }

            if (viewModel.DirectPurchaseGridsGridList != null)
            {
                foreach (var item in viewModel.DirectPurchaseGridsGridList)
                {
                    var directPurchaseGridsImported = (DirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)directPurchaseGridsImported).IsDeleted)
                        continue;
                    directPurchaseGridsImported.EpisodeAction = manipulation;
                }
            }

            var episodeImported = manipulation.Episode;
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

            if (viewModel.GridReturnReasonsGridList != null)
            {
                foreach (var item in viewModel.GridReturnReasonsGridList)
                {
                    var manipulationReturnReasonsImported = (ManipulationReturnReasonsGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manipulationReturnReasonsImported).IsDeleted)
                        continue;
                    manipulationReturnReasonsImported.Manipulation = manipulation;
                }
            }

            var transDef = manipulation.TransDef;
            PostScript_ManipulationProcedureForm(viewModel, manipulation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manipulation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manipulation);
            AfterContextSaveScript_ManipulationProcedureForm(viewModel, manipulation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext);
    partial void PostScript_ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ManipulationProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridManipulationsGridList = viewModel._Manipulation.ManipulationProcedures.OfType<ManipulationProcedure>().ToArray();
        viewModel.GridPersonnelGridList = viewModel._Manipulation.ManipulationPersonnel.OfType<ManipulationPersonnel>().ToArray();
        viewModel.GridTreatmentMaterialsGridList = viewModel._Manipulation.ManipulationTreatmentMaterials.OfType<ManipulationTreatmentMaterial>().ToArray();
        viewModel.GridAdditionalApplicationsGridList = viewModel._Manipulation.ManipulationAdditionalApplications.OfType<ManipulationAdditionalApplication>().ToArray();
        viewModel.DirectPurchaseGridsGridList = viewModel._Manipulation.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
        var episode = viewModel._Manipulation.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.GridReturnReasonsGridList = viewModel._Manipulation.ManipulationReturnReasons.OfType<ManipulationReturnReasonsGrid>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SagSols = objectContext.LocalQuery<SagSol>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ManipulationRequests = objectContext.LocalQuery<ManipulationRequest>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ManiplationListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SagSolListDefinition", viewModel.SagSols);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AdditionalApplicationListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ManipulationProcedureFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Manipulation _Manipulation { get; set; }
        public TTObjectClasses.ManipulationProcedure[] GridManipulationsGridList { get; set; }
        public TTObjectClasses.ManipulationPersonnel[] GridPersonnelGridList { get; set; }
        public TTObjectClasses.ManipulationTreatmentMaterial[] GridTreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.ManipulationAdditionalApplication[] GridAdditionalApplicationsGridList { get; set; }
        public TTObjectClasses.DirectPurchaseGrid[] DirectPurchaseGridsGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.ManipulationReturnReasonsGrid[] GridReturnReasonsGridList { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SagSol[] SagSols { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ManipulationRequest[] ManipulationRequests { get; set; }
    }
}
