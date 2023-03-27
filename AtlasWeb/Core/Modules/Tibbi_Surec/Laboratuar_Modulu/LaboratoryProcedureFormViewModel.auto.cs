//$41103D10
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class LaboratoryProcedureServiceController : Controller
{
    [HttpGet]
    public LaboratoryProcedureFormViewModel LaboratoryProcedureForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return LaboratoryProcedureFormLoadInternal(input);
    }

    [HttpPost]
    public LaboratoryProcedureFormViewModel LaboratoryProcedureFormLoad(FormLoadInput input)
    {
        return LaboratoryProcedureFormLoadInternal(input);
    }

    private LaboratoryProcedureFormViewModel LaboratoryProcedureFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("445d43f5-6c8d-4938-9b69-fcf4f6e61fdb");
        var objectDefID = Guid.Parse("f87eac33-a91e-4934-a010-edf6029d2d18");
        var viewModel = new LaboratoryProcedureFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LaboratoryProcedure = objectContext.GetObject(id.Value, objectDefID) as LaboratoryProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._LaboratoryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._LaboratoryProcedure);
                PreScript_LaboratoryProcedureForm(viewModel, viewModel._LaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LaboratoryProcedure = new LaboratoryProcedure(objectContext);
                var entryStateID = Guid.Parse("5eaf4c46-c99e-491c-a880-37d07484437e");
                viewModel._LaboratoryProcedure.CurrentStateDefID = entryStateID;
                viewModel.GridSubProceduresGridList = new TTObjectClasses.LaboratorySubProcedure[]{};
                viewModel.MaterialsGridList = new TTObjectClasses.LaboratoryMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._LaboratoryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._LaboratoryProcedure);
                PreScript_LaboratoryProcedureForm(viewModel, viewModel._LaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void LaboratoryProcedureForm(LaboratoryProcedureFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("445d43f5-6c8d-4938-9b69-fcf4f6e61fdb");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResLaboratoryDepartments);
            objectContext.AddToRawObjectList(viewModel.LaboratoryRequests);
            objectContext.AddToRawObjectList(viewModel.ResLaboratoryEquipments);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.GridSubProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.MaterialsGridList);
            var entryStateID = Guid.Parse("5eaf4c46-c99e-491c-a880-37d07484437e");
            objectContext.AddToRawObjectList(viewModel._LaboratoryProcedure, entryStateID);
            objectContext.ProcessRawObjects();
            var laboratoryProcedure = (LaboratoryProcedure)objectContext.GetLoadedObject(viewModel._LaboratoryProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(laboratoryProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
            if (viewModel.GridSubProceduresGridList != null)
            {
                foreach (var item in viewModel.GridSubProceduresGridList)
                {
                    var laboratorySubProceduresImported = (LaboratorySubProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    laboratorySubProceduresImported.LaboratoryProcedure = laboratoryProcedure;
                }
            }

            if (viewModel.MaterialsGridList != null)
            {
                foreach (var item in viewModel.MaterialsGridList)
                {
                    var materialsImported = (LaboratoryMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    materialsImported.LaboratoryTest = laboratoryProcedure;
                }
            }

            var transDef = laboratoryProcedure.TransDef;
            PostScript_LaboratoryProcedureForm(viewModel, laboratoryProcedure, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_LaboratoryProcedureForm(viewModel, laboratoryProcedure, transDef, objectContext);
        }
    }

    partial void PreScript_LaboratoryProcedureForm(LaboratoryProcedureFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTObjectContext objectContext);
    partial void PostScript_LaboratoryProcedureForm(LaboratoryProcedureFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_LaboratoryProcedureForm(LaboratoryProcedureFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(LaboratoryProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridSubProceduresGridList = viewModel._LaboratoryProcedure.LaboratorySubProcedures.OfType<LaboratorySubProcedure>().ToArray();
        viewModel.MaterialsGridList = viewModel._LaboratoryProcedure.Materials.OfType<LaboratoryMaterial>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResLaboratoryDepartments = objectContext.LocalQuery<ResLaboratoryDepartment>().ToArray();
        viewModel.LaboratoryRequests = objectContext.LocalQuery<LaboratoryRequest>().ToArray();
        viewModel.ResLaboratoryEquipments = objectContext.LocalQuery<ResLaboratoryEquipment>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
    }
}
}

namespace Core.Models
{
    public partial class LaboratoryProcedureFormViewModel : BaseViewModel
    {
        public TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratorySubProcedure[] GridSubProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryMaterial[] MaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResLaboratoryDepartment[] ResLaboratoryDepartments
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryRequest[] LaboratoryRequests
        {
            get;
            set;
        }

        public TTObjectClasses.ResLaboratoryEquipment[] ResLaboratoryEquipments
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}