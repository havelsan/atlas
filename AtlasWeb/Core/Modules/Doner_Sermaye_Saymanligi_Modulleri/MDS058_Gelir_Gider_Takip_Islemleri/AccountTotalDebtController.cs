//$F0608704
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class AccountTotalDebtController : Controller
    {
        public ActionResult AccountTotalDebtForm()
        {
            const string viewVirtualPath = "~/Modules/Doner_Sermaye_Saymanligi_Modulleri/MDS058_Gelir_Gider_Takip_Islemleri/AccountTotalDebtForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
