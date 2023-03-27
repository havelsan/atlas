//$7B013E6E
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class SurgeryAppointmentController : Controller
    {
        public ActionResult SurgeryAppointmentForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Ameliyat_Modulu/SurgeryAppointmentForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
