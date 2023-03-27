//$7BA294C2
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
    public partial class EmergencySpecialityObjectServiceController : Controller
{
    [HttpGet]
    public OldEmergencyFormViewModel OldEmergencyForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldEmergencyFormLoadInternal(input);
    }

    [HttpPost]
    public OldEmergencyFormViewModel OldEmergencyFormLoad(FormLoadInput input)
    {
        return OldEmergencyFormLoadInternal(input);
    }

    private OldEmergencyFormViewModel OldEmergencyFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a2c2d82a-d7cf-4334-9fb8-f079966ffdef");
        var objectDefID = Guid.Parse("17dc5dfb-6d41-419b-ac33-c90757bd68d4");
        var viewModel = new OldEmergencyFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EmergencySpecialityObject = objectContext.GetObject(id.Value, objectDefID) as EmergencySpecialityObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EmergencySpecialityObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EmergencySpecialityObject, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EmergencySpecialityObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EmergencySpecialityObject);
                PreScript_OldEmergencyForm(viewModel, viewModel._EmergencySpecialityObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EmergencySpecialityObject = new EmergencySpecialityObject(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EmergencySpecialityObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EmergencySpecialityObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EmergencySpecialityObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EmergencySpecialityObject);
                PreScript_OldEmergencyForm(viewModel, viewModel._EmergencySpecialityObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldEmergencyForm(OldEmergencyFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("a2c2d82a-d7cf-4334-9fb8-f079966ffdef");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._EmergencySpecialityObject);
            objectContext.ProcessRawObjects();
            var emergencySpecialityObject = (EmergencySpecialityObject)objectContext.GetLoadedObject(viewModel._EmergencySpecialityObject.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(emergencySpecialityObject, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EmergencySpecialityObject, formDefID);
            var transDef = emergencySpecialityObject.TransDef;
            PostScript_OldEmergencyForm(viewModel, emergencySpecialityObject, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldEmergencyForm(viewModel, emergencySpecialityObject, transDef, objectContext);
        }
    }

    partial void PreScript_OldEmergencyForm(OldEmergencyFormViewModel viewModel, EmergencySpecialityObject emergencySpecialityObject, TTObjectContext objectContext);
    partial void PostScript_OldEmergencyForm(OldEmergencyFormViewModel viewModel, EmergencySpecialityObject emergencySpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldEmergencyForm(OldEmergencyFormViewModel viewModel, EmergencySpecialityObject emergencySpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldEmergencyFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldEmergencyFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EmergencySpecialityObject _EmergencySpecialityObject
        {
            get;
            set;
        }
    }
}