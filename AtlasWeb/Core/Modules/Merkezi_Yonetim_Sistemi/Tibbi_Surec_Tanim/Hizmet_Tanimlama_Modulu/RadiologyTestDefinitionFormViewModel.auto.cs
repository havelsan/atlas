//$1E100D0B
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
    public partial class RadiologyTestDefinitionServiceController : Controller
{
    [HttpGet]
    public RadiologyTestDefinitionFormViewModel RadiologyTestDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return RadiologyTestDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public RadiologyTestDefinitionFormViewModel RadiologyTestDefinitionFormLoad(FormLoadInput input)
    {
        return RadiologyTestDefinitionFormLoadInternal(input);
    }

    private RadiologyTestDefinitionFormViewModel RadiologyTestDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a9cb78e1-353b-4a56-8a46-be0e0191f821");
        var objectDefID = Guid.Parse("2a86ddb5-6508-41c6-ae55-6b983add9c84");
        var viewModel = new RadiologyTestDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RadiologyTestDefinition = objectContext.GetObject(id.Value, objectDefID) as RadiologyTestDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RadiologyTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._RadiologyTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._RadiologyTestDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_RadiologyTestDefinitionForm(viewModel, viewModel._RadiologyTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RadiologyTestDefinition = new RadiologyTestDefinition(objectContext);
                viewModel.TabNameGridGridList = new TTObjectClasses.RadiologyTabNamesGrid[]{};
                viewModel.ttgrid2GridList = new TTObjectClasses.RadiologyGridRestrictedTestDefinition[]{};
                viewModel.ttgrid3GridList = new TTObjectClasses.RadiologyGridDepartmentDefinition[]{};
                viewModel.ttgrid4GridList = new TTObjectClasses.RadiologyGridEquipmentDefinition[]{};
                viewModel.ttgrid1GridList = new TTObjectClasses.RadiologyGridMaterialDefinition[]{};
                viewModel.ttgrid5GridList = new TTObjectClasses.RadiologyGridTestDescriptionDefinition[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RadiologyTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._RadiologyTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._RadiologyTestDefinition);
                PreScript_RadiologyTestDefinitionForm(viewModel, viewModel._RadiologyTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel RadiologyTestDefinitionForm(RadiologyTestDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return RadiologyTestDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel RadiologyTestDefinitionFormInternal(RadiologyTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a9cb78e1-353b-4a56-8a46-be0e0191f821");
        objectContext.AddToRawObjectList(viewModel.RadiologyTestTMDefinitions);
        objectContext.AddToRawObjectList(viewModel.RadiologyTabDefinitions);
        objectContext.AddToRawObjectList(viewModel.RadiologyTestTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResRadiologyDepartments);
        objectContext.AddToRawObjectList(viewModel.ResRadiologyEquipments);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.RadiologyTestDescriptionDefinitions);
        objectContext.AddToRawObjectList(viewModel.SKRSLOINCs);
        objectContext.AddToRawObjectList(viewModel.TabNameGridGridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid3GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid4GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid5GridList);
        objectContext.AddToRawObjectList(viewModel._RadiologyTestDefinition);
        objectContext.ProcessRawObjects();
        var radiologyTestDefinition = (RadiologyTestDefinition)objectContext.GetLoadedObject(viewModel._RadiologyTestDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(radiologyTestDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyTestDefinition, formDefID);
        if (viewModel.TabNameGridGridList != null)
        {
            foreach (var item in viewModel.TabNameGridGridList)
            {
                var tabNamesImported = (RadiologyTabNamesGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)tabNamesImported).IsDeleted)
                    continue;
                tabNamesImported.RadiologyTestDefinition = radiologyTestDefinition;
            }
        }

        if (viewModel.ttgrid2GridList != null)
        {
            foreach (var item in viewModel.ttgrid2GridList)
            {
                var restrictedsImported = (RadiologyGridRestrictedTestDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)restrictedsImported).IsDeleted)
                    continue;
                restrictedsImported.RadiologyTestDefinition = radiologyTestDefinition;
            }
        }

