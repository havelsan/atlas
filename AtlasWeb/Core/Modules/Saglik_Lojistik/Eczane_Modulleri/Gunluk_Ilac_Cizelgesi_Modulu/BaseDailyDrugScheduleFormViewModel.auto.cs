//$3B30D380
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
    public partial class DailyDrugScheduleServiceController : Controller
{
    [HttpGet]
    public BaseDailyDrugScheduleFormViewModel BaseDailyDrugScheduleForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseDailyDrugScheduleFormLoadInternal(input);
    }

    [HttpPost]
    public BaseDailyDrugScheduleFormViewModel BaseDailyDrugScheduleFormLoad(FormLoadInput input)
    {
        return BaseDailyDrugScheduleFormLoadInternal(input);
    }

    private BaseDailyDrugScheduleFormViewModel BaseDailyDrugScheduleFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c2557f81-98b0-441e-9c51-93050ed623c2");
        var objectDefID = Guid.Parse("2faf2b7b-63b1-40f6-8946-23ec393e0b4a");
        var viewModel = new BaseDailyDrugScheduleFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DailyDrugSchedule = objectContext.GetObject(id.Value, objectDefID) as DailyDrugSchedule;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DailyDrugSchedule, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DailyDrugSchedule, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DailyDrugSchedule);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DailyDrugSchedule);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseDailyDrugScheduleForm(viewModel, viewModel._DailyDrugSchedule, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseDailyDrugScheduleForm(BaseDailyDrugScheduleFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c2557f81-98b0-441e-9c51-93050ed623c2");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.DailyDrugPatients);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.DailyDrugPatientsGridGridList);
            objectContext.AddToRawObjectList(viewModel.DailyDrugSchOrdersGridGridList);
            objectContext.AddToRawObjectList(viewModel.DailyDrugUnDrugsGridGridList);
            objectContext.AddToRawObjectList(viewModel._DailyDrugSchedule);
            objectContext.ProcessRawObjects();
            var dailyDrugSchedule = (DailyDrugSchedule)objectContext.GetLoadedObject(viewModel._DailyDrugSchedule.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dailyDrugSchedule, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DailyDrugSchedule, formDefID);
            if (viewModel.DailyDrugPatientsGridGridList != null)
            {
                foreach (var item in viewModel.DailyDrugPatientsGridGridList)
                {
                    var dailyDrugPatientsImported = (DailyDrugPatient)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dailyDrugPatientsImported).IsDeleted)
                        continue;
                    dailyDrugPatientsImported.DailyDrugSchedule = dailyDrugSchedule;
                }
            }

            if (viewModel.DailyDrugSchOrdersGridGridList != null)
            {
                foreach (var item in viewModel.DailyDrugSchOrdersGridGridList)
                {
                    var dailyDrugSchOrdersImported = (DailyDrugSchOrder)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dailyDrugSchOrdersImported).IsDeleted)
                        continue;
                    dailyDrugSchOrdersImported.DailyDrugSchedule = dailyDrugSchedule;
                }
            }

            if (viewModel.DailyDrugUnDrugsGridGridList != null)
            {
                foreach (var item in viewModel.DailyDrugUnDrugsGridGridList)
                {
                    var dailyDrugUnDrugsImported = (DailyDrugUnDrug)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dailyDrugUnDrugsImported).IsDeleted)
                        continue;
                    dailyDrugUnDrugsImported.DailyDrugSchedule = dailyDrugSchedule;
                }
            }

            var transDef = dailyDrugSchedule.TransDef;
            PostScript_BaseDailyDrugScheduleForm(viewModel, dailyDrugSchedule, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dailyDrugSchedule);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dailyDrugSchedule);
            AfterContextSaveScript_BaseDailyDrugScheduleForm(viewModel, dailyDrugSchedule, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseDailyDrugScheduleForm(BaseDailyDrugScheduleFormViewModel viewModel, DailyDrugSchedule dailyDrugSchedule, TTObjectContext objectContext);
    partial void PostScript_BaseDailyDrugScheduleForm(BaseDailyDrugScheduleFormViewModel viewModel, DailyDrugSchedule dailyDrugSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseDailyDrugScheduleForm(BaseDailyDrugScheduleFormViewModel viewModel, DailyDrugSchedule dailyDrugSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseDailyDrugScheduleFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DailyDrugPatientsGridGridList = viewModel._DailyDrugSchedule.DailyDrugPatients.OfType<DailyDrugPatient>().ToArray();
        viewModel.DailyDrugSchOrdersGridGridList = viewModel._DailyDrugSchedule.DailyDrugSchOrders.OfType<DailyDrugSchOrder>().ToArray();
        viewModel.DailyDrugUnDrugsGridGridList = viewModel._DailyDrugSchedule.DailyDrugUnDrugs.OfType<DailyDrugUnDrug>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.DailyDrugPatients = objectContext.LocalQuery<DailyDrugPatient>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PharmacyStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomAndSubStoreList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class BaseDailyDrugScheduleFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DailyDrugSchedule _DailyDrugSchedule { get; set; }
        public TTObjectClasses.DailyDrugPatient[] DailyDrugPatientsGridGridList { get; set; }
        public TTObjectClasses.DailyDrugSchOrder[] DailyDrugSchOrdersGridGridList { get; set; }
        public TTObjectClasses.DailyDrugUnDrug[] DailyDrugUnDrugsGridGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.DailyDrugPatient[] DailyDrugPatients { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
