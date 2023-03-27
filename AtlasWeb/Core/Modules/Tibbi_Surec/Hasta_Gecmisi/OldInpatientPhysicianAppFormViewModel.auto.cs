//$4483A2F7
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class InPatientPhysicianApplicationServiceController : Controller
{
    [HttpGet]
    public OldInpatientPhysicianAppFormViewModel OldInpatientPhysicianAppForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldInpatientPhysicianAppFormLoadInternal(input);
    }

    [HttpPost]
    public OldInpatientPhysicianAppFormViewModel OldInpatientPhysicianAppFormLoad(FormLoadInput input)
    {
        return OldInpatientPhysicianAppFormLoadInternal(input);
    }

    private OldInpatientPhysicianAppFormViewModel OldInpatientPhysicianAppFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5d728780-b710-460b-917a-f158f5c37d01");
        var objectDefID = Guid.Parse("92accee7-68ce-44a6-8e02-8747e426104b");
        var viewModel = new OldInpatientPhysicianAppFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InPatientPhysicianApplication = objectContext.GetObject(id.Value, objectDefID) as InPatientPhysicianApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InPatientPhysicianApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InPatientPhysicianApplication);
                PreScript_OldInpatientPhysicianAppForm(viewModel, viewModel._InPatientPhysicianApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldInpatientPhysicianAppForm(OldInpatientPhysicianAppFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("5d728780-b710-460b-917a-f158f5c37d01");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._InPatientPhysicianApplication);
            objectContext.ProcessRawObjects();
            var inPatientPhysicianApplication = (InPatientPhysicianApplication)objectContext.GetLoadedObject(viewModel._InPatientPhysicianApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inPatientPhysicianApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientPhysicianApplication, formDefID);
            var transDef = inPatientPhysicianApplication.TransDef;
            PostScript_OldInpatientPhysicianAppForm(viewModel, inPatientPhysicianApplication, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldInpatientPhysicianAppForm(viewModel, inPatientPhysicianApplication, transDef, objectContext);
        }
    }

    partial void PreScript_OldInpatientPhysicianAppForm(OldInpatientPhysicianAppFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTObjectContext objectContext);
    partial void PostScript_OldInpatientPhysicianAppForm(OldInpatientPhysicianAppFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldInpatientPhysicianAppForm(OldInpatientPhysicianAppFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldInpatientPhysicianAppFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldInpatientPhysicianAppFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InPatientPhysicianApplication _InPatientPhysicianApplication
        {
            get;
            set;
        }
    }
}