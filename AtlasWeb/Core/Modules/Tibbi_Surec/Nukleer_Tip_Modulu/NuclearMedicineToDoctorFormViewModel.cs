//$D9B237EF
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
    public partial class NuclearMedicineServiceController
    {
        partial void PreScript_NuclearMedicineToDoctorForm(NuclearMedicineToDoctorFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext)
        {
            nuclearMedicine.SetProcedureDoctorAsCurrentResource();

            if (nuclearMedicine.ProcedureDate != null && nuclearMedicine.InjectionDate != null) {

                TimeSpan duration = Convert.ToDateTime(nuclearMedicine.ProcedureDate) - Convert.ToDateTime(nuclearMedicine.InjectionDate);
             


                viewModel.PatientWaitTime = duration.TotalMinutes.ToString() +" dk.";
            }
        }
    }
}

namespace Core.Models
{
    public partial class NuclearMedicineToDoctorFormViewModel: BaseViewModel
    {
        public string PatientWaitTime { get; set; }
    }

    public class vmNuclearMedicine
    {
        public Guid ActionObjectId { get; set; }
        public string AccessionNo { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedByResUser { get; set; }
        public string ProcedureResUser { get; set; }
        public string ActionStatus { get; set; }
        public string ProcedureResultLink { get; set; }
        public string ProcedureReportLink { get; set; }
        public bool isResultShown { get; set; }
        public bool isReportShown { get; set; }
        public string FromResourceName { get; set; }
    }
}
