//$68EB0CA0
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
    public partial class AnesthesiaAndReanimationServiceController : Controller
{
    [HttpGet]
    public AnesthesiaRequestAcceptionFormViewModel AnesthesiaRequestAcceptionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AnesthesiaRequestAcceptionFormLoadInternal(input);
    }

    [HttpPost]
    public AnesthesiaRequestAcceptionFormViewModel AnesthesiaRequestAcceptionFormLoad(FormLoadInput input)
    {
        return AnesthesiaRequestAcceptionFormLoadInternal(input);
    }

    private AnesthesiaRequestAcceptionFormViewModel AnesthesiaRequestAcceptionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("fdc1fa23-8a1f-4e44-9cf0-4781938dc906");
        var objectDefID = Guid.Parse("240cc318-843b-4302-a944-0b9ac2e9edb8");
        var viewModel = new AnesthesiaRequestAcceptionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AnesthesiaAndReanimation = objectContext.GetObject(id.Value, objectDefID) as AnesthesiaAndReanimation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AnesthesiaAndReanimation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaAndReanimation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AnesthesiaAndReanimation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AnesthesiaAndReanimation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AnesthesiaRequestAcceptionForm(viewModel, viewModel._AnesthesiaAndReanimation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AnesthesiaRequestAcceptionForm(AnesthesiaRequestAcceptionFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("fdc1fa23-8a1f-4e44-9cf0-4781938dc906");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.Surgerys);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.RequestedProcedureGridList);
            objectContext.AddToRawObjectList(viewModel.GridSurgeryProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel._AnesthesiaAndReanimation);
            objectContext.ProcessRawObjects();
            var anesthesiaAndReanimation = (AnesthesiaAndReanimation)objectContext.GetLoadedObject(viewModel._AnesthesiaAndReanimation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(anesthesiaAndReanimation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaAndReanimation, formDefID);
            if (viewModel.RequestedProcedureGridList != null)
            {
                foreach (var item in viewModel.RequestedProcedureGridList)
                {
                    var requestedProcedureImported = (AnesthesiaAndReanimationRequestedProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)requestedProcedureImported).IsDeleted)
                        continue;
                    requestedProcedureImported.AnesthesiaAndReanimation = anesthesiaAndReanimation;
                }
            }

            var mainSurgeryImported = anesthesiaAndReanimation.MainSurgery;
            if (mainSurgeryImported != null)
            {
                if (viewModel.GridSurgeryProceduresGridList != null)
                {
                    foreach (var item in viewModel.GridSurgeryProceduresGridList)
                    {
                        var surgeryProceduresImported = (SurgeryProcedure)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)surgeryProceduresImported).IsDeleted)
                            continue;
                        surgeryProceduresImported.Surgery = mainSurgeryImported;
                    }
                }
            }

            var episodeImported = anesthesiaAndReanimation.Episode;
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

            var transDef = anesthesiaAndReanimation.TransDef;
            PostScript_AnesthesiaRequestAcceptionForm(viewModel, anesthesiaAndReanimation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(anesthesiaAndReanimation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(anesthesiaAndReanimation);
            AfterContextSaveScript_AnesthesiaRequestAcceptionForm(viewModel, anesthesiaAndReanimation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AnesthesiaRequestAcceptionForm(AnesthesiaRequestAcceptionFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTObjectContext objectContext);
    partial void PostScript_AnesthesiaRequestAcceptionForm(AnesthesiaRequestAcceptionFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AnesthesiaRequestAcceptionForm(AnesthesiaRequestAcceptionFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AnesthesiaRequestAcceptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.RequestedProcedureGridList = viewModel._AnesthesiaAndReanimation.RequestedProcedure.OfType<AnesthesiaAndReanimationRequestedProcedure>().ToArray();
        var mainSurgery = viewModel._AnesthesiaAndReanimation.MainSurgery;
        if (mainSurgery != null)
        {
            viewModel.GridSurgeryProceduresGridList = mainSurgery.SurgeryProcedures.OfType<SurgeryProcedure>().ToArray();
        }

        var episode = viewModel._AnesthesiaAndReanimation.Episode;
        if (episode != null)
        {
            viewModel.GridDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.Surgerys = objectContext.LocalQuery<Surgery>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class AnesthesiaRequestAcceptionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation { get; set; }
        public TTObjectClasses.AnesthesiaAndReanimationRequestedProcedure[] RequestedProcedureGridList { get; set; }
        public TTObjectClasses.SurgeryProcedure[] GridSurgeryProceduresGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.Surgery[] Surgerys { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
