//$089AE2D2
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class RadiologyAdditionalReportController : Controller
    {
        public ActionResult RadiologyTestAdditionalReportForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Radyoloji_Modulu/RadiologyTestAdditionalReportForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
