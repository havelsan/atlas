//$1C9F5A7E
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class PathologyPanicAlertController : Controller
    {
        public ActionResult PanicAlertForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Patoloji_Modulu/PanicAlertForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
