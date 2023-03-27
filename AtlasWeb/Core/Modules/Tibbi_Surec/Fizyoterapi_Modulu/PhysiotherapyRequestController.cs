//$F96159D3
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class PhysiotherapyRequestController : Controller
    {
        public ActionResult PhysiotherapyRequestForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyRequestForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyCancelledForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyCancelledForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyPlanningForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyPlanningForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult OldPhysiotherapyRequestForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/OldPhysiotherapyRequestForm.cshtml";
            return View(viewVirtualPath);
        }
        public ActionResult PhysiotherapyRequestPlanningForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyRequestPlanningForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
