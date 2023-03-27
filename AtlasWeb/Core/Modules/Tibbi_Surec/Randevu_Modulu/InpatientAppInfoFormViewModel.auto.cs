//$EB11A64C
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
        public InpatientAppInfoFormViewModel InpatientAppInfoForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return InpatientAppInfoFormLoadInternal(input);
        }

        [HttpPost]
        public InpatientAppInfoFormViewModel InpatientAppInfoFormLoad(FormLoadInput input)
        {
            return InpatientAppInfoFormLoadInternal(input);
        }

        private InpatientAppInfoFormViewModel InpatientAppInfoFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("907c23ca-543b-4efe-98fb-3282aa31b389");
            var objectDefID = Guid.Parse("db2cc7f9-1fab-4da2-a1ce-8ddc9339eaeb");
            var viewModel = new InpatientAppInfoFormViewModel();
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

                    PreScript_InpatientAppInfoForm(viewModel, viewModel._InpatientAppointment, objectContext);
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
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InpatientAppointment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InpatientAppointment);
                    PreScript_InpatientAppInfoForm(viewModel, viewModel._InpatientAppointment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel InpatientAppInfoForm(InpatientAppInfoFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return InpatientAppInfoFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel InpatientAppInfoFormInternal(InpatientAppInfoFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("907c23ca-543b-4efe-98fb-3282aa31b389");
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResBeds);
            objectContext.AddToRawObjectList(viewModel.ResRooms);
            objectContext.AddToRawObjectList(viewModel.ResWards);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            var entryStateID = Guid.Parse("197b703f-1d22-4892-88db-8cb77d9e1d94");
            objectContext.AddToRawObjectList(viewModel._InpatientAppointment, entryStateID);
            objectContext.ProcessRawObjects(false);

            var inpatientAppointment = (InpatientAppointment)objectContext.GetLoadedObject(viewModel._InpatientAppointment.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientAppointment, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAppointment, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(inpatientAppointment);
            PostScript_InpatientAppInfoForm(viewModel, inpatientAppointment, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientAppointment);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientAppointment);
            AfterContextSaveScript_InpatientAppInfoForm(viewModel, inpatientAppointment, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_InpatientAppInfoForm(InpatientAppInfoFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTObjectContext objectContext);
        partial void PostScript_InpatientAppInfoForm(InpatientAppInfoFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_InpatientAppInfoForm(InpatientAppInfoFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(InpatientAppInfoFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ResBeds = objectContext.LocalQuery<ResBed>().ToArray();
            viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
            viewModel.ResWards = objectContext.LocalQuery<ResWard>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BedListDefinition", viewModel.ResBeds);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomListDefinition", viewModel.ResRooms);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WardListDefinition", viewModel.ResWards);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class InpatientAppInfoFormViewModel
    {
        public TTObjectClasses.InpatientAppointment _InpatientAppointment
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.ResBed[] ResBeds
        {
            get;
            set;
        }

        public TTObjectClasses.ResRoom[] ResRooms
        {
            get;
            set;
        }

        public TTObjectClasses.ResWard[] ResWards
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
