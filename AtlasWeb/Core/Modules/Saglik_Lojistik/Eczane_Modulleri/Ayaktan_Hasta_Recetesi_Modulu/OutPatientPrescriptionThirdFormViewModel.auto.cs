//$7BD44498
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
    public OutPatientPrescriptionThirdFormViewModel OutPatientPrescriptionThirdForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OutPatientPrescriptionThirdFormLoadInternal(input);
    }

    [HttpPost]
    public OutPatientPrescriptionThirdFormViewModel OutPatientPrescriptionThirdFormLoad(FormLoadInput input)
    {
        return OutPatientPrescriptionThirdFormLoadInternal(input);
    }

    private OutPatientPrescriptionThirdFormViewModel OutPatientPrescriptionThirdFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5be3c95f-5d9c-4f40-b64f-7d8e446d594b");
        var objectDefID = Guid.Parse("39dc2f2a-2723-4522-9e3f-92c010b1e72b");
        var viewModel = new OutPatientPrescriptionThirdFormViewModel();
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
                PreScript_OutPatientPrescriptionThirdForm(viewModel, viewModel._OutPatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OutPatientPrescriptionThirdForm(OutPatientPrescriptionThirdFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5be3c95f-5d9c-4f40-b64f-7d8e446d594b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
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
            PostScript_OutPatientPrescriptionThirdForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(outPatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(outPatientPrescription);
            AfterContextSaveScript_OutPatientPrescriptionThirdForm(viewModel, outPatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OutPatientPrescriptionThirdForm(OutPatientPrescriptionThirdFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTObjectContext objectContext);
    partial void PostScript_OutPatientPrescriptionThirdForm(OutPatientPrescriptionThirdFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OutPatientPrescriptionThirdForm(OutPatientPrescriptionThirdFormViewModel viewModel, OutPatientPrescription outPatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OutPatientPrescriptionThirdFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.OutPatientDrugOrdersGridList = viewModel._OutPatientPrescription.OutPatientDrugOrders.OfType<OutPatientDrugOrder>().ToArray();
        viewModel.SPTSDiagnosisesGridList = viewModel._OutPatientPrescription.SPTSDiagnosises.OfType<DiagnosisForPresc>().ToArray();
        viewModel.SPTSDiagnosisInfosGridList = viewModel._OutPatientPrescription.DiagnosisForSPTSs.OfType<DiagnosisForSPTS>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.SPTSDiagnosisInfos = objectContext.LocalQuery<SPTSDiagnosisInfo>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SPTSDiagnosisInfoDefinitionList", viewModel.SPTSDiagnosisInfos);
    }
}
}


namespace Core.Models
{
    public partial class OutPatientPrescriptionThirdFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OutPatientPrescription _OutPatientPrescription { get; set; }
        public TTObjectClasses.OutPatientDrugOrder[] OutPatientDrugOrdersGridList { get; set; }
        public TTObjectClasses.DiagnosisForPresc[] SPTSDiagnosisesGridList { get; set; }
        public TTObjectClasses.DiagnosisForSPTS[] SPTSDiagnosisInfosGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.SPTSDiagnosisInfo[] SPTSDiagnosisInfos { get; set; }
    }
}
