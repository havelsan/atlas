//$C4F3B4A8
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
        public HemodialysisPlanFormViewModel HemodialysisPlanForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return HemodialysisPlanFormLoadInternal(input);
        }

        [HttpPost]
        public HemodialysisPlanFormViewModel HemodialysisPlanFormLoad(FormLoadInput input)
        {
            return HemodialysisPlanFormLoadInternal(input);
        }

        private HemodialysisPlanFormViewModel HemodialysisPlanFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("d5981925-a004-4740-97a3-1cf8d3e8ce70");
            var objectDefID = Guid.Parse("c458664d-91b0-4003-a2d2-18f194eb4727");
            var viewModel = new HemodialysisPlanFormViewModel();
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

                    PreScript_HemodialysisPlanForm(viewModel, viewModel._HemodialysisOrder, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel HemodialysisPlanForm(HemodialysisPlanFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return HemodialysisPlanFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel HemodialysisPlanFormInternal(HemodialysisPlanFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("d5981925-a004-4740-97a3-1cf8d3e8ce70");
            objectContext.AddToRawObjectList(viewModel.HemodialysisRequests);
            objectContext.AddToRawObjectList(viewModel.ResEquipments);
            objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
            objectContext.AddToRawObjectList(viewModel.PackageProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.SKRSDiyalizeGirmeSikligis);
            objectContext.AddToRawObjectList(viewModel._HemodialysisOrder);
            objectContext.ProcessRawObjects();

            var hemodialysisOrder = (HemodialysisOrder)objectContext.GetLoadedObject(viewModel._HemodialysisOrder.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisOrder, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrder, formDefID);
            var transDef = hemodialysisOrder.TransDef;
            PostScript_HemodialysisPlanForm(viewModel, hemodialysisOrder, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisOrder);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisOrder);
            AfterContextSaveScript_HemodialysisPlanForm(viewModel, hemodialysisOrder, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_HemodialysisPlanForm(HemodialysisPlanFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTObjectContext objectContext);
        partial void PostScript_HemodialysisPlanForm(HemodialysisPlanFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_HemodialysisPlanForm(HemodialysisPlanFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(HemodialysisPlanFormViewModel viewModel, TTObjectContext objectContext)
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
    public partial class HemodialysisPlanFormViewModel
    {
        public TTObjectClasses.HemodialysisOrder _HemodialysisOrder
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

        public TTObjectClasses.ResTreatmentDiagnosisUnit[] ResTreatmentDiagnosisUnits
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
