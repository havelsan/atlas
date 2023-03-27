//$0994D9DC
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
    public PathologyRequestMainFormViewModel PathologyRequestMainForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyRequestMainFormLoadInternal(input);
    }

    [HttpPost]
    public PathologyRequestMainFormViewModel PathologyRequestMainFormLoad(FormLoadInput input)
    {
        return PathologyRequestMainFormLoadInternal(input);
    }

    private PathologyRequestMainFormViewModel PathologyRequestMainFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("cd5e6d67-d017-4ef8-b67e-d4d871e0b0b6");
        var objectDefID = Guid.Parse("6eb39f91-8f9f-4184-ac32-ff4c383fa9b5");
        var viewModel = new PathologyRequestMainFormViewModel();
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
                PreScript_PathologyRequestMainForm(viewModel, viewModel._PathologyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PathologyRequestMainFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PathologyRequestMainFormInternal(PathologyRequestMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("cd5e6d67-d017-4ef8-b67e-d4d871e0b0b6");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.SKRSICDOYERLESIMYERIs);
        objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
        objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlinmaSeklis);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDiagnosisGridGridList);
        objectContext.AddToRawObjectList(viewModel.PathologyMaterialsGridList);
        objectContext.AddToRawObjectList(viewModel._PathologyRequest);
        objectContext.ProcessRawObjects();
        var pathologyRequest = (PathologyRequest)objectContext.GetLoadedObject(viewModel._PathologyRequest.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyRequest, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyRequest, formDefID);
        var episodeImported = pathologyRequest.Episode;
        if (episodeImported != null)
        {
            if (viewModel.DiagnosisDiagnosisGridGridList != null)
            {
                foreach (var item in viewModel.DiagnosisDiagnosisGridGridList)
                {
                    var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.Episode = episodeImported;
                }
            }
        }

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

        var transDef = pathologyRequest.TransDef;
        PostScript_PathologyRequestMainForm(viewModel, pathologyRequest, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyRequest);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyRequest);
        AfterContextSaveScript_PathologyRequestMainForm(viewModel, pathologyRequest, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel, PathologyRequest pathologyRequest, TTObjectContext objectContext);
    partial void PostScript_PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyRequestMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._PathologyRequest.Episode;
        if (episode != null)
        {
            viewModel.DiagnosisDiagnosisGridGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.PathologyMaterialsGridList = viewModel._PathologyRequest.PathologyMaterials.OfType<PathologyMaterial>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.SKRSICDOYERLESIMYERIs = objectContext.LocalQuery<SKRSICDOYERLESIMYERI>().ToArray();
        viewModel.SKRSNumuneAlindigiDokununTemelOzelligis = objectContext.LocalQuery<SKRSNumuneAlindigiDokununTemelOzelligi>().ToArray();
        viewModel.SKRSNumuneAlinmaSeklis = objectContext.LocalQuery<SKRSNumuneAlinmaSekli>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDOYERLESIMYERIList", viewModel.SKRSICDOYERLESIMYERIs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlindigiDokununTemelOzelligiList", viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlinmaSekliList", viewModel.SKRSNumuneAlinmaSeklis);
    }
}
}


namespace Core.Models
{
    public partial class PathologyRequestMainFormViewModel
    {
        public TTObjectClasses.PathologyRequest _PathologyRequest
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] DiagnosisDiagnosisGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyMaterial[] PathologyMaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICDOYERLESIMYERI[] SKRSICDOYERLESIMYERIs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSNumuneAlindigiDokununTemelOzelligi[] SKRSNumuneAlindigiDokununTemelOzelligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSNumuneAlinmaSekli[] SKRSNumuneAlinmaSeklis
        {
            get;
            set;
        }
    }
}
