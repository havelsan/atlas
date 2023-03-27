//$459FE149
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
    public partial class DialysisDefinitionServiceController : Controller
    {
        [HttpGet]
        public DialysisDefinitionFormViewModel DialysisDefinitionForm(Guid? id)
        {
            var formDefID = Guid.Parse("53741d7d-6a80-4020-aae3-8926921c136a");
            var objectDefID = Guid.Parse("1df2debd-0c76-4218-a95b-6cb9ee5ba779");
            var viewModel = new DialysisDefinitionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DialysisDefinition = objectContext.GetObject(id.Value, objectDefID) as DialysisDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DialysisDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DialysisDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DialysisDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DialysisDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_DialysisDefinitionForm(viewModel, viewModel._DialysisDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DialysisDefinition = new DialysisDefinition(objectContext);
                    viewModel.TreatmentUnitsGridList = new TTObjectClasses.DialysisTreatmentUnitGrid[] { };
                    viewModel.DialysisTreatmentEquipmentsGridList = new TTObjectClasses.DialysisTreatmentEquipmentGrid[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DialysisDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DialysisDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DialysisDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DialysisDefinition);
                    PreScript_DialysisDefinitionForm(viewModel, viewModel._DialysisDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel DialysisDefinitionForm(DialysisDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return DialysisDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel DialysisDefinitionFormInternal(DialysisDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("53741d7d-6a80-4020-aae3-8926921c136a");
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
            objectContext.AddToRawObjectList(viewModel.ResEquipments);
            objectContext.AddToRawObjectList(viewModel.TreatmentUnitsGridList);
            objectContext.AddToRawObjectList(viewModel.DialysisTreatmentEquipmentsGridList);
            objectContext.AddToRawObjectList(viewModel._DialysisDefinition);
            objectContext.ProcessRawObjects();

            var dialysisDefinition = (DialysisDefinition)objectContext.GetLoadedObject(viewModel._DialysisDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dialysisDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DialysisDefinition, formDefID);

            if (viewModel.TreatmentUnitsGridList != null)
            {
                foreach (var item in viewModel.TreatmentUnitsGridList)
                {
                    var treatmentUnitsImported = (DialysisTreatmentUnitGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)treatmentUnitsImported).IsDeleted)
                        continue;
                    treatmentUnitsImported.DefinitionAction = dialysisDefinition;
                }
            }

            if (viewModel.DialysisTreatmentEquipmentsGridList != null)
            {
                foreach (var item in viewModel.DialysisTreatmentEquipmentsGridList)
                {
                    var dialysisTreatmentEquipmentsImported = (DialysisTreatmentEquipmentGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dialysisTreatmentEquipmentsImported).IsDeleted)
                        continue;
                    dialysisTreatmentEquipmentsImported.DialysisDefinition = dialysisDefinition;
                }
            }
            var transDef = dialysisDefinition.TransDef;
            PostScript_DialysisDefinitionForm(viewModel, dialysisDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dialysisDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dialysisDefinition);
            AfterContextSaveScript_DialysisDefinitionForm(viewModel, dialysisDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_DialysisDefinitionForm(DialysisDefinitionFormViewModel viewModel, DialysisDefinition dialysisDefinition, TTObjectContext objectContext);
        partial void PostScript_DialysisDefinitionForm(DialysisDefinitionFormViewModel viewModel, DialysisDefinition dialysisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_DialysisDefinitionForm(DialysisDefinitionFormViewModel viewModel, DialysisDefinition dialysisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(DialysisDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.TreatmentUnitsGridList = viewModel._DialysisDefinition.TreatmentUnits.OfType<DialysisTreatmentUnitGrid>().ToArray();
            viewModel.DialysisTreatmentEquipmentsGridList = viewModel._DialysisDefinition.DialysisTreatmentEquipments.OfType<DialysisTreatmentEquipmentGrid>().ToArray();
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            viewModel.ResTreatmentDiagnosisUnits = objectContext.LocalQuery<ResTreatmentDiagnosisUnit>().ToArray();
            viewModel.ResEquipments = objectContext.LocalQuery<ResEquipment>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentDiagnosisUnitListDefinition", viewModel.ResTreatmentDiagnosisUnits);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "EquipmentListDefinition", viewModel.ResEquipments);
        }
    }
}


namespace Core.Models
{
    public partial class DialysisDefinitionFormViewModel
    {
        public TTObjectClasses.DialysisDefinition _DialysisDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.DialysisTreatmentUnitGrid[] TreatmentUnitsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DialysisTreatmentEquipmentGrid[] DialysisTreatmentEquipmentsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResTreatmentDiagnosisUnit[] ResTreatmentDiagnosisUnits
        {
            get;
            set;
        }

        public TTObjectClasses.ResEquipment[] ResEquipments
        {
            get;
            set;
        }
    }
}
