//$FFF78042
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class NursingWoundedAssesmentController : Controller
    {
        public ActionResult NursingWoundedAssesmentForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/NursingWoundedAssesmentForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
