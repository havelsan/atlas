//$AEF2A40E
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
    public partial class NuclearMedicineTestDefinitionServiceController : Controller
{
    [HttpGet]
    public NuclearMedicineTestDefinitionFormViewModel NuclearMedicineTestDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineTestDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineTestDefinitionFormViewModel NuclearMedicineTestDefinitionFormLoad(FormLoadInput input)
    {
        return NuclearMedicineTestDefinitionFormLoadInternal(input);
    }

    private NuclearMedicineTestDefinitionFormViewModel NuclearMedicineTestDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3a07c719-9877-4c50-b3fc-938563111ab6");
        var objectDefID = Guid.Parse("c8f0ec5a-969b-458e-9f5c-fdd67db7a42f");
        var viewModel = new NuclearMedicineTestDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NuclearMedicineTestDefinition = objectContext.GetObject(id.Value, objectDefID) as NuclearMedicineTestDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NuclearMedicineTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicineTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NuclearMedicineTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NuclearMedicineTestDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NuclearMedicineTestDefinitionForm(viewModel, viewModel._NuclearMedicineTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NuclearMedicineTestDefinition = new NuclearMedicineTestDefinition(objectContext);
                viewModel.ttgrid1GridList = new TTObjectClasses.NucMedTabNamesGrid[]{};
                viewModel.ttgrid4GridList = new TTObjectClasses.NuclearMedicineGridEquipmentDefinition[]{};
                viewModel.ttgrid3GridList = new TTObjectClasses.NuclearMedicineGridPharmDefinition[]{};
                viewModel.ttgrid2GridList = new TTObjectClasses.NuclearMedicineGridMaterialDefinition[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NuclearMedicineTestDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicineTestDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NuclearMedicineTestDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NuclearMedicineTestDefinition);
                PreScript_NuclearMedicineTestDefinitionForm(viewModel, viewModel._NuclearMedicineTestDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineTestDefinitionForm(NuclearMedicineTestDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineTestDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineTestDefinitionFormInternal(NuclearMedicineTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3a07c719-9877-4c50-b3fc-938563111ab6");
            objectContext.AddToRawObjectList(viewModel.SKRSLOINCs);
            objectContext.AddToRawObjectList(viewModel.NucMedTestGroupDefs);
        objectContext.AddToRawObjectList(viewModel.ResNuclearMedicineEquipments);
        objectContext.AddToRawObjectList(viewModel.RadioPharmaceuticalDefinitions);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid4GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid3GridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
        objectContext.AddToRawObjectList(viewModel._NuclearMedicineTestDefinition);
        objectContext.ProcessRawObjects();
        var nuclearMedicineTestDefinition = (NuclearMedicineTestDefinition)objectContext.GetLoadedObject(viewModel._NuclearMedicineTestDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nuclearMedicineTestDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicineTestDefinition, formDefID);
        if (viewModel.ttgrid1GridList != null)
        {
            foreach (var item in viewModel.ttgrid1GridList)
            {
                var tabsBelongToImported = (NucMedTabNamesGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)tabsBelongToImported).IsDeleted)
                    continue;
                tabsBelongToImported.NuclearMedicineTest = nuclearMedicineTestDefinition;
            }
        }

        if (viewModel.ttgrid4GridList != null)
        {
            foreach (var item in viewModel.ttgrid4GridList)
            {
                var equipmentsImported = (NuclearMedicineGridEquipmentDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)equipmentsImported).IsDeleted)
                    continue;
                equipmentsImported.NuclearMedicineTest = nuclearMedicineTestDefinition;
            }
        }

        if (viewModel.ttgrid3GridList != null)
        {
            foreach (var item in viewModel.ttgrid3GridList)
            {
                var pharmMaterialsImported = (NuclearMedicineGridPharmDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pharmMaterialsImported).IsDeleted)
                    continue;
                pharmMaterialsImported.NuclearMedicineTestDefinition = nuclearMedicineTestDefinition;
            }
        }

        if (viewModel.ttgrid2GridList != null)
        {
            foreach (var item in viewModel.ttgrid2GridList)
            {
                var materialsImported = (NuclearMedicineGridMaterialDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)materialsImported).IsDeleted)
                    continue;
                materialsImported.NuclearMedicineTest = nuclearMedicineTestDefinition;
            }
        }

        var transDef = nuclearMedicineTestDefinition.TransDef;
        PostScript_NuclearMedicineTestDefinitionForm(viewModel, nuclearMedicineTestDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicineTestDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicineTestDefinition);
        AfterContextSaveScript_NuclearMedicineTestDefinitionForm(viewModel, nuclearMedicineTestDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineTestDefinitionForm(NuclearMedicineTestDefinitionFormViewModel viewModel, NuclearMedicineTestDefinition nuclearMedicineTestDefinition, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineTestDefinitionForm(NuclearMedicineTestDefinitionFormViewModel viewModel, NuclearMedicineTestDefinition nuclearMedicineTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineTestDefinitionForm(NuclearMedicineTestDefinitionFormViewModel viewModel, NuclearMedicineTestDefinition nuclearMedicineTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgrid1GridList = viewModel._NuclearMedicineTestDefinition.TabsBelongTo.OfType<NucMedTabNamesGrid>().ToArray();
        viewModel.ttgrid4GridList = viewModel._NuclearMedicineTestDefinition.Equipments.OfType<NuclearMedicineGridEquipmentDefinition>().ToArray();
        viewModel.ttgrid3GridList = viewModel._NuclearMedicineTestDefinition.PharmMaterials.OfType<NuclearMedicineGridPharmDefinition>().ToArray();
        viewModel.ttgrid2GridList = viewModel._NuclearMedicineTestDefinition.Materials.OfType<NuclearMedicineGridMaterialDefinition>().ToArray();
            viewModel.SKRSLOINCs = objectContext.LocalQuery<SKRSLOINC>().ToArray();
            viewModel.NucMedTestGroupDefs = objectContext.LocalQuery<NucMedTestGroupDef>().ToArray();
        viewModel.ResNuclearMedicineEquipments = objectContext.LocalQuery<ResNuclearMedicineEquipment>().ToArray();
        viewModel.RadioPharmaceuticalDefinitions = objectContext.LocalQuery<RadioPharmaceuticalDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSLOINCList", viewModel.SKRSLOINCs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NucMedTestGroupListDefinition", viewModel.NucMedTestGroupDefs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NucMedEquipmntListDefinition", viewModel.ResNuclearMedicineEquipments);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadioPharmaceuticalListDef", viewModel.RadioPharmaceuticalDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineTestDefinitionFormViewModel
    {
        public TTObjectClasses.NuclearMedicineTestDefinition _NuclearMedicineTestDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.NucMedTabNamesGrid[] ttgrid1GridList
        {
            get;
            set;
        }

        public TTObjectClasses.NuclearMedicineGridEquipmentDefinition[] ttgrid4GridList
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSLOINC[] SKRSLOINCs
        {
            get;
            set;
        }
        public TTObjectClasses.NuclearMedicineGridPharmDefinition[] ttgrid3GridList
        {
            get;
            set;
        }

        public TTObjectClasses.NuclearMedicineGridMaterialDefinition[] ttgrid2GridList
        {
            get;
            set;
        }

        public TTObjectClasses.NucMedTestGroupDef[] NucMedTestGroupDefs
        {
            get;
            set;
        }

        public TTObjectClasses.ResNuclearMedicineEquipment[] ResNuclearMedicineEquipments
        {
            get;
            set;
        }

        public TTObjectClasses.RadioPharmaceuticalDefinition[] RadioPharmaceuticalDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }
    }
}
