//$ECA724FB
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class HemodialysisOrderController : Controller
    {
        public ActionResult HemodialysisPlanForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodialysisPlanForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult HemodialysisOrderForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodialysisOrderForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
