//$91B72688
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
    public partial class RadiologyTestServiceController : Controller
{
    [HttpGet]
    public RadiologyTestApproveFormViewModel RadiologyTestApproveForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return RadiologyTestApproveFormLoadInternal(input);
    }

    [HttpPost]
    public RadiologyTestApproveFormViewModel RadiologyTestApproveFormLoad(FormLoadInput input)
    {
        return RadiologyTestApproveFormLoadInternal(input);
    }

    private RadiologyTestApproveFormViewModel RadiologyTestApproveFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a6d5935a-6307-4045-b441-f2db2081fc35");
        var objectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
        var viewModel = new RadiologyTestApproveFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RadiologyTest = objectContext.GetObject(id.Value, objectDefID) as RadiologyTest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RadiologyTest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._RadiologyTest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._RadiologyTest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_RadiologyTestApproveForm(viewModel, viewModel._RadiologyTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel RadiologyTestApproveForm(RadiologyTestApproveFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a6d5935a-6307-4045-b441-f2db2081fc35");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
            objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.Radiologys);
            objectContext.AddToRawObjectList(viewModel.SagSols);
            objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
            objectContext.AddToRawObjectList(viewModel.ResRadiologyEquipments);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResRadiologyDepartments);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
            objectContext.AddToRawObjectList(viewModel.DPADetailFirmPriceOffers);
            objectContext.AddToRawObjectList(viewModel.ProductDefinitions);
            objectContext.AddToRawObjectList(viewModel.DirectPurchaseActionDetails);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.MaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.SurgeryDirectPurchaseGridsGridList);
            objectContext.AddToRawObjectList(viewModel._RadiologyTest);
            objectContext.ProcessRawObjects();
            var radiologyTest = (RadiologyTest)objectContext.GetLoadedObject(viewModel._RadiologyTest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(radiologyTest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTest, formDefID);
            var episodeImported = radiologyTest.Episode;
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

            if (viewModel.MaterialsGridList != null)
            {
                foreach (var item in viewModel.MaterialsGridList)
                {
                    var radiologyTestTreatmentMaterialImported = (RadiologyMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)radiologyTestTreatmentMaterialImported).IsDeleted)
                        continue;
                    radiologyTestTreatmentMaterialImported.SubactionProcedureFlowable = radiologyTest;
                }
            }

            if (viewModel.SurgeryDirectPurchaseGridsGridList != null)
            {
                foreach (var item in viewModel.SurgeryDirectPurchaseGridsGridList)
                {
                    var radiologyTest_SurgeryDirectPurchaseGridsImported = (SurgeryDirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)radiologyTest_SurgeryDirectPurchaseGridsImported).IsDeleted)
                        continue;
                    radiologyTest_SurgeryDirectPurchaseGridsImported.SubactionProcedureFlowable = radiologyTest;
                }
            }

            var transDef = radiologyTest.TransDef;
            PostScript_RadiologyTestApproveForm(viewModel, radiologyTest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(radiologyTest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(radiologyTest);
            AfterContextSaveScript_RadiologyTestApproveForm(viewModel, radiologyTest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_RadiologyTestApproveForm(RadiologyTestApproveFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext);
    partial void PostScript_RadiologyTestApproveForm(RadiologyTestApproveFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_RadiologyTestApproveForm(RadiologyTestApproveFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(RadiologyTestApproveFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._RadiologyTest.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.MaterialsGridList = viewModel._RadiologyTest.RadiologyTestTreatmentMaterial.OfType<RadiologyMaterial>().ToArray();
        viewModel.SurgeryDirectPurchaseGridsGridList = viewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids.OfType<SurgeryDirectPurchaseGrid>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.Radiologys = objectContext.LocalQuery<Radiology>().ToArray();
        viewModel.SagSols = objectContext.LocalQuery<SagSol>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        viewModel.ResRadiologyEquipments = objectContext.LocalQuery<ResRadiologyEquipment>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResRadiologyDepartments = objectContext.LocalQuery<ResRadiologyDepartment>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.DPADetailFirmPriceOffers = objectContext.LocalQuery<DPADetailFirmPriceOffer>().ToArray();
        viewModel.ProductDefinitions = objectContext.LocalQuery<ProductDefinition>().ToArray();
        viewModel.DirectPurchaseActionDetails = objectContext.LocalQuery<DirectPurchaseActionDetail>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.SKRSILKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SagSolListDefinition", viewModel.SagSols);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyEquipmentListDefinition", viewModel.ResRadiologyEquipments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyDepartmentListDefinition", viewModel.ResRadiologyDepartments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DirectPurchaseActionDetailList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListByReportNQL", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class RadiologyTestApproveFormViewModel : BaseViewModel
    {
        public TTObjectClasses.RadiologyTest _RadiologyTest { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.RadiologyMaterial[] MaterialsGridList { get; set; }
        public TTObjectClasses.SurgeryDirectPurchaseGrid[] SurgeryDirectPurchaseGridsGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris { get; set; }
        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.Radiology[] Radiologys { get; set; }
        public TTObjectClasses.SagSol[] SagSols { get; set; }
        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis { get; set; }
        public TTObjectClasses.ResRadiologyEquipment[] ResRadiologyEquipments { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResRadiologyDepartment[] ResRadiologyDepartments { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.MalzemeTuru[] MalzemeTurus { get; set; }
        public TTObjectClasses.DPADetailFirmPriceOffer[] DPADetailFirmPriceOffers { get; set; }
        public TTObjectClasses.ProductDefinition[] ProductDefinitions { get; set; }
        public TTObjectClasses.DirectPurchaseActionDetail[] DirectPurchaseActionDetails { get; set; }
    }
}
