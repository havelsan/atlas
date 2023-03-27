//$2DF37929
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class HemodialysisOrderDetailController : Controller
    {
        public ActionResult HemodialysisOrderDetailForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodialysisOrderDetailForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
