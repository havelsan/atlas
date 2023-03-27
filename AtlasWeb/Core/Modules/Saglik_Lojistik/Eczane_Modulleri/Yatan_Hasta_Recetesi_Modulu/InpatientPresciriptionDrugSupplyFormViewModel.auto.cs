//$99F6FD89
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
    public InpatientPresciriptionDrugSupplyFormViewModel InpatientPresciriptionDrugSupplyForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InpatientPresciriptionDrugSupplyFormLoadInternal(input);
    }

    [HttpPost]
    public InpatientPresciriptionDrugSupplyFormViewModel InpatientPresciriptionDrugSupplyFormLoad(FormLoadInput input)
    {
        return InpatientPresciriptionDrugSupplyFormLoadInternal(input);
    }

    private InpatientPresciriptionDrugSupplyFormViewModel InpatientPresciriptionDrugSupplyFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("49ffe777-1287-4836-9c0d-337324713bfc");
        var objectDefID = Guid.Parse("fda28150-7a87-49c7-9acb-b68fe9bd5d20");
        var viewModel = new InpatientPresciriptionDrugSupplyFormViewModel();
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
                PreScript_InpatientPresciriptionDrugSupplyForm(viewModel, viewModel._InpatientPrescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InpatientPresciriptionDrugSupplyForm(InpatientPresciriptionDrugSupplyFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("49ffe777-1287-4836-9c0d-337324713bfc");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.MaterialBarcodeLevels);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ExternalPharmacys);
            objectContext.AddToRawObjectList(viewModel.PrescriptionPapers);
            objectContext.AddToRawObjectList(viewModel.InpatientDrugOrdersGridList);
            objectContext.AddToRawObjectList(viewModel._InpatientPrescription);
            objectContext.ProcessRawObjects();
            var inpatientPrescription = (InpatientPrescription)objectContext.GetLoadedObject(viewModel._InpatientPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientPrescription, formDefID);
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
            PostScript_InpatientPresciriptionDrugSupplyForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientPrescription);
            AfterContextSaveScript_InpatientPresciriptionDrugSupplyForm(viewModel, inpatientPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InpatientPresciriptionDrugSupplyForm(InpatientPresciriptionDrugSupplyFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTObjectContext objectContext);
    partial void PostScript_InpatientPresciriptionDrugSupplyForm(InpatientPresciriptionDrugSupplyFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InpatientPresciriptionDrugSupplyForm(InpatientPresciriptionDrugSupplyFormViewModel viewModel, InpatientPrescription inpatientPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InpatientPresciriptionDrugSupplyFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.InpatientDrugOrdersGridList = viewModel._InpatientPrescription.InpatientDrugOrders.OfType<InpatientDrugOrder>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.MaterialBarcodeLevels = objectContext.LocalQuery<MaterialBarcodeLevel>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ExternalPharmacys = objectContext.LocalQuery<ExternalPharmacy>().ToArray();
        viewModel.PrescriptionPapers = objectContext.LocalQuery<PrescriptionPaper>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ExternalPharmacyList", viewModel.ExternalPharmacys);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PrescriptionPaperListDefinition", viewModel.PrescriptionPapers);
    }
}
}


namespace Core.Models
{
    public partial class InpatientPresciriptionDrugSupplyFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientPrescription _InpatientPrescription { get; set; }
        public TTObjectClasses.InpatientDrugOrder[] InpatientDrugOrdersGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.MaterialBarcodeLevel[] MaterialBarcodeLevels { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ExternalPharmacy[] ExternalPharmacys { get; set; }
        public TTObjectClasses.PrescriptionPaper[] PrescriptionPapers { get; set; }
    }
}
