//$5F21BCDB
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class InpatientAppointmentServiceController
    {
        partial void PreScript_GivenInpatientAppointmentForm(GivenInpatientAppointmentFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTObjectContext objectContext)
        {
            InPatientTreatmentClinicApplication inpatientEpisodeAction = new InPatientTreatmentClinicApplication();
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                inpatientEpisodeAction = objectContext.GetObject<InPatientTreatmentClinicApplication>(selectedEpisodeActionObjectID.Value);
            }

            viewModel.InpatientAppointmentList = new List<InpatientAppointmentInfo>();
            var appList = InpatientAppointment.GetInpatientAppByPatientAndClinic(objectContext, inpatientEpisodeAction.Episode.Patient.ObjectID, inpatientEpisodeAction.MasterResource.ObjectID);
            foreach (var item in appList)
            {
                InpatientAppointmentInfo info = new InpatientAppointmentInfo
                {
                    ObjectId = item.ObjectID,
                    ObjectDefName = item.ObjectDef.Name,
                    ClinicName = item.MasterResource.Name,
                    DoctorName = item.ResponsibleDoctor.Name,
                    AppDate = item.AppointmentDate != null ? item.AppointmentDate.Value : item.EntryDate.Value
                };
                viewModel.InpatientAppointmentList.Add(info);
            }

        }
        partial void PostScript_GivenInpatientAppointmentForm(GivenInpatientAppointmentFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            inpatientAppointment.IgnoreEdit();
            inpatientAppointment.DoNotSave = true;
        }
    }
}

namespace Core.Models
{
    public partial class GivenInpatientAppointmentFormViewModel : BaseViewModel
    {
        public List<InpatientAppointmentInfo> InpatientAppointmentList { get; set; }
        public List<InpatientAppointmentInfo> selectedRowKeysResultList { get; set; }
    }

    public class InpatientAppointmentInfo
    {
        public Guid ObjectId { get; set; }
        public string ObjectDefName { get; set; }
        public string ClinicName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppDate { get; set; }
    }
}
