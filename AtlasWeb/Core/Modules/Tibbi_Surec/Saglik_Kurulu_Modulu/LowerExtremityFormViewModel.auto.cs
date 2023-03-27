//$0B385324
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
    public partial class LowerExtremityServiceController : Controller
{
    [HttpGet]
    public LowerExtremityFormViewModel LowerExtremityForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return LowerExtremityFormLoadInternal(input);
    }

    [HttpPost]
    public LowerExtremityFormViewModel LowerExtremityFormLoad(FormLoadInput input)
    {
        return LowerExtremityFormLoadInternal(input);
    }

    private LowerExtremityFormViewModel LowerExtremityFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("bdb90a0c-e8d6-4056-904f-9821f5257c46");
        var objectDefID = Guid.Parse("120db1ea-7158-41bc-809a-e3c780000056");
        var viewModel = new LowerExtremityFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LowerExtremity = objectContext.GetObject(id.Value, objectDefID) as LowerExtremity;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LowerExtremity, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LowerExtremity, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._LowerExtremity);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._LowerExtremity);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_LowerExtremityForm(viewModel, viewModel._LowerExtremity, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LowerExtremity = new LowerExtremity(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LowerExtremity, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LowerExtremity, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._LowerExtremity);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._LowerExtremity);
                PreScript_LowerExtremityForm(viewModel, viewModel._LowerExtremity, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel LowerExtremityForm(LowerExtremityFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return LowerExtremityFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel LowerExtremityFormInternal(LowerExtremityFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("bdb90a0c-e8d6-4056-904f-9821f5257c46");
        objectContext.AddToRawObjectList(viewModel._LowerExtremity);
        objectContext.ProcessRawObjects();
        var lowerExtremity = (LowerExtremity)objectContext.GetLoadedObject(viewModel._LowerExtremity.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(lowerExtremity, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LowerExtremity, formDefID);
        var transDef = lowerExtremity.TransDef;
        PostScript_LowerExtremityForm(viewModel, lowerExtremity, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(lowerExtremity);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(lowerExtremity);
        AfterContextSaveScript_LowerExtremityForm(viewModel, lowerExtremity, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_LowerExtremityForm(LowerExtremityFormViewModel viewModel, LowerExtremity lowerExtremity, TTObjectContext objectContext);
    partial void PostScript_LowerExtremityForm(LowerExtremityFormViewModel viewModel, LowerExtremity lowerExtremity, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_LowerExtremityForm(LowerExtremityFormViewModel viewModel, LowerExtremity lowerExtremity, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(LowerExtremityFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class LowerExtremityFormViewModel
    {
        public TTObjectClasses.LowerExtremity _LowerExtremity
        {
            get;
            set;
        }
    }
}
