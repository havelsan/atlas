//$8FFCDC5B
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
    public partial class SurgeryAppointmentServiceController
    {
        partial void PreScript_SurgeryAppointmentForm(SurgeryAppointmentFormViewModel viewModel, SurgeryAppointment surgeryAppointment, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            Guid? selectedPatientObjectID = viewModel.GetSelectedPatientID();
            if (selectedEpisodeActionObjectID.HasValue) //Randevu Action üzerinden açýldýðýnda
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel.PatientObject = episodeAction.Episode.Patient;
            }
            else if (selectedPatientObjectID.HasValue) //Randevu Action üzerinden açýlmadýðýnda
            {
                viewModel.PatientObject = objectContext.GetObject<Patient>(selectedPatientObjectID.Value);
            }

            viewModel._SurgeryAppointment.CreatedBy = Common.CurrentResource;
            viewModel._SurgeryAppointment.CreatedDate = Common.RecTime();
            viewModel._SurgeryAppointment.Patient = viewModel.PatientObject;
            if (surgeryAppointment.IsNeedAnesthesia == null)
                surgeryAppointment.IsNeedAnesthesia = true;
            bool isHeadDoctorApproveActive = TTObjectClasses.SystemParameter.GetParameterValue("AMELIYATRANDEVUBASHEKIMONAYAKTIF", "FALSE") == "FALSE" ? false : true;


            if (Common.CurrentUser.HasRole(TTRoleNames.Tabip))
            {
                if (isHeadDoctorApproveActive == true)
                    surgeryAppointment.CurrentStateDefID = SurgeryAppointment.States.HeadDoctorApproval;
                else
                    surgeryAppointment.CurrentStateDefID = SurgeryAppointment.States.Approved;
            }
        }

        partial void PostScript_SurgeryAppointmentForm(SurgeryAppointmentFormViewModel viewModel, SurgeryAppointment surgeryAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            foreach (SurgeryAppointmentProc proc in surgeryAppointment.SurgeryAppointmentProcedures)
            {
                if (proc.ProcedureDefinition.ProcedureMaterialMatches.Count > 0)
                {
                    //Hizmet malzeme eþleþmesinden gelen malzemeleri randevuya eklemek için
                    foreach (ProcedureMaterialMatch match in proc.ProcedureDefinition.ProcedureMaterialMatches)
                    {
                        SurgeryAppointmentMaterial surgeryMaterial = new SurgeryAppointmentMaterial(objectContext);
                        surgeryMaterial.Procedure = match.Procedure;
                        surgeryMaterial.Material = match.Material;
                        surgeryMaterial.Store = match.Store;
                        surgeryMaterial.Amount = match.Amount;
                        surgeryMaterial.SurgeryAppointment = surgeryAppointment;
                    }
                    objectContext.Save();
                }
            }

        }
    }
}

namespace Core.Models
{
    public partial class SurgeryAppointmentFormViewModel : BaseViewModel
    {
        public Patient PatientObject { get; set; }
    }
}
