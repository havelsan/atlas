//$2D3C126D
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
    public PhysiotherapyOrderRequestFormViewModel PhysiotherapyOrderRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PhysiotherapyOrderRequestFormLoadInternal(input);
    }

    [HttpPost]
    public PhysiotherapyOrderRequestFormViewModel PhysiotherapyOrderRequestFormLoad(FormLoadInput input)
    {
        return PhysiotherapyOrderRequestFormLoadInternal(input);
    }

    private PhysiotherapyOrderRequestFormViewModel PhysiotherapyOrderRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("113c215e-c53e-4eea-85f4-7bc9b2861379");
        var objectDefID = Guid.Parse("ee1a78c9-9c9d-4fb5-9a00-e719b53ca848");
        var viewModel = new PhysiotherapyOrderRequestFormViewModel();
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
                PreScript_PhysiotherapyOrderRequestForm(viewModel, viewModel._PhysiotherapyOrder, objectContext);
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
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyOrder, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysiotherapyOrder);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysiotherapyOrder);
                PreScript_PhysiotherapyOrderRequestForm(viewModel, viewModel._PhysiotherapyOrder, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("113c215e-c53e-4eea-85f4-7bc9b2861379");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
            objectContext.AddToRawObjectList(viewModel.FTRVucutBolgesis);
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyReportss);
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyOrder);
            objectContext.ProcessRawObjects();
            var physiotherapyOrder = (PhysiotherapyOrder)objectContext.GetLoadedObject(viewModel._PhysiotherapyOrder.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyOrder, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);
            var transDef = physiotherapyOrder.TransDef;
            PostScript_PhysiotherapyOrderRequestForm(viewModel, physiotherapyOrder, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyOrder);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyOrder);
            AfterContextSaveScript_PhysiotherapyOrderRequestForm(viewModel, physiotherapyOrder, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTObjectContext objectContext);
    partial void PostScript_PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PhysiotherapyOrderRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PhysiotherapyDefinitions = objectContext.LocalQuery<PhysiotherapyDefinition>().ToArray();
        viewModel.ResTreatmentDiagnosisUnits = objectContext.LocalQuery<ResTreatmentDiagnosisUnit>().ToArray();
        viewModel.FTRVucutBolgesis = objectContext.LocalQuery<FTRVucutBolgesi>().ToArray();
        viewModel.PhysiotherapyReportss = objectContext.LocalQuery<PhysiotherapyReports>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PhysiotherapyListDefinition", viewModel.PhysiotherapyDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentDiagnosisUnitListDefinition", viewModel.ResTreatmentDiagnosisUnits);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FTRVucutBolgesiTTObjectListDefinition", viewModel.FTRVucutBolgesis);
    }
}
}


namespace Core.Models
{
    public partial class PhysiotherapyOrderRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder { get; set; }
        public TTObjectClasses.PhysiotherapyDefinition[] PhysiotherapyDefinitions { get; set; }
        public TTObjectClasses.ResTreatmentDiagnosisUnit[] ResTreatmentDiagnosisUnits { get; set; }
        public TTObjectClasses.FTRVucutBolgesi[] FTRVucutBolgesis { get; set; }
        public TTObjectClasses.PhysiotherapyReports[] PhysiotherapyReportss { get; set; }
    }
}
