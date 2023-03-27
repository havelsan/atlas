//$4C827E70
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
    public AnesthesiaReportFormViewModel AnesthesiaReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AnesthesiaReportFormLoadInternal(input);
    }

    [HttpPost]
    public AnesthesiaReportFormViewModel AnesthesiaReportFormLoad(FormLoadInput input)
    {
        return AnesthesiaReportFormLoadInternal(input);
    }

    private AnesthesiaReportFormViewModel AnesthesiaReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9b2b8edc-51c7-4b0a-96ef-7fcebe42c528");
        var objectDefID = Guid.Parse("240cc318-843b-4302-a944-0b9ac2e9edb8");
        var viewModel = new AnesthesiaReportFormViewModel();
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
                PreScript_AnesthesiaReportForm(viewModel, viewModel._AnesthesiaAndReanimation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AnesthesiaAndReanimation = new AnesthesiaAndReanimation(objectContext);
                var entryStateID = Guid.Parse("19951b61-fcf0-4343-9757-9c628fe8469d");
                viewModel._AnesthesiaAndReanimation.CurrentStateDefID = entryStateID;
                viewModel.GridSurgeryProceduresGridList = new TTObjectClasses.SurgeryProcedure[]{};
                viewModel.GridAnesthesiaPersonnelsGridList = new TTObjectClasses.AnesthesiaPersonnel[]{};
                viewModel.GridAnesthesiaProceduresGridList = new TTObjectClasses.AnesthesiaProcedure[]{};
                viewModel.GridAnesthesiaExpendsGridList = new TTObjectClasses.AnesthesiaAndReanimationTreatmentMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AnesthesiaAndReanimation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaAndReanimation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AnesthesiaAndReanimation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AnesthesiaAndReanimation);
                PreScript_AnesthesiaReportForm(viewModel, viewModel._AnesthesiaAndReanimation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AnesthesiaReportForm(AnesthesiaReportFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9b2b8edc-51c7-4b0a-96ef-7fcebe42c528");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Surgerys);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryRooms);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryDesks);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.GridSurgeryProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.GridAnesthesiaPersonnelsGridList);
            objectContext.AddToRawObjectList(viewModel.GridAnesthesiaProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.GridAnesthesiaExpendsGridList);
            var entryStateID = Guid.Parse("19951b61-fcf0-4343-9757-9c628fe8469d");
            objectContext.AddToRawObjectList(viewModel._AnesthesiaAndReanimation, entryStateID);
            objectContext.ProcessRawObjects(false);
            var anesthesiaAndReanimation = (AnesthesiaAndReanimation)objectContext.GetLoadedObject(viewModel._AnesthesiaAndReanimation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(anesthesiaAndReanimation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaAndReanimation, formDefID);
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

            if (viewModel.GridAnesthesiaPersonnelsGridList != null)
            {
                foreach (var item in viewModel.GridAnesthesiaPersonnelsGridList)
                {
                    var anesthesiaPersonnelsImported = (AnesthesiaPersonnel)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)anesthesiaPersonnelsImported).IsDeleted)
                        continue;
                    anesthesiaPersonnelsImported.AnesthesiaAndReanimation = anesthesiaAndReanimation;
                }
            }

            if (viewModel.GridAnesthesiaProceduresGridList != null)
            {
                foreach (var item in viewModel.GridAnesthesiaProceduresGridList)
                {
                    var anaesthesiaAndReanimationAnesthesiaProceduresImported = (AnesthesiaProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)anaesthesiaAndReanimationAnesthesiaProceduresImported).IsDeleted)
                        continue;
                    anaesthesiaAndReanimationAnesthesiaProceduresImported.AnaesthesiaAndReanimation = anesthesiaAndReanimation;
                }
            }

            if (viewModel.GridAnesthesiaExpendsGridList != null)
            {
                foreach (var item in viewModel.GridAnesthesiaExpendsGridList)
                {
                    var anestheAndReaniTreatMatrialsImported = (AnesthesiaAndReanimationTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)anestheAndReaniTreatMatrialsImported).IsDeleted)
                        continue;
                    anestheAndReaniTreatMatrialsImported.AnesthesiaAndReanimation = anesthesiaAndReanimation;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(anesthesiaAndReanimation);
            PostScript_AnesthesiaReportForm(viewModel, anesthesiaAndReanimation, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(anesthesiaAndReanimation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(anesthesiaAndReanimation);
            AfterContextSaveScript_AnesthesiaReportForm(viewModel, anesthesiaAndReanimation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AnesthesiaReportForm(AnesthesiaReportFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTObjectContext objectContext);
    partial void PostScript_AnesthesiaReportForm(AnesthesiaReportFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AnesthesiaReportForm(AnesthesiaReportFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AnesthesiaReportFormViewModel viewModel, TTObjectContext objectContext)
    {
        var mainSurgery = viewModel._AnesthesiaAndReanimation.MainSurgery;
        if (mainSurgery != null)
        {
            viewModel.GridSurgeryProceduresGridList = mainSurgery.SurgeryProcedures.OfType<SurgeryProcedure>().ToArray();
        }

        viewModel.GridAnesthesiaPersonnelsGridList = viewModel._AnesthesiaAndReanimation.AnesthesiaPersonnels.OfType<AnesthesiaPersonnel>().ToArray();
        viewModel.GridAnesthesiaProceduresGridList = viewModel._AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures.OfType<AnesthesiaProcedure>().ToArray();
        viewModel.GridAnesthesiaExpendsGridList = viewModel._AnesthesiaAndReanimation.AnestheAndReaniTreatMatrials.OfType<AnesthesiaAndReanimationTreatmentMaterial>().ToArray();
        viewModel.Surgerys = objectContext.LocalQuery<Surgery>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResSurgeryRooms = objectContext.LocalQuery<ResSurgeryRoom>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        viewModel.ResSurgeryDesks = objectContext.LocalQuery<ResSurgeryDesk>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRoomListDefinition", viewModel.ResSurgeryRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryDeskListDefinition", viewModel.ResSurgeryDesks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AnaesthesiaTeamListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AnesthesiaListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
    }
}
}


namespace Core.Models
{
    public partial class AnesthesiaReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation { get; set; }
        public TTObjectClasses.SurgeryProcedure[] GridSurgeryProceduresGridList { get; set; }
        public TTObjectClasses.AnesthesiaPersonnel[] GridAnesthesiaPersonnelsGridList { get; set; }
        public TTObjectClasses.AnesthesiaProcedure[] GridAnesthesiaProceduresGridList { get; set; }
        public TTObjectClasses.AnesthesiaAndReanimationTreatmentMaterial[] GridAnesthesiaExpendsGridList { get; set; }
        public TTObjectClasses.Surgery[] Surgerys { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResSurgeryRoom[] ResSurgeryRooms { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis { get; set; }
        public TTObjectClasses.ResSurgeryDesk[] ResSurgeryDesks { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.MalzemeTuru[] MalzemeTurus { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
    }
}
