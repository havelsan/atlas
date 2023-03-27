//$FE61DFD7
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
        public ShortInpatientReasonFormViewModel ShortInpatientReasonForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ShortInpatientReasonFormLoadInternal(input);
        }

        [HttpPost]
        public ShortInpatientReasonFormViewModel ShortInpatientReasonFormLoad(FormLoadInput input)
        {
            return ShortInpatientReasonFormLoadInternal(input);
        }

        private ShortInpatientReasonFormViewModel ShortInpatientReasonFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("3e0d1799-205b-4561-8e11-96719512143c");
            var objectDefID = Guid.Parse("cc4f64b5-98c9-4f37-a51d-0a6bbf2897bd");
            var viewModel = new ShortInpatientReasonFormViewModel();
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

                    PreScript_ShortInpatientReasonForm(viewModel, viewModel._InPatientTreatmentClinicApplication, objectContext);
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

                    PreScript_ShortInpatientReasonForm(viewModel, viewModel._InPatientTreatmentClinicApplication, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ShortInpatientReasonForm(ShortInpatientReasonFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ShortInpatientReasonFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ShortInpatientReasonFormInternal(ShortInpatientReasonFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("3e0d1799-205b-4561-8e11-96719512143c");
            objectContext.AddToRawObjectList(viewModel._InPatientTreatmentClinicApplication);
            objectContext.ProcessRawObjects();

            var inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)objectContext.GetLoadedObject(viewModel._InPatientTreatmentClinicApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inPatientTreatmentClinicApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
            var transDef = inPatientTreatmentClinicApplication.TransDef;
            PostScript_ShortInpatientReasonForm(viewModel, inPatientTreatmentClinicApplication, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inPatientTreatmentClinicApplication);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inPatientTreatmentClinicApplication);
            AfterContextSaveScript_ShortInpatientReasonForm(viewModel, inPatientTreatmentClinicApplication, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ShortInpatientReasonForm(ShortInpatientReasonFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTObjectContext objectContext);
        partial void PostScript_ShortInpatientReasonForm(ShortInpatientReasonFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ShortInpatientReasonForm(ShortInpatientReasonFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ShortInpatientReasonFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class ShortInpatientReasonFormViewModel
    {
        public TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication
        {
            get;
            set;
        }
    }
}
