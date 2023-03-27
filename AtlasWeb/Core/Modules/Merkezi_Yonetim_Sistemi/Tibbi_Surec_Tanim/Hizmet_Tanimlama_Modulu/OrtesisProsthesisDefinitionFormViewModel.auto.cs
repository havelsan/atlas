//$E601F267
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
    public partial class OrtesisProsthesisDefinitionServiceController : Controller
{
    [HttpGet]
    public OrtesisProsthesisDefinitionFormViewModel OrtesisProsthesisDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OrtesisProsthesisDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public OrtesisProsthesisDefinitionFormViewModel OrtesisProsthesisDefinitionFormLoad(FormLoadInput input)
    {
        return OrtesisProsthesisDefinitionFormLoadInternal(input);
    }

    private OrtesisProsthesisDefinitionFormViewModel OrtesisProsthesisDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("733a81cf-5923-426d-aa64-080c7270fdfa");
        var objectDefID = Guid.Parse("5304a981-6aec-426c-bf29-c36e8edc105d");
        var viewModel = new OrtesisProsthesisDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OrtesisProsthesisDefinition = objectContext.GetObject(id.Value, objectDefID) as OrtesisProsthesisDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OrtesisProsthesisDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrtesisProsthesisDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OrtesisProsthesisDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OrtesisProsthesisDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OrtesisProsthesisDefinitionForm(viewModel, viewModel._OrtesisProsthesisDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OrtesisProsthesisDefinition = new OrtesisProsthesisDefinition(objectContext);
                viewModel.MaterialsGridGridList = new TTObjectClasses.OrtesisProsthesisMaterialGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OrtesisProsthesisDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrtesisProsthesisDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._OrtesisProsthesisDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._OrtesisProsthesisDefinition);
                PreScript_OrtesisProsthesisDefinitionForm(viewModel, viewModel._OrtesisProsthesisDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OrtesisProsthesisDefinitionForm(OrtesisProsthesisDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return OrtesisProsthesisDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel OrtesisProsthesisDefinitionFormInternal(OrtesisProsthesisDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("733a81cf-5923-426d-aa64-080c7270fdfa");
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.MaterialsGridGridList);
        objectContext.AddToRawObjectList(viewModel._OrtesisProsthesisDefinition);
        objectContext.ProcessRawObjects();
        var ortesisProsthesisDefinition = (OrtesisProsthesisDefinition)objectContext.GetLoadedObject(viewModel._OrtesisProsthesisDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(ortesisProsthesisDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrtesisProsthesisDefinition, formDefID);
        if (viewModel.MaterialsGridGridList != null)
        {
            foreach (var item in viewModel.MaterialsGridGridList)
            {
                var materialsImported = (OrtesisProsthesisMaterialGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)materialsImported).IsDeleted)
                    continue;
                materialsImported.OrtesisProsthesisDefinition = ortesisProsthesisDefinition;
            }
        }

        var transDef = ortesisProsthesisDefinition.TransDef;
        PostScript_OrtesisProsthesisDefinitionForm(viewModel, ortesisProsthesisDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(ortesisProsthesisDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(ortesisProsthesisDefinition);
        AfterContextSaveScript_OrtesisProsthesisDefinitionForm(viewModel, ortesisProsthesisDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_OrtesisProsthesisDefinitionForm(OrtesisProsthesisDefinitionFormViewModel viewModel, OrtesisProsthesisDefinition ortesisProsthesisDefinition, TTObjectContext objectContext);
    partial void PostScript_OrtesisProsthesisDefinitionForm(OrtesisProsthesisDefinitionFormViewModel viewModel, OrtesisProsthesisDefinition ortesisProsthesisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OrtesisProsthesisDefinitionForm(OrtesisProsthesisDefinitionFormViewModel viewModel, OrtesisProsthesisDefinition ortesisProsthesisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OrtesisProsthesisDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MaterialsGridGridList = viewModel._OrtesisProsthesisDefinition.Materials.OfType<OrtesisProsthesisMaterialGrid>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class OrtesisProsthesisDefinitionFormViewModel
    {
        public TTObjectClasses.OrtesisProsthesisDefinition _OrtesisProsthesisDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.OrtesisProsthesisMaterialGrid[] MaterialsGridGridList
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
    }
}
