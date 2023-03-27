//$B12C44F4
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
    public partial class GlassesReportServiceController : Controller
{
    [HttpGet]
    public GlassesReportFormViewModel GlassesReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return GlassesReportFormLoadInternal(input);
    }

    [HttpPost]
    public GlassesReportFormViewModel GlassesReportFormLoad(FormLoadInput input)
    {
        return GlassesReportFormLoadInternal(input);
    }

    private GlassesReportFormViewModel GlassesReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("113b0230-177c-4342-88da-562ed9ccc224");
        var objectDefID = Guid.Parse("306dde5c-6bee-416a-8d8f-1de11c1e0bd7");
        var viewModel = new GlassesReportFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GlassesReport = objectContext.GetObject(id.Value, objectDefID) as GlassesReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GlassesReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GlassesReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GlassesReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GlassesReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_GlassesReportForm(viewModel, viewModel._GlassesReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GlassesReport = new GlassesReport(objectContext);
                var entryStateID = Guid.Parse("1565624c-b35c-46df-8b52-bf8a6c95c525");
                viewModel._GlassesReport.CurrentStateDefID = entryStateID;
                viewModel.SecDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.DiagnosisDiagnosisGridGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GlassesReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GlassesReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._GlassesReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._GlassesReport);
                PreScript_GlassesReportForm(viewModel, viewModel._GlassesReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel GlassesReportForm(GlassesReportFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("113b0230-177c-4342-88da-562ed9ccc224");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.SecDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDiagnosisGridGridList);
            var entryStateID = Guid.Parse("1565624c-b35c-46df-8b52-bf8a6c95c525");
            objectContext.AddToRawObjectList(viewModel._GlassesReport, entryStateID);
            objectContext.ProcessRawObjects(false);
            var glassesReport = (GlassesReport)objectContext.GetLoadedObject(viewModel._GlassesReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(glassesReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GlassesReport, formDefID);
            if (viewModel.SecDiagnosisGridList != null)
            {
                foreach (var item in viewModel.SecDiagnosisGridList)
                {
                    var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.EpisodeAction = glassesReport;
                }
            }

            var episodeImported = glassesReport.Episode;
            if (episodeImported != null)
            {
                if (viewModel.DiagnosisDiagnosisGridGridList != null)
                {
                    foreach (var item in viewModel.DiagnosisDiagnosisGridGridList)
                    {
                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episodeImported;
                    }
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(glassesReport);
            PostScript_GlassesReportForm(viewModel, glassesReport, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(glassesReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(glassesReport);
            AfterContextSaveScript_GlassesReportForm(viewModel, glassesReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_GlassesReportForm(GlassesReportFormViewModel viewModel, GlassesReport glassesReport, TTObjectContext objectContext);
    partial void PostScript_GlassesReportForm(GlassesReportFormViewModel viewModel, GlassesReport glassesReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_GlassesReportForm(GlassesReportFormViewModel viewModel, GlassesReport glassesReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(GlassesReportFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SecDiagnosisGridList = viewModel._GlassesReport.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        var episode = viewModel._GlassesReport.Episode;
        if (episode != null)
        {
            viewModel.DiagnosisDiagnosisGridGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class GlassesReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.GlassesReport _GlassesReport { get; set; }
        public TTObjectClasses.DiagnosisGrid[] SecDiagnosisGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] DiagnosisDiagnosisGridGridList { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
    }
}
