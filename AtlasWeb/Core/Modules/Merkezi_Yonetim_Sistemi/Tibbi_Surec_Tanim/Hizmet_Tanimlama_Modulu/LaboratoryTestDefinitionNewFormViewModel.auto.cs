//$79CCFC80
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
    public partial class LaboratoryTestDefinitionServiceController : Controller
{
    [HttpGet]
    public LaboratoryTestDefinitionNewFormViewModel LaboratoryTestDefinitionNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return LaboratoryTestDefinitionNewFormLoadInternal(input);
    }

    [HttpPost]
    public LaboratoryTestDefinitionNewFormViewModel LaboratoryTestDefinitionNewFormLoad(FormLoadInput input)
    {
        return LaboratoryTestDefinitionNewFormLoadInternal(input);
    }

    private LaboratoryTestDefinitionNewFormViewModel LaboratoryTestDefinitionNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a944b47e-5632-420d-b9fe-79d148e5ff3b");
        var objectDefID = Guid.Parse("42ed5391-9525-457f-8412-500f7b0935bf");
        var viewModel = new LaboratoryTestDefinitionNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LaboratoryTestDefinition = objectContext.GetObject(id.Value, objectDefID) as LaboratoryTestDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LaboratoryTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._LaboratoryTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._LaboratoryTestDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_LaboratoryTestDefinitionNewForm(viewModel, viewModel._LaboratoryTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LaboratoryTestDefinition = new LaboratoryTestDefinition(objectContext);
                viewModel.TabNameGridGridList = new TTObjectClasses.LaboratoryTabNamesGrid[]{};
                viewModel.GridPanelTestsGridList = new TTObjectClasses.LaboratoryGridPanelTestDefinition[]{};
                viewModel.GridDepartmentsGridList = new TTObjectClasses.LaboratoryGridDepartmentDefinition[]{};
                viewModel.GridRestrictedTestsGridList = new TTObjectClasses.LaboratoryGridRestrictedTestDefiniton[]{};
                viewModel.GridBoundedTestsGridList = new TTObjectClasses.LaboratoryGridBoundedTestDefinition[]{};
                viewModel.GridMaterialsGridList = new TTObjectClasses.LaboratoryGridMaterialDefinition[]{};
                viewModel.ttgrid1GridList = new TTObjectClasses.LabGridSpecialityDefinition[] { };
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LaboratoryTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._LaboratoryTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._LaboratoryTestDefinition);
                PreScript_LaboratoryTestDefinitionNewForm(viewModel, viewModel._LaboratoryTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel LaboratoryTestDefinitionNewForm(LaboratoryTestDefinitionNewFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return LaboratoryTestDefinitionNewFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel LaboratoryTestDefinitionNewFormInternal(LaboratoryTestDefinitionNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a944b47e-5632-420d-b9fe-79d148e5ff3b");
        objectContext.AddToRawObjectList(viewModel.SKRSLOINCs);
        objectContext.AddToRawObjectList(viewModel.LaboratoryRequestFormTabDefinitions);
        objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.LaboratoryTestTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResLaboratoryDepartments);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
        objectContext.AddToRawObjectList(viewModel.TahlilTipis);
        objectContext.AddToRawObjectList(viewModel.TabNameGridGridList);
        objectContext.AddToRawObjectList(viewModel.GridPanelTestsGridList);
        objectContext.AddToRawObjectList(viewModel.GridDepartmentsGridList);
        objectContext.AddToRawObjectList(viewModel.GridRestrictedTestsGridList);
        objectContext.AddToRawObjectList(viewModel.GridBoundedTestsGridList);
        objectContext.AddToRawObjectList(viewModel.GridMaterialsGridList);
        objectContext.AddToRawObjectList(viewModel._LaboratoryTestDefinition);
        objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
        objectContext.ProcessRawObjects();
        var laboratoryTestDefinition = (LaboratoryTestDefinition)objectContext.GetLoadedObject(viewModel._LaboratoryTestDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(laboratoryTestDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryTestDefinition, formDefID);
        if (viewModel.TabNameGridGridList != null)
        {
            foreach (var item in viewModel.TabNameGridGridList)
            {
                var tabNamesImported = (LaboratoryTabNamesGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)tabNamesImported).IsDeleted)
                    continue;
                tabNamesImported.LaboratoryTestDefinition = laboratoryTestDefinition;
            }
        }

        if (viewModel.GridPanelTestsGridList != null)
        {
            foreach (var item in viewModel.GridPanelTestsGridList)
            {
                var panelTestsImported = (LaboratoryGridPanelTestDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)panelTestsImported).IsDeleted)
                    continue;
                panelTestsImported.LaboratoryTestDefinition = laboratoryTestDefinition;
            }
        }

        if (viewModel.GridDepartmentsGridList != null)
        {
            foreach (var item in viewModel.GridDepartmentsGridList)
            {
                var departmentsImported = (LaboratoryGridDepartmentDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)departmentsImported).IsDeleted)
                    continue;
                departmentsImported.LaboratoryTest = laboratoryTestDefinition;
            }
        }

        if (viewModel.GridRestrictedTestsGridList != null)
        {
            foreach (var item in viewModel.GridRestrictedTestsGridList)
            {
                var restrictedTestsImported = (LaboratoryGridRestrictedTestDefiniton)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)restrictedTestsImported).IsDeleted)
                    continue;
                restrictedTestsImported.LaboratoryTestDefinition = laboratoryTestDefinition;
            }
        }

        if (viewModel.GridBoundedTestsGridList != null)
        {
            foreach (var item in viewModel.GridBoundedTestsGridList)
            {
                var boundedTestsImported = (LaboratoryGridBoundedTestDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)boundedTestsImported).IsDeleted)
                    continue;
                boundedTestsImported.LaboratoryTestDefinition = laboratoryTestDefinition;
            }
        }

        if (viewModel.GridMaterialsGridList != null)
        {
            foreach (var item in viewModel.GridMaterialsGridList)
            {
                var materialsImported = (LaboratoryGridMaterialDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)materialsImported).IsDeleted)
                    continue;
                materialsImported.LaboratoryTestDefinition = laboratoryTestDefinition;
            }
        }

        if (viewModel.ttgrid1GridList != null)
        {
            foreach (var item in viewModel.ttgrid1GridList)
            {
                var branchsImported = (LabGridSpecialityDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)branchsImported).IsDeleted)
                    continue;
                branchsImported.LaboratoryTest = laboratoryTestDefinition;
            }
        }

            var transDef = laboratoryTestDefinition.TransDef;
        PostScript_LaboratoryTestDefinitionNewForm(viewModel, laboratoryTestDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(laboratoryTestDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(laboratoryTestDefinition);
        AfterContextSaveScript_LaboratoryTestDefinitionNewForm(viewModel, laboratoryTestDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_LaboratoryTestDefinitionNewForm(LaboratoryTestDefinitionNewFormViewModel viewModel, LaboratoryTestDefinition laboratoryTestDefinition, TTObjectContext objectContext);
    partial void PostScript_LaboratoryTestDefinitionNewForm(LaboratoryTestDefinitionNewFormViewModel viewModel, LaboratoryTestDefinition laboratoryTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_LaboratoryTestDefinitionNewForm(LaboratoryTestDefinitionNewFormViewModel viewModel, LaboratoryTestDefinition laboratoryTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(LaboratoryTestDefinitionNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.TabNameGridGridList = viewModel._LaboratoryTestDefinition.TabNames.OfType<LaboratoryTabNamesGrid>().ToArray();
        viewModel.GridPanelTestsGridList = viewModel._LaboratoryTestDefinition.PanelTests.OfType<LaboratoryGridPanelTestDefinition>().ToArray();
        viewModel.GridDepartmentsGridList = viewModel._LaboratoryTestDefinition.Departments.OfType<LaboratoryGridDepartmentDefinition>().ToArray();
        viewModel.GridRestrictedTestsGridList = viewModel._LaboratoryTestDefinition.RestrictedTests.OfType<LaboratoryGridRestrictedTestDefiniton>().ToArray();
        viewModel.GridBoundedTestsGridList = viewModel._LaboratoryTestDefinition.BoundedTests.OfType<LaboratoryGridBoundedTestDefinition>().ToArray();
        viewModel.GridMaterialsGridList = viewModel._LaboratoryTestDefinition.Materials.OfType<LaboratoryGridMaterialDefinition>().ToArray();
        viewModel.ttgrid1GridList = viewModel._LaboratoryTestDefinition.Branchs.OfType<LabGridSpecialityDefinition>().ToArray();
        viewModel.SKRSLOINCs = objectContext.LocalQuery<SKRSLOINC>().ToArray();
        viewModel.LaboratoryRequestFormTabDefinitions = objectContext.LocalQuery<LaboratoryRequestFormTabDefinition>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.LaboratoryTestTypeDefinitions = objectContext.LocalQuery<LaboratoryTestTypeDefinition>().ToArray();
        viewModel.LaboratoryTestDefinitions = objectContext.LocalQuery<LaboratoryTestDefinition>().ToArray();
        viewModel.ResLaboratoryDepartments = objectContext.LocalQuery<ResLaboratoryDepartment>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        viewModel.TahlilTipis = objectContext.LocalQuery<TahlilTipi>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSLOINCList", viewModel.SKRSLOINCs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "LaboratoryRequestFormTabListDefinition", viewModel.LaboratoryRequestFormTabDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "LaboratoryTestTypeListDefinition", viewModel.LaboratoryTestTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "LaboratorySubTestListDefinition", viewModel.LaboratoryTestDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResLaboratoryDepartmentListDefinition", viewModel.ResLaboratoryDepartments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "LaboratoryNotSubTestListDefinition", viewModel.LaboratoryTestDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TahlilTipiListDefinition", viewModel.TahlilTipis);
    }
}
}


namespace Core.Models
{
    public partial class LaboratoryTestDefinitionNewFormViewModel
    {
        public TTObjectClasses.LaboratoryTestDefinition _LaboratoryTestDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryTabNamesGrid[] TabNameGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryGridPanelTestDefinition[] GridPanelTestsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryGridDepartmentDefinition[] GridDepartmentsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryGridRestrictedTestDefiniton[] GridRestrictedTestsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryGridBoundedTestDefinition[] GridBoundedTestsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryGridMaterialDefinition[] GridMaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LabGridSpecialityDefinition[] ttgrid1GridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSLOINC[] SKRSLOINCs
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryRequestFormTabDefinition[] LaboratoryRequestFormTabDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryTestTypeDefinition[] LaboratoryTestTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryTestDefinition[] LaboratoryTestDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResLaboratoryDepartment[] ResLaboratoryDepartments
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.TahlilTipi[] TahlilTipis
        {
            get;
            set;
        }
    }
}
