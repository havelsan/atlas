//$4C41EA7A
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class PostpartumFollowUpController : Controller
    {
        public ActionResult PostpartumFollowUpForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Kadin_Dogum_Modulu/PostpartumFollowUpForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
