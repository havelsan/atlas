//$B79185BC
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
    public OutPatientPrescriptionApprovalFormViewModel OutPatientPrescriptionApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OutPatientPrescriptionApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public OutPatientPrescriptionApprovalFormViewModel OutPatientPrescriptionApprovalFormLoad(FormLoadInput input)
    {
        return OutPatientPrescriptionApprovalFormLoadInternal(input);
    }

    private OutPatientPrescriptionApprovalFormViewModel OutPatientPrescriptionApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d961887a-b543-4bc9-ac12-d69bb0988d07");
        var objectDefID = Guid.Parse("39dc2f2a-2723-4522-9e3f-92c010b1e72b");
        var viewModel = new OutPatientPrescriptionApprovalFormViewModel();
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
                PreScript_OutPatientPrescriptionApprovalForm(viewModel, viewModel._OutPatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OutPatientPrescriptionApprovalForm(OutPatientPrescriptionApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d961887a-b543-4bc9-ac12-d69bb0988d07");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.DrugDefinitions);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.SPTSDiagnosisInfos);
            objectContext.AddToRawObjectList(viewModel.OutPatientDrugOrdersGridList);
            objectContext.AddToRawObjectList(viewModel.SPTSDiagnosisesGridList);
            objectContext.AddToRawObjectList(viewModel.SPTSDiagnosisInfosGridList);
            objectContext.AddToRawObjectList(viewModel._OutPatientPrescription);
            objectContext.ProcessRawObjects();
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

            if (viewModel.SPTSDiagnosisInfosGridList != null)
            {
                foreach (var item in viewModel.SPTSDiagnosisInfosGridList)
                {
                    var diagnosisForSPTSsImported = (DiagnosisForSPTS)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisForSPTSsImported).IsDeleted)
                        continue;
                    diagnosisForSPTSsImported.Prescription = outPatientPrescription;
                }
            }

            var transDef = outPatientPrescription.TransDef;
            PostScript_OutPatientPrescriptionApprovalForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(outPatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(outPatientPrescription);
            AfterContextSaveScript_OutPatientPrescriptionApprovalForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OutPatientPrescriptionApprovalForm(OutPatientPrescriptionApprovalFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTObjectContext objectContext);
    partial void PostScript_OutPatientPrescriptionApprovalForm(OutPatientPrescriptionApprovalFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OutPatientPrescriptionApprovalForm(OutPatientPrescriptionApprovalFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OutPatientPrescriptionApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.OutPatientDrugOrdersGridList = viewModel._OutPatientPrescription.OutPatientDrugOrders.OfType<OutPatientDrugOrder>().ToArray();
        viewModel.SPTSDiagnosisesGridList = viewModel._OutPatientPrescription.SPTSDiagnosises.OfType<DiagnosisForPresc>().ToArray();
        viewModel.SPTSDiagnosisInfosGridList = viewModel._OutPatientPrescription.DiagnosisForSPTSs.OfType<DiagnosisForSPTS>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.DrugDefinitions = objectContext.LocalQuery<DrugDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.SPTSDiagnosisInfos = objectContext.LocalQuery<SPTSDiagnosisInfo>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.DrugDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SPTSDiagnosisInfoDefinitionList", viewModel.SPTSDiagnosisInfos);
    }
}
}


namespace Core.Models
{
    public partial class OutPatientPrescriptionApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OutPatientPrescription _OutPatientPrescription { get; set; }
        public TTObjectClasses.OutPatientDrugOrder[] OutPatientDrugOrdersGridList { get; set; }
        public TTObjectClasses.DiagnosisForPresc[] SPTSDiagnosisesGridList { get; set; }
        public TTObjectClasses.DiagnosisForSPTS[] SPTSDiagnosisInfosGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.DrugDefinition[] DrugDefinitions { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.SPTSDiagnosisInfo[] SPTSDiagnosisInfos { get; set; }
    }
}
