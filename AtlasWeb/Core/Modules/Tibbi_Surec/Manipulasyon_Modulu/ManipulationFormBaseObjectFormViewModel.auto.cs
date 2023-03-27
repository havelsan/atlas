//$780485F5
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
    public partial class ManipulationFormBaseObjectServiceController : Controller
{
    [HttpGet]
    public ManipulationFormBaseObjectFormViewModel ManipulationFormBaseObjectForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ManipulationFormBaseObjectFormLoadInternal(input);
    }

    [HttpPost]
    public ManipulationFormBaseObjectFormViewModel ManipulationFormBaseObjectFormLoad(FormLoadInput input)
    {
        return ManipulationFormBaseObjectFormLoadInternal(input);
    }

    private ManipulationFormBaseObjectFormViewModel ManipulationFormBaseObjectFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("67e3776e-f3b1-4313-a2ae-62b7bc8b3488");
        var objectDefID = Guid.Parse("0c7cbcbd-736c-4c5f-96f8-2246d0be21f6");
        var viewModel = new ManipulationFormBaseObjectFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManipulationFormBaseObject = objectContext.GetObject(id.Value, objectDefID) as ManipulationFormBaseObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManipulationFormBaseObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationFormBaseObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ManipulationFormBaseObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ManipulationFormBaseObject);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ManipulationFormBaseObjectForm(viewModel, viewModel._ManipulationFormBaseObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManipulationFormBaseObject = new ManipulationFormBaseObject(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManipulationFormBaseObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationFormBaseObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ManipulationFormBaseObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ManipulationFormBaseObject);
                PreScript_ManipulationFormBaseObjectForm(viewModel, viewModel._ManipulationFormBaseObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ManipulationFormBaseObjectForm(ManipulationFormBaseObjectFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ManipulationFormBaseObjectFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ManipulationFormBaseObjectFormInternal(ManipulationFormBaseObjectFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("67e3776e-f3b1-4313-a2ae-62b7bc8b3488");
        objectContext.AddToRawObjectList(viewModel._ManipulationFormBaseObject);
        objectContext.ProcessRawObjects();
        var manipulationFormBaseObject = (ManipulationFormBaseObject)objectContext.GetLoadedObject(viewModel._ManipulationFormBaseObject.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulationFormBaseObject, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationFormBaseObject, formDefID);
        var transDef = manipulationFormBaseObject.TransDef;
        PostScript_ManipulationFormBaseObjectForm(viewModel, manipulationFormBaseObject, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manipulationFormBaseObject);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manipulationFormBaseObject);
        AfterContextSaveScript_ManipulationFormBaseObjectForm(viewModel, manipulationFormBaseObject, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ManipulationFormBaseObjectForm(ManipulationFormBaseObjectFormViewModel viewModel, ManipulationFormBaseObject manipulationFormBaseObject, TTObjectContext objectContext);
    partial void PostScript_ManipulationFormBaseObjectForm(ManipulationFormBaseObjectFormViewModel viewModel, ManipulationFormBaseObject manipulationFormBaseObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ManipulationFormBaseObjectForm(ManipulationFormBaseObjectFormViewModel viewModel, ManipulationFormBaseObject manipulationFormBaseObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ManipulationFormBaseObjectFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class ManipulationFormBaseObjectFormViewModel
    {
        public TTObjectClasses.ManipulationFormBaseObject _ManipulationFormBaseObject
        {
            get;
            set;
        }
    }
}
