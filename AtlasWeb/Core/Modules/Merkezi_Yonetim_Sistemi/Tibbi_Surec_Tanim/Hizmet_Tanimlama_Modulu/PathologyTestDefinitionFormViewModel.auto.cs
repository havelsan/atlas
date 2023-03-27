//$22530A65
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
    public partial class PathologyTestDefinitionServiceController : Controller
{
    [HttpGet]
    public PathologyTestDefinitionFormViewModel PathologyTestDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyTestDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public PathologyTestDefinitionFormViewModel PathologyTestDefinitionFormLoad(FormLoadInput input)
    {
        return PathologyTestDefinitionFormLoadInternal(input);
    }

    private PathologyTestDefinitionFormViewModel PathologyTestDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("35e93cca-0cdd-4e36-810f-66e58032d555");
        var objectDefID = Guid.Parse("0ec41b0f-08bb-4549-ad85-3ffc8e3c8ae6");
        var viewModel = new PathologyTestDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyTestDefinition = objectContext.GetObject(id.Value, objectDefID) as PathologyTestDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PathologyTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PathologyTestDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PathologyTestDefinitionForm(viewModel, viewModel._PathologyTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyTestDefinition = new PathologyTestDefinition(objectContext);
                viewModel.MaterialsGridList = new TTObjectClasses.PathologyGridMaterialDefinition[]{};
                viewModel.ttgrid1GridList = new TTObjectClasses.PathologyGridDescriptionDefinition[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PathologyTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PathologyTestDefinition);
                PreScript_PathologyTestDefinitionForm(viewModel, viewModel._PathologyTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyTestDefinitionForm(PathologyTestDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PathologyTestDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PathologyTestDefinitionFormInternal(PathologyTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("35e93cca-0cdd-4e36-810f-66e58032d555");
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.PathologyTestDescriptionDefinitions);
        objectContext.AddToRawObjectList(viewModel.TahlilTipis);
        objectContext.AddToRawObjectList(viewModel.PathologyTestCategoryDefinitions);
        objectContext.AddToRawObjectList(viewModel.MaterialsGridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
        objectContext.AddToRawObjectList(viewModel._PathologyTestDefinition);
        objectContext.ProcessRawObjects();
        var pathologyTestDefinition = (PathologyTestDefinition)objectContext.GetLoadedObject(viewModel._PathologyTestDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyTestDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyTestDefinition, formDefID);
        if (viewModel.MaterialsGridList != null)
        {
            foreach (var item in viewModel.MaterialsGridList)
            {
                var materialsImported = (PathologyGridMaterialDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)materialsImported).IsDeleted)
                    continue;
                materialsImported.PathologyTest = pathologyTestDefinition;
            }
        }

        if (viewModel.ttgrid1GridList != null)
        {
            foreach (var item in viewModel.ttgrid1GridList)
            {
                var pathologyTestDescriptionImported = (PathologyGridDescriptionDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pathologyTestDescriptionImported).IsDeleted)
                    continue;
                pathologyTestDescriptionImported.PathologyTest = pathologyTestDefinition;
            }
        }

        var transDef = pathologyTestDefinition.TransDef;
        PostScript_PathologyTestDefinitionForm(viewModel, pathologyTestDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyTestDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyTestDefinition);
        AfterContextSaveScript_PathologyTestDefinitionForm(viewModel, pathologyTestDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PathologyTestDefinitionForm(PathologyTestDefinitionFormViewModel viewModel, PathologyTestDefinition pathologyTestDefinition, TTObjectContext objectContext);
    partial void PostScript_PathologyTestDefinitionForm(PathologyTestDefinitionFormViewModel viewModel, PathologyTestDefinition pathologyTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyTestDefinitionForm(PathologyTestDefinitionFormViewModel viewModel, PathologyTestDefinition pathologyTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MaterialsGridList = viewModel._PathologyTestDefinition.Materials.OfType<PathologyGridMaterialDefinition>().ToArray();
        viewModel.ttgrid1GridList = viewModel._PathologyTestDefinition.PathologyTestDescription.OfType<PathologyGridDescriptionDefinition>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.PathologyTestDescriptionDefinitions = objectContext.LocalQuery<PathologyTestDescriptionDefinition>().ToArray();
        viewModel.TahlilTipis = objectContext.LocalQuery<TahlilTipi>().ToArray();
        viewModel.PathologyTestCategoryDefinitions = objectContext.LocalQuery<PathologyTestCategoryDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PathologyTestDescriptionListDefinition", viewModel.PathologyTestDescriptionDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TahlilTipiListDefinition", viewModel.TahlilTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PatholohyTestCategoryListDefinition", viewModel.PathologyTestCategoryDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class PathologyTestDefinitionFormViewModel
    {
        public TTObjectClasses.PathologyTestDefinition _PathologyTestDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyGridMaterialDefinition[] MaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyGridDescriptionDefinition[] ttgrid1GridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyTestDescriptionDefinition[] PathologyTestDescriptionDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.TahlilTipi[] TahlilTipis
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyTestCategoryDefinition[] PathologyTestCategoryDefinitions
        {
            get;
            set;
        }
    }
}
