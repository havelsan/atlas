//$66EF38F4
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
    public partial class PathologyAdditionalReportServiceController : Controller
{
    [HttpGet]
    public PathologyAdditionalReportFormViewModel PathologyAdditionalReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyAdditionalReportFormLoadInternal(input);
    }

    [HttpPost]
    public PathologyAdditionalReportFormViewModel PathologyAdditionalReportFormLoad(FormLoadInput input)
    {
        return PathologyAdditionalReportFormLoadInternal(input);
    }

    private PathologyAdditionalReportFormViewModel PathologyAdditionalReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7dadf282-7229-4150-be4b-b7fd672ed38d");
        var objectDefID = Guid.Parse("1dd61f2a-7a69-4f8f-9ca9-24db780be41f");
        var viewModel = new PathologyAdditionalReportFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyAdditionalReport = objectContext.GetObject(id.Value, objectDefID) as PathologyAdditionalReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyAdditionalReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyAdditionalReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PathologyAdditionalReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PathologyAdditionalReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PathologyAdditionalReportForm(viewModel, viewModel._PathologyAdditionalReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyAdditionalReport = new PathologyAdditionalReport(objectContext);
                var entryStateID = Guid.Parse("56caa1f9-3539-4bc1-a8f1-7f82c261868c");
                viewModel._PathologyAdditionalReport.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyAdditionalReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyAdditionalReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PathologyAdditionalReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PathologyAdditionalReport);
                PreScript_PathologyAdditionalReportForm(viewModel, viewModel._PathologyAdditionalReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyAdditionalReportForm(PathologyAdditionalReportFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("7dadf282-7229-4150-be4b-b7fd672ed38d");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("56caa1f9-3539-4bc1-a8f1-7f82c261868c");
            objectContext.AddToRawObjectList(viewModel._PathologyAdditionalReport, entryStateID);
            objectContext.ProcessRawObjects(false);
            var pathologyAdditionalReport = (PathologyAdditionalReport)objectContext.GetLoadedObject(viewModel._PathologyAdditionalReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyAdditionalReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyAdditionalReport, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(pathologyAdditionalReport);
            PostScript_PathologyAdditionalReportForm(viewModel, pathologyAdditionalReport, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyAdditionalReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyAdditionalReport);
            AfterContextSaveScript_PathologyAdditionalReportForm(viewModel, pathologyAdditionalReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PathologyAdditionalReportForm(PathologyAdditionalReportFormViewModel viewModel, PathologyAdditionalReport pathologyAdditionalReport, TTObjectContext objectContext);
    partial void PostScript_PathologyAdditionalReportForm(PathologyAdditionalReportFormViewModel viewModel, PathologyAdditionalReport pathologyAdditionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyAdditionalReportForm(PathologyAdditionalReportFormViewModel viewModel, PathologyAdditionalReport pathologyAdditionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyAdditionalReportFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class PathologyAdditionalReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PathologyAdditionalReport _PathologyAdditionalReport { get; set; }
    }
}
