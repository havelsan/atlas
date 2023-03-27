//$AD05F622
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
    public partial class AnesthesiaDefinitionServiceController : Controller
    {

        [HttpGet]
        public AnesthesiaDefinitionFormViewModel AnesthesiaDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return AnesthesiaDefinitionFormInternal(input);
        }

        [HttpPost]
        public AnesthesiaDefinitionFormViewModel AnesthesiaDefinitionFormLoad(FormLoadInput input)
        {
            return AnesthesiaDefinitionFormInternal(input);
        }

        private AnesthesiaDefinitionFormViewModel AnesthesiaDefinitionFormInternal(FormLoadInput input)
        {

            Guid? id = input.Id;

            var formDefID = Guid.Parse("bc1e3852-d92f-4dbd-90aa-592dec534895");
            var objectDefID = Guid.Parse("6fd42f4d-4a22-445f-8e6d-4c3e588a9283");
            var viewModel = new AnesthesiaDefinitionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._AnesthesiaDefinition = objectContext.GetObject(id.Value, objectDefID) as AnesthesiaDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AnesthesiaDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AnesthesiaDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AnesthesiaDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_AnesthesiaDefinitionForm(viewModel, viewModel._AnesthesiaDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._AnesthesiaDefinition = new AnesthesiaDefinition(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AnesthesiaDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AnesthesiaDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AnesthesiaDefinition);
                    PreScript_AnesthesiaDefinitionForm(viewModel, viewModel._AnesthesiaDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel AnesthesiaDefinitionForm(AnesthesiaDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return AnesthesiaDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel AnesthesiaDefinitionFormInternal(AnesthesiaDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("bc1e3852-d92f-4dbd-90aa-592dec534895");
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel._AnesthesiaDefinition);
            objectContext.ProcessRawObjects();

            var anesthesiaDefinition = (AnesthesiaDefinition)objectContext.GetLoadedObject(viewModel._AnesthesiaDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(anesthesiaDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AnesthesiaDefinition, formDefID);
            var transDef = anesthesiaDefinition.TransDef;
            PostScript_AnesthesiaDefinitionForm(viewModel, anesthesiaDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(anesthesiaDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(anesthesiaDefinition);
            AfterContextSaveScript_AnesthesiaDefinitionForm(viewModel, anesthesiaDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_AnesthesiaDefinitionForm(AnesthesiaDefinitionFormViewModel viewModel, AnesthesiaDefinition anesthesiaDefinition, TTObjectContext objectContext);
        partial void PostScript_AnesthesiaDefinitionForm(AnesthesiaDefinitionFormViewModel viewModel, AnesthesiaDefinition anesthesiaDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_AnesthesiaDefinitionForm(AnesthesiaDefinitionFormViewModel viewModel, AnesthesiaDefinition anesthesiaDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(AnesthesiaDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class AnesthesiaDefinitionFormViewModel
    {
        public TTObjectClasses.AnesthesiaDefinition _AnesthesiaDefinition
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
