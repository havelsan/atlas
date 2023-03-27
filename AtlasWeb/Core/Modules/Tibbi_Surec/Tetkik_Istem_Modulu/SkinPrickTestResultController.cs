//$B7327BC6
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class SkinPrickTestResultController : Controller
    {
        public ActionResult SkinPrickTestResultForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/SkinPrickTestResultForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
