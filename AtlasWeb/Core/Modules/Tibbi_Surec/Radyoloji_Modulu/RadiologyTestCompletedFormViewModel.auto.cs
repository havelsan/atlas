//$8E582BF4
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
    public RadiologyTestCompletedFormViewModel RadiologyTestCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return RadiologyTestCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public RadiologyTestCompletedFormViewModel RadiologyTestCompletedFormLoad(FormLoadInput input)
    {
        return RadiologyTestCompletedFormLoadInternal(input);
    }

    private RadiologyTestCompletedFormViewModel RadiologyTestCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6e8cbff6-6130-4a03-a127-61522b3090cb");
        var objectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
        var viewModel = new RadiologyTestCompletedFormViewModel();
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
                PreScript_RadiologyTestCompletedForm(viewModel, viewModel._RadiologyTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RadiologyTest = new RadiologyTest(objectContext);
                var entryStateID = Guid.Parse("66151cc1-9a6a-4961-a2f5-e7528f65a6f9");
                viewModel._RadiologyTest.CurrentStateDefID = entryStateID;
                viewModel.MaterialsGridList = new TTObjectClasses.RadiologyMaterial[]{};
                viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.SurgeryDirectPurchaseGridsGridList = new TTObjectClasses.SurgeryDirectPurchaseGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RadiologyTest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._RadiologyTest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._RadiologyTest);
                PreScript_RadiologyTestCompletedForm(viewModel, viewModel._RadiologyTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel RadiologyTestCompletedForm(RadiologyTestCompletedFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return RadiologyTestCompletedFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel RadiologyTestCompletedFormInternal(RadiologyTestCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6e8cbff6-6130-4a03-a127-61522b3090cb");
        objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
        objectContext.AddToRawObjectList(viewModel.RadiologyRepeatReasonDefinitions);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.Patients);
        objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ResRadiologyDepartments);
        objectContext.AddToRawObjectList(viewModel.ResRadiologyEquipments);
        objectContext.AddToRawObjectList(viewModel.DPADetailFirmPriceOffers);
        objectContext.AddToRawObjectList(viewModel.ProductDefinitions);
        objectContext.AddToRawObjectList(viewModel.DirectPurchaseActionDetails);
        objectContext.AddToRawObjectList(viewModel.Radiologys);
        objectContext.AddToRawObjectList(viewModel.MaterialsGridList);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel.SurgeryDirectPurchaseGridsGridList);
        var entryStateID = Guid.Parse("66151cc1-9a6a-4961-a2f5-e7528f65a6f9");
        objectContext.AddToRawObjectList(viewModel._RadiologyTest, entryStateID);
        objectContext.ProcessRawObjects(false);
        var radiologyTest = (RadiologyTest)objectContext.GetLoadedObject(viewModel._RadiologyTest.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(radiologyTest, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTest, formDefID);
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

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(radiologyTest);
        PostScript_RadiologyTestCompletedForm(viewModel, radiologyTest, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(radiologyTest);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(radiologyTest);
        AfterContextSaveScript_RadiologyTestCompletedForm(viewModel, radiologyTest, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_RadiologyTestCompletedForm(RadiologyTestCompletedFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext);
    partial void PostScript_RadiologyTestCompletedForm(RadiologyTestCompletedFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_RadiologyTestCompletedForm(RadiologyTestCompletedFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(RadiologyTestCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MaterialsGridList = viewModel._RadiologyTest.RadiologyTestTreatmentMaterial.OfType<RadiologyMaterial>().ToArray();
        var episode = viewModel._RadiologyTest.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.SurgeryDirectPurchaseGridsGridList = viewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids.OfType<SurgeryDirectPurchaseGrid>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.RadiologyRepeatReasonDefinitions = objectContext.LocalQuery<RadiologyRepeatReasonDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResRadiologyDepartments = objectContext.LocalQuery<ResRadiologyDepartment>().ToArray();
        viewModel.ResRadiologyEquipments = objectContext.LocalQuery<ResRadiologyEquipment>().ToArray();
        viewModel.DPADetailFirmPriceOffers = objectContext.LocalQuery<DPADetailFirmPriceOffer>().ToArray();
        viewModel.ProductDefinitions = objectContext.LocalQuery<ProductDefinition>().ToArray();
        viewModel.DirectPurchaseActionDetails = objectContext.LocalQuery<DirectPurchaseActionDetail>().ToArray();
        viewModel.Radiologys = objectContext.LocalQuery<Radiology>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyRepeatReasonListDefinition", viewModel.RadiologyRepeatReasonDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.SKRSILKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyDepartmentListDefinition", viewModel.ResRadiologyDepartments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyEquipmentListDefinition", viewModel.ResRadiologyEquipments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DirectPurchaseActionDetailList", viewModel.DPADetailFirmPriceOffers);
    }
}
}


namespace Core.Models
{
    public partial class RadiologyTestCompletedFormViewModel
    {
        public TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyMaterial[] MaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SurgeryDirectPurchaseGrid[] SurgeryDirectPurchaseGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyRepeatReasonDefinition[] RadiologyRepeatReasonDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ResRadiologyDepartment[] ResRadiologyDepartments
        {
            get;
            set;
        }

        public TTObjectClasses.ResRadiologyEquipment[] ResRadiologyEquipments
        {
            get;
            set;
        }

        public TTObjectClasses.DPADetailFirmPriceOffer[] DPADetailFirmPriceOffers
        {
            get;
            set;
        }

        public TTObjectClasses.ProductDefinition[] ProductDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.DirectPurchaseActionDetail[] DirectPurchaseActionDetails
        {
            get;
            set;
        }

        public TTObjectClasses.Radiology[] Radiologys
        {
            get;
            set;
        }
    }
}
