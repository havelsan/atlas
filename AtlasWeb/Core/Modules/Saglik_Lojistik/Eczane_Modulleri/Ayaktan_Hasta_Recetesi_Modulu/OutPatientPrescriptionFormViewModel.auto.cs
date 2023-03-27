//$3347DE40
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
    public partial class OutPatientPrescriptionServiceController : Controller
{
    [HttpGet]
    public OutPatientPrescriptionFormViewModel OutPatientPrescriptionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OutPatientPrescriptionFormLoadInternal(input);
    }

    [HttpPost]
    public OutPatientPrescriptionFormViewModel OutPatientPrescriptionFormLoad(FormLoadInput input)
    {
        return OutPatientPrescriptionFormLoadInternal(input);
    }

    private OutPatientPrescriptionFormViewModel OutPatientPrescriptionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e019cefb-f094-46cf-8ac0-c74f1c292eff");
        var objectDefID = Guid.Parse("39dc2f2a-2723-4522-9e3f-92c010b1e72b");
        var viewModel = new OutPatientPrescriptionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OutPatientPrescription = objectContext.GetObject(id.Value, objectDefID) as OutPatientPrescription;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OutPatientPrescription, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OutPatientPrescription, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OutPatientPrescription);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OutPatientPrescription);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OutPatientPrescriptionForm(viewModel, viewModel._OutPatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OutPatientPrescription = new OutPatientPrescription(objectContext);
                var entryStateID = Guid.Parse("439ded48-8553-42a9-9def-994f1eeac334");
                viewModel._OutPatientPrescription.CurrentStateDefID = entryStateID;
                viewModel.OutPatientDrugOrdersGridList = new TTObjectClasses.OutPatientDrugOrder[]{};
                viewModel.SPTSDiagnosisesGridList = new TTObjectClasses.DiagnosisForPresc[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OutPatientPrescription, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OutPatientPrescription, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._OutPatientPrescription);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._OutPatientPrescription);
                PreScript_OutPatientPrescriptionForm(viewModel, viewModel._OutPatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OutPatientPrescriptionForm(OutPatientPrescriptionFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e019cefb-f094-46cf-8ac0-c74f1c292eff");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DrugDefinitions);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.PrescriptionPapers);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.OutPatientDrugOrdersGridList);
            objectContext.AddToRawObjectList(viewModel.SPTSDiagnosisesGridList);
            var entryStateID = Guid.Parse("439ded48-8553-42a9-9def-994f1eeac334");
            objectContext.AddToRawObjectList(viewModel._OutPatientPrescription, entryStateID);
            objectContext.ProcessRawObjects(false);
            var outPatientPrescription = (OutPatientPrescription)objectContext.GetLoadedObject(viewModel._OutPatientPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(outPatientPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OutPatientPrescription, formDefID);
            if (viewModel.OutPatientDrugOrdersGridList != null)
            {
                foreach (var item in viewModel.OutPatientDrugOrdersGridList)
                {
                    var outPatientDrugOrdersImported = (OutPatientDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)outPatientDrugOrdersImported).IsDeleted)
                        continue;
                    outPatientDrugOrdersImported.OutPatientPrescription = outPatientPrescription;
                }
            }

            if (viewModel.SPTSDiagnosisesGridList != null)
            {
                foreach (var item in viewModel.SPTSDiagnosisesGridList)
                {
                    var sPTSDiagnosisesImported = (DiagnosisForPresc)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)sPTSDiagnosisesImported).IsDeleted)
                        continue;
                    sPTSDiagnosisesImported.Prescription = outPatientPrescription;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(outPatientPrescription);
            PostScript_OutPatientPrescriptionForm(viewModel, outPatientPrescription, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(outPatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(outPatientPrescription);
            AfterContextSaveScript_OutPatientPrescriptionForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OutPatientPrescriptionForm(OutPatientPrescriptionFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTObjectContext objectContext);
    partial void PostScript_OutPatientPrescriptionForm(OutPatientPrescriptionFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OutPatientPrescriptionForm(OutPatientPrescriptionFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OutPatientPrescriptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.OutPatientDrugOrdersGridList = viewModel._OutPatientPrescription.OutPatientDrugOrders.OfType<OutPatientDrugOrder>().ToArray();
        viewModel.SPTSDiagnosisesGridList = viewModel._OutPatientPrescription.SPTSDiagnosises.OfType<DiagnosisForPresc>().ToArray();
        viewModel.DrugDefinitions = objectContext.LocalQuery<DrugDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.PrescriptionPapers = objectContext.LocalQuery<PrescriptionPaper>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugOutPharInheldStatusList", viewModel.DrugDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugOutPharInheldStatusList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PrescriptionPaperListDefinition", viewModel.PrescriptionPapers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityDefinitionList", viewModel.SpecialityDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class OutPatientPrescriptionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OutPatientPrescription _OutPatientPrescription { get; set; }
        public TTObjectClasses.OutPatientDrugOrder[] OutPatientDrugOrdersGridList { get; set; }
        public TTObjectClasses.DiagnosisForPresc[] SPTSDiagnosisesGridList { get; set; }
        public TTObjectClasses.DrugDefinition[] DrugDefinitions { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.PrescriptionPaper[] PrescriptionPapers { get; set; }
        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
    }
}
