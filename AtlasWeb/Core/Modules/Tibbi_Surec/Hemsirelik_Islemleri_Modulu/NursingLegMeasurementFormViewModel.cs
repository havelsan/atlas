//$CF64C516
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
    public partial class NursingLegMeasurementServiceController
    {
        partial void PreScript_NursingLegMeasurementForm(NursingLegMeasurementFormViewModel viewModel, NursingLegMeasurement nursingLegMeasurement, TTObjectContext objectContext)
        {
            if (nursingLegMeasurement.ApplicationUser == null)
                nursingLegMeasurement.ApplicationUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class NursingLegMeasurementFormViewModel
    {
    }
}
