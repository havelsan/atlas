//$5BFA3DB0
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class FollowingPatientsController : Controller
    {
        public ActionResult FollowingPatientsForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/FollowingPatientandAdmission/FollowingPatientsForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
