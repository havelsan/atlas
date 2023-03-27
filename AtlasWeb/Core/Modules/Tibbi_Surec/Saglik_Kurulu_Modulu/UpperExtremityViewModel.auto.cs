//$81800C01
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
    public partial class UpperExtremityServiceController : Controller
{
    [HttpGet]
    public UpperExtremityViewModel UpperExtremity(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return UpperExtremityLoadInternal(input);
    }

    [HttpPost]
    public UpperExtremityViewModel UpperExtremityLoad(FormLoadInput input)
    {
        return UpperExtremityLoadInternal(input);
    }

    private UpperExtremityViewModel UpperExtremityLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("948287d1-544f-4015-a09d-2f12bfa083dc");
        var objectDefID = Guid.Parse("474b455a-eca8-464a-9cdf-b33e3afdd273");
        var viewModel = new UpperExtremityViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._UpperExtremity = objectContext.GetObject(id.Value, objectDefID) as UpperExtremity;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._UpperExtremity, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._UpperExtremity, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._UpperExtremity);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._UpperExtremity);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_UpperExtremity(viewModel, viewModel._UpperExtremity, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._UpperExtremity = new UpperExtremity(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._UpperExtremity, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._UpperExtremity, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._UpperExtremity);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._UpperExtremity);
                PreScript_UpperExtremity(viewModel, viewModel._UpperExtremity, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel UpperExtremity(UpperExtremityViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return UpperExtremityInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel UpperExtremityInternal(UpperExtremityViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("948287d1-544f-4015-a09d-2f12bfa083dc");
        objectContext.AddToRawObjectList(viewModel._UpperExtremity);
        objectContext.ProcessRawObjects();
        var upperExtremity = (UpperExtremity)objectContext.GetLoadedObject(viewModel._UpperExtremity.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(upperExtremity, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._UpperExtremity, formDefID);
        var transDef = upperExtremity.TransDef;
        PostScript_UpperExtremity(viewModel, upperExtremity, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(upperExtremity);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(upperExtremity);
        AfterContextSaveScript_UpperExtremity(viewModel, upperExtremity, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_UpperExtremity(UpperExtremityViewModel viewModel, UpperExtremity upperExtremity, TTObjectContext objectContext);
    partial void PostScript_UpperExtremity(UpperExtremityViewModel viewModel, UpperExtremity upperExtremity, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_UpperExtremity(UpperExtremityViewModel viewModel, UpperExtremity upperExtremity, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(UpperExtremityViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class UpperExtremityViewModel
    {
        public TTObjectClasses.UpperExtremity _UpperExtremity
        {
            get;
            set;
        }
    }
}
