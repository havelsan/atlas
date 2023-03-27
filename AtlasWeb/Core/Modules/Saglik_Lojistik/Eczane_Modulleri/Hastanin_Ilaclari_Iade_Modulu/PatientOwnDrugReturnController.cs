//$295AC717
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class PatientOwnDrugReturnController : Controller
    {
        public ActionResult PatientOwnDrugReturnForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Eczane_Modulleri/Hastanin_Ilaclari_Iade_Modulu/PatientOwnDrugReturnForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PatientOwnDrugReturnCompForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Eczane_Modulleri/Hastanin_Ilaclari_Iade_Modulu/PatientOwnDrugReturnCompForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
