//$19E2CC66
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
    public partial class PathologyMaterialServiceController : Controller
{
    [HttpGet]
    public PathologyMaterialInfoViewModel PathologyMaterialInfo(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyMaterialInfoLoadInternal(input);
    }

    [HttpPost]
    public PathologyMaterialInfoViewModel PathologyMaterialInfoLoad(FormLoadInput input)
    {
        return PathologyMaterialInfoLoadInternal(input);
    }

    private PathologyMaterialInfoViewModel PathologyMaterialInfoLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c4a2f290-3a9f-4788-ad6c-f8ca9dc561ba");
        var objectDefID = Guid.Parse("6f1ac2cf-8a56-45c0-a383-690541cd7c4e");
        var viewModel = new PathologyMaterialInfoViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyMaterial = objectContext.GetObject(id.Value, objectDefID) as PathologyMaterial;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyMaterial, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyMaterial, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PathologyMaterial);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PathologyMaterial);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PathologyMaterialInfo(viewModel, viewModel._PathologyMaterial, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyMaterial = new PathologyMaterial(objectContext);
                var entryStateID = Guid.Parse("36ecf220-6d61-4a16-8cb9-7f877f1d0253");
                viewModel._PathologyMaterial.CurrentStateDefID = entryStateID;
                viewModel.PathologyTestProcedureGridList = new TTObjectClasses.PathologyTestProcedure[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyMaterial, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyMaterial, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PathologyMaterial);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PathologyMaterial);
                PreScript_PathologyMaterialInfo(viewModel, viewModel._PathologyMaterial, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyMaterialInfo(PathologyMaterialInfoViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c4a2f290-3a9f-4788-ad6c-f8ca9dc561ba");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSICDOYERLESIMYERIs);
            objectContext.AddToRawObjectList(viewModel.SKRSPatolojiPreparatiDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlinmaSeklis);
            objectContext.AddToRawObjectList(viewModel.SKRSICDOMORFOLOJIKODUs);
            objectContext.AddToRawObjectList(viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
            objectContext.AddToRawObjectList(viewModel.PathologyTestCategoryDefinitions);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.PathologyTestProcedureGridList);
            var entryStateID = Guid.Parse("36ecf220-6d61-4a16-8cb9-7f877f1d0253");
            objectContext.AddToRawObjectList(viewModel._PathologyMaterial, entryStateID);
            objectContext.ProcessRawObjects(false);
            var pathologyMaterial = (PathologyMaterial)objectContext.GetLoadedObject(viewModel._PathologyMaterial.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyMaterial, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyMaterial, formDefID);
            if (viewModel.PathologyTestProcedureGridList != null)
            {
                foreach (var item in viewModel.PathologyTestProcedureGridList)
                {
                    var pathologyTestProcedureImported = (PathologyTestProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)pathologyTestProcedureImported).IsDeleted)
                        continue;
                    pathologyTestProcedureImported.PathologyMaterial = pathologyMaterial;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(pathologyMaterial);
            PostScript_PathologyMaterialInfo(viewModel, pathologyMaterial, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyMaterial);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyMaterial);
            AfterContextSaveScript_PathologyMaterialInfo(viewModel, pathologyMaterial, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PathologyMaterialInfo(PathologyMaterialInfoViewModel viewModel, PathologyMaterial pathologyMaterial, TTObjectContext objectContext);
    partial void PostScript_PathologyMaterialInfo(PathologyMaterialInfoViewModel viewModel, PathologyMaterial pathologyMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyMaterialInfo(PathologyMaterialInfoViewModel viewModel, PathologyMaterial pathologyMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyMaterialInfoViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PathologyTestProcedureGridList = viewModel._PathologyMaterial.PathologyTestProcedure.OfType<PathologyTestProcedure>().ToArray();
        viewModel.SKRSICDOYERLESIMYERIs = objectContext.LocalQuery<SKRSICDOYERLESIMYERI>().ToArray();
        viewModel.SKRSPatolojiPreparatiDurumus = objectContext.LocalQuery<SKRSPatolojiPreparatiDurumu>().ToArray();
        viewModel.SKRSNumuneAlinmaSeklis = objectContext.LocalQuery<SKRSNumuneAlinmaSekli>().ToArray();
        viewModel.SKRSICDOMORFOLOJIKODUs = objectContext.LocalQuery<SKRSICDOMORFOLOJIKODU>().ToArray();
        viewModel.SKRSNumuneAlindigiDokununTemelOzelligis = objectContext.LocalQuery<SKRSNumuneAlindigiDokununTemelOzelligi>().ToArray();
        viewModel.PathologyTestCategoryDefinitions = objectContext.LocalQuery<PathologyTestCategoryDefinition>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDOYERLESIMYERIList", viewModel.SKRSICDOYERLESIMYERIs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPatolojiPreparatiDurumuList", viewModel.SKRSPatolojiPreparatiDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlinmaSekliList", viewModel.SKRSNumuneAlinmaSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDOMORFOLOJIKODUList", viewModel.SKRSICDOMORFOLOJIKODUs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSNumuneAlindigiDokununTemelOzelligiList", viewModel.SKRSNumuneAlindigiDokununTemelOzelligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PathologyTestCategoryList", viewModel.PathologyTestCategoryDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PathologyTestListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class PathologyMaterialInfoViewModel : BaseViewModel
    {
        public TTObjectClasses.PathologyMaterial _PathologyMaterial { get; set; }
        public TTObjectClasses.PathologyTestProcedure[] PathologyTestProcedureGridList { get; set; }
        public TTObjectClasses.SKRSICDOYERLESIMYERI[] SKRSICDOYERLESIMYERIs { get; set; }
        public TTObjectClasses.SKRSPatolojiPreparatiDurumu[] SKRSPatolojiPreparatiDurumus { get; set; }
        public TTObjectClasses.SKRSNumuneAlinmaSekli[] SKRSNumuneAlinmaSeklis { get; set; }
        public TTObjectClasses.SKRSICDOMORFOLOJIKODU[] SKRSICDOMORFOLOJIKODUs { get; set; }
        public TTObjectClasses.SKRSNumuneAlindigiDokununTemelOzelligi[] SKRSNumuneAlindigiDokununTemelOzelligis { get; set; }
        public TTObjectClasses.PathologyTestCategoryDefinition[] PathologyTestCategoryDefinitions { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
