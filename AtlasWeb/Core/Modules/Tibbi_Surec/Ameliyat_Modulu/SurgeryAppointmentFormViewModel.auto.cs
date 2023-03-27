//$0F8A6C36
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
    public partial class SurgeryAppointmentServiceController : Controller
    {

        [HttpGet]
        public SurgeryAppointmentFormViewModel SurgeryAppointmentForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SurgeryAppointmentFormLoadInternal(input);
        }

        [HttpPost]
        public SurgeryAppointmentFormViewModel SurgeryAppointmentFormLoad(FormLoadInput input)
        {
            return SurgeryAppointmentFormLoadInternal(input);
        }

        [HttpGet]
        public SurgeryAppointmentFormViewModel SurgeryAppointmentFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("cc259d9e-7e00-4d9f-a396-0ce08395c73d");
            var objectDefID = Guid.Parse("e0ba0d80-285d-4c08-9abf-e9a2655906bc");
            var viewModel = new SurgeryAppointmentFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SurgeryAppointment = objectContext.GetObject(id.Value, objectDefID) as SurgeryAppointment;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryAppointment, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryAppointment, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SurgeryAppointment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SurgeryAppointment);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_SurgeryAppointmentForm(viewModel, viewModel._SurgeryAppointment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SurgeryAppointment = new SurgeryAppointment(objectContext);
                    var entryStateID = Guid.Parse("67a5fd03-99a6-4a02-bf66-00135b67beb2");
                    viewModel._SurgeryAppointment.CurrentStateDefID = entryStateID;
                    viewModel.SurgeryAppointmentProceduresGridList = new TTObjectClasses.SurgeryAppointmentProc[] { };

                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryAppointment, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryAppointment, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SurgeryAppointment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SurgeryAppointment);
                    PreScript_SurgeryAppointmentForm(viewModel, viewModel._SurgeryAppointment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SurgeryAppointmentForm(SurgeryAppointmentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return SurgeryAppointmentFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel SurgeryAppointmentFormInternal(SurgeryAppointmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("cc259d9e-7e00-4d9f-a396-0ce08395c73d");
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryRooms);
            objectContext.AddToRawObjectList(viewModel.ResSurgeryDesks);
            objectContext.AddToRawObjectList(viewModel.SurgeryAppointmentProceduresGridList);
            objectContext.AddToRawObjectList(viewModel._SurgeryAppointment);
            objectContext.ProcessRawObjects();

            var surgeryAppointment = (SurgeryAppointment)objectContext.GetLoadedObject(viewModel._SurgeryAppointment.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgeryAppointment, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryAppointment, formDefID);

            if (viewModel.SurgeryAppointmentProceduresGridList != null)
            {
                foreach (var item in viewModel.SurgeryAppointmentProceduresGridList)
                {
                    var surgeryAppointmentProceduresImported = (SurgeryAppointmentProc)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)surgeryAppointmentProceduresImported).IsDeleted)
                        continue;
                    surgeryAppointmentProceduresImported.SurgeryAppointment = surgeryAppointment;
                }
            }
            var transDef = surgeryAppointment.TransDef;
            PostScript_SurgeryAppointmentForm(viewModel, surgeryAppointment, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgeryAppointment);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgeryAppointment);
            AfterContextSaveScript_SurgeryAppointmentForm(viewModel, surgeryAppointment, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_SurgeryAppointmentForm(SurgeryAppointmentFormViewModel viewModel, SurgeryAppointment surgeryAppointment, TTObjectContext objectContext);
        partial void PostScript_SurgeryAppointmentForm(SurgeryAppointmentFormViewModel viewModel, SurgeryAppointment surgeryAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SurgeryAppointmentForm(SurgeryAppointmentFormViewModel viewModel, SurgeryAppointment surgeryAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(SurgeryAppointmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.SurgeryAppointmentProceduresGridList = viewModel._SurgeryAppointment.SurgeryAppointmentProcedures.OfType<SurgeryAppointmentProc>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSurgeryRooms = objectContext.LocalQuery<ResSurgeryRoom>().ToArray();
            viewModel.ResSurgeryDesks = objectContext.LocalQuery<ResSurgeryDesk>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryRoomListDefinition", viewModel.ResSurgeryRooms);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryDeskListDefinition", viewModel.ResSurgeryDesks);
        }
    }
}


namespace Core.Models
{
    public partial class SurgeryAppointmentFormViewModel
    {
        public TTObjectClasses.SurgeryAppointment _SurgeryAppointment
        {
            get;
            set;
        }

        public TTObjectClasses.SurgeryAppointmentProc[] SurgeryAppointmentProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ResSurgeryRoom[] ResSurgeryRooms
        {
            get;
            set;
        }

        public TTObjectClasses.ResSurgeryDesk[] ResSurgeryDesks
        {
            get;
            set;
        }
    }
}
