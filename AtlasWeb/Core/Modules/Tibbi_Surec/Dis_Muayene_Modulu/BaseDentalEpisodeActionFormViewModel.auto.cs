//$881D727E
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
    public partial class BaseDentalEpisodeActionServiceController : Controller
{
    [HttpGet]
    public BaseDentalEpisodeActionFormViewModel BaseDentalEpisodeActionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseDentalEpisodeActionFormLoadInternal(input);
    }

    [HttpPost]
    public BaseDentalEpisodeActionFormViewModel BaseDentalEpisodeActionFormLoad(FormLoadInput input)
    {
        return BaseDentalEpisodeActionFormLoadInternal(input);
    }

    private BaseDentalEpisodeActionFormViewModel BaseDentalEpisodeActionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1cb2224b-5b54-4149-91c0-7b728204c000");
        var objectDefID = Guid.Parse("63527a94-5a23-47c5-8428-3901eafeca37");
        var viewModel = new BaseDentalEpisodeActionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseDentalEpisodeAction = objectContext.GetObject(id.Value, objectDefID) as BaseDentalEpisodeAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseDentalEpisodeAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseDentalEpisodeAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseDentalEpisodeAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseDentalEpisodeAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseDentalEpisodeActionForm(viewModel, viewModel._BaseDentalEpisodeAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseDentalEpisodeAction = new BaseDentalEpisodeAction(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseDentalEpisodeAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseDentalEpisodeAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseDentalEpisodeAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseDentalEpisodeAction);
                PreScript_BaseDentalEpisodeActionForm(viewModel, viewModel._BaseDentalEpisodeAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseDentalEpisodeActionForm(BaseDentalEpisodeActionFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1cb2224b-5b54-4149-91c0-7b728204c000");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._BaseDentalEpisodeAction);
            objectContext.ProcessRawObjects();
            var baseDentalEpisodeAction = (BaseDentalEpisodeAction)objectContext.GetLoadedObject(viewModel._BaseDentalEpisodeAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseDentalEpisodeAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseDentalEpisodeAction, formDefID);
            var transDef = baseDentalEpisodeAction.TransDef;
            PostScript_BaseDentalEpisodeActionForm(viewModel, baseDentalEpisodeAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseDentalEpisodeAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseDentalEpisodeAction);
            AfterContextSaveScript_BaseDentalEpisodeActionForm(viewModel, baseDentalEpisodeAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseDentalEpisodeActionForm(BaseDentalEpisodeActionFormViewModel viewModel, BaseDentalEpisodeAction baseDentalEpisodeAction, TTObjectContext objectContext);
    partial void PostScript_BaseDentalEpisodeActionForm(BaseDentalEpisodeActionFormViewModel viewModel, BaseDentalEpisodeAction baseDentalEpisodeAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseDentalEpisodeActionForm(BaseDentalEpisodeActionFormViewModel viewModel, BaseDentalEpisodeAction baseDentalEpisodeAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseDentalEpisodeActionFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BaseDentalEpisodeActionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseDentalEpisodeAction _BaseDentalEpisodeAction { get; set; }
    }
}
