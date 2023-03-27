//$46413C98
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
    public partial class PhysiotherapyDefinitionServiceController : Controller
{
    [HttpGet]
    public PhysiotherapyDefinitionFormViewModel PhysiotherapyDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PhysiotherapyDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public PhysiotherapyDefinitionFormViewModel PhysiotherapyDefinitionFormLoad(FormLoadInput input)
    {
        return PhysiotherapyDefinitionFormLoadInternal(input);
    }

    private PhysiotherapyDefinitionFormViewModel PhysiotherapyDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c884bde1-7e5a-4d32-8fa1-0be065ba6329");
        var objectDefID = Guid.Parse("887e25df-9f74-4dfb-a28b-3b45e1c34ae2");
        var viewModel = new PhysiotherapyDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyDefinition = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PhysiotherapyDefinitionForm(viewModel, viewModel._PhysiotherapyDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyDefinition = new PhysiotherapyDefinition(objectContext);
                viewModel.TreatmentUnitsGridList = new TTObjectClasses.PhysiotherapyTreatmentUnitGrid[]{};
                viewModel.TreatmentRoomsGridList = new TTObjectClasses.PhysiotherapyTreatmentRoomGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysiotherapyDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysiotherapyDefinition);
                PreScript_PhysiotherapyDefinitionForm(viewModel, viewModel._PhysiotherapyDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PhysiotherapyDefinitionForm(PhysiotherapyDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PhysiotherapyDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PhysiotherapyDefinitionFormInternal(PhysiotherapyDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c884bde1-7e5a-4d32-8fa1-0be065ba6329");
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
        objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisRooms);
        objectContext.AddToRawObjectList(viewModel.TreatmentUnitsGridList);
        objectContext.AddToRawObjectList(viewModel.TreatmentRoomsGridList);
        objectContext.AddToRawObjectList(viewModel._PhysiotherapyDefinition);
        objectContext.ProcessRawObjects();
        var physiotherapyDefinition = (PhysiotherapyDefinition)objectContext.GetLoadedObject(viewModel._PhysiotherapyDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyDefinition, formDefID);
        if (viewModel.TreatmentUnitsGridList != null)
        {
            foreach (var item in viewModel.TreatmentUnitsGridList)
            {
                var treatmentUnitsImported = (PhysiotherapyTreatmentUnitGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)treatmentUnitsImported).IsDeleted)
                    continue;
                treatmentUnitsImported.PhysiotherapyDefinition = physiotherapyDefinition;
            }
        }

        if (viewModel.TreatmentRoomsGridList != null)
        {
            foreach (var item in viewModel.TreatmentRoomsGridList)
            {
                var treatmentRoomsImported = (PhysiotherapyTreatmentRoomGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)treatmentRoomsImported).IsDeleted)
                    continue;
                treatmentRoomsImported.PhysiotherapyDefinition = physiotherapyDefinition;
            }
        }

        var transDef = physiotherapyDefinition.TransDef;
        PostScript_PhysiotherapyDefinitionForm(viewModel, physiotherapyDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyDefinition);
        AfterContextSaveScript_PhysiotherapyDefinitionForm(viewModel, physiotherapyDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PhysiotherapyDefinitionForm(PhysiotherapyDefinitionFormViewModel viewModel, PhysiotherapyDefinition physiotherapyDefinition, TTObjectContext objectContext);
    partial void PostScript_PhysiotherapyDefinitionForm(PhysiotherapyDefinitionFormViewModel viewModel, PhysiotherapyDefinition physiotherapyDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PhysiotherapyDefinitionForm(PhysiotherapyDefinitionFormViewModel viewModel, PhysiotherapyDefinition physiotherapyDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PhysiotherapyDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.TreatmentUnitsGridList = viewModel._PhysiotherapyDefinition.TreatmentUnits.OfType<PhysiotherapyTreatmentUnitGrid>().ToArray();
        viewModel.TreatmentRoomsGridList = viewModel._PhysiotherapyDefinition.TreatmentRooms.OfType<PhysiotherapyTreatmentRoomGrid>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.ResTreatmentDiagnosisUnits = objectContext.LocalQuery<ResTreatmentDiagnosisUnit>().ToArray();
        viewModel.ResTreatmentDiagnosisRooms = objectContext.LocalQuery<ResTreatmentDiagnosisRoom>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentDiagnosisUnitListDefinition", viewModel.ResTreatmentDiagnosisUnits);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentDiagnosisRoomListDefinition", viewModel.ResTreatmentDiagnosisRooms);
    }
}
}


namespace Core.Models
{
    public partial class PhysiotherapyDefinitionFormViewModel
    {
        public TTObjectClasses.PhysiotherapyDefinition _PhysiotherapyDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.PhysiotherapyTreatmentUnitGrid[] TreatmentUnitsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PhysiotherapyTreatmentRoomGrid[] TreatmentRoomsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResTreatmentDiagnosisUnit[] ResTreatmentDiagnosisUnits
        {
            get;
            set;
        }

        public TTObjectClasses.ResTreatmentDiagnosisRoom[] ResTreatmentDiagnosisRooms
        {
            get;
            set;
        }
    }
}
