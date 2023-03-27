//$09F48E20
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PatientOnVacationServiceController
    {
        partial void PreScript_PatientOnVacationForm(PatientOnVacationFormViewModel viewModel, PatientOnVacation patientOnVacation, TTObjectContext objectContext)
        {
            int a = 0;
            if (patientOnVacation.InpatientPhysician == null)
            {
                InPatientPhysicianApplication physicianApplication = patientOnVacation.ObjectContext.GetObject<InPatientPhysicianApplication>(viewModel.ActiveIDsModel.EpisodeActionId.Value);
                patientOnVacation.InpatientPhysician = physicianApplication;
                patientOnVacation.ApproveDoctor = physicianApplication.ProcedureDoctor;
                patientOnVacation.VacationAdress = physicianApplication.PatientAdmission != null ? physicianApplication.PatientAdmission.PA_Address.HomeAddress : physicianApplication.Episode.Patient.PatientAddress.HomeAddress;

                ContextToViewModel(viewModel, objectContext);
            }

            //if (!((ITTObject)viewModel._PatientOnVacation).IsNew && patientOnVacation.CurrentStateDefID == PatientOnVacation.States.OnVacation)
            //{
            //    patientOnVacation.EndDate = Common.RecTime();
            //}
        }

        partial void PostScript_PatientOnVacationForm(PatientOnVacationFormViewModel viewModel, PatientOnVacation patientOnVacation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }
    }
}

namespace Core.Models
{
    public partial class PatientOnVacationFormViewModel: BaseViewModel
    {
    }
}
