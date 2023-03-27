//$5F7A6534
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
    public partial class OutPatientPrescriptionServiceController : Controller
{
    [HttpGet]
    public OutPatientPresDetailFormViewModel OutPatientPresDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OutPatientPresDetailFormLoadInternal(input);
    }

    [HttpPost]
    public OutPatientPresDetailFormViewModel OutPatientPresDetailFormLoad(FormLoadInput input)
    {
        return OutPatientPresDetailFormLoadInternal(input);
    }

    private OutPatientPresDetailFormViewModel OutPatientPresDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("0574569b-925a-440a-ad3d-5d2f5f888538");
        var objectDefID = Guid.Parse("39dc2f2a-2723-4522-9e3f-92c010b1e72b");
        var viewModel = new OutPatientPresDetailFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OutPatientPrescription = objectContext.GetObject(id.Value, objectDefID) as OutPatientPrescription;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OutPatientPrescription, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OutPatientPrescription, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OutPatientPrescription);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OutPatientPrescription);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OutPatientPresDetailForm(viewModel, viewModel._OutPatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OutPatientPresDetailForm(OutPatientPresDetailFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("0574569b-925a-440a-ad3d-5d2f5f888538");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._OutPatientPrescription);
            objectContext.ProcessRawObjects();
            var outPatientPrescription = (OutPatientPrescription)objectContext.GetLoadedObject(viewModel._OutPatientPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(outPatientPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OutPatientPrescription, formDefID);
            var transDef = outPatientPrescription.TransDef;
            PostScript_OutPatientPresDetailForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(outPatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(outPatientPrescription);
            AfterContextSaveScript_OutPatientPresDetailForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OutPatientPresDetailForm(OutPatientPresDetailFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTObjectContext objectContext);
    partial void PostScript_OutPatientPresDetailForm(OutPatientPresDetailFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OutPatientPresDetailForm(OutPatientPresDetailFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OutPatientPresDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class OutPatientPresDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OutPatientPrescription _OutPatientPrescription { get; set; }
    }
}
