//$C491BD3F
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
    public partial class NursingPatientPreAssessmentServiceController : Controller
{
    [HttpGet]
    public NursingPatientPreAssessmentFormViewModel NursingPatientPreAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingPatientPreAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public NursingPatientPreAssessmentFormViewModel NursingPatientPreAssessmentFormLoad(FormLoadInput input)
    {
        return NursingPatientPreAssessmentFormLoadInternal(input);
    }

    private NursingPatientPreAssessmentFormViewModel NursingPatientPreAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c5dcb97b-720b-4e2b-8ba6-314178f652d0");
        var objectDefID = Guid.Parse("d868c3fc-3955-4689-a2a7-8e3307bc0d36");
        var viewModel = new NursingPatientPreAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingPatientPreAssessment = objectContext.GetObject(id.Value, objectDefID) as NursingPatientPreAssessment;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingPatientPreAssessment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPatientPreAssessment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingPatientPreAssessment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingPatientPreAssessment);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingPatientPreAssessmentForm(viewModel, viewModel._NursingPatientPreAssessment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingPatientPreAssessment = new NursingPatientPreAssessment(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingPatientPreAssessment.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingPatientPreAssessment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPatientPreAssessment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingPatientPreAssessment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingPatientPreAssessment);
                PreScript_NursingPatientPreAssessmentForm(viewModel, viewModel._NursingPatientPreAssessment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingPatientPreAssessmentForm(NursingPatientPreAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingPatientPreAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingPatientPreAssessmentFormInternal(NursingPatientPreAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c5dcb97b-720b-4e2b-8ba6-314178f652d0");
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingPatientPreAssessment, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingPatientPreAssessment = (NursingPatientPreAssessment)objectContext.GetLoadedObject(viewModel._NursingPatientPreAssessment.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingPatientPreAssessment, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPatientPreAssessment, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingPatientPreAssessment);
        PostScript_NursingPatientPreAssessmentForm(viewModel, nursingPatientPreAssessment, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingPatientPreAssessment);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingPatientPreAssessment);
        AfterContextSaveScript_NursingPatientPreAssessmentForm(viewModel, nursingPatientPreAssessment, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingPatientPreAssessmentForm(NursingPatientPreAssessmentFormViewModel viewModel, NursingPatientPreAssessment nursingPatientPreAssessment, TTObjectContext objectContext);
    partial void PostScript_NursingPatientPreAssessmentForm(NursingPatientPreAssessmentFormViewModel viewModel, NursingPatientPreAssessment nursingPatientPreAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingPatientPreAssessmentForm(NursingPatientPreAssessmentFormViewModel viewModel, NursingPatientPreAssessment nursingPatientPreAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingPatientPreAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingPatientPreAssessmentFormViewModel
    {
        public TTObjectClasses.NursingPatientPreAssessment _NursingPatientPreAssessment
        {
            get;
            set;
        }
    }
}
