//$993F3F21
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
    public partial class ForensicMedicalReportServiceController : Controller
{
    [HttpGet]
    public ForensicMedicalReportFormViewModel ForensicMedicalReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ForensicMedicalReportFormLoadInternal(input);
    }

    [HttpPost]
    public ForensicMedicalReportFormViewModel ForensicMedicalReportFormLoad(FormLoadInput input)
    {
        return ForensicMedicalReportFormLoadInternal(input);
    }

    private ForensicMedicalReportFormViewModel ForensicMedicalReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4ffe469c-1d6f-4618-a6b4-d614f87fa3c2");
        var objectDefID = Guid.Parse("d923530b-11fb-4fce-9302-fdbd55a45eed");
        var viewModel = new ForensicMedicalReportFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ForensicMedicalReport = objectContext.GetObject(id.Value, objectDefID) as ForensicMedicalReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ForensicMedicalReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ForensicMedicalReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ForensicMedicalReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ForensicMedicalReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ForensicMedicalReportForm(viewModel, viewModel._ForensicMedicalReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ForensicMedicalReport = new ForensicMedicalReport(objectContext);
                var entryStateID = Guid.Parse("c9f3be98-f21a-4989-a25c-c0058f898dcd");
                viewModel._ForensicMedicalReport.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ForensicMedicalReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ForensicMedicalReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ForensicMedicalReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ForensicMedicalReport);
                PreScript_ForensicMedicalReportForm(viewModel, viewModel._ForensicMedicalReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ForensicMedicalReportForm(ForensicMedicalReportFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ForensicMedicalReportFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ForensicMedicalReportFormInternal(ForensicMedicalReportFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4ffe469c-1d6f-4618-a6b4-d614f87fa3c2");
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.MilitaryUnits);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        var entryStateID = Guid.Parse("c9f3be98-f21a-4989-a25c-c0058f898dcd");
        objectContext.AddToRawObjectList(viewModel._ForensicMedicalReport, entryStateID);
        objectContext.ProcessRawObjects(false);
        var forensicMedicalReport = (ForensicMedicalReport)objectContext.GetLoadedObject(viewModel._ForensicMedicalReport.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(forensicMedicalReport, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ForensicMedicalReport, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(forensicMedicalReport);
        PostScript_ForensicMedicalReportForm(viewModel, forensicMedicalReport, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(forensicMedicalReport);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(forensicMedicalReport);
        AfterContextSaveScript_ForensicMedicalReportForm(viewModel, forensicMedicalReport, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ForensicMedicalReportForm(ForensicMedicalReportFormViewModel viewModel, ForensicMedicalReport forensicMedicalReport, TTObjectContext objectContext);
    partial void PostScript_ForensicMedicalReportForm(ForensicMedicalReportFormViewModel viewModel, ForensicMedicalReport forensicMedicalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ForensicMedicalReportForm(ForensicMedicalReportFormViewModel viewModel, ForensicMedicalReport forensicMedicalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ForensicMedicalReportFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.MilitaryUnits = objectContext.LocalQuery<MilitaryUnit>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SenderChairListDefinition", viewModel.MilitaryUnits);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ForensicMedicalReportFormViewModel
    {
        public TTObjectClasses.ForensicMedicalReport _ForensicMedicalReport
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.MilitaryUnit[] MilitaryUnits
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
