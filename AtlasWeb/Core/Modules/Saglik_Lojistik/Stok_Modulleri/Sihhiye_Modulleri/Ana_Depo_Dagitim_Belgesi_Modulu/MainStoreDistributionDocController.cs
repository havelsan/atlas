//$FB56345D
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class MainStoreDistributionDocController : Controller
    {
        public ActionResult BaseMainStoreDistributionDocForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/BaseMainStoreDistributionDocForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult MainStoreDistDocNewForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/MainStoreDistDocNewForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult MainStoreDistDocApprovalForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/MainStoreDistDocApprovalForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult MainStoreDistDocComplatedForm()
        {
            const string viewVirtualPath = "~/Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/MainStoreDistDocComplatedForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
