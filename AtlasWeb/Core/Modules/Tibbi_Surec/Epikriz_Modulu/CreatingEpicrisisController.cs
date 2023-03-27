//$B85E1471
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class CreatingEpicrisisController : Controller
    {       
        public ActionResult CreatingEpicrisisForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Epikriz_Modulu/CreatingEpicrisisForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
