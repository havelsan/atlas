//$6FEF3835
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ManipulationServiceController
    {
        partial void PreScript_AppointmentFormManipulation(AppointmentFormManipulationViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext)
        {
            viewModel.AppointmentDescription = BaseAction.GetFullAppointmentDescription(manipulation);
        }

        partial void PostScript_AppointmentFormManipulation(AppointmentFormManipulationViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            manipulation.CompleteMyNewAppoinments();
        }
    }
}

namespace Core.Models
{
    public partial class AppointmentFormManipulationViewModel
    {
        public string AppointmentDescription;
    }
}