//$E049CF57
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
    public RadiologyTestCancelFormViewModel RadiologyTestCancelForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return RadiologyTestCancelFormLoadInternal(input);
    }

    [HttpPost]
    public RadiologyTestCancelFormViewModel RadiologyTestCancelFormLoad(FormLoadInput input)
    {
        return RadiologyTestCancelFormLoadInternal(input);
    }

    private RadiologyTestCancelFormViewModel RadiologyTestCancelFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e3822f56-89ac-4f89-a0ec-9515fdfd44e9");
        var objectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
        var viewModel = new RadiologyTestCancelFormViewModel();
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
                PreScript_RadiologyTestCancelForm(viewModel, viewModel._RadiologyTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel RadiologyTestCancelForm(RadiologyTestCancelFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e3822f56-89ac-4f89-a0ec-9515fdfd44e9");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResRadiologyEquipments);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResRadiologyDepartments);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Radiologys);
            objectContext.AddToRawObjectList(viewModel.MaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel._RadiologyTest);
            objectContext.ProcessRawObjects();
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

            var transDef = radiologyTest.TransDef;
            PostScript_RadiologyTestCancelForm(viewModel, radiologyTest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(radiologyTest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(radiologyTest);
            AfterContextSaveScript_RadiologyTestCancelForm(viewModel, radiologyTest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_RadiologyTestCancelForm(RadiologyTestCancelFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext);
    partial void PostScript_RadiologyTestCancelForm(RadiologyTestCancelFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_RadiologyTestCancelForm(RadiologyTestCancelFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(RadiologyTestCancelFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MaterialsGridList = viewModel._RadiologyTest.RadiologyTestTreatmentMaterial.OfType<RadiologyMaterial>().ToArray();
        var episode = viewModel._RadiologyTest.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ResRadiologyEquipments = objectContext.LocalQuery<ResRadiologyEquipment>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResRadiologyDepartments = objectContext.LocalQuery<ResRadiologyDepartment>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Radiologys = objectContext.LocalQuery<Radiology>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyEquipmentListDefinition", viewModel.ResRadiologyEquipments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyDepartmentListDefinition", viewModel.ResRadiologyDepartments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class RadiologyTestCancelFormViewModel : BaseViewModel
    {
        public TTObjectClasses.RadiologyTest _RadiologyTest { get; set; }
        public TTObjectClasses.RadiologyMaterial[] MaterialsGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.ResRadiologyEquipment[] ResRadiologyEquipments { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResRadiologyDepartment[] ResRadiologyDepartments { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Radiology[] Radiologys { get; set; }
    }
}
