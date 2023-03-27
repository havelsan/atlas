//$C12C21DE
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
    public partial class DentalTreatmentDefinitionServiceController : Controller
{
    [HttpGet]
    public DentalTreatmentDefinitionFormViewModel DentalTreatmentDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DentalTreatmentDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public DentalTreatmentDefinitionFormViewModel DentalTreatmentDefinitionFormLoad(FormLoadInput input)
    {
        return DentalTreatmentDefinitionFormLoadInternal(input);
    }

    private DentalTreatmentDefinitionFormViewModel DentalTreatmentDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("097b99b8-31c8-4c5c-a52d-53027391c4e4");
        var objectDefID = Guid.Parse("aa4158e2-1004-443d-9d3b-3fc9958515e4");
        var viewModel = new DentalTreatmentDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalTreatmentDefinition = objectContext.GetObject(id.Value, objectDefID) as DentalTreatmentDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalTreatmentDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalTreatmentDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DentalTreatmentDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DentalTreatmentDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DentalTreatmentDefinitionForm(viewModel, viewModel._DentalTreatmentDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalTreatmentDefinition = new DentalTreatmentDefinition(objectContext);
                viewModel.DepartmentsGridList = new TTObjectClasses.DentalTreatmentDepartmentGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalTreatmentDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalTreatmentDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DentalTreatmentDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DentalTreatmentDefinition);
                PreScript_DentalTreatmentDefinitionForm(viewModel, viewModel._DentalTreatmentDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DentalTreatmentDefinitionForm(DentalTreatmentDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DentalTreatmentDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel DentalTreatmentDefinitionFormInternal(DentalTreatmentDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("097b99b8-31c8-4c5c-a52d-53027391c4e4");
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.DentalRequestTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.DepartmentsGridList);
        objectContext.AddToRawObjectList(viewModel._DentalTreatmentDefinition);
        objectContext.ProcessRawObjects();
        var dentalTreatmentDefinition = (DentalTreatmentDefinition)objectContext.GetLoadedObject(viewModel._DentalTreatmentDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(dentalTreatmentDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalTreatmentDefinition, formDefID);
        if (viewModel.DepartmentsGridList != null)
        {
            foreach (var item in viewModel.DepartmentsGridList)
            {
                var departmentsImported = (DentalTreatmentDepartmentGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)departmentsImported).IsDeleted)
                    continue;
                departmentsImported.DentalTreatmentDefinition = dentalTreatmentDefinition;
            }
        }

        var transDef = dentalTreatmentDefinition.TransDef;
        PostScript_DentalTreatmentDefinitionForm(viewModel, dentalTreatmentDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dentalTreatmentDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dentalTreatmentDefinition);
        AfterContextSaveScript_DentalTreatmentDefinitionForm(viewModel, dentalTreatmentDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DentalTreatmentDefinitionForm(DentalTreatmentDefinitionFormViewModel viewModel, DentalTreatmentDefinition dentalTreatmentDefinition, TTObjectContext objectContext);
    partial void PostScript_DentalTreatmentDefinitionForm(DentalTreatmentDefinitionFormViewModel viewModel, DentalTreatmentDefinition dentalTreatmentDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DentalTreatmentDefinitionForm(DentalTreatmentDefinitionFormViewModel viewModel, DentalTreatmentDefinition dentalTreatmentDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DentalTreatmentDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DepartmentsGridList = viewModel._DentalTreatmentDefinition.Departments.OfType<DentalTreatmentDepartmentGrid>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.DentalRequestTypeDefinitions = objectContext.LocalQuery<DentalRequestTypeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DentalRequestTypeListDefinition", viewModel.DentalRequestTypeDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class DentalTreatmentDefinitionFormViewModel
    {
        public TTObjectClasses.DentalTreatmentDefinition _DentalTreatmentDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.DentalTreatmentDepartmentGrid[] DepartmentsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.DentalRequestTypeDefinition[] DentalRequestTypeDefinitions
        {
            get;
            set;
        }
    }
}
