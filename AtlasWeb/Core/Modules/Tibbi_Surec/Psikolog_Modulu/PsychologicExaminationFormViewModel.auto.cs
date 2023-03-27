//$BE57CA05
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class PsychologicExaminationServiceController : Controller
{
    [HttpGet]
    public PsychologicExaminationFormViewModel PsychologicExaminationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PsychologicExaminationFormLoadInternal(input);
    }

    [HttpPost]
    public PsychologicExaminationFormViewModel PsychologicExaminationFormLoad(FormLoadInput input)
    {
        return PsychologicExaminationFormLoadInternal(input);
    }

    private PsychologicExaminationFormViewModel PsychologicExaminationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("eeb7532e-a2dc-4cb5-bdd3-78f84d00ddad");
        var objectDefID = Guid.Parse("b4b5ecaf-c7b8-4293-b4bc-3bae71476721");
        var viewModel = new PsychologicExaminationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologicExamination = objectContext.GetObject(id.Value, objectDefID) as PsychologicExamination;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologicExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologicExamination, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PsychologicExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PsychologicExamination);
                PreScript_PsychologicExaminationForm(viewModel, viewModel._PsychologicExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologicExamination = new PsychologicExamination(objectContext);
                var entryStateID = Guid.Parse("ec7a621a-52d8-495e-a508-dea58d40b4d1");
                viewModel._PsychologicExamination.CurrentStateDefID = entryStateID;
                viewModel.PsychologyTestsGridList = new TTObjectClasses.PsychologyTest[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologicExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologicExamination, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PsychologicExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PsychologicExamination);
                PreScript_PsychologicExaminationForm(viewModel, viewModel._PsychologicExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PsychologicExaminationForm(PsychologicExaminationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("eeb7532e-a2dc-4cb5-bdd3-78f84d00ddad");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.PsychologyTestsGridList);
            var entryStateID = Guid.Parse("ec7a621a-52d8-495e-a508-dea58d40b4d1");
            objectContext.AddToRawObjectList(viewModel._PsychologicExamination, entryStateID);
            objectContext.ProcessRawObjects(false);
            var psychologicExamination = (PsychologicExamination)objectContext.GetLoadedObject(viewModel._PsychologicExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(psychologicExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologicExamination, formDefID);
            if (viewModel.PsychologyTestsGridList != null)
            {
                foreach (var item in viewModel.PsychologyTestsGridList)
                {
                    var psychologyTestsImported = (PsychologyTest)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)psychologyTestsImported).IsDeleted)
                        continue;
                    psychologyTestsImported.PsychologicExamination = psychologicExamination;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(psychologicExamination);
            PostScript_PsychologicExaminationForm(viewModel, psychologicExamination, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(psychologicExamination);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(psychologicExamination);
            AfterContextSaveScript_PsychologicExaminationForm(viewModel, psychologicExamination, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PsychologicExaminationForm(PsychologicExaminationFormViewModel viewModel, PsychologicExamination psychologicExamination, TTObjectContext objectContext);
    partial void PostScript_PsychologicExaminationForm(PsychologicExaminationFormViewModel viewModel, PsychologicExamination psychologicExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PsychologicExaminationForm(PsychologicExaminationFormViewModel viewModel, PsychologicExamination psychologicExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PsychologicExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PsychologyTestsGridList = viewModel._PsychologicExamination.PsychologyTests.OfType<PsychologyTest>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
    }
}
}

namespace Core.Models
{
    public partial class PsychologicExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PsychologicExamination _PsychologicExamination
        {
            get;
            set;
        }

        public TTObjectClasses.PsychologyTest[] PsychologyTestsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
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