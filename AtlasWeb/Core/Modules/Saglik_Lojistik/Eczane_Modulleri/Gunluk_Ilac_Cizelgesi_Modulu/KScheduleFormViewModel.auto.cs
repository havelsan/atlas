//$A654816E
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
    public partial class KScheduleServiceController : Controller
{
    [HttpGet]
    public KScheduleFormViewModel KScheduleForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return KScheduleFormLoadInternal(input);
    }

    [HttpPost]
    public KScheduleFormViewModel KScheduleFormLoad(FormLoadInput input)
    {
        return KScheduleFormLoadInternal(input);
    }

    private KScheduleFormViewModel KScheduleFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ccbf6413-136b-4189-bbdf-ce1a1a4de6a2");
        var objectDefID = Guid.Parse("98befb68-75cc-4d99-b76b-55ed1721e254");
        var viewModel = new KScheduleFormViewModel();
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
                PreScript_KScheduleForm(viewModel, viewModel._KSchedule, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KSchedule = new KSchedule(objectContext);
                var entryStateID = Guid.Parse("2dc13622-ea16-4999-a45b-289d6b47bad0");
                viewModel._KSchedule.CurrentStateDefID = entryStateID;
                viewModel.StockActionOutDetailsGridList = new TTObjectClasses.KScheduleMaterial[]{};
                viewModel.UnSupplyGridGridList = new TTObjectClasses.KScheduleUnListMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KSchedule, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KSchedule, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._KSchedule);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._KSchedule);
                PreScript_KScheduleForm(viewModel, viewModel._KSchedule, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel KScheduleForm(KScheduleFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ccbf6413-136b-4189-bbdf-ce1a1a4de6a2");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.UnSupplyGridGridList);
            var entryStateID = Guid.Parse("2dc13622-ea16-4999-a45b-289d6b47bad0");
            objectContext.AddToRawObjectList(viewModel._KSchedule, entryStateID);
            objectContext.ProcessRawObjects(false);
            var kSchedule = (KSchedule)objectContext.GetLoadedObject(viewModel._KSchedule.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(kSchedule, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KSchedule, formDefID);
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

            if (viewModel.UnSupplyGridGridList != null)
            {
                foreach (var item in viewModel.UnSupplyGridGridList)
                {
                    var kScheduleUnListMaterialsImported = (KScheduleUnListMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)kScheduleUnListMaterialsImported).IsDeleted)
                        continue;
                    kScheduleUnListMaterialsImported.KSchedule = kSchedule;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(kSchedule);
            PostScript_KScheduleForm(viewModel, kSchedule, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kSchedule);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kSchedule);
            AfterContextSaveScript_KScheduleForm(viewModel, kSchedule, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_KScheduleForm(KScheduleFormViewModel viewModel, KSchedule kSchedule, TTObjectContext objectContext);
    partial void PostScript_KScheduleForm(KScheduleFormViewModel viewModel, KSchedule kSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_KScheduleForm(KScheduleFormViewModel viewModel, KSchedule kSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(KScheduleFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionOutDetailsGridList = viewModel._KSchedule.KScheduleMaterials.OfType<KScheduleMaterial>().ToArray();
        viewModel.UnSupplyGridGridList = viewModel._KSchedule.KScheduleUnListMaterials.OfType<KScheduleUnListMaterial>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomAndSubStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoresList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class KScheduleFormViewModel : BaseViewModel
    {
        public TTObjectClasses.KSchedule _KSchedule { get; set; }
        public TTObjectClasses.KScheduleMaterial[] StockActionOutDetailsGridList { get; set; }
        public TTObjectClasses.KScheduleUnListMaterial[] UnSupplyGridGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
    }
}
