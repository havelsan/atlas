//$D53F8CF7
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ForensicMedicalReportController : Controller
    {
        public ActionResult ForensicMedicalCancelledForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/ForensicMedicalCancelledForm.cshtml";
            return View(viewVirtualPath);
        }
   
    }
}
