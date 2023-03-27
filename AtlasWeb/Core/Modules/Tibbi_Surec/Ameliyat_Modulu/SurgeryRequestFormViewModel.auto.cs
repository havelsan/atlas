//$9A5770FD
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
    public partial class SurgeryServiceController : Controller
{
    [HttpGet]
    public SurgeryRequestFormViewModel SurgeryRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SurgeryRequestFormLoadInternal(input);
    }

    [HttpPost]
    public SurgeryRequestFormViewModel SurgeryRequestFormLoad(FormLoadInput input)
    {
        return SurgeryRequestFormLoadInternal(input);
    }

    private SurgeryRequestFormViewModel SurgeryRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("f77e64de-1f7a-4344-a460-8dac1b8434c4");
        var objectDefID = Guid.Parse("8dc586f0-14a5-42a3-a7c6-51e1be031ee0");
        var viewModel = new SurgeryRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Surgery = objectContext.GetObject(id.Value, objectDefID) as Surgery;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Surgery, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Surgery);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Surgery);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SurgeryRequestForm(viewModel, viewModel._Surgery, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Surgery = new Surgery(objectContext);
                var entryStateID = Guid.Parse("e8995933-3381-4409-8b7c-95c00f1a52d0");
                viewModel._Surgery.CurrentStateDefID = entryStateID;
                viewModel.GridDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.GridMainSurgeryProceduresGridList = new TTObjectClasses.MainSurgeryProcedure[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Surgery, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Surgery);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Surgery);
                PreScript_SurgeryRequestForm(viewModel, viewModel._Surgery, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SurgeryRequestForm(SurgeryRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("f77e64de-1f7a-4344-a460-8dac1b8434c4");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSurgeryDesks);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryRooms);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.GridMainSurgeryProceduresGridList);
            if(viewModel.LinkedSurgeryAppointment != null) 
               objectContext.AddToRawObjectList(viewModel.LinkedSurgeryAppointment);
            var entryStateID = Guid.Parse("e8995933-3381-4409-8b7c-95c00f1a52d0");
            objectContext.AddToRawObjectList(viewModel._Surgery, entryStateID);
            objectContext.ProcessRawObjects(false);
            var surgery = (Surgery)objectContext.GetLoadedObject(viewModel._Surgery.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgery, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
            var episodeImported = surgery.Episode;
            if (episodeImported != null)
            {
                if (viewModel.GridDiagnosisGridList != null)
                {
                    foreach (var item in viewModel.GridDiagnosisGridList)
                    {
                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episodeImported;
                    }
                }
            }

            if (viewModel.GridMainSurgeryProceduresGridList != null)
            {
                foreach (var item in viewModel.GridMainSurgeryProceduresGridList)
                {
                    var mainSurgeryProceduresImported = (MainSurgeryProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)mainSurgeryProceduresImported).IsDeleted)
                        continue;
                    mainSurgeryProceduresImported.MainSurgery = surgery;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(surgery);
            PostScript_SurgeryRequestForm(viewModel, surgery, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgery);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgery);
            AfterContextSaveScript_SurgeryRequestForm(viewModel, surgery, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SurgeryRequestForm(SurgeryRequestFormViewModel viewModel, Surgery surgery, TTObjectContext objectContext);
    partial void PostScript_SurgeryRequestForm(SurgeryRequestFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SurgeryRequestForm(SurgeryRequestFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SurgeryRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._Surgery.Episode;
        if (episode != null)
        {
            viewModel.GridDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.GridMainSurgeryProceduresGridList = viewModel._Surgery.MainSurgeryProcedures.OfType<MainSurgeryProcedure>().ToArray();
        viewModel.ResSurgeryDesks = objectContext.LocalQuery<ResSurgeryDesk>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResSurgeryRooms = objectContext.LocalQuery<ResSurgeryRoom>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryDeskListDefinition", viewModel.ResSurgeryDesks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRoomListDefinition", viewModel.ResSurgeryRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class SurgeryRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Surgery _Surgery { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public TTObjectClasses.MainSurgeryProcedure[] GridMainSurgeryProceduresGridList { get; set; }
        public TTObjectClasses.ResSurgeryDesk[] ResSurgeryDesks { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSurgeryRoom[] ResSurgeryRooms { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
    }
}
