//$CDBEF9C3
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
    public partial class PsychologyBasedObjectServiceController : Controller
{
    [HttpGet]
    public PsychologyBasedObjectFormViewModel PsychologyBasedObjectForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PsychologyBasedObjectFormLoadInternal(input);
    }

    [HttpPost]
    public PsychologyBasedObjectFormViewModel PsychologyBasedObjectFormLoad(FormLoadInput input)
    {
        return PsychologyBasedObjectFormLoadInternal(input);
    }

    private PsychologyBasedObjectFormViewModel PsychologyBasedObjectFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6b408a4f-79e9-4b8e-8f7d-862afd54cc9c");
        var objectDefID = Guid.Parse("306a68a6-aa4b-4f51-9f3c-a9b04b793f17");
        var viewModel = new PsychologyBasedObjectFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologyBasedObject = objectContext.GetObject(id.Value, objectDefID) as PsychologyBasedObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PsychologyBasedObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PsychologyBasedObject);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PsychologyBasedObjectForm(viewModel, viewModel._PsychologyBasedObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologyBasedObject = new PsychologyBasedObject(objectContext);
                viewModel.PsychologyAuthorizedUsersGridList = new TTObjectClasses.PsychologyAuthorizedUser[]{};
                viewModel.IQIntelligenceTestReportGridList = new TTObjectClasses.IQIntelligenceTestReport[]{};
                viewModel.VerbalAndPerformanceTestsGridList = new TTObjectClasses.VerbalAndPerformanceTests[]{};
                viewModel.ttgrid1GridList = new TTObjectClasses.CognitiveEvaluation[]{};
                viewModel.PsychologicEvaluationGridList = new TTObjectClasses.PsychologicEvaluation[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyBasedObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PsychologyBasedObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PsychologyBasedObject);
                PreScript_PsychologyBasedObjectForm(viewModel, viewModel._PsychologyBasedObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PsychologyBasedObjectForm(PsychologyBasedObjectFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6b408a4f-79e9-4b8e-8f7d-862afd54cc9c");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.PsychologyAuthorizedUsersGridList);
            objectContext.AddToRawObjectList(viewModel.IQIntelligenceTestReportGridList);
            objectContext.AddToRawObjectList(viewModel.VerbalAndPerformanceTestsGridList);
            objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
            objectContext.AddToRawObjectList(viewModel.PsychologicEvaluationGridList);
            objectContext.AddToRawObjectList(viewModel._PsychologyBasedObject);
            objectContext.ProcessRawObjects();
            var psychologyBasedObject = (PsychologyBasedObject)objectContext.GetLoadedObject(viewModel._PsychologyBasedObject.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(psychologyBasedObject, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyBasedObject, formDefID);
            if (viewModel.PsychologyAuthorizedUsersGridList != null)
            {
                foreach (var item in viewModel.PsychologyAuthorizedUsersGridList)
                {
                    var psychologyAuthorizedUsersImported = (PsychologyAuthorizedUser)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)psychologyAuthorizedUsersImported).IsDeleted)
                        continue;
                    psychologyAuthorizedUsersImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (viewModel.IQIntelligenceTestReportGridList != null)
            {
                foreach (var item in viewModel.IQIntelligenceTestReportGridList)
                {
                    var iQIntelligenceTestReportImported = (IQIntelligenceTestReport)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)iQIntelligenceTestReportImported).IsDeleted)
                        continue;
                    iQIntelligenceTestReportImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (viewModel.VerbalAndPerformanceTestsGridList != null)
            {
                foreach (var item in viewModel.VerbalAndPerformanceTestsGridList)
                {
                    var verbalAndPerformanceTestsImported = (VerbalAndPerformanceTests)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)verbalAndPerformanceTestsImported).IsDeleted)
                        continue;
                    verbalAndPerformanceTestsImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (viewModel.ttgrid1GridList != null)
            {
                foreach (var item in viewModel.ttgrid1GridList)
                {
                    var cognitiveEvaluationImported = (CognitiveEvaluation)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)cognitiveEvaluationImported).IsDeleted)
                        continue;
                    cognitiveEvaluationImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (viewModel.PsychologicEvaluationGridList != null)
            {
                foreach (var item in viewModel.PsychologicEvaluationGridList)
                {
                    var psychologicEvaluationImported = (PsychologicEvaluation)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)psychologicEvaluationImported).IsDeleted)
                        continue;
                    psychologicEvaluationImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            var transDef = psychologyBasedObject.TransDef;
            PostScript_PsychologyBasedObjectForm(viewModel, psychologyBasedObject, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(psychologyBasedObject);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(psychologyBasedObject);
            AfterContextSaveScript_PsychologyBasedObjectForm(viewModel, psychologyBasedObject, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PsychologyBasedObjectForm(PsychologyBasedObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTObjectContext objectContext);
    partial void PostScript_PsychologyBasedObjectForm(PsychologyBasedObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PsychologyBasedObjectForm(PsychologyBasedObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PsychologyBasedObjectFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PsychologyAuthorizedUsersGridList = viewModel._PsychologyBasedObject.PsychologyAuthorizedUsers.OfType<PsychologyAuthorizedUser>().ToArray();
        viewModel.IQIntelligenceTestReportGridList = viewModel._PsychologyBasedObject.IQIntelligenceTestReport.OfType<IQIntelligenceTestReport>().ToArray();
        viewModel.VerbalAndPerformanceTestsGridList = viewModel._PsychologyBasedObject.VerbalAndPerformanceTests.OfType<VerbalAndPerformanceTests>().ToArray();
        viewModel.ttgrid1GridList = viewModel._PsychologyBasedObject.CognitiveEvaluation.OfType<CognitiveEvaluation>().ToArray();
        viewModel.PsychologicEvaluationGridList = viewModel._PsychologyBasedObject.PsychologicEvaluation.OfType<PsychologicEvaluation>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.PsychologyBasedObjects = objectContext.LocalQuery<PsychologyBasedObject>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class PsychologyBasedObjectFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PsychologyBasedObject _PsychologyBasedObject { get; set; }
        public TTObjectClasses.PsychologyAuthorizedUser[] PsychologyAuthorizedUsersGridList { get; set; }
        public TTObjectClasses.IQIntelligenceTestReport[] IQIntelligenceTestReportGridList { get; set; }
        public TTObjectClasses.VerbalAndPerformanceTests[] VerbalAndPerformanceTestsGridList { get; set; }
        public TTObjectClasses.CognitiveEvaluation[] ttgrid1GridList { get; set; }
        public TTObjectClasses.PsychologicEvaluation[] PsychologicEvaluationGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.PsychologyBasedObject[] PsychologyBasedObjects { get; set; }
        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus { get; set; }
        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers { get; set; }
    }
}
