//$E086295A
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
    public partial class SurgeryRejectReasonServiceController : Controller
    {

        [HttpGet]
        public SurgeryRejectReasonFormViewModel SurgeryRejectReasonForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SurgeryRejectReasonFormLoadInternal(input);
        }

        [HttpPost]
        public SurgeryRejectReasonFormViewModel SurgeryRejectReasonFormLoad(FormLoadInput input)
        {
            return SurgeryRejectReasonFormLoadInternal(input);
        }

        private SurgeryRejectReasonFormViewModel SurgeryRejectReasonFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("f6ccc1cc-86be-4ebf-8aa3-8530a65ea606");
            var objectDefID = Guid.Parse("fd82a2fd-e836-4418-91f1-18dfe0635ab4");
            var viewModel = new SurgeryRejectReasonFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SurgeryRejectReason = objectContext.GetObject(id.Value, objectDefID) as SurgeryRejectReason;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryRejectReason, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryRejectReason, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SurgeryRejectReason);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SurgeryRejectReason);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_SurgeryRejectReasonForm(viewModel, viewModel._SurgeryRejectReason, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SurgeryRejectReason = new SurgeryRejectReason(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryRejectReason, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryRejectReason, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SurgeryRejectReason);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SurgeryRejectReason);
                    PreScript_SurgeryRejectReasonForm(viewModel, viewModel._SurgeryRejectReason, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SurgeryRejectReasonForm(SurgeryRejectReasonFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return SurgeryRejectReasonFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel SurgeryRejectReasonFormInternal(SurgeryRejectReasonFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("f6ccc1cc-86be-4ebf-8aa3-8530a65ea606");
            objectContext.AddToRawObjectList(viewModel._SurgeryRejectReason);
            objectContext.ProcessRawObjects();

            var surgeryRejectReason = (SurgeryRejectReason)objectContext.GetLoadedObject(viewModel._SurgeryRejectReason.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgeryRejectReason, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryRejectReason, formDefID);
            var transDef = surgeryRejectReason.TransDef;
            PostScript_SurgeryRejectReasonForm(viewModel, surgeryRejectReason, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgeryRejectReason);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgeryRejectReason);
            AfterContextSaveScript_SurgeryRejectReasonForm(viewModel, surgeryRejectReason, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_SurgeryRejectReasonForm(SurgeryRejectReasonFormViewModel viewModel, SurgeryRejectReason surgeryRejectReason, TTObjectContext objectContext);
        partial void PostScript_SurgeryRejectReasonForm(SurgeryRejectReasonFormViewModel viewModel, SurgeryRejectReason surgeryRejectReason, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SurgeryRejectReasonForm(SurgeryRejectReasonFormViewModel viewModel, SurgeryRejectReason surgeryRejectReason, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(SurgeryRejectReasonFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class SurgeryRejectReasonFormViewModel
    {
        public TTObjectClasses.SurgeryRejectReason _SurgeryRejectReason
        {
            get;
            set;
        }
    }
}
