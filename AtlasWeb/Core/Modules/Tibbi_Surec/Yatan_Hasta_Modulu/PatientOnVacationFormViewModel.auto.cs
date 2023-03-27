//$A29ECE92
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
    public partial class PatientOnVacationServiceController : Controller
    {

        [HttpGet]
        public PatientOnVacationFormViewModel PatientOnVacationForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PatientOnVacationFormLoadInternal(input);
        }

        [HttpPost]
        public PatientOnVacationFormViewModel PatientOnVacationFormLoad(FormLoadInput input)
        {
            return PatientOnVacationFormLoadInternal(input);
        }

        private PatientOnVacationFormViewModel PatientOnVacationFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("f54e5c85-a588-4989-81f7-724b58e77ade");
            var objectDefID = Guid.Parse("cc78827c-768e-4bcd-b5b0-17cda23e7726");
            var viewModel = new PatientOnVacationFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientOnVacation = objectContext.GetObject(id.Value, objectDefID) as PatientOnVacation;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOnVacation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOnVacation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PatientOnVacation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PatientOnVacation);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PatientOnVacationForm(viewModel, viewModel._PatientOnVacation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientOnVacation = new PatientOnVacation(objectContext);
                    var entryStateID = Guid.Parse("136902bc-e6e5-4b0d-8fbb-280e14e1f4fa");
                    viewModel._PatientOnVacation.CurrentStateDefID = entryStateID;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOnVacation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOnVacation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientOnVacation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientOnVacation);
                    PreScript_PatientOnVacationForm(viewModel, viewModel._PatientOnVacation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PatientOnVacationForm(PatientOnVacationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PatientOnVacationFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PatientOnVacationFormInternal(PatientOnVacationFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("f54e5c85-a588-4989-81f7-724b58e77ade");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            var entryStateID = Guid.Parse("136902bc-e6e5-4b0d-8fbb-280e14e1f4fa");
            objectContext.AddToRawObjectList(viewModel._PatientOnVacation, entryStateID);
            objectContext.ProcessRawObjects(false);

            var patientOnVacation = (PatientOnVacation)objectContext.GetLoadedObject(viewModel._PatientOnVacation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientOnVacation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOnVacation, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(patientOnVacation);
            PostScript_PatientOnVacationForm(viewModel, patientOnVacation, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientOnVacation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientOnVacation);
            AfterContextSaveScript_PatientOnVacationForm(viewModel, patientOnVacation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_PatientOnVacationForm(PatientOnVacationFormViewModel viewModel, PatientOnVacation patientOnVacation, TTObjectContext objectContext);
        partial void PostScript_PatientOnVacationForm(PatientOnVacationFormViewModel viewModel, PatientOnVacation patientOnVacation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PatientOnVacationForm(PatientOnVacationFormViewModel viewModel, PatientOnVacation patientOnVacation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(PatientOnVacationFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class PatientOnVacationFormViewModel
    {
        public TTObjectClasses.PatientOnVacation _PatientOnVacation
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
