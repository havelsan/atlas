//$EFFDE794
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
    public partial class PatientOwnDrugReturnServiceController : Controller
{
    [HttpGet]
    public PatientOwnDrugReturnFormViewModel PatientOwnDrugReturnForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PatientOwnDrugReturnFormLoadInternal(input);
    }

    [HttpPost]
    public PatientOwnDrugReturnFormViewModel PatientOwnDrugReturnFormLoad(FormLoadInput input)
    {
        return PatientOwnDrugReturnFormLoadInternal(input);
    }

    private PatientOwnDrugReturnFormViewModel PatientOwnDrugReturnFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("07fc7b5e-5029-4515-809a-50210c5df4a4");
        var objectDefID = Guid.Parse("fe88b005-e22f-4acb-b308-9717c5e4945a");
        var viewModel = new PatientOwnDrugReturnFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientOwnDrugReturn = objectContext.GetObject(id.Value, objectDefID) as PatientOwnDrugReturn;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOwnDrugReturn, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugReturn, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PatientOwnDrugReturn);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PatientOwnDrugReturn);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PatientOwnDrugReturnForm(viewModel, viewModel._PatientOwnDrugReturn, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientOwnDrugReturn = new PatientOwnDrugReturn(objectContext);
                var entryStateID = Guid.Parse("5b0ccbea-e981-4491-a6de-ed9394324c38");
                viewModel._PatientOwnDrugReturn.CurrentStateDefID = entryStateID;
                viewModel.PatientOwnDrugReturnDetailsGridList = new TTObjectClasses.PatientOwnDrugReturnDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOwnDrugReturn, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugReturn, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientOwnDrugReturn);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientOwnDrugReturn);
                PreScript_PatientOwnDrugReturnForm(viewModel, viewModel._PatientOwnDrugReturn, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PatientOwnDrugReturnForm(PatientOwnDrugReturnFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PatientOwnDrugReturnFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PatientOwnDrugReturnFormInternal(PatientOwnDrugReturnFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("07fc7b5e-5029-4515-809a-50210c5df4a4");
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.Patients);
        objectContext.AddToRawObjectList(viewModel.PatientOwnDrugReturnDetailsGridList);
        var entryStateID = Guid.Parse("5b0ccbea-e981-4491-a6de-ed9394324c38");
        objectContext.AddToRawObjectList(viewModel._PatientOwnDrugReturn, entryStateID);
        objectContext.ProcessRawObjects(false);
        var patientOwnDrugReturn = (PatientOwnDrugReturn)objectContext.GetLoadedObject(viewModel._PatientOwnDrugReturn.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientOwnDrugReturn, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugReturn, formDefID);
        if (viewModel.PatientOwnDrugReturnDetailsGridList != null)
        {
            foreach (var item in viewModel.PatientOwnDrugReturnDetailsGridList)
            {
                var patientOwnDrugReturnDetailsImported = (PatientOwnDrugReturnDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)patientOwnDrugReturnDetailsImported).IsDeleted)
                    continue;
                patientOwnDrugReturnDetailsImported.PatientOwnDrugReturn = patientOwnDrugReturn;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(patientOwnDrugReturn);
        PostScript_PatientOwnDrugReturnForm(viewModel, patientOwnDrugReturn, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientOwnDrugReturn);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientOwnDrugReturn);
        AfterContextSaveScript_PatientOwnDrugReturnForm(viewModel, patientOwnDrugReturn, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PatientOwnDrugReturnForm(PatientOwnDrugReturnFormViewModel viewModel, PatientOwnDrugReturn patientOwnDrugReturn, TTObjectContext objectContext);
    partial void PostScript_PatientOwnDrugReturnForm(PatientOwnDrugReturnFormViewModel viewModel, PatientOwnDrugReturn patientOwnDrugReturn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PatientOwnDrugReturnForm(PatientOwnDrugReturnFormViewModel viewModel, PatientOwnDrugReturn patientOwnDrugReturn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PatientOwnDrugReturnFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PatientOwnDrugReturnDetailsGridList = viewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails.OfType<PatientOwnDrugReturnDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class PatientOwnDrugReturnFormViewModel
    {
        public TTObjectClasses.PatientOwnDrugReturn _PatientOwnDrugReturn
        {
            get;
            set;
        }

        public TTObjectClasses.PatientOwnDrugReturnDetail[] PatientOwnDrugReturnDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }
        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }
    }
}
