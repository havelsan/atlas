//$A3CF6710
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ChemotherapyRadiotherapyController : Controller
    {
        public ActionResult ChemotherapyRadiotherapyForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Kemoterapi_ve_Radyoterapi_Modulu/ChemotherapyRadiotherapyForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
