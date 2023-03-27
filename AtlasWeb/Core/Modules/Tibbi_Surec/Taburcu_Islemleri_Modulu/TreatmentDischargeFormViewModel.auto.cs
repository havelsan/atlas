//$23EA5AA5
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
    public partial class TreatmentDischargeServiceController : Controller
{
    [HttpGet]
    public TreatmentDischargeFormViewModel TreatmentDischargeForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return TreatmentDischargeFormLoadInternal(input);
    }

    [HttpPost]
    public TreatmentDischargeFormViewModel TreatmentDischargeFormLoad(FormLoadInput input)
    {
        return TreatmentDischargeFormLoadInternal(input);
    }

    private TreatmentDischargeFormViewModel TreatmentDischargeFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("fc10a117-73ef-436f-84cc-025cf1860430");
        var objectDefID = Guid.Parse("6221d93b-6805-440b-9d4e-7e5e3d9bb88c");
        var viewModel = new TreatmentDischargeFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TreatmentDischarge = objectContext.GetObject(id.Value, objectDefID) as TreatmentDischarge;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TreatmentDischarge, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TreatmentDischarge, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._TreatmentDischarge);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._TreatmentDischarge);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_TreatmentDischargeForm(viewModel, viewModel._TreatmentDischarge, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TreatmentDischarge = new TreatmentDischarge(objectContext);
                var entryStateID = Guid.Parse("ef074cf1-50ed-45f0-a73b-92eb8dd685a1");
                viewModel._TreatmentDischarge.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TreatmentDischarge, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TreatmentDischarge, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._TreatmentDischarge);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._TreatmentDischarge);
                PreScript_TreatmentDischargeForm(viewModel, viewModel._TreatmentDischarge, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("fc10a117-73ef-436f-84cc-025cf1860430");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResClinics);
            objectContext.AddToRawObjectList(viewModel.DischargeTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            var entryStateID = Guid.Parse("ef074cf1-50ed-45f0-a73b-92eb8dd685a1");
            objectContext.AddToRawObjectList(viewModel._TreatmentDischarge, entryStateID);
            objectContext.ProcessRawObjects(false);
            var treatmentDischarge = (TreatmentDischarge)objectContext.GetLoadedObject(viewModel._TreatmentDischarge.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(treatmentDischarge, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TreatmentDischarge, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(treatmentDischarge);
            PostScript_TreatmentDischargeForm(viewModel, treatmentDischarge, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(treatmentDischarge);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(treatmentDischarge);
            AfterContextSaveScript_TreatmentDischargeForm(viewModel, treatmentDischarge, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTObjectContext objectContext);
    partial void PostScript_TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(TreatmentDischargeFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResClinics = objectContext.LocalQuery<ResClinic>().ToArray();
        viewModel.DischargeTypeDefinitions = objectContext.LocalQuery<DischargeTypeDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResClinics);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DischargeTypeListDefinition", viewModel.DischargeTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class TreatmentDischargeFormViewModel : BaseViewModel
    {
        public TTObjectClasses.TreatmentDischarge _TreatmentDischarge { get; set; }
        public TTObjectClasses.ResClinic[] ResClinics { get; set; }
        public TTObjectClasses.DischargeTypeDefinition[] DischargeTypeDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
