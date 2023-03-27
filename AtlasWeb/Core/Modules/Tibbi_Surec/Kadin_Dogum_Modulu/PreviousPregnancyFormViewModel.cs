//$80A99715
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class PregnancyServiceController
    {
        partial void PreScript_PreviousPregnancyForm(PreviousPregnancyFormViewModel viewModel, Pregnancy pregnancy, TTObjectContext objectContext)
        {
            if (viewModel._Pregnancy.Patient == null)
            {
                Guid? activePatientObjectID = viewModel.GetSelectedPatientID();
                if (activePatientObjectID.HasValue)
                {
                    Patient patient = objectContext.GetObject<Patient>(activePatientObjectID.Value);
                    viewModel._Pregnancy.Patient = patient;
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class PreviousPregnancyFormViewModel
    {
    }
}
