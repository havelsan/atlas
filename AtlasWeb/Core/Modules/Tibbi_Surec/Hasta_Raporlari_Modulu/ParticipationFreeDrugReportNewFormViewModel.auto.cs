//$64DB28A4
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
    public partial class ParticipatnFreeDrugReportServiceController : Controller
{
    [HttpGet]
    public ParticipationFreeDrugReportNewFormViewModel ParticipationFreeDrugReportNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ParticipationFreeDrugReportNewFormLoadInternal(input);
    }

    [HttpPost]
    public ParticipationFreeDrugReportNewFormViewModel ParticipationFreeDrugReportNewFormLoad(FormLoadInput input)
    {
        return ParticipationFreeDrugReportNewFormLoadInternal(input);
    }

    private ParticipationFreeDrugReportNewFormViewModel ParticipationFreeDrugReportNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("03427eac-3998-45e7-a2be-3b0f444b93a4");
        var objectDefID = Guid.Parse("c3d26685-4b86-4454-9884-1ae2c8bc932f");
        var viewModel = new ParticipationFreeDrugReportNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ParticipatnFreeDrugReport = objectContext.GetObject(id.Value, objectDefID) as ParticipatnFreeDrugReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ParticipatnFreeDrugReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ParticipatnFreeDrugReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ParticipationFreeDrugReportNewForm(viewModel, viewModel._ParticipatnFreeDrugReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ParticipatnFreeDrugReport = new ParticipatnFreeDrugReport(objectContext);
                var entryStateID = Guid.Parse("04200b26-1590-4f3d-abed-dda38b822304");
                viewModel._ParticipatnFreeDrugReport.CurrentStateDefID = entryStateID;
                viewModel.MedulaReportResultsGridList = new TTObjectClasses.MedulaReportResult[]{};
                viewModel.ParticipationFreeDrugsGridList = new TTObjectClasses.ParticipationFreeDrgGrid[]{};
                viewModel.GridDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ParticipatnFreeDrugReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ParticipatnFreeDrugReport);
                PreScript_ParticipationFreeDrugReportNewForm(viewModel, viewModel._ParticipatnFreeDrugReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ParticipationFreeDrugReportNewForm(ParticipationFreeDrugReportNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("03427eac-3998-45e7-a2be-3b0f444b93a4");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.EtkinMaddes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.Teshiss);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.MedulaReportResultsGridList);
            objectContext.AddToRawObjectList(viewModel.ParticipationFreeDrugsGridList);
            objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
            var entryStateID = Guid.Parse("04200b26-1590-4f3d-abed-dda38b822304");
            objectContext.AddToRawObjectList(viewModel._ParticipatnFreeDrugReport, entryStateID);
            objectContext.ProcessRawObjects(false);
            var participatnFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetLoadedObject(viewModel._ParticipatnFreeDrugReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(participatnFreeDrugReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
            if (viewModel.MedulaReportResultsGridList != null)
            {
                foreach (var item in viewModel.MedulaReportResultsGridList)
                {
                    var medulaReportResultsImported = (MedulaReportResult)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)medulaReportResultsImported).IsDeleted)
                        continue;
                    medulaReportResultsImported.ParticipatnFreeDrugReport = participatnFreeDrugReport;
                }
            }

            if (viewModel.ParticipationFreeDrugsGridList != null)
            {
                foreach (var item in viewModel.ParticipationFreeDrugsGridList)
                {
                    var participationFreeDrugsImported = (ParticipationFreeDrgGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)participationFreeDrugsImported).IsDeleted)
                        continue;
                    participationFreeDrugsImported.ParticipatnFreeDrugReport = participatnFreeDrugReport;
                }
            }

            if (viewModel.GridDiagnosisGridList != null)
            {
                foreach (var item in viewModel.GridDiagnosisGridList)
                {
                    var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.EpisodeAction = participatnFreeDrugReport;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(participatnFreeDrugReport);
            PostScript_ParticipationFreeDrugReportNewForm(viewModel, participatnFreeDrugReport, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(participatnFreeDrugReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(participatnFreeDrugReport);
            AfterContextSaveScript_ParticipationFreeDrugReportNewForm(viewModel, participatnFreeDrugReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ParticipationFreeDrugReportNewForm(ParticipationFreeDrugReportNewFormViewModel viewModel, ParticipatnFreeDrugReport participatnFreeDrugReport, TTObjectContext objectContext);
    partial void PostScript_ParticipationFreeDrugReportNewForm(ParticipationFreeDrugReportNewFormViewModel viewModel, ParticipatnFreeDrugReport participatnFreeDrugReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ParticipationFreeDrugReportNewForm(ParticipationFreeDrugReportNewFormViewModel viewModel, ParticipatnFreeDrugReport participatnFreeDrugReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ParticipationFreeDrugReportNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MedulaReportResultsGridList = viewModel._ParticipatnFreeDrugReport.MedulaReportResults.OfType<MedulaReportResult>().ToArray();
        viewModel.ParticipationFreeDrugsGridList = viewModel._ParticipatnFreeDrugReport.ParticipationFreeDrugs.OfType<ParticipationFreeDrgGrid>().ToArray();
        viewModel.GridDiagnosisGridList = viewModel._ParticipatnFreeDrugReport.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.EtkinMaddes = objectContext.LocalQuery<EtkinMadde>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.Teshiss = objectContext.LocalQuery<Teshis>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "EtkinMaddeListDefinition", viewModel.EtkinMaddes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TeshisListDefinition", viewModel.Teshiss);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ParticipationFreeDrugReportNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ParticipatnFreeDrugReport _ParticipatnFreeDrugReport { get; set; }
        public TTObjectClasses.MedulaReportResult[] MedulaReportResultsGridList { get; set; }
        public TTObjectClasses.ParticipationFreeDrgGrid[] ParticipationFreeDrugsGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.EtkinMadde[] EtkinMaddes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.Teshis[] Teshiss { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
    }
}
