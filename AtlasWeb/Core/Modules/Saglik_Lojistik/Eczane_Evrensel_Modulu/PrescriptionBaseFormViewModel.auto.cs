//$8EB77D40
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
    public partial class PrescriptionServiceController : Controller
{
    [HttpGet]
    public PrescriptionBaseFormViewModel PrescriptionBaseForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PrescriptionBaseFormLoadInternal(input);
    }

    [HttpPost]
    public PrescriptionBaseFormViewModel PrescriptionBaseFormLoad(FormLoadInput input)
    {
        return PrescriptionBaseFormLoadInternal(input);
    }

    private PrescriptionBaseFormViewModel PrescriptionBaseFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4c215821-af09-4ab5-a656-45a0cd6a282e");
        var objectDefID = Guid.Parse("835cf537-d43e-4f8b-a58d-977cf9ad81ed");
        var viewModel = new PrescriptionBaseFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Prescription = objectContext.GetObject(id.Value, objectDefID) as Prescription;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Prescription, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Prescription, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Prescription);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Prescription);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PrescriptionBaseForm(viewModel, viewModel._Prescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PrescriptionBaseForm(PrescriptionBaseFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4c215821-af09-4ab5-a656-45a0cd6a282e");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._Prescription);
            objectContext.ProcessRawObjects();
            var prescription = (Prescription)objectContext.GetLoadedObject(viewModel._Prescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(prescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Prescription, formDefID);
            var transDef = prescription.TransDef;
            PostScript_PrescriptionBaseForm(viewModel, prescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(prescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(prescription);
            AfterContextSaveScript_PrescriptionBaseForm(viewModel, prescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PrescriptionBaseForm(PrescriptionBaseFormViewModel viewModel, Prescription prescription, TTObjectContext objectContext);
    partial void PostScript_PrescriptionBaseForm(PrescriptionBaseFormViewModel viewModel, Prescription prescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PrescriptionBaseForm(PrescriptionBaseFormViewModel viewModel, Prescription prescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PrescriptionBaseFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class PrescriptionBaseFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Prescription _Prescription { get; set; }
    }
}
