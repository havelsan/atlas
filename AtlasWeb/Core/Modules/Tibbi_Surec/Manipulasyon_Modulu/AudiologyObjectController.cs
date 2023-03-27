//$B0D7EB72
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class AudiologyObjectController : Controller
    {
        public ActionResult AudiologyForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Manipulasyon_Modulu/AudiologyForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
