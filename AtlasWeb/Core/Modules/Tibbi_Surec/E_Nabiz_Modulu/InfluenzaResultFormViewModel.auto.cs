//$7F5C71FD
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
    public partial class InfluenzaResultServiceController : Controller
{
    [HttpGet]
    public InfluenzaResultFormViewModel InfluenzaResultForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InfluenzaResultFormLoadInternal(input);
    }

    [HttpPost]
    public InfluenzaResultFormViewModel InfluenzaResultFormLoad(FormLoadInput input)
    {
        return InfluenzaResultFormLoadInternal(input);
    }

    private InfluenzaResultFormViewModel InfluenzaResultFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("06bc78eb-4fd9-4287-8886-df17e81a4818");
        var objectDefID = Guid.Parse("c6719b38-23e7-4dcd-98e1-c4f2068a6a2a");
        var viewModel = new InfluenzaResultFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InfluenzaResult = objectContext.GetObject(id.Value, objectDefID) as InfluenzaResult;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InfluenzaResult, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfluenzaResult, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InfluenzaResult);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InfluenzaResult);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InfluenzaResultForm(viewModel, viewModel._InfluenzaResult, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InfluenzaResult = new InfluenzaResult(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InfluenzaResult, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfluenzaResult, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InfluenzaResult);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InfluenzaResult);
                PreScript_InfluenzaResultForm(viewModel, viewModel._InfluenzaResult, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InfluenzaResultForm(InfluenzaResultFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return InfluenzaResultFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel InfluenzaResultFormInternal(InfluenzaResultFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("06bc78eb-4fd9-4287-8886-df17e81a4818");
        objectContext.AddToRawObjectList(viewModel._InfluenzaResult);
        objectContext.ProcessRawObjects();
        var influenzaResult = (InfluenzaResult)objectContext.GetLoadedObject(viewModel._InfluenzaResult.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(influenzaResult, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfluenzaResult, formDefID);
        var transDef = influenzaResult.TransDef;
        PostScript_InfluenzaResultForm(viewModel, influenzaResult, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(influenzaResult);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(influenzaResult);
        AfterContextSaveScript_InfluenzaResultForm(viewModel, influenzaResult, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_InfluenzaResultForm(InfluenzaResultFormViewModel viewModel, InfluenzaResult influenzaResult, TTObjectContext objectContext);
    partial void PostScript_InfluenzaResultForm(InfluenzaResultFormViewModel viewModel, InfluenzaResult influenzaResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InfluenzaResultForm(InfluenzaResultFormViewModel viewModel, InfluenzaResult influenzaResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InfluenzaResultFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class InfluenzaResultFormViewModel
    {
        public TTObjectClasses.InfluenzaResult _InfluenzaResult
        {
            get;
            set;
        }
    }
}
