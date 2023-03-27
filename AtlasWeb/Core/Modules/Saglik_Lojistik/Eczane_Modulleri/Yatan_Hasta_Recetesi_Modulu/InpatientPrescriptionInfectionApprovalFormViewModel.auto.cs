//$43B5028E
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
    public partial class InpatientPrescriptionServiceController : Controller
{
    [HttpGet]
    public InpatientPrescriptionInfectionApprovalFormViewModel InpatientPrescriptionInfectionApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InpatientPrescriptionInfectionApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public InpatientPrescriptionInfectionApprovalFormViewModel InpatientPrescriptionInfectionApprovalFormLoad(FormLoadInput input)
    {
        return InpatientPrescriptionInfectionApprovalFormLoadInternal(input);
    }

    private InpatientPrescriptionInfectionApprovalFormViewModel InpatientPrescriptionInfectionApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("86411dba-b6db-4f03-8c3a-ec47537dffce");
        var objectDefID = Guid.Parse("fda28150-7a87-49c7-9acb-b68fe9bd5d20");
        var viewModel = new InpatientPrescriptionInfectionApprovalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientPrescription = objectContext.GetObject(id.Value, objectDefID) as InpatientPrescription;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientPrescription, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientPrescription, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InpatientPrescription);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InpatientPrescription);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InpatientPrescriptionInfectionApprovalForm(viewModel, viewModel._InpatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InpatientPrescriptionInfectionApprovalForm(InpatientPrescriptionInfectionApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("86411dba-b6db-4f03-8c3a-ec47537dffce");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.InpatientDrugOrders);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.PrescriptionPapers);
            objectContext.AddToRawObjectList(viewModel.SPTSDiagnosisesGridList);
            objectContext.AddToRawObjectList(viewModel.InfectionApprovalDrugOrderGridList);
            objectContext.AddToRawObjectList(viewModel.InpatientDrugOrdersGridList);
            objectContext.AddToRawObjectList(viewModel._InpatientPrescription);
            objectContext.ProcessRawObjects();
            var inpatientPrescription = (InpatientPrescription)objectContext.GetLoadedObject(viewModel._InpatientPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientPrescription, formDefID);
            if (viewModel.SPTSDiagnosisesGridList != null)
            {
                foreach (var item in viewModel.SPTSDiagnosisesGridList)
                {
                    var sPTSDiagnosisesImported = (DiagnosisForPresc)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)sPTSDiagnosisesImported).IsDeleted)
                        continue;
                    sPTSDiagnosisesImported.Prescription = inpatientPrescription;
                }
            }

            if (viewModel.InfectionApprovalDrugOrderGridList != null)
            {
                foreach (var item in viewModel.InfectionApprovalDrugOrderGridList)
                {
                    var infectionApprovalDrugOrderImported = (InfectionApprovalDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)infectionApprovalDrugOrderImported).IsDeleted)
                        continue;
                    infectionApprovalDrugOrderImported.InpatientPrescription = inpatientPrescription;
                }
            }

            if (viewModel.InpatientDrugOrdersGridList != null)
            {
                foreach (var item in viewModel.InpatientDrugOrdersGridList)
                {
                    var inpatientDrugOrdersImported = (InpatientDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)inpatientDrugOrdersImported).IsDeleted)
                        continue;
                    inpatientDrugOrdersImported.InpatientPrescription = inpatientPrescription;
                }
            }

            var transDef = inpatientPrescription.TransDef;
            PostScript_InpatientPrescriptionInfectionApprovalForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientPrescription);
            AfterContextSaveScript_InpatientPrescriptionInfectionApprovalForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InpatientPrescriptionInfectionApprovalForm(InpatientPrescriptionInfectionApprovalFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTObjectContext objectContext);
    partial void PostScript_InpatientPrescriptionInfectionApprovalForm(InpatientPrescriptionInfectionApprovalFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InpatientPrescriptionInfectionApprovalForm(InpatientPrescriptionInfectionApprovalFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InpatientPrescriptionInfectionApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SPTSDiagnosisesGridList = viewModel._InpatientPrescription.SPTSDiagnosises.OfType<DiagnosisForPresc>().ToArray();
        viewModel.InfectionApprovalDrugOrderGridList = viewModel._InpatientPrescription.InfectionApprovalDrugOrder.OfType<InfectionApprovalDrugOrder>().ToArray();
        viewModel.InpatientDrugOrdersGridList = viewModel._InpatientPrescription.InpatientDrugOrders.OfType<InpatientDrugOrder>().ToArray();
        viewModel.InpatientDrugOrders = objectContext.LocalQuery<InpatientDrugOrder>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.PrescriptionPapers = objectContext.LocalQuery<PrescriptionPaper>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PrescriptionPaperListDefinition", viewModel.PrescriptionPapers);
    }
}
}


namespace Core.Models
{
    public partial class InpatientPrescriptionInfectionApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientPrescription _InpatientPrescription { get; set; }
        public TTObjectClasses.DiagnosisForPresc[] SPTSDiagnosisesGridList { get; set; }
        public TTObjectClasses.InfectionApprovalDrugOrder[] InfectionApprovalDrugOrderGridList { get; set; }
        public TTObjectClasses.InpatientDrugOrder[] InpatientDrugOrdersGridList { get; set; }
        public TTObjectClasses.InpatientDrugOrder[] InpatientDrugOrders { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.PrescriptionPaper[] PrescriptionPapers { get; set; }
    }
}
