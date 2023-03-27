//$4E520AA5
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
    public partial class NursingLegMeasurementServiceController : Controller
{
    [HttpGet]
    public NursingLegMeasurementFormViewModel NursingLegMeasurementForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingLegMeasurementFormLoadInternal(input);
    }

    [HttpPost]
    public NursingLegMeasurementFormViewModel NursingLegMeasurementFormLoad(FormLoadInput input)
    {
        return NursingLegMeasurementFormLoadInternal(input);
    }

    private NursingLegMeasurementFormViewModel NursingLegMeasurementFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("b7f74f05-5fd3-4dba-b550-d801e6120f96");
        var objectDefID = Guid.Parse("2542af50-dd96-47a3-8e6c-d479d183c6a9");
        var viewModel = new NursingLegMeasurementFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingLegMeasurement = objectContext.GetObject(id.Value, objectDefID) as NursingLegMeasurement;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingLegMeasurement, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingLegMeasurement, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingLegMeasurement);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingLegMeasurement);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingLegMeasurementForm(viewModel, viewModel._NursingLegMeasurement, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingLegMeasurement = new NursingLegMeasurement(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingLegMeasurement.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingLegMeasurement, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingLegMeasurement, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingLegMeasurement);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingLegMeasurement);
                PreScript_NursingLegMeasurementForm(viewModel, viewModel._NursingLegMeasurement, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingLegMeasurementForm(NursingLegMeasurementFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingLegMeasurementFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingLegMeasurementFormInternal(NursingLegMeasurementFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("b7f74f05-5fd3-4dba-b550-d801e6120f96");
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingLegMeasurement, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingLegMeasurement = (NursingLegMeasurement)objectContext.GetLoadedObject(viewModel._NursingLegMeasurement.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingLegMeasurement, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingLegMeasurement, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingLegMeasurement);
        PostScript_NursingLegMeasurementForm(viewModel, nursingLegMeasurement, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingLegMeasurement);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingLegMeasurement);
        AfterContextSaveScript_NursingLegMeasurementForm(viewModel, nursingLegMeasurement, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingLegMeasurementForm(NursingLegMeasurementFormViewModel viewModel, NursingLegMeasurement nursingLegMeasurement, TTObjectContext objectContext);
    partial void PostScript_NursingLegMeasurementForm(NursingLegMeasurementFormViewModel viewModel, NursingLegMeasurement nursingLegMeasurement, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingLegMeasurementForm(NursingLegMeasurementFormViewModel viewModel, NursingLegMeasurement nursingLegMeasurement, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingLegMeasurementFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingLegMeasurementFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingLegMeasurement _NursingLegMeasurement { get; set; }
    }
}
