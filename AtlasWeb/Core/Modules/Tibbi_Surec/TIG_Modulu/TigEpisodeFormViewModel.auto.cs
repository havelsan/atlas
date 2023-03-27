//$E972B8D1
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
    public partial class TigEpisodeServiceController : Controller
{
    [HttpGet]
    public TigEpisodeFormViewModel TigEpisodeForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return TigEpisodeFormLoadInternal(input);
    }

    [HttpPost]
    public TigEpisodeFormViewModel TigEpisodeFormLoad(FormLoadInput input)
    {
        return TigEpisodeFormLoadInternal(input);
    }

    private TigEpisodeFormViewModel TigEpisodeFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("345a26ad-5b87-426b-a78c-431059785293");
        var objectDefID = Guid.Parse("f0656fe8-68db-455c-86a4-dbc030c20291");
        var viewModel = new TigEpisodeFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TigEpisode = objectContext.GetObject(id.Value, objectDefID) as TigEpisode;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TigEpisode, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TigEpisode, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._TigEpisode);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._TigEpisode);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_TigEpisodeForm(viewModel, viewModel._TigEpisode, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TigEpisode = new TigEpisode(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TigEpisode, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TigEpisode, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._TigEpisode);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._TigEpisode);
                PreScript_TigEpisodeForm(viewModel, viewModel._TigEpisode, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel TigEpisodeForm(TigEpisodeFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("345a26ad-5b87-426b-a78c-431059785293");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._TigEpisode);
            objectContext.ProcessRawObjects();
            var tigEpisode = (TigEpisode)objectContext.GetLoadedObject(viewModel._TigEpisode.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(tigEpisode, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TigEpisode, formDefID);
            var transDef = tigEpisode.TransDef;
            PostScript_TigEpisodeForm(viewModel, tigEpisode, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(tigEpisode);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(tigEpisode);
            AfterContextSaveScript_TigEpisodeForm(viewModel, tigEpisode, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_TigEpisodeForm(TigEpisodeFormViewModel viewModel, TigEpisode tigEpisode, TTObjectContext objectContext);
    partial void PostScript_TigEpisodeForm(TigEpisodeFormViewModel viewModel, TigEpisode tigEpisode, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_TigEpisodeForm(TigEpisodeFormViewModel viewModel, TigEpisode tigEpisode, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(TigEpisodeFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class TigEpisodeFormViewModel : BaseViewModel
    {
        public TTObjectClasses.TigEpisode _TigEpisode { get; set; }
    }
}
