//$3076C446
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
    public partial class StatusNotificationReportServiceController : Controller
{
    [HttpGet]
    public StatusNotificationReportFormViewModel StatusNotificationReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return StatusNotificationReportFormLoadInternal(input);
    }

    [HttpPost]
    public StatusNotificationReportFormViewModel StatusNotificationReportFormLoad(FormLoadInput input)
    {
        return StatusNotificationReportFormLoadInternal(input);
    }

    private StatusNotificationReportFormViewModel StatusNotificationReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1a563a40-3951-4d92-9e68-df9b976edc99");
        var objectDefID = Guid.Parse("1ddbfd97-104e-4845-8e1e-d3cb8ed45adb");
        var viewModel = new StatusNotificationReportFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._StatusNotificationReport = objectContext.GetObject(id.Value, objectDefID) as StatusNotificationReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._StatusNotificationReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StatusNotificationReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._StatusNotificationReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._StatusNotificationReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_StatusNotificationReportForm(viewModel, viewModel._StatusNotificationReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._StatusNotificationReport = new StatusNotificationReport(objectContext);
                var entryStateID = Guid.Parse("46146d21-c76a-44b0-bbcf-b6e9986286cc");
                viewModel._StatusNotificationReport.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._StatusNotificationReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StatusNotificationReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._StatusNotificationReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._StatusNotificationReport);
                PreScript_StatusNotificationReportForm(viewModel, viewModel._StatusNotificationReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel StatusNotificationReportForm(StatusNotificationReportFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1a563a40-3951-4d92-9e68-df9b976edc99");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.HCRequestReasons);
            objectContext.AddToRawObjectList(viewModel.ReasonForExaminationDefinitions);
            var entryStateID = Guid.Parse("46146d21-c76a-44b0-bbcf-b6e9986286cc");
            objectContext.AddToRawObjectList(viewModel._StatusNotificationReport, entryStateID);
            objectContext.ProcessRawObjects(false);
            var statusNotificationReport = (StatusNotificationReport)objectContext.GetLoadedObject(viewModel._StatusNotificationReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(statusNotificationReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StatusNotificationReport, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(statusNotificationReport);
            PostScript_StatusNotificationReportForm(viewModel, statusNotificationReport, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(statusNotificationReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(statusNotificationReport);
            AfterContextSaveScript_StatusNotificationReportForm(viewModel, statusNotificationReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_StatusNotificationReportForm(StatusNotificationReportFormViewModel viewModel, StatusNotificationReport statusNotificationReport, TTObjectContext objectContext);
    partial void PostScript_StatusNotificationReportForm(StatusNotificationReportFormViewModel viewModel, StatusNotificationReport statusNotificationReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_StatusNotificationReportForm(StatusNotificationReportFormViewModel viewModel, StatusNotificationReport statusNotificationReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(StatusNotificationReportFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.HCRequestReasons = objectContext.LocalQuery<HCRequestReason>().ToArray();
        viewModel.ReasonForExaminationDefinitions = objectContext.LocalQuery<ReasonForExaminationDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "HealthCommitteeExaminationReasonListDefinition", viewModel.ReasonForExaminationDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class StatusNotificationReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.StatusNotificationReport _StatusNotificationReport { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.HCRequestReason[] HCRequestReasons { get; set; }
        public TTObjectClasses.ReasonForExaminationDefinition[] ReasonForExaminationDefinitions { get; set; }
    }
}
