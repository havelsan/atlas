//$CE630BE8
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class PhysiotherapyOrderController : Controller
    {
        public ActionResult PhysiotherapyOrderRequestForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyOrderRequestForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyPlannedOrdersForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyPlannedOrdersForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyOrderCancelledForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyOrderCancelledForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult BasePhysiotherapyOrderForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/BasePhysiotherapyOrderForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyCokluOzelDurum()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyCokluOzelDurum.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyOrderForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyOrderForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyPlanForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyPlanForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyOrderPlanningForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyOrderPlanningForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
