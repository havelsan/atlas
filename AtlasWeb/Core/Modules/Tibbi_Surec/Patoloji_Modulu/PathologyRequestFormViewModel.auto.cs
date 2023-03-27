//$F9BC3354
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
    public partial class PathologyRequestServiceController : Controller
{
    [HttpGet]
    public PathologyRequestFormViewModel PathologyRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyRequestFormLoadInternal(input);
    }

    [HttpPost]
    public PathologyRequestFormViewModel PathologyRequestFormLoad(FormLoadInput input)
    {
        return PathologyRequestFormLoadInternal(input);
    }

    private PathologyRequestFormViewModel PathologyRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("b228b923-63f6-443d-83ff-fa2795a84195");
        var objectDefID = Guid.Parse("6eb39f91-8f9f-4184-ac32-ff4c383fa9b5");
        var viewModel = new PathologyRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyRequest = objectContext.GetObject(id.Value, objectDefID) as PathologyRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PathologyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PathologyRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PathologyRequestForm(viewModel, viewModel._PathologyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyRequest = new PathologyRequest(objectContext);
                var entryStateID = Guid.Parse("2f00cba0-57f3-4aa4-88e5-78ee94a19389");
                viewModel._PathologyRequest.CurrentStateDefID = entryStateID;
                viewModel.PathologyMaterialsGridList = new TTObjectClasses.PathologyMaterial[]{};
                viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PathologyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PathologyRequest);
                PreScript_PathologyRequestForm(viewModel, viewModel._PathologyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyRequestForm(PathologyRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("b228b923-63f6-443d-83ff-fa2795a84195");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSICDOYERLESIMYERIs);
            objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
            objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlinmaSeklis);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.PathologyMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            var entryStateID = Guid.Parse("2f00cba0-57f3-4aa4-88e5-78ee94a19389");
            objectContext.AddToRawObjectList(viewModel._PathologyRequest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var pathologyRequest = (PathologyRequest)objectContext.GetLoadedObject(viewModel._PathologyRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyRequest, formDefID);
            if (viewModel.PathologyMaterialsGridList != null)
            {
                foreach (var item in viewModel.PathologyMaterialsGridList)
                {
                    var pathologyMaterialsImported = (PathologyMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)pathologyMaterialsImported).IsDeleted)
                        continue;
                    pathologyMaterialsImported.PathologyRequest = pathologyRequest;
                }
            }

            var episodeImported = pathologyRequest.Episode;
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

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(pathologyRequest);
            PostScript_PathologyRequestForm(viewModel, pathologyRequest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyRequest);
            AfterContextSaveScript_PathologyRequestForm(viewModel, pathologyRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PathologyRequestForm(PathologyRequestFormViewModel viewModel, PathologyRequest pathologyRequest, TTObjectContext objectContext);
    partial void PostScript_PathologyRequestForm(PathologyRequestFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyRequestForm(PathologyRequestFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PathologyMaterialsGridList = viewModel._PathologyRequest.PathologyMaterials.OfType<PathologyMaterial>().ToArray();
        var episode = viewModel._PathologyRequest.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSICDOYERLESIMYERIs = objectContext.LocalQuery<SKRSICDOYERLESIMYERI>().ToArray();
        viewModel.SKRSNumuneAlindigiDokununTemelOzelligis = objectContext.LocalQuery<SKRSNumuneAlindigiDokununTemelOzelligi>().ToArray();
        viewModel.SKRSNumuneAlinmaSeklis = objectContext.LocalQuery<SKRSNumuneAlinmaSekli>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDOYERLESIMYERIList", viewModel.SKRSICDOYERLESIMYERIs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlindigiDokununTemelOzelligiList", viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlinmaSekliList", viewModel.SKRSNumuneAlinmaSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class PathologyRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PathologyRequest _PathologyRequest { get; set; }
        public TTObjectClasses.PathologyMaterial[] PathologyMaterialsGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSICDOYERLESIMYERI[] SKRSICDOYERLESIMYERIs { get; set; }
        public TTObjectClasses.SKRSNumuneAlindigiDokununTemelOzelligi[] SKRSNumuneAlindigiDokununTemelOzelligis { get; set; }
        public TTObjectClasses.SKRSNumuneAlinmaSekli[] SKRSNumuneAlinmaSeklis { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
    }
}
