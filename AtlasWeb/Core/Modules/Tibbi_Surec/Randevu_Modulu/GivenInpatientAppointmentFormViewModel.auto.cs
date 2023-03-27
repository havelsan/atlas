//$47F25137
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
    public partial class InpatientAppointmentServiceController : Controller
    {
        [HttpGet]
        public GivenInpatientAppointmentFormViewModel GivenInpatientAppointmentForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return GivenInpatientAppointmentFormLoadInternal(input);
        }

        [HttpPost]
        public GivenInpatientAppointmentFormViewModel GivenInpatientAppointmentFormLoad(FormLoadInput input)
        {
            return GivenInpatientAppointmentFormLoadInternal(input);
        }

        private GivenInpatientAppointmentFormViewModel GivenInpatientAppointmentFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("4e07a392-31b1-4ef4-8190-38c1687e3139");
            var objectDefID = Guid.Parse("db2cc7f9-1fab-4da2-a1ce-8ddc9339eaeb");
            var viewModel = new GivenInpatientAppointmentFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InpatientAppointment = objectContext.GetObject(id.Value, objectDefID) as InpatientAppointment;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientAppointment, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAppointment, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InpatientAppointment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InpatientAppointment);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_GivenInpatientAppointmentForm(viewModel, viewModel._InpatientAppointment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InpatientAppointment = new InpatientAppointment(objectContext);
                    var entryStateID = Guid.Parse("197b703f-1d22-4892-88db-8cb77d9e1d94");
                    viewModel._InpatientAppointment.CurrentStateDefID = entryStateID;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientAppointment, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAppointment, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InpatientAppointment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InpatientAppointment);

                    PreScript_GivenInpatientAppointmentForm(viewModel, viewModel._InpatientAppointment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel GivenInpatientAppointmentForm(GivenInpatientAppointmentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return GivenInpatientAppointmentFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel GivenInpatientAppointmentFormInternal(GivenInpatientAppointmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("4e07a392-31b1-4ef4-8190-38c1687e3139");
            objectContext.AddToRawObjectList(viewModel._InpatientAppointment);
            objectContext.ProcessRawObjects();

            var inpatientAppointment = (InpatientAppointment)objectContext.GetLoadedObject(viewModel._InpatientAppointment.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientAppointment, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAppointment, formDefID);
            var transDef = inpatientAppointment.TransDef;
            PostScript_GivenInpatientAppointmentForm(viewModel, inpatientAppointment, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientAppointment);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientAppointment);
            AfterContextSaveScript_GivenInpatientAppointmentForm(viewModel, inpatientAppointment, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_GivenInpatientAppointmentForm(GivenInpatientAppointmentFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTObjectContext objectContext);
        partial void PostScript_GivenInpatientAppointmentForm(GivenInpatientAppointmentFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_GivenInpatientAppointmentForm(GivenInpatientAppointmentFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(GivenInpatientAppointmentFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class GivenInpatientAppointmentFormViewModel
    {
        public TTObjectClasses.InpatientAppointment _InpatientAppointment
        {
            get;
            set;
        }
    }
}
