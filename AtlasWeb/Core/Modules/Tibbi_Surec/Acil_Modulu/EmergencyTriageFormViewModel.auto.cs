//$0FA0A9A9
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
    public partial class EmergencyInterventionServiceController : Controller
{
    [HttpGet]
    public EmergencyTriageFormViewModel EmergencyTriageForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return EmergencyTriageFormLoadInternal(input);
    }

    [HttpPost]
    public EmergencyTriageFormViewModel EmergencyTriageFormLoad(FormLoadInput input)
    {
        return EmergencyTriageFormLoadInternal(input);
    }

    private EmergencyTriageFormViewModel EmergencyTriageFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("61e9b44c-09a6-4be0-8df2-204dbf8f840a");
        var objectDefID = Guid.Parse("232dd688-7f7c-44ff-bee1-d135d2a90d98");
        var viewModel = new EmergencyTriageFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EmergencyIntervention = objectContext.GetObject(id.Value, objectDefID) as EmergencyIntervention;
                //  viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EmergencyIntervention, formDefID);
                //  viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EmergencyIntervention, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._EmergencyIntervention);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._EmergencyIntervention);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_EmergencyTriageForm(viewModel, viewModel._EmergencyIntervention, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EmergencyIntervention = new EmergencyIntervention(objectContext);
                var entryStateID = Guid.Parse("dc998a28-e0ea-4da4-bbe5-2252b3ea1aa1");
                viewModel._EmergencyIntervention.CurrentStateDefID = entryStateID;
                viewModel.ttgrid1GridList = new TTObjectClasses.Allergy[]{};
                viewModel.ttgrid2GridList = new TTObjectClasses.Vaccination[]{};
                // viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EmergencyIntervention, formDefID);
                // viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EmergencyIntervention, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EmergencyIntervention);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EmergencyIntervention);
                PreScript_EmergencyTriageForm(viewModel, viewModel._EmergencyIntervention, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel EmergencyTriageForm(EmergencyTriageFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("61e9b44c-09a6-4be0-8df2-204dbf8f840a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSTRIAJKODUs);
            objectContext.AddToRawObjectList(viewModel.ImportantMedicalInformations);
            objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
            objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
            var entryStateID = Guid.Parse("dc998a28-e0ea-4da4-bbe5-2252b3ea1aa1");
            objectContext.AddToRawObjectList(viewModel._EmergencyIntervention, entryStateID);
            objectContext.ProcessRawObjects(false);
            var emergencyIntervention = (EmergencyIntervention)objectContext.GetLoadedObject(viewModel._EmergencyIntervention.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(emergencyIntervention, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EmergencyIntervention, formDefID);
            var importantMedicalInformationImported = emergencyIntervention.ImportantMedicalInformation;
            if (importantMedicalInformationImported != null)
            {
                if (viewModel.ttgrid1GridList != null)
                {
                    foreach (var item in viewModel.ttgrid1GridList)
                    {
                        var allergiesImported = (Allergy)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)allergiesImported).IsDeleted)
                            continue;
                        allergiesImported.ImportantMedicalInformation = importantMedicalInformationImported;
                    }
                }

                if (viewModel.ttgrid2GridList != null)
                {
                    foreach (var item in viewModel.ttgrid2GridList)
                    {
                        var vaccinationsImported = (Vaccination)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)vaccinationsImported).IsDeleted)
                            continue;
                        vaccinationsImported.ImportantMedicalInformation = importantMedicalInformationImported;
                    }
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(emergencyIntervention);
            PostScript_EmergencyTriageForm(viewModel, emergencyIntervention, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(emergencyIntervention);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(emergencyIntervention);
            AfterContextSaveScript_EmergencyTriageForm(viewModel, emergencyIntervention, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_EmergencyTriageForm(EmergencyTriageFormViewModel viewModel, EmergencyIntervention emergencyIntervention, TTObjectContext objectContext);
    partial void PostScript_EmergencyTriageForm(EmergencyTriageFormViewModel viewModel, EmergencyIntervention emergencyIntervention, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_EmergencyTriageForm(EmergencyTriageFormViewModel viewModel, EmergencyIntervention emergencyIntervention, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(EmergencyTriageFormViewModel viewModel, TTObjectContext objectContext)
    {
        var importantMedicalInformation = viewModel._EmergencyIntervention.ImportantMedicalInformation;
        if (importantMedicalInformation != null)
        {
            viewModel.ttgrid1GridList = importantMedicalInformation.Allergies.OfType<Allergy>().ToArray();
            viewModel.ttgrid2GridList = importantMedicalInformation.Vaccinations.OfType<Vaccination>().ToArray();
        }

        viewModel.SKRSTRIAJKODUs = objectContext.LocalQuery<SKRSTRIAJKODU>().ToArray();
        viewModel.ImportantMedicalInformations = objectContext.LocalQuery<ImportantMedicalInformation>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTRIAJKODUList", viewModel.SKRSTRIAJKODUs);
    }
}
}


namespace Core.Models
{
    public partial class EmergencyTriageFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EmergencyIntervention _EmergencyIntervention { get; set; }
        public TTObjectClasses.Allergy[] ttgrid1GridList { get; set; }
        public TTObjectClasses.Vaccination[] ttgrid2GridList { get; set; }
        public TTObjectClasses.SKRSTRIAJKODU[] SKRSTRIAJKODUs { get; set; }
        public TTObjectClasses.ImportantMedicalInformation[] ImportantMedicalInformations { get; set; }
    }
}
