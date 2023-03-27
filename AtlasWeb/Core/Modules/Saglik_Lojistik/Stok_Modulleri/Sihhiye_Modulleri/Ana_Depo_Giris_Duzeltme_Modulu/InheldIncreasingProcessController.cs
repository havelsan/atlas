//$243B57E2
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class InheldIncreasingProcessController : Controller
    {
        public ActionResult InheldIncreasingProcessForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Giris_Duzeltme_Modulu/InheldIncreasingProcessForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
