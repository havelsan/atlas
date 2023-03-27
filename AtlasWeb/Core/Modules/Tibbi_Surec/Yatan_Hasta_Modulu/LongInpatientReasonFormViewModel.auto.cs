//$3D3DEACE
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
    public partial class InPatientTreatmentClinicApplicationServiceController : Controller
    {
        [HttpGet]
        public LongInpatientReasonFormViewModel LongInpatientReasonForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return LongInpatientReasonFormLoadInternal(input);
        }

        [HttpPost]
        public LongInpatientReasonFormViewModel LongInpatientReasonFormLoad(FormLoadInput input)
        {
            return LongInpatientReasonFormLoadInternal(input);
        }

        private LongInpatientReasonFormViewModel LongInpatientReasonFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("e3fc10fd-5124-41c6-bbe7-66f55cc0d990");
            var objectDefID = Guid.Parse("cc4f64b5-98c9-4f37-a51d-0a6bbf2897bd");
            var viewModel = new LongInpatientReasonFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InPatientTreatmentClinicApplication = objectContext.GetObject(id.Value, objectDefID) as InPatientTreatmentClinicApplication;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InPatientTreatmentClinicApplication);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InPatientTreatmentClinicApplication);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_LongInpatientReasonForm(viewModel, viewModel._InPatientTreatmentClinicApplication, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InPatientTreatmentClinicApplication);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InPatientTreatmentClinicApplication);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_LongInpatientReasonForm(viewModel, viewModel._InPatientTreatmentClinicApplication, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel LongInpatientReasonForm(LongInpatientReasonFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return LongInpatientReasonFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel LongInpatientReasonFormInternal(LongInpatientReasonFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("e3fc10fd-5124-41c6-bbe7-66f55cc0d990");
            objectContext.AddToRawObjectList(viewModel._InPatientTreatmentClinicApplication);
            objectContext.ProcessRawObjects();

            var inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)objectContext.GetLoadedObject(viewModel._InPatientTreatmentClinicApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inPatientTreatmentClinicApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
            var transDef = inPatientTreatmentClinicApplication.TransDef;
            PostScript_LongInpatientReasonForm(viewModel, inPatientTreatmentClinicApplication, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inPatientTreatmentClinicApplication);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inPatientTreatmentClinicApplication);
            AfterContextSaveScript_LongInpatientReasonForm(viewModel, inPatientTreatmentClinicApplication, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_LongInpatientReasonForm(LongInpatientReasonFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTObjectContext objectContext);
        partial void PostScript_LongInpatientReasonForm(LongInpatientReasonFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_LongInpatientReasonForm(LongInpatientReasonFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(LongInpatientReasonFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class LongInpatientReasonFormViewModel
    {
        public TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication
        {
            get;
            set;
        }
    }
}
