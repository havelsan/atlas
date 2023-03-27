//$34314695
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ActionInfoCorrectionController : Controller
    {
        public ActionResult ActionInfoCorrectionForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Giris_Duzeltme_Modulu/ActionInfoCorrectionForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
