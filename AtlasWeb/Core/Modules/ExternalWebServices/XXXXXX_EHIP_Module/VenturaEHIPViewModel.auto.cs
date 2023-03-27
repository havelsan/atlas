//$67FAA983
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
    public partial class XXXXXXEHIPServiceController : Controller
{
    [HttpGet]
    public XXXXXXEHIPViewModel XXXXXXEHIP(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return XXXXXXEHIPLoadInternal(input);
    }

    [HttpPost]
    public XXXXXXEHIPViewModel XXXXXXEHIPLoad(FormLoadInput input)
    {
        return XXXXXXEHIPLoadInternal(input);
    }

    private XXXXXXEHIPViewModel XXXXXXEHIPLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("0b7e49f2-ef9a-431a-bbde-5bb25a1f3884");
        var objectDefID = Guid.Parse("31ac4645-14fa-4976-99cf-b79dbcf23685");
        var viewModel = new XXXXXXEHIPViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._XXXXXXEHIP = objectContext.GetObject(id.Value, objectDefID) as XXXXXXEHIP;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._XXXXXXEHIP, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._XXXXXXEHIP, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._XXXXXXEHIP);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._XXXXXXEHIP);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_XXXXXXEHIP(viewModel, viewModel._XXXXXXEHIP, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._XXXXXXEHIP = new XXXXXXEHIP(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._XXXXXXEHIP, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._XXXXXXEHIP, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._XXXXXXEHIP);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._XXXXXXEHIP);
                PreScript_XXXXXXEHIP(viewModel, viewModel._XXXXXXEHIP, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel XXXXXXEHIP(XXXXXXEHIPViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("0b7e49f2-ef9a-431a-bbde-5bb25a1f3884");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._XXXXXXEHIP);
            objectContext.ProcessRawObjects();
            var XXXXXXEHIP = (XXXXXXEHIP)objectContext.GetLoadedObject(viewModel._XXXXXXEHIP.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(XXXXXXEHIP, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._XXXXXXEHIP, formDefID);
            var transDef = XXXXXXEHIP.TransDef;
            PostScript_XXXXXXEHIP(viewModel, XXXXXXEHIP, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(XXXXXXEHIP);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(XXXXXXEHIP);
            AfterContextSaveScript_XXXXXXEHIP(viewModel, XXXXXXEHIP, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_XXXXXXEHIP(XXXXXXEHIPViewModel viewModel, XXXXXXEHIP XXXXXXEHIP, TTObjectContext objectContext);
    partial void PostScript_XXXXXXEHIP(XXXXXXEHIPViewModel viewModel, XXXXXXEHIP XXXXXXEHIP, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_XXXXXXEHIP(XXXXXXEHIPViewModel viewModel, XXXXXXEHIP XXXXXXEHIP, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(XXXXXXEHIPViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class XXXXXXEHIPViewModel : BaseViewModel
    {
        public TTObjectClasses.XXXXXXEHIP _XXXXXXEHIP { get; set; }
    }
}
