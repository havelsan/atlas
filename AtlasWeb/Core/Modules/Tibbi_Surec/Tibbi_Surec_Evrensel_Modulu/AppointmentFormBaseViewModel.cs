//$E2651808
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class BaseActionServiceController
    {
        partial void PreScript_AppointmentFormBase(AppointmentFormBaseViewModel viewModel, BaseAction baseAction, TTObjectContext objectContext)
        {
            viewModel.AppointmentDescription = BaseAction.GetFullAppointmentDescription(baseAction);
        }

        partial void PostScript_AppointmentFormBase(AppointmentFormBaseViewModel viewModel, BaseAction baseAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            baseAction.CompleteMyNewAppoinments();
        }
    }
}

namespace Core.Models
{
    public partial class AppointmentFormBaseViewModel
    {
        public string AppointmentDescription;
    }
}