//$DE7AB58E
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
    public partial class EstheticAlternativeProcedureDefinitionServiceController : Controller
    {
        [HttpGet]
        public EstheticAlternativeProcedureDefinitionFormViewModel EstheticAlternativeProcedureDefinitionForm(Guid? id)
        {
            var formDefID = Guid.Parse("c0a95f49-8f26-45b2-80cf-4358063ac50c");
            var objectDefID = Guid.Parse("445ead76-eff9-4e60-8dc3-854e7fa17088");
            var viewModel = new EstheticAlternativeProcedureDefinitionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._EstheticAlternativeProcedureDefinition = objectContext.GetObject(id.Value, objectDefID) as EstheticAlternativeProcedureDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EstheticAlternativeProcedureDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EstheticAlternativeProcedureDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._EstheticAlternativeProcedureDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._EstheticAlternativeProcedureDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_EstheticAlternativeProcedureDefinitionForm(viewModel, viewModel._EstheticAlternativeProcedureDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._EstheticAlternativeProcedureDefinition = new EstheticAlternativeProcedureDefinition(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EstheticAlternativeProcedureDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EstheticAlternativeProcedureDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EstheticAlternativeProcedureDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EstheticAlternativeProcedureDefinition);
                    PreScript_EstheticAlternativeProcedureDefinitionForm(viewModel, viewModel._EstheticAlternativeProcedureDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel EstheticAlternativeProcedureDefinitionForm(EstheticAlternativeProcedureDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return EstheticAlternativeProcedureDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel EstheticAlternativeProcedureDefinitionFormInternal(EstheticAlternativeProcedureDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("c0a95f49-8f26-45b2-80cf-4358063ac50c");
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel._EstheticAlternativeProcedureDefinition);
            objectContext.ProcessRawObjects();

            var estheticAlternativeProcedureDefinition = (EstheticAlternativeProcedureDefinition)objectContext.GetLoadedObject(viewModel._EstheticAlternativeProcedureDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(estheticAlternativeProcedureDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EstheticAlternativeProcedureDefinition, formDefID);
            var transDef = estheticAlternativeProcedureDefinition.TransDef;
            PostScript_EstheticAlternativeProcedureDefinitionForm(viewModel, estheticAlternativeProcedureDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(estheticAlternativeProcedureDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(estheticAlternativeProcedureDefinition);
            AfterContextSaveScript_EstheticAlternativeProcedureDefinitionForm(viewModel, estheticAlternativeProcedureDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_EstheticAlternativeProcedureDefinitionForm(EstheticAlternativeProcedureDefinitionFormViewModel viewModel, EstheticAlternativeProcedureDefinition estheticAlternativeProcedureDefinition, TTObjectContext objectContext);
        partial void PostScript_EstheticAlternativeProcedureDefinitionForm(EstheticAlternativeProcedureDefinitionFormViewModel viewModel, EstheticAlternativeProcedureDefinition estheticAlternativeProcedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_EstheticAlternativeProcedureDefinitionForm(EstheticAlternativeProcedureDefinitionFormViewModel viewModel, EstheticAlternativeProcedureDefinition estheticAlternativeProcedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(EstheticAlternativeProcedureDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class EstheticAlternativeProcedureDefinitionFormViewModel
    {
        public TTObjectClasses.EstheticAlternativeProcedureDefinition _EstheticAlternativeProcedureDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }
    }
}
