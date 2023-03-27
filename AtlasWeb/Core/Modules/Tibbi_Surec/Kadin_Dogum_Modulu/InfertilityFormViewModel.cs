//$113818DF
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
    public partial class InfertilityServiceController
    {
        partial void PreScript_InfertilityForm(InfertilityFormViewModel viewModel, Infertility infertility, TTObjectContext objectContext)
        {
            Guid? activePatientObjectID = viewModel.GetSelectedPatientID();
            if (activePatientObjectID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(activePatientObjectID.Value);
                viewModel._Patient = patient;
            }

            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class InfertilityFormViewModel
    {
        public Patient _Patient
        {
            get;
            set;
        }
    }
}
