//$4DFF3992
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
    public InpatientPresEReceteDetailFormViewModel InpatientPresEReceteDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InpatientPresEReceteDetailFormLoadInternal(input);
    }

    [HttpPost]
    public InpatientPresEReceteDetailFormViewModel InpatientPresEReceteDetailFormLoad(FormLoadInput input)
    {
        return InpatientPresEReceteDetailFormLoadInternal(input);
    }

    private InpatientPresEReceteDetailFormViewModel InpatientPresEReceteDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d09ef329-fddb-401f-8344-addc0d0bb803");
        var objectDefID = Guid.Parse("fda28150-7a87-49c7-9acb-b68fe9bd5d20");
        var viewModel = new InpatientPresEReceteDetailFormViewModel();
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
                PreScript_InpatientPresEReceteDetailForm(viewModel, viewModel._InpatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InpatientPresEReceteDetailForm(InpatientPresEReceteDetailFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d09ef329-fddb-401f-8344-addc0d0bb803");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._InpatientPrescription);
            objectContext.ProcessRawObjects();
            var inpatientPrescription = (InpatientPrescription)objectContext.GetLoadedObject(viewModel._InpatientPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientPrescription, formDefID);
            var transDef = inpatientPrescription.TransDef;
            PostScript_InpatientPresEReceteDetailForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientPrescription);
            AfterContextSaveScript_InpatientPresEReceteDetailForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InpatientPresEReceteDetailForm(InpatientPresEReceteDetailFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTObjectContext objectContext);
    partial void PostScript_InpatientPresEReceteDetailForm(InpatientPresEReceteDetailFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InpatientPresEReceteDetailForm(InpatientPresEReceteDetailFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InpatientPresEReceteDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class InpatientPresEReceteDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientPrescription _InpatientPrescription { get; set; }
    }
}
