//$8234CA6F
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
    public partial class InpatientPrescriptionServiceController : Controller
{
    [HttpGet]
    public InpatientPrescriptionBaseFormViewModel InpatientPrescriptionBaseForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InpatientPrescriptionBaseFormLoadInternal(input);
    }

    [HttpPost]
    public InpatientPrescriptionBaseFormViewModel InpatientPrescriptionBaseFormLoad(FormLoadInput input)
    {
        return InpatientPrescriptionBaseFormLoadInternal(input);
    }

    private InpatientPrescriptionBaseFormViewModel InpatientPrescriptionBaseFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("386de6ca-3153-43dd-ab1b-a8e5a967dcb8");
        var objectDefID = Guid.Parse("fda28150-7a87-49c7-9acb-b68fe9bd5d20");
        var viewModel = new InpatientPrescriptionBaseFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientPrescription = objectContext.GetObject(id.Value, objectDefID) as InpatientPrescription;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientPrescription, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientPrescription, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InpatientPrescription);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InpatientPrescription);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InpatientPrescriptionBaseForm(viewModel, viewModel._InpatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InpatientPrescriptionBaseForm(InpatientPrescriptionBaseFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("386de6ca-3153-43dd-ab1b-a8e5a967dcb8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._InpatientPrescription);
            objectContext.ProcessRawObjects();
            var inpatientPrescription = (InpatientPrescription)objectContext.GetLoadedObject(viewModel._InpatientPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientPrescription, formDefID);
            var transDef = inpatientPrescription.TransDef;
            PostScript_InpatientPrescriptionBaseForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientPrescription);
            AfterContextSaveScript_InpatientPrescriptionBaseForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InpatientPrescriptionBaseForm(InpatientPrescriptionBaseFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTObjectContext objectContext);
    partial void PostScript_InpatientPrescriptionBaseForm(InpatientPrescriptionBaseFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InpatientPrescriptionBaseForm(InpatientPrescriptionBaseFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InpatientPrescriptionBaseFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class InpatientPrescriptionBaseFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientPrescription _InpatientPrescription { get; set; }
    }
}
