//$34D0AE98
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class PatientOnVacationController : Controller
    {
        public ActionResult PatientOnVacationForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/PatientOnVacationForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
