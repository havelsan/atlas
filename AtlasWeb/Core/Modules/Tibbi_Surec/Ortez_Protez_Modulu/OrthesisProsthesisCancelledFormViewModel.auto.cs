//$3C3524B2
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
    public partial class OrthesisProsthesisRequestServiceController : Controller
{
    [HttpGet]
    public OrthesisProsthesisCancelledFormViewModel OrthesisProsthesisCancelledForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OrthesisProsthesisCancelledFormLoadInternal(input);
    }

    [HttpPost]
    public OrthesisProsthesisCancelledFormViewModel OrthesisProsthesisCancelledFormLoad(FormLoadInput input)
    {
        return OrthesisProsthesisCancelledFormLoadInternal(input);
    }

    private OrthesisProsthesisCancelledFormViewModel OrthesisProsthesisCancelledFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d4117c62-6045-4674-a3ab-8ba03221647a");
        var objectDefID = Guid.Parse("29f8be50-7930-426f-94f5-83536cc7a4c4");
        var viewModel = new OrthesisProsthesisCancelledFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OrthesisProsthesisRequest = objectContext.GetObject(id.Value, objectDefID) as OrthesisProsthesisRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OrthesisProsthesisRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OrthesisProsthesisRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OrthesisProsthesisCancelledForm(viewModel, viewModel._OrthesisProsthesisRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OrthesisProsthesisCancelledForm(OrthesisProsthesisCancelledFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d4117c62-6045-4674-a3ab-8ba03221647a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.OrthesisProsthesisProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel._OrthesisProsthesisRequest);
            objectContext.ProcessRawObjects();
            var orthesisProsthesisRequest = (OrthesisProsthesisRequest)objectContext.GetLoadedObject(viewModel._OrthesisProsthesisRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(orthesisProsthesisRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
            if (viewModel.OrthesisProsthesisProceduresGridList != null)
            {
                foreach (var item in viewModel.OrthesisProsthesisProceduresGridList)
                {
                    var orthesisProsthesisProceduresImported = (OrthesisProsthesisProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)orthesisProsthesisProceduresImported).IsDeleted)
                        continue;
                    orthesisProsthesisProceduresImported.OrthesisProsthesisRequest = orthesisProsthesisRequest;
                }
            }

            var episodeImported = orthesisProsthesisRequest.Episode;
            if (episodeImported != null)
            {
                if (viewModel.GridEpisodeDiagnosisGridList != null)
                {
                    foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                    {
                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episodeImported;
                    }
                }
            }

            var transDef = orthesisProsthesisRequest.TransDef;
            PostScript_OrthesisProsthesisCancelledForm(viewModel, orthesisProsthesisRequest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(orthesisProsthesisRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(orthesisProsthesisRequest);
            AfterContextSaveScript_OrthesisProsthesisCancelledForm(viewModel, orthesisProsthesisRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OrthesisProsthesisCancelledForm(OrthesisProsthesisCancelledFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTObjectContext objectContext);
    partial void PostScript_OrthesisProsthesisCancelledForm(OrthesisProsthesisCancelledFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OrthesisProsthesisCancelledForm(OrthesisProsthesisCancelledFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OrthesisProsthesisCancelledFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.OrthesisProsthesisProceduresGridList = viewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.OfType<OrthesisProsthesisProcedure>().ToArray();
        var episode = viewModel._OrthesisProsthesisRequest.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OrtesisProsthesisListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class OrthesisProsthesisCancelledFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest { get; set; }
        public TTObjectClasses.OrthesisProsthesisProcedure[] OrthesisProsthesisProceduresGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions { get; set; }
    }
}
