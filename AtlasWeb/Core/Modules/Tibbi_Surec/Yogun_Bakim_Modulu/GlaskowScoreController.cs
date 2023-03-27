//$9380100E
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class GlaskowScoreController : Controller
    {
        public ActionResult GlaskowScoreForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Yogun_Bakim_Modulu/GlaskowScoreForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
