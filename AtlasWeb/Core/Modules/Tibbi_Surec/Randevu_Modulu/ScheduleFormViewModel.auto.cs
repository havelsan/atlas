//$7B3A5BFA
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class ScheduleServiceController : Controller
    {

    }
}

namespace Core.Models
{
    public partial class ScheduleFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Schedule _Schedule
        {
            get;
            set;
        }
    }
}