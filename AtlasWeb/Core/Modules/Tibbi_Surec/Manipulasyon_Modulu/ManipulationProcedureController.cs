//$FA66391B
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ManipulationProcedureController : Controller
    {
        public ActionResult ManipulationProcedureRequestInfo()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Manipulasyon_Modulu/ManipulationProcedureRequestInfo.cshtml";
            return View(viewVirtualPath);
        }
    }
}
