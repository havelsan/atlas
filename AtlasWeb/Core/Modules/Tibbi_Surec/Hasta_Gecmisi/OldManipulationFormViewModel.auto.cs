//$1B07CD9E
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
    public partial class ManipulationServiceController : Controller
{
    [HttpGet]
    public OldManipulationFormViewModel OldManipulationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldManipulationFormLoadInternal(input);
    }

    [HttpPost]
    public OldManipulationFormViewModel OldManipulationFormLoad(FormLoadInput input)
    {
        return OldManipulationFormLoadInternal(input);
    }

    private OldManipulationFormViewModel OldManipulationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("b53509ce-f1bf-4e8e-9b6e-4c3f66145f32");
        var objectDefID = Guid.Parse("528f1264-6f0b-41ab-b8a3-a8eda6d9134a");
        var viewModel = new OldManipulationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Manipulation = objectContext.GetObject(id.Value, objectDefID) as Manipulation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Manipulation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Manipulation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Manipulation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OldManipulationForm(viewModel, viewModel._Manipulation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldManipulationForm(OldManipulationFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("b53509ce-f1bf-4e8e-9b6e-4c3f66145f32");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._Manipulation);
            objectContext.ProcessRawObjects();
            var manipulation = (Manipulation)objectContext.GetLoadedObject(viewModel._Manipulation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
            var transDef = manipulation.TransDef;
            PostScript_OldManipulationForm(viewModel, manipulation, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldManipulationForm(viewModel, manipulation, transDef, objectContext);
        }
    }

    partial void PreScript_OldManipulationForm(OldManipulationFormViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext);
    partial void PostScript_OldManipulationForm(OldManipulationFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldManipulationForm(OldManipulationFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldManipulationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class OldManipulationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Manipulation _Manipulation { get; set; }
    }
}
