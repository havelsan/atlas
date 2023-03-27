//$432EB968
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class MedicalOncologyController : Controller
    {
        public ActionResult MedicalOncologySpecialityForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Onkoloji_Modulu/MedicalOncologySpecialityForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
