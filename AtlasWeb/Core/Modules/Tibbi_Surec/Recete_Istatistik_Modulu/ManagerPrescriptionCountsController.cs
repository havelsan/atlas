//$0489DF10
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ManagerPrescriptionCountsController : Controller
    {
        public ActionResult ManagerPrescriptionCountForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Poliklinik_Modulu/ManagerPrescriptionCountForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
