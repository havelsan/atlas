//$454B9B34
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
    public partial class PatientOwnDrugEntryServiceController : Controller
{
    [HttpGet]
    public PatientOwnDrugEntryApprovalFormViewModel PatientOwnDrugEntryApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PatientOwnDrugEntryApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public PatientOwnDrugEntryApprovalFormViewModel PatientOwnDrugEntryApprovalFormLoad(FormLoadInput input)
    {
        return PatientOwnDrugEntryApprovalFormLoadInternal(input);
    }

    private PatientOwnDrugEntryApprovalFormViewModel PatientOwnDrugEntryApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c9181cf6-99f1-4c7a-9147-fc041cbcd01d");
        var objectDefID = Guid.Parse("0fe703f4-0496-4e27-abfb-80992bfc6628");
        var viewModel = new PatientOwnDrugEntryApprovalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientOwnDrugEntry = objectContext.GetObject(id.Value, objectDefID) as PatientOwnDrugEntry;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOwnDrugEntry, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugEntry, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PatientOwnDrugEntry);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PatientOwnDrugEntry);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PatientOwnDrugEntryApprovalForm(viewModel, viewModel._PatientOwnDrugEntry, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PatientOwnDrugEntryApprovalForm(PatientOwnDrugEntryApprovalFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PatientOwnDrugEntryApprovalFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PatientOwnDrugEntryApprovalFormInternal(PatientOwnDrugEntryApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c9181cf6-99f1-4c7a-9147-fc041cbcd01d");
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.PatientOwnDrugEntryDetailsGridList);
        objectContext.AddToRawObjectList(viewModel._PatientOwnDrugEntry);
        objectContext.ProcessRawObjects();
        var patientOwnDrugEntry = (PatientOwnDrugEntry)objectContext.GetLoadedObject(viewModel._PatientOwnDrugEntry.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientOwnDrugEntry, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugEntry, formDefID);
        if (viewModel.PatientOwnDrugEntryDetailsGridList != null)
        {
            foreach (var item in viewModel.PatientOwnDrugEntryDetailsGridList)
            {
                var patientOwnDrugEntryDetailsImported = (PatientOwnDrugEntryDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)patientOwnDrugEntryDetailsImported).IsDeleted)
                    continue;
                patientOwnDrugEntryDetailsImported.PatientOwnDrugEntry = patientOwnDrugEntry;
            }
        }

        var transDef = patientOwnDrugEntry.TransDef;
        PostScript_PatientOwnDrugEntryApprovalForm(viewModel, patientOwnDrugEntry, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientOwnDrugEntry);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientOwnDrugEntry);
        AfterContextSaveScript_PatientOwnDrugEntryApprovalForm(viewModel, patientOwnDrugEntry, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PatientOwnDrugEntryApprovalForm(PatientOwnDrugEntryApprovalFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTObjectContext objectContext);
    partial void PostScript_PatientOwnDrugEntryApprovalForm(PatientOwnDrugEntryApprovalFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PatientOwnDrugEntryApprovalForm(PatientOwnDrugEntryApprovalFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PatientOwnDrugEntryApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PatientOwnDrugEntryDetailsGridList = viewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails.OfType<PatientOwnDrugEntryDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class PatientOwnDrugEntryApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PatientOwnDrugEntry _PatientOwnDrugEntry { get; set; }
        public TTObjectClasses.PatientOwnDrugEntryDetail[] PatientOwnDrugEntryDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
    }
}
