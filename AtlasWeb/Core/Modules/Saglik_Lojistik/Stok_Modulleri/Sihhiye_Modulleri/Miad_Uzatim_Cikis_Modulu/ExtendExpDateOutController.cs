//$83B9414D
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ExtendExpDateOutController : Controller
    {
        public ActionResult ExtendExpDateOutForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Cikis_Modulu/ExtendExpDateOutForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult ExtendExpDateOutCompFom()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Cikis_Modulu/ExtendExpDateOutCompFom.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult BaseExtendExpDateOutForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Cikis_Modulu/BaseExtendExpDateOutForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
