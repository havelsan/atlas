//$6989B4F3
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
    public partial class HemodialysisOrderServiceController : Controller
    {
        [HttpGet]
        public HemodialysisOrderFormViewModel HemodialysisOrderForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return HemodialysisOrderFormLoadInternal(input);
        }

        [HttpPost]
        public HemodialysisOrderFormViewModel HemodialysisOrderFormLoad(FormLoadInput input)
        {
            return HemodialysisOrderFormLoadInternal(input);
        }

        private HemodialysisOrderFormViewModel HemodialysisOrderFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("721805c9-371c-4993-918f-34d45fa1858e");
            var objectDefID = Guid.Parse("c458664d-91b0-4003-a2d2-18f194eb4727");
            var viewModel = new HemodialysisOrderFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HemodialysisOrder = objectContext.GetObject(id.Value, objectDefID) as HemodialysisOrder;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisOrder, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrder, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HemodialysisOrder);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HemodialysisOrder);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_HemodialysisOrderForm(viewModel, viewModel._HemodialysisOrder, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HemodialysisOrder = new HemodialysisOrder(objectContext);
                    var entryStateID = Guid.Parse("4f23396e-2d48-4aa4-8a8e-c45b02313167");
                    viewModel._HemodialysisOrder.CurrentStateDefID = entryStateID;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisOrder, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrder, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HemodialysisOrder);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HemodialysisOrder);
                    PreScript_HemodialysisOrderForm(viewModel, viewModel._HemodialysisOrder, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return HemodialysisOrderFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel HemodialysisOrderFormInternal(HemodialysisOrderFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("721805c9-371c-4993-918f-34d45fa1858e");
            objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
            objectContext.AddToRawObjectList(viewModel.HemodialysisRequests);
            objectContext.AddToRawObjectList(viewModel.ResEquipments);
            objectContext.AddToRawObjectList(viewModel.PackageProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.SKRSDiyalizeGirmeSikligis);
            var entryStateID = Guid.Parse("4f23396e-2d48-4aa4-8a8e-c45b02313167");
            objectContext.AddToRawObjectList(viewModel._HemodialysisOrder, entryStateID);
            objectContext.ProcessRawObjects(false);
            var hemodialysisOrder = (HemodialysisOrder)objectContext.GetLoadedObject(viewModel._HemodialysisOrder.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisOrder, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrder, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(hemodialysisOrder);
            PostScript_HemodialysisOrderForm(viewModel, hemodialysisOrder, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisOrder);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisOrder);
            AfterContextSaveScript_HemodialysisOrderForm(viewModel, hemodialysisOrder, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTObjectContext objectContext);
        partial void PostScript_HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(HemodialysisOrderFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.HemodialysisRequests = objectContext.LocalQuery<HemodialysisRequest>().ToArray();
            viewModel.ResEquipments = objectContext.LocalQuery<ResEquipment>().ToArray();
            viewModel.ResTreatmentDiagnosisUnits = objectContext.LocalQuery<ResTreatmentDiagnosisUnit>().ToArray();
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            viewModel.SKRSDiyalizeGirmeSikligis = objectContext.LocalQuery<SKRSDiyalizeGirmeSikligi>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "EquipmentListDefinition", viewModel.ResEquipments);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentDiagnosisUnitListDefinition", viewModel.ResTreatmentDiagnosisUnits);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DialysisPackageProcedureList", viewModel.PackageProcedureDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyalizeGirmeSikligiList", viewModel.SKRSDiyalizeGirmeSikligis);
        }
    }
}


namespace Core.Models
{
    public partial class HemodialysisOrderFormViewModel
    {
        public TTObjectClasses.HemodialysisOrder _HemodialysisOrder
        {
            get;
            set;
        }

        public TTObjectClasses.ResTreatmentDiagnosisUnit[] ResTreatmentDiagnosisUnits
        {
            get;
            set;
        }

        public TTObjectClasses.HemodialysisRequest[] HemodialysisRequests
        {
            get;
            set;
        }

        public TTObjectClasses.ResEquipment[] ResEquipments
        {
            get;
            set;
        }

        public TTObjectClasses.PackageProcedureDefinition[] PackageProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDiyalizeGirmeSikligi[] SKRSDiyalizeGirmeSikligis
        {
            get;
            set;
        }
    }
}
