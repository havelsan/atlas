//$DA877B5E
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class KScheduleServiceController : Controller
{
    [HttpGet]
    public KScheduleCompletedFormViewModel KScheduleCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return KScheduleCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public KScheduleCompletedFormViewModel KScheduleCompletedFormLoad(FormLoadInput input)
    {
        return KScheduleCompletedFormLoadInternal(input);
    }

    private KScheduleCompletedFormViewModel KScheduleCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("50c52224-8455-459e-a8f8-17fb6d76dc46");
        var objectDefID = Guid.Parse("98befb68-75cc-4d99-b76b-55ed1721e254");
        var viewModel = new KScheduleCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KSchedule = objectContext.GetObject(id.Value, objectDefID) as KSchedule;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KSchedule, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KSchedule, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._KSchedule);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._KSchedule);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_KScheduleCompletedForm(viewModel, viewModel._KSchedule, objectContext);
                if (viewModel._KSchedule.KSchedulePatienOwnDrugs != null)
                {
                    List<Material> MaterialOwns = new List<Material>();
                    foreach (KSchedulePatienOwnDrug ownDrug in viewModel._KSchedule.KSchedulePatienOwnDrugs)
                    {
                        MaterialOwns.Add(ownDrug.Material);
                    }

                    foreach (Material mat in viewModel.Materials)
                    {
                        MaterialOwns.Add(mat);
                    }

                    viewModel.Materials = MaterialOwns.ToArray();
                }

                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel KScheduleCompletedForm(KScheduleCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("50c52224-8455-459e-a8f8-17fb6d76dc46");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.KSchedulePatienOwnDrugsGridList);
            objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
            objectContext.AddToRawObjectList(viewModel._KSchedule);
            objectContext.ProcessRawObjects();
            var kSchedule = (KSchedule)objectContext.GetLoadedObject(viewModel._KSchedule.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(kSchedule, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KSchedule, formDefID);
            if (viewModel.KSchedulePatienOwnDrugsGridList != null)
            {
                foreach (var item in viewModel.KSchedulePatienOwnDrugsGridList)
                {
                    var kSchedulePatienOwnDrugsImported = (KSchedulePatienOwnDrug)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)kSchedulePatienOwnDrugsImported).IsDeleted)
                        continue;
                    kSchedulePatienOwnDrugsImported.KSchedule = kSchedule;
                }
            }

            if (viewModel.StockActionOutDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionOutDetailsGridList)
                {
                    var kScheduleMaterialsImported = (KScheduleMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)kScheduleMaterialsImported).IsDeleted)
                        continue;
                    kScheduleMaterialsImported.StockAction = kSchedule;
                }
            }

            if (viewModel.ttgrid2GridList != null)
            {
                foreach (var item in viewModel.ttgrid2GridList)
                {
                    var kScheduleUnListMaterialsImported = (KScheduleUnListMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)kScheduleUnListMaterialsImported).IsDeleted)
                        continue;
                    kScheduleUnListMaterialsImported.KSchedule = kSchedule;
                }
            }

            var transDef = kSchedule.TransDef;
            PostScript_KScheduleCompletedForm(viewModel, kSchedule, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kSchedule);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kSchedule);
            AfterContextSaveScript_KScheduleCompletedForm(viewModel, kSchedule, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_KScheduleCompletedForm(KScheduleCompletedFormViewModel viewModel, KSchedule kSchedule, TTObjectContext objectContext);
    partial void PostScript_KScheduleCompletedForm(KScheduleCompletedFormViewModel viewModel, KSchedule kSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_KScheduleCompletedForm(KScheduleCompletedFormViewModel viewModel, KSchedule kSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(KScheduleCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.KSchedulePatienOwnDrugsGridList = viewModel._KSchedule.KSchedulePatienOwnDrugs.OfType<KSchedulePatienOwnDrug>().ToArray();
        viewModel.StockActionOutDetailsGridList = viewModel._KSchedule.KScheduleMaterials.OfType<KScheduleMaterial>().ToArray();
        viewModel.ttgrid2GridList = viewModel._KSchedule.KScheduleUnListMaterials.OfType<KScheduleUnListMaterial>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomAndSubStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoresList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class KScheduleCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.KSchedulePatienOwnDrug[] KSchedulePatienOwnDrugsGridList { get; set; }
        public TTObjectClasses.KSchedule _KSchedule { get; set; }
        public TTObjectClasses.KScheduleMaterial[] StockActionOutDetailsGridList { get; set; }
        public TTObjectClasses.KScheduleUnListMaterial[] ttgrid2GridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
