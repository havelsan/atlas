//$90DFD63A
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
    public partial class HalfDoseDestructionServiceController : Controller
    {
        [HttpGet]
        public HalfDoseDestructionFormViewModel HalfDoseDestructionForm(Guid? id)
        {
            var formDefID = Guid.Parse("ffcf8daf-f4c6-43db-81c6-8f7f139f55fc");
            var objectDefID = Guid.Parse("d4338e34-3e24-42a0-892a-4ce9ec2eb144");
            var viewModel = new HalfDoseDestructionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HalfDoseDestruction = objectContext.GetObject(id.Value, objectDefID) as HalfDoseDestruction;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HalfDoseDestruction, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HalfDoseDestruction, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HalfDoseDestruction);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HalfDoseDestruction);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_HalfDoseDestructionForm(viewModel, viewModel._HalfDoseDestruction, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HalfDoseDestruction = new HalfDoseDestruction(objectContext);
                    var entryStateID = Guid.Parse("ae3bce9a-968c-40f2-be56-2a883b10cf3d");
                    viewModel._HalfDoseDestruction.CurrentStateDefID = entryStateID;
                    viewModel.HalfDoseDestructionDetailsGridList = new TTObjectClasses.HalfDoseDestructionDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HalfDoseDestruction, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HalfDoseDestruction, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HalfDoseDestruction);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HalfDoseDestruction);
                    PreScript_HalfDoseDestructionForm(viewModel, viewModel._HalfDoseDestruction, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel HalfDoseDestructionForm(HalfDoseDestructionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return HalfDoseDestructionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel HalfDoseDestructionFormInternal(HalfDoseDestructionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("ffcf8daf-f4c6-43db-81c6-8f7f139f55fc");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.UnitDefinitions);
            objectContext.AddToRawObjectList(viewModel.HalfDoseDestructionDetailsGridList);
            var entryStateID = Guid.Parse("ae3bce9a-968c-40f2-be56-2a883b10cf3d");
            objectContext.AddToRawObjectList(viewModel._HalfDoseDestruction, entryStateID);
            objectContext.ProcessRawObjects(false);

            var halfDoseDestruction = (HalfDoseDestruction)objectContext.GetLoadedObject(viewModel._HalfDoseDestruction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(halfDoseDestruction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HalfDoseDestruction, formDefID);

            if (viewModel.HalfDoseDestructionDetailsGridList != null)
            {
                foreach (var item in viewModel.HalfDoseDestructionDetailsGridList)
                {
                    var halfDoseDestructionDetailsImported = (HalfDoseDestructionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)halfDoseDestructionDetailsImported).IsDeleted)
                        continue;
                    halfDoseDestructionDetailsImported.HalfDoseDestruction = halfDoseDestruction;
                }
            }
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(halfDoseDestruction);
            PostScript_HalfDoseDestructionForm(viewModel, halfDoseDestruction, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(halfDoseDestruction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(halfDoseDestruction);
            AfterContextSaveScript_HalfDoseDestructionForm(viewModel, halfDoseDestruction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_HalfDoseDestructionForm(HalfDoseDestructionFormViewModel viewModel, HalfDoseDestruction halfDoseDestruction, TTObjectContext objectContext);
        partial void PostScript_HalfDoseDestructionForm(HalfDoseDestructionFormViewModel viewModel, HalfDoseDestruction halfDoseDestruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_HalfDoseDestructionForm(HalfDoseDestructionFormViewModel viewModel, HalfDoseDestruction halfDoseDestruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(HalfDoseDestructionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.HalfDoseDestructionDetailsGridList = viewModel._HalfDoseDestruction.HalfDoseDestructionDetails.OfType<HalfDoseDestructionDetail>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.UnitDefinitions = objectContext.LocalQuery<UnitDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserDefinitionList", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoresList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UnitListDefinition", viewModel.UnitDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class HalfDoseDestructionFormViewModel
    {
        public TTObjectClasses.HalfDoseDestruction _HalfDoseDestruction
        {
            get;
            set;
        }

        public TTObjectClasses.HalfDoseDestructionDetail[] HalfDoseDestructionDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }

        public TTObjectClasses.UnitDefinition[] UnitDefinitions
        {
            get;
            set;
        }
    }
}
