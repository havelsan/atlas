//$5417D8DE
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ExtendExpDateInController : Controller
    {
        public ActionResult BaseExtendExpDateInForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Giris_Modulu/BaseExtendExpDateInForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult ExtendExpDateInForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Giris_Modulu/ExtendExpDateInForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult ExtendExpDateInCompForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Giris_Modulu/ExtendExpDateInCompForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
