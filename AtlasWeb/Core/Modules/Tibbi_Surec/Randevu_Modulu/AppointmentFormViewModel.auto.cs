//$F95F87C7
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class AppointmentServiceController : Controller
    {
        partial void PreScript_AppointmentForm(AppointmentFormViewModel viewModel, Appointment appointment, TTObjectContext objectContext);
        partial void PostScript_AppointmentForm(AppointmentFormViewModel viewModel, Appointment appointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_AppointmentForm(AppointmentFormViewModel viewModel, Appointment appointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        partial void PreScript_AppointmentListForm(AppointmentFormViewModel viewModel, Appointment appointment, TTObjectContext objectContext);
        partial void PostScript_AppointmentListForm(AppointmentFormViewModel viewModel, Appointment appointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_AppointmentListForm(AppointmentFormViewModel viewModel, Appointment appointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    }
}

namespace Core.Models
{
    public partial class AppointmentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Appointment _Appointment
        {
            get;
            set;
        }
    }
}