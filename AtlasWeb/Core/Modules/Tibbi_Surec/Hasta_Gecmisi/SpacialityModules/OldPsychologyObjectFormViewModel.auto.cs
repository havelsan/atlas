//$00A7198D
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
    public partial class PsychologyBasedObjectServiceController : Controller
{
    [HttpGet]
    public OldPsychologyObjectFormViewModel OldPsychologyObjectForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldPsychologyObjectFormLoadInternal(input);
    }

    [HttpPost]
    public OldPsychologyObjectFormViewModel OldPsychologyObjectFormLoad(FormLoadInput input)
    {
        return OldPsychologyObjectFormLoadInternal(input);
    }

    private OldPsychologyObjectFormViewModel OldPsychologyObjectFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d3bb5db4-7e6a-4309-8300-e3aca85dc492");
        var objectDefID = Guid.Parse("306a68a6-aa4b-4f51-9f3c-a9b04b793f17");
        var viewModel = new OldPsychologyObjectFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologyBasedObject = objectContext.GetObject(id.Value, objectDefID) as PsychologyBasedObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyBasedObject, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PsychologyBasedObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PsychologyBasedObject);
                PreScript_OldPsychologyObjectForm(viewModel, viewModel._PsychologyBasedObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologyBasedObject = new PsychologyBasedObject(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PsychologyBasedObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PsychologyBasedObject);
                PreScript_OldPsychologyObjectForm(viewModel, viewModel._PsychologyBasedObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldPsychologyObjectForm(OldPsychologyObjectFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("d3bb5db4-7e6a-4309-8300-e3aca85dc492");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._PsychologyBasedObject);
            objectContext.ProcessRawObjects();
            var psychologyBasedObject = (PsychologyBasedObject)objectContext.GetLoadedObject(viewModel._PsychologyBasedObject.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(psychologyBasedObject, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyBasedObject, formDefID);
            var transDef = psychologyBasedObject.TransDef;
            PostScript_OldPsychologyObjectForm(viewModel, psychologyBasedObject, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldPsychologyObjectForm(viewModel, psychologyBasedObject, transDef, objectContext);
        }
    }

    partial void PreScript_OldPsychologyObjectForm(OldPsychologyObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTObjectContext objectContext);
    partial void PostScript_OldPsychologyObjectForm(OldPsychologyObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldPsychologyObjectForm(OldPsychologyObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldPsychologyObjectFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldPsychologyObjectFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PsychologyBasedObject _PsychologyBasedObject
        {
            get;
            set;
        }
    }
}