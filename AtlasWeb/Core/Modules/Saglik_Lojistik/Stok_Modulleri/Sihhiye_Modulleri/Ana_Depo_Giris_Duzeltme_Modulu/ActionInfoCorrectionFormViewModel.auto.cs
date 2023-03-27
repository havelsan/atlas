//$644C2140
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
    public partial class ActionInfoCorrectionServiceController : Controller
    {
        [HttpGet]
        public ActionInfoCorrectionFormViewModel ActionInfoCorrectionForm(Guid? id)
        {
            var formDefID = Guid.Parse("d7f2c395-10be-43dd-b6b2-530fe0a648ef");
            var objectDefID = Guid.Parse("368cad20-87de-4e4b-8d3d-c747c292d296");
            var viewModel = new ActionInfoCorrectionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ActionInfoCorrection = objectContext.GetObject(id.Value, objectDefID) as ActionInfoCorrection;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ActionInfoCorrection, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ActionInfoCorrection, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ActionInfoCorrection);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ActionInfoCorrection);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ActionInfoCorrectionForm(viewModel, viewModel._ActionInfoCorrection, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ActionInfoCorrection = new ActionInfoCorrection(objectContext);
                    var entryStateID = Guid.Parse("3fb1ad9a-7f3a-4628-ae1b-9d2d04286d39");
                    viewModel._ActionInfoCorrection.CurrentStateDefID = entryStateID;
                    viewModel.ActionInfoCorrectionDetsGridList = new TTObjectClasses.ActionInfoCorrectionDet[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ActionInfoCorrection, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ActionInfoCorrection, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ActionInfoCorrection);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ActionInfoCorrection);
                    PreScript_ActionInfoCorrectionForm(viewModel, viewModel._ActionInfoCorrection, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ActionInfoCorrectionForm(ActionInfoCorrectionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ActionInfoCorrectionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ActionInfoCorrectionFormInternal(ActionInfoCorrectionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("d7f2c395-10be-43dd-b6b2-530fe0a648ef");
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.ActionInfoCorrectionDetsGridList);
            var entryStateID = Guid.Parse("3fb1ad9a-7f3a-4628-ae1b-9d2d04286d39");
            objectContext.AddToRawObjectList(viewModel._ActionInfoCorrection, entryStateID);
            objectContext.ProcessRawObjects(false);

            var actionInfoCorrection = (ActionInfoCorrection)objectContext.GetLoadedObject(viewModel._ActionInfoCorrection.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(actionInfoCorrection, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ActionInfoCorrection, formDefID);

            if (viewModel.ActionInfoCorrectionDetsGridList != null)
            {
                foreach (var item in viewModel.ActionInfoCorrectionDetsGridList)
                {
                    var actionInfoCorrectionDetsImported = (ActionInfoCorrectionDet)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)actionInfoCorrectionDetsImported).IsDeleted)
                        continue;
                    actionInfoCorrectionDetsImported.ActionInfoCorrection = actionInfoCorrection;
                }
            }
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(actionInfoCorrection);
            PostScript_ActionInfoCorrectionForm(viewModel, actionInfoCorrection, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(actionInfoCorrection);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(actionInfoCorrection);
            AfterContextSaveScript_ActionInfoCorrectionForm(viewModel, actionInfoCorrection, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ActionInfoCorrectionForm(ActionInfoCorrectionFormViewModel viewModel, ActionInfoCorrection actionInfoCorrection, TTObjectContext objectContext);
        partial void PostScript_ActionInfoCorrectionForm(ActionInfoCorrectionFormViewModel viewModel, ActionInfoCorrection actionInfoCorrection, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ActionInfoCorrectionForm(ActionInfoCorrectionFormViewModel viewModel, ActionInfoCorrection actionInfoCorrection, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ActionInfoCorrectionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ActionInfoCorrectionDetsGridList = viewModel._ActionInfoCorrection.ActionInfoCorrectionDets.OfType<ActionInfoCorrectionDet>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        }
    }
}


namespace Core.Models
{
    public partial class ActionInfoCorrectionFormViewModel
    {
        public TTObjectClasses.ActionInfoCorrection _ActionInfoCorrection
        {
            get;
            set;
        }

        public TTObjectClasses.ActionInfoCorrectionDet[] ActionInfoCorrectionDetsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}