        if (viewModel.ttgrid3GridList != null)
        {
            foreach (var item in viewModel.ttgrid3GridList)
            {
                var departmentsImported = (RadiologyGridDepartmentDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)departmentsImported).IsDeleted)
                    continue;
                departmentsImported.RadiologyTest = radiologyTestDefinition;
            }
        }

        if (viewModel.ttgrid4GridList != null)
        {
            foreach (var item in viewModel.ttgrid4GridList)
            {
                var equipmentsImported = (RadiologyGridEquipmentDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)equipmentsImported).IsDeleted)
                    continue;
                equipmentsImported.RadiologyTest = radiologyTestDefinition;
            }
        }

        if (viewModel.ttgrid1GridList != null)
        {
            foreach (var item in viewModel.ttgrid1GridList)
            {
                var materialsImported = (RadiologyGridMaterialDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)materialsImported).IsDeleted)
                    continue;
                materialsImported.RadiologyTest = radiologyTestDefinition;
            }
        }

        if (viewModel.ttgrid5GridList != null)
        {
            foreach (var item in viewModel.ttgrid5GridList)
            {
                var radiologyTestDescriptionsImported = (RadiologyGridTestDescriptionDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)radiologyTestDescriptionsImported).IsDeleted)
                    continue;
                radiologyTestDescriptionsImported.RadiologyTest = radiologyTestDefinition;
            }
        }

        var transDef = radiologyTestDefinition.TransDef;
        PostScript_RadiologyTestDefinitionForm(viewModel, radiologyTestDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(radiologyTestDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(radiologyTestDefinition);
        AfterContextSaveScript_RadiologyTestDefinitionForm(viewModel, radiologyTestDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_RadiologyTestDefinitionForm(RadiologyTestDefinitionFormViewModel viewModel, RadiologyTestDefinition radiologyTestDefinition, TTObjectContext objectContext);
    partial void PostScript_RadiologyTestDefinitionForm(RadiologyTestDefinitionFormViewModel viewModel, RadiologyTestDefinition radiologyTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_RadiologyTestDefinitionForm(RadiologyTestDefinitionFormViewModel viewModel, RadiologyTestDefinition radiologyTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(RadiologyTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.TabNameGridGridList = viewModel._RadiologyTestDefinition.TabNames.OfType<RadiologyTabNamesGrid>().ToArray();
        viewModel.ttgrid2GridList = viewModel._RadiologyTestDefinition.Restricteds.OfType<RadiologyGridRestrictedTestDefinition>().ToArray();
        viewModel.ttgrid3GridList = viewModel._RadiologyTestDefinition.Departments.OfType<RadiologyGridDepartmentDefinition>().ToArray();
        viewModel.ttgrid4GridList = viewModel._RadiologyTestDefinition.Equipments.OfType<RadiologyGridEquipmentDefinition>().ToArray();
        viewModel.ttgrid1GridList = viewModel._RadiologyTestDefinition.Materials.OfType<RadiologyGridMaterialDefinition>().ToArray();
        viewModel.ttgrid5GridList = viewModel._RadiologyTestDefinition.RadiologyTestDescriptions.OfType<RadiologyGridTestDescriptionDefinition>().ToArray();
        viewModel.RadiologyTestTMDefinitions = objectContext.LocalQuery<RadiologyTestTMDefinition>().ToArray();
        viewModel.RadiologyTabDefinitions = objectContext.LocalQuery<RadiologyTabDefinition>().ToArray();
        viewModel.RadiologyTestTypeDefinitions = objectContext.LocalQuery<RadiologyTestTypeDefinition>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.RadiologyTestDefinitions = objectContext.LocalQuery<RadiologyTestDefinition>().ToArray();
        viewModel.ResRadiologyDepartments = objectContext.LocalQuery<ResRadiologyDepartment>().ToArray();
        viewModel.ResRadiologyEquipments = objectContext.LocalQuery<ResRadiologyEquipment>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.RadiologyTestDescriptionDefinitions = objectContext.LocalQuery<RadiologyTestDescriptionDefinition>().ToArray();
        viewModel.SKRSLOINCs = objectContext.LocalQuery<SKRSLOINC>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestLisTMDefinition", viewModel.RadiologyTestTMDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTabListDefinition", viewModel.RadiologyTabDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestTypeListDefinition", viewModel.RadiologyTestTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestListDefinition", viewModel.RadiologyTestDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyDepartmentListDefinition", viewModel.ResRadiologyDepartments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResRadiologyEquipmentListDefinition", viewModel.ResRadiologyEquipments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadiologyTestDescriptionListDefinition", viewModel.RadiologyTestDescriptionDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSLOINCList", viewModel.SKRSLOINCs);
    }
}
}


namespace Core.Models
{
    public partial class RadiologyTestDefinitionFormViewModel
    {
        public TTObjectClasses.RadiologyTestDefinition _RadiologyTestDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTabNamesGrid[] TabNameGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyGridRestrictedTestDefinition[] ttgrid2GridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyGridDepartmentDefinition[] ttgrid3GridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyGridEquipmentDefinition[] ttgrid4GridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyGridMaterialDefinition[] ttgrid1GridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyGridTestDescriptionDefinition[] ttgrid5GridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTestTMDefinition[] RadiologyTestTMDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTabDefinition[] RadiologyTabDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTestTypeDefinition[] RadiologyTestTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTestDefinition[] RadiologyTestDefinitions
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

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTestDescriptionDefinition[] RadiologyTestDescriptionDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSLOINC[] SKRSLOINCs
        {
            get;
            set;
        }
    }
}
