//$22F6D79A
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
    public partial class SapsScoreServiceController : Controller
{
    [HttpGet]
    public SapScoreFormViewModel SapScoreForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SapScoreFormLoadInternal(input);
    }

    [HttpPost]
    public SapScoreFormViewModel SapScoreFormLoad(FormLoadInput input)
    {
        return SapScoreFormLoadInternal(input);
    }

    private SapScoreFormViewModel SapScoreFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9115e74d-505d-4470-9638-a9d88439692a");
        var objectDefID = Guid.Parse("9dabc5da-74f6-4cb9-a83e-8d0cad68b2b9");
        var viewModel = new SapScoreFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SapsScore = objectContext.GetObject(id.Value, objectDefID) as SapsScore;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SapsScore, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SapsScore, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SapsScore);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SapsScore);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SapScoreForm(viewModel, viewModel._SapsScore, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SapsScore = new SapsScore(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SapsScore, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SapsScore, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SapsScore);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SapsScore);
                PreScript_SapScoreForm(viewModel, viewModel._SapsScore, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SapScoreForm(SapScoreFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return SapScoreFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel SapScoreFormInternal(SapScoreFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9115e74d-505d-4470-9638-a9d88439692a");
        objectContext.AddToRawObjectList(viewModel._SapsScore);
        objectContext.ProcessRawObjects();
        var sapsScore = (SapsScore)objectContext.GetLoadedObject(viewModel._SapsScore.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(sapsScore, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SapsScore, formDefID);
        var transDef = sapsScore.TransDef;
        PostScript_SapScoreForm(viewModel, sapsScore, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(sapsScore);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(sapsScore);
        AfterContextSaveScript_SapScoreForm(viewModel, sapsScore, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_SapScoreForm(SapScoreFormViewModel viewModel, SapsScore sapsScore, TTObjectContext objectContext);
    partial void PostScript_SapScoreForm(SapScoreFormViewModel viewModel, SapsScore sapsScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SapScoreForm(SapScoreFormViewModel viewModel, SapsScore sapsScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SapScoreFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class SapScoreFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SapsScore _SapsScore
        {
            get;
            set;
        }
    }
}
