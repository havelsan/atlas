//$16E02781
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class HalfDoseDestructionController : Controller
    {
        public ActionResult HalfDoseDestructionForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Eczane_Modulleri/Yarim_Doz_Imha_Modulu/HalfDoseDestructionForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
