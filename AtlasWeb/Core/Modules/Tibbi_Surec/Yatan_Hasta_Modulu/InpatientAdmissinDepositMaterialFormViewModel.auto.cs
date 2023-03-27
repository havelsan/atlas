//$C9F485A3
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
    public partial class InpatientAdmissionDepositMaterialServiceController : Controller
{
    [HttpGet]
    public InpatientAdmissinDepositMaterialFormViewModel InpatientAdmissinDepositMaterialForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InpatientAdmissinDepositMaterialFormLoadInternal(input);
    }

    [HttpPost]
    public InpatientAdmissinDepositMaterialFormViewModel InpatientAdmissinDepositMaterialFormLoad(FormLoadInput input)
    {
        return InpatientAdmissinDepositMaterialFormLoadInternal(input);
    }

    private InpatientAdmissinDepositMaterialFormViewModel InpatientAdmissinDepositMaterialFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("17da44c9-fc3f-4ee0-a6e1-808e8c74a162");
        var objectDefID = Guid.Parse("a85e7f73-bf5a-4d84-a5d8-82e5d035908a");
        var viewModel = new InpatientAdmissinDepositMaterialFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientAdmissionDepositMaterial = objectContext.GetObject(id.Value, objectDefID) as InpatientAdmissionDepositMaterial;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientAdmissionDepositMaterial, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmissionDepositMaterial, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InpatientAdmissionDepositMaterial);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InpatientAdmissionDepositMaterial);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InpatientAdmissinDepositMaterialForm(viewModel, viewModel._InpatientAdmissionDepositMaterial, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientAdmissionDepositMaterial = new InpatientAdmissionDepositMaterial(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientAdmissionDepositMaterial, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmissionDepositMaterial, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InpatientAdmissionDepositMaterial);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InpatientAdmissionDepositMaterial);
                PreScript_InpatientAdmissinDepositMaterialForm(viewModel, viewModel._InpatientAdmissionDepositMaterial, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InpatientAdmissinDepositMaterialForm(InpatientAdmissinDepositMaterialFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("17da44c9-fc3f-4ee0-a6e1-808e8c74a162");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._InpatientAdmissionDepositMaterial);
            objectContext.ProcessRawObjects();
            var inpatientAdmissionDepositMaterial = (InpatientAdmissionDepositMaterial)objectContext.GetLoadedObject(viewModel._InpatientAdmissionDepositMaterial.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientAdmissionDepositMaterial, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmissionDepositMaterial, formDefID);
            var transDef = inpatientAdmissionDepositMaterial.TransDef;
            PostScript_InpatientAdmissinDepositMaterialForm(viewModel, inpatientAdmissionDepositMaterial, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientAdmissionDepositMaterial);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientAdmissionDepositMaterial);
            AfterContextSaveScript_InpatientAdmissinDepositMaterialForm(viewModel, inpatientAdmissionDepositMaterial, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InpatientAdmissinDepositMaterialForm(InpatientAdmissinDepositMaterialFormViewModel viewModel, InpatientAdmissionDepositMaterial inpatientAdmissionDepositMaterial, TTObjectContext objectContext);
    partial void PostScript_InpatientAdmissinDepositMaterialForm(InpatientAdmissinDepositMaterialFormViewModel viewModel, InpatientAdmissionDepositMaterial inpatientAdmissionDepositMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InpatientAdmissinDepositMaterialForm(InpatientAdmissinDepositMaterialFormViewModel viewModel, InpatientAdmissionDepositMaterial inpatientAdmissionDepositMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InpatientAdmissinDepositMaterialFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class InpatientAdmissinDepositMaterialFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientAdmissionDepositMaterial _InpatientAdmissionDepositMaterial { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
