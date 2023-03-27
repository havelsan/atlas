//$752C481C
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
    public partial class DispatchExaminationServiceController : Controller
{
    [HttpGet]
    public DispatchExaminationFormViewModel DispatchExaminationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DispatchExaminationFormLoadInternal(input);
    }

    [HttpPost]
    public DispatchExaminationFormViewModel DispatchExaminationFormLoad(FormLoadInput input)
    {
        return DispatchExaminationFormLoadInternal(input);
    }

    private DispatchExaminationFormViewModel DispatchExaminationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a8fa966a-e6d6-490a-b3ca-bfcf8218219f");
        var objectDefID = Guid.Parse("95db3356-de80-4bcd-9ac2-5f8daba12771");
        var viewModel = new DispatchExaminationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DispatchExamination = objectContext.GetObject(id.Value, objectDefID) as DispatchExamination;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DispatchExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DispatchExamination, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DispatchExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DispatchExamination);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DispatchExaminationForm(viewModel, viewModel._DispatchExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DispatchExamination = new DispatchExamination(objectContext);
                var entryStateID = Guid.Parse("7973275f-30bb-47fb-9511-9078320902a0");
                viewModel._DispatchExamination.CurrentStateDefID = entryStateID;
                viewModel.GridDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                //     viewModel.GridAdditionalApplicationsGridList = new TTObjectClasses.DispatchExaminationAdditionalApplication[] { };
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DispatchExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DispatchExamination, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DispatchExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DispatchExamination);
                PreScript_DispatchExaminationForm(viewModel, viewModel._DispatchExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DispatchExaminationForm(DispatchExaminationFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DispatchExaminationFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel DispatchExaminationFormInternal(DispatchExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a8fa966a-e6d6-490a-b3ca-bfcf8218219f");
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
        objectContext.AddToRawObjectList(viewModel.EpisodeActions);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
        // objectContext.AddToRawObjectList(viewModel.GridAdditionalApplicationsGridList);
        var entryStateID = Guid.Parse("7973275f-30bb-47fb-9511-9078320902a0");
        objectContext.AddToRawObjectList(viewModel._DispatchExamination, entryStateID);
        objectContext.ProcessRawObjects(false);
        var dispatchExamination = (DispatchExamination)objectContext.GetLoadedObject(viewModel._DispatchExamination.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(dispatchExamination, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DispatchExamination, formDefID);
        if (viewModel.GridDiagnosisGridList != null)
        {
            foreach (var item in viewModel.GridDiagnosisGridList)
            {
                var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)diagnosisImported).IsDeleted)
                    continue;
                diagnosisImported.EpisodeAction = dispatchExamination;
            }
        }

        //if (viewModel.GridAdditionalApplicationsGridList != null)
        //{
        //    foreach (var item in viewModel.GridAdditionalApplicationsGridList)
        //    {
        //        var dispatchExaminationAdditionalApplicationsImported = (DispatchExaminationAdditionalApplication)objectContext.GetLoadedObject(item.ObjectID);
        //        if (((ITTObject)dispatchExaminationAdditionalApplicationsImported).IsDeleted)
        //            continue;
        //        dispatchExaminationAdditionalApplicationsImported.DispatchExamination = dispatchExamination;
        //    }
        //}
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(dispatchExamination);
        PostScript_DispatchExaminationForm(viewModel, dispatchExamination, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dispatchExamination);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dispatchExamination);
        AfterContextSaveScript_DispatchExaminationForm(viewModel, dispatchExamination, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DispatchExaminationForm(DispatchExaminationFormViewModel viewModel, DispatchExamination dispatchExamination, TTObjectContext objectContext);
    partial void PostScript_DispatchExaminationForm(DispatchExaminationFormViewModel viewModel, DispatchExamination dispatchExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DispatchExaminationForm(DispatchExaminationFormViewModel viewModel, DispatchExamination dispatchExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DispatchExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridDiagnosisGridList = viewModel._DispatchExamination.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        //     viewModel.GridAdditionalApplicationsGridList = viewModel._DispatchExamination.DispatchExaminationAdditionalApplications.OfType<DispatchExaminationAdditionalApplication>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.EpisodeActions = objectContext.LocalQuery<EpisodeAction>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AdditionalApplicationListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
    }
}
}


namespace Core.Models
{
    public partial class DispatchExaminationFormViewModel
    {
        public TTObjectClasses.DispatchExamination _DispatchExamination
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList
        {
            get;
            set;
        }

        //public TTObjectClasses.DispatchExaminationAdditionalApplication[] GridAdditionalApplicationsGridList
        //{
        //    get;
        //    set;
        //}

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.EpisodeAction[] EpisodeActions
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }
    }
}
