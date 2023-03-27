//$6E396936
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
    public partial class IQIntelligenceTestReportServiceController : Controller
{
    [HttpGet]
    public IQIntelligenceTestReportFormViewModel IQIntelligenceTestReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return IQIntelligenceTestReportFormLoadInternal(input);
    }

    [HttpPost]
    public IQIntelligenceTestReportFormViewModel IQIntelligenceTestReportFormLoad(FormLoadInput input)
    {
        return IQIntelligenceTestReportFormLoadInternal(input);
    }

    private IQIntelligenceTestReportFormViewModel IQIntelligenceTestReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("16178c9b-5ef5-485c-8726-c2a22e72c00b");
        var objectDefID = Guid.Parse("ca2bde5d-9cb5-4966-9b43-57323066a6cd");
        var viewModel = new IQIntelligenceTestReportFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IQIntelligenceTestReport = objectContext.GetObject(id.Value, objectDefID) as IQIntelligenceTestReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IQIntelligenceTestReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IQIntelligenceTestReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._IQIntelligenceTestReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._IQIntelligenceTestReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_IQIntelligenceTestReportForm(viewModel, viewModel._IQIntelligenceTestReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IQIntelligenceTestReport = new IQIntelligenceTestReport(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IQIntelligenceTestReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IQIntelligenceTestReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._IQIntelligenceTestReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._IQIntelligenceTestReport);
                PreScript_IQIntelligenceTestReportForm(viewModel, viewModel._IQIntelligenceTestReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel IQIntelligenceTestReportForm(IQIntelligenceTestReportFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("16178c9b-5ef5-485c-8726-c2a22e72c00b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel._IQIntelligenceTestReport);
            objectContext.ProcessRawObjects();
            var iQIntelligenceTestReport = (IQIntelligenceTestReport)objectContext.GetLoadedObject(viewModel._IQIntelligenceTestReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(iQIntelligenceTestReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IQIntelligenceTestReport, formDefID);
            var transDef = iQIntelligenceTestReport.TransDef;
            PostScript_IQIntelligenceTestReportForm(viewModel, iQIntelligenceTestReport, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(iQIntelligenceTestReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(iQIntelligenceTestReport);
            AfterContextSaveScript_IQIntelligenceTestReportForm(viewModel, iQIntelligenceTestReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_IQIntelligenceTestReportForm(IQIntelligenceTestReportFormViewModel viewModel, IQIntelligenceTestReport iQIntelligenceTestReport, TTObjectContext objectContext);
    partial void PostScript_IQIntelligenceTestReportForm(IQIntelligenceTestReportFormViewModel viewModel, IQIntelligenceTestReport iQIntelligenceTestReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_IQIntelligenceTestReportForm(IQIntelligenceTestReportFormViewModel viewModel, IQIntelligenceTestReport iQIntelligenceTestReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(IQIntelligenceTestReportFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class IQIntelligenceTestReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.IQIntelligenceTestReport _IQIntelligenceTestReport { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers { get; set; }
        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus { get; set; }
    }
}
