using TTObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTInstanceManagement;
using Core.Models;
using static Core.Controllers.PatientAdmissionServiceController;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public class KioskServices: Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResultSet LoadPatientAdmission1(long? kimlikno)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmissionServiceController serviceController = new PatientAdmissionServiceController();
                Patient p = Patient.GetPatientsByUniqueRefNo(objectContext,kimlikno.Value).FirstOrDefault();
                PatientAdmissionFormViewModel viewModel = serviceController.PatientAdmissionFormLoad(p);
                return SavePatientAdmission1(viewModel);
            }



        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResultSet SavePatientAdmission1(PatientAdmissionFormViewModel viewModel)
        {
            PatientAdmissionServiceController serviceController = new PatientAdmissionServiceController();
            try
            {
                ResultSet result = serviceController.PatientAdmissionForm(viewModel);
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
