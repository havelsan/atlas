//$05C71666
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class DentalCommitmentController : Controller
    {
        public ActionResult DentalCommitmentForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Dis_Muayene_Modulu/DentalCommitmentForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
