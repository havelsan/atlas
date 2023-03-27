//$AEFF975D
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
    public partial class PhysiotherapyOrderServiceController : Controller
{
    [HttpGet]
    public PhysiotherapyPlannedOrdersFormViewModel PhysiotherapyPlannedOrdersForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PhysiotherapyPlannedOrdersFormLoadInternal(input);
    }

    [HttpPost]
    public PhysiotherapyPlannedOrdersFormViewModel PhysiotherapyPlannedOrdersFormLoad(FormLoadInput input)
    {
        return PhysiotherapyPlannedOrdersFormLoadInternal(input);
    }

    private PhysiotherapyPlannedOrdersFormViewModel PhysiotherapyPlannedOrdersFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("87df6e56-4417-4e38-a6fd-66ee06820ccc");
        var objectDefID = Guid.Parse("ee1a78c9-9c9d-4fb5-9a00-e719b53ca848");
        var viewModel = new PhysiotherapyPlannedOrdersFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyOrder = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyOrder;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyOrder, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyOrder);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyOrder);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PhysiotherapyPlannedOrdersForm(viewModel, viewModel._PhysiotherapyOrder, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyOrder = new PhysiotherapyOrder(objectContext);
                var entryStateID = Guid.Parse("16b54535-aacc-414b-ab69-b06759532cd7");
                viewModel._PhysiotherapyOrder.CurrentStateDefID = entryStateID;
                viewModel.PhysiotherapyOrderDetailsGridList = new TTObjectClasses.PhysiotherapyOrderDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyOrder, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysiotherapyOrder);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysiotherapyOrder);
                PreScript_PhysiotherapyPlannedOrdersForm(viewModel, viewModel._PhysiotherapyOrder, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PhysiotherapyPlannedOrdersForm(PhysiotherapyPlannedOrdersFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("87df6e56-4417-4e38-a6fd-66ee06820ccc");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PackageProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyReportss);
            objectContext.AddToRawObjectList(viewModel.FTRVucutBolgesis);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyOrderDetailsGridList);
            var entryStateID = Guid.Parse("16b54535-aacc-414b-ab69-b06759532cd7");
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyOrder, entryStateID);
            objectContext.ProcessRawObjects(false);
            var physiotherapyOrder = (PhysiotherapyOrder)objectContext.GetLoadedObject(viewModel._PhysiotherapyOrder.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyOrder, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);
            if (viewModel.PhysiotherapyOrderDetailsGridList != null)
            {
                foreach (var item in viewModel.PhysiotherapyOrderDetailsGridList)
                {
                    var physiotherapyOrderDetailsImported = (PhysiotherapyOrderDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)physiotherapyOrderDetailsImported).IsDeleted)
                        continue;
                    physiotherapyOrderDetailsImported.PhysiotherapyOrder = physiotherapyOrder;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(physiotherapyOrder);
            PostScript_PhysiotherapyPlannedOrdersForm(viewModel, physiotherapyOrder, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyOrder);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyOrder);
            AfterContextSaveScript_PhysiotherapyPlannedOrdersForm(viewModel, physiotherapyOrder, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PhysiotherapyPlannedOrdersForm(PhysiotherapyPlannedOrdersFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTObjectContext objectContext);
    partial void PostScript_PhysiotherapyPlannedOrdersForm(PhysiotherapyPlannedOrdersFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PhysiotherapyPlannedOrdersForm(PhysiotherapyPlannedOrdersFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PhysiotherapyPlannedOrdersFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PhysiotherapyOrderDetailsGridList = viewModel._PhysiotherapyOrder.PhysiotherapyOrderDetails.OfType<PhysiotherapyOrderDetail>().ToArray();
        viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
        viewModel.PhysiotherapyReportss = objectContext.LocalQuery<PhysiotherapyReports>().ToArray();
        viewModel.FTRVucutBolgesis = objectContext.LocalQuery<FTRVucutBolgesi>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.PhysiotherapyDefinitions = objectContext.LocalQuery<PhysiotherapyDefinition>().ToArray();
        viewModel.ResTreatmentDiagnosisUnits = objectContext.LocalQuery<ResTreatmentDiagnosisUnit>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FTRPackageProcedureList", viewModel.PackageProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FTRVucutBolgesiTTObjectListDefinition", viewModel.FTRVucutBolgesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PhysiotherapistListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PhysiotherapyListDefinition", viewModel.PhysiotherapyDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentDiagnosisUnitListDefinition", viewModel.ResTreatmentDiagnosisUnits);
    }
}
}


namespace Core.Models
{
    public partial class PhysiotherapyPlannedOrdersFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder { get; set; }
        public TTObjectClasses.PhysiotherapyOrderDetail[] PhysiotherapyOrderDetailsGridList { get; set; }
        public TTObjectClasses.PackageProcedureDefinition[] PackageProcedureDefinitions { get; set; }
        public TTObjectClasses.PhysiotherapyReports[] PhysiotherapyReportss { get; set; }
        public TTObjectClasses.FTRVucutBolgesi[] FTRVucutBolgesis { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.PhysiotherapyDefinition[] PhysiotherapyDefinitions { get; set; }
        public TTObjectClasses.ResTreatmentDiagnosisUnit[] ResTreatmentDiagnosisUnits { get; set; }
    }
}
