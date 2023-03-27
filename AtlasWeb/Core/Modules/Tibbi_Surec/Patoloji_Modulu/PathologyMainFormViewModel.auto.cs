//$2E5C247E
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
    public partial class PathologyServiceController : Controller
{
    [HttpGet]
    public PathologyMainFormViewModel PathologyMainForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyMainFormLoadInternal(input);
    }

    [HttpPost]
    public PathologyMainFormViewModel PathologyMainFormLoad(FormLoadInput input)
    {
        return PathologyMainFormLoadInternal(input);
    }

    private PathologyMainFormViewModel PathologyMainFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("88f1cb01-d5e3-41af-b964-48a2c9565c62");
        var objectDefID = Guid.Parse("01e7562e-b24d-4f7b-8fd8-21f6079ccb51");
        var viewModel = new PathologyMainFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Pathology = objectContext.GetObject(id.Value, objectDefID) as Pathology;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Pathology, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pathology, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Pathology);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Pathology);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PathologyMainForm(viewModel, viewModel._Pathology, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Pathology = new Pathology(objectContext);
                var entryStateID = Guid.Parse("61ba736a-0a59-44bd-9e6d-261256f0f372");
                viewModel._Pathology.CurrentStateDefID = entryStateID;
                viewModel.PathologyPanicAlertGridList = new TTObjectClasses.PathologyPanicAlert[]{};
                viewModel.PathologyAdditionalReportGridList = new TTObjectClasses.PathologyAdditionalReport[]{};
                viewModel.DiagnosisDiagnosisGridGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.PathologyMaterialGridList = new TTObjectClasses.PathologyMaterial[]{};
                viewModel.TreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Pathology, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pathology, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Pathology);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Pathology);
                PreScript_PathologyMainForm(viewModel, viewModel._Pathology, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyMainForm(PathologyMainFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PathologyMainFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PathologyMainFormInternal(PathologyMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("88f1cb01-d5e3-41af-b964-48a2c9565c62");
        objectContext.AddToRawObjectList(viewModel.PathologyPanicReasonDefs);
        objectContext.AddToRawObjectList(viewModel.PathologyRequests);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.SKRSICDOYERLESIMYERIs);
        objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
        objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlinmaSeklis);
        objectContext.AddToRawObjectList(viewModel.SKRSPatolojiPreparatiDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSICDOMORFOLOJIKODUs);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.StockCards);
        objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.PathologyPanicAlertGridList);
        objectContext.AddToRawObjectList(viewModel.PathologyAdditionalReportGridList);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDiagnosisGridGridList);
        objectContext.AddToRawObjectList(viewModel.PathologyMaterialGridList);
        objectContext.AddToRawObjectList(viewModel.TreatmentMaterialsGridList);
        var entryStateID = Guid.Parse("61ba736a-0a59-44bd-9e6d-261256f0f372");
        objectContext.AddToRawObjectList(viewModel._Pathology, entryStateID);
        objectContext.ProcessRawObjects(false);
        var pathology = (Pathology)objectContext.GetLoadedObject(viewModel._Pathology.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathology, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pathology, formDefID);
        //if (viewModel.PathologyPanicAlertGridList != null)
        //{
        //    foreach (var item in viewModel.PathologyPanicAlertGridList)
        //    {
        //        var pathologyPanicAlertImported = (PathologyPanicAlert)objectContext.GetLoadedObject(item.ObjectID);
        //        if (((ITTObject)pathologyPanicAlertImported).IsDeleted)
        //            continue;
        //        pathologyPanicAlertImported.Pathology = pathology;
        //    }
        //}

        //if (viewModel.PathologyAdditionalReportGridList != null)
        //{
        //    foreach (var item in viewModel.PathologyAdditionalReportGridList)
        //    {
        //        var pathologyAdditionalReportImported = (PathologyAdditionalReport)objectContext.GetLoadedObject(item.ObjectID);
        //        if (((ITTObject)pathologyAdditionalReportImported).IsDeleted)
        //            continue;
        //        pathologyAdditionalReportImported.Pathology = pathology;
        //    }
        //}

        var episodeImported = pathology.Episode;
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

        if (viewModel.PathologyMaterialGridList != null)
        {
            foreach (var item in viewModel.PathologyMaterialGridList)
            {
                var pathologyMaterialImported = (PathologyMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pathologyMaterialImported).IsDeleted)
                    continue;
                pathologyMaterialImported.Pathology = pathology;
            }
        }

        if (viewModel.TreatmentMaterialsGridList != null)
        {
            foreach (var item in viewModel.TreatmentMaterialsGridList)
            {
                var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                    continue;
                treatmentMaterialsImported.EpisodeAction = pathology;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(pathology);
        PostScript_PathologyMainForm(viewModel, pathology, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathology);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathology);
        AfterContextSaveScript_PathologyMainForm(viewModel, pathology, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PathologyMainForm(PathologyMainFormViewModel viewModel, Pathology pathology, TTObjectContext objectContext);
    partial void PostScript_PathologyMainForm(PathologyMainFormViewModel viewModel, Pathology pathology, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyMainForm(PathologyMainFormViewModel viewModel, Pathology pathology, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        //viewModel.PathologyPanicAlertGridList = viewModel._Pathology.PathologyPanicAlert.OfType<PathologyPanicAlert>().ToArray();
        //viewModel.PathologyAdditionalReportGridList = viewModel._Pathology.PathologyAdditionalReport.OfType<PathologyAdditionalReport>().ToArray();
        var episode = viewModel._Pathology.Episode;
        if (episode != null)
        {
            viewModel.DiagnosisDiagnosisGridGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.PathologyMaterialGridList = viewModel._Pathology.PathologyMaterial.OfType<PathologyMaterial>().ToArray();
        viewModel.TreatmentMaterialsGridList = viewModel._Pathology.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.PathologyPanicReasonDefs = objectContext.LocalQuery<PathologyPanicReasonDef>().ToArray();
        viewModel.Pathologys = objectContext.LocalQuery<Pathology>().ToArray();
        viewModel.PathologyRequests = objectContext.LocalQuery<PathologyRequest>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.SKRSICDOYERLESIMYERIs = objectContext.LocalQuery<SKRSICDOYERLESIMYERI>().ToArray();
        viewModel.SKRSNumuneAlindigiDokununTemelOzelligis = objectContext.LocalQuery<SKRSNumuneAlindigiDokununTemelOzelligi>().ToArray();
        viewModel.SKRSNumuneAlinmaSeklis = objectContext.LocalQuery<SKRSNumuneAlinmaSekli>().ToArray();
        viewModel.SKRSPatolojiPreparatiDurumus = objectContext.LocalQuery<SKRSPatolojiPreparatiDurumu>().ToArray();
        viewModel.SKRSICDOMORFOLOJIKODUs = objectContext.LocalQuery<SKRSICDOMORFOLOJIKODU>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PathologyPanicListDef", viewModel.PathologyPanicReasonDefs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisDefinitionList", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDOYERLESIMYERIList", viewModel.SKRSICDOYERLESIMYERIs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlindigiDokununTemelOzelligiList", viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlinmaSekliList", viewModel.SKRSNumuneAlinmaSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPatolojiPreparatiDurumuList", viewModel.SKRSPatolojiPreparatiDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDOMORFOLOJIKODUList", viewModel.SKRSICDOMORFOLOJIKODUs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class PathologyMainFormViewModel
    {
        public TTObjectClasses.Pathology _Pathology
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyPanicAlert[] PathologyPanicAlertGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyAdditionalReport[] PathologyAdditionalReportGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] DiagnosisDiagnosisGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyMaterial[] PathologyMaterialGridList
        {
            get;
            set;
        }

        public TTObjectClasses.BaseTreatmentMaterial[] TreatmentMaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyPanicReasonDef[] PathologyPanicReasonDefs
        {
            get;
            set;
        }

        public TTObjectClasses.Pathology[] Pathologys
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyRequest[] PathologyRequests
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

        public TTObjectClasses.SKRSPatolojiPreparatiDurumu[] SKRSPatolojiPreparatiDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICDOMORFOLOJIKODU[] SKRSICDOMORFOLOJIKODUs
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
        {
            get;
            set;
        }
    }
}
