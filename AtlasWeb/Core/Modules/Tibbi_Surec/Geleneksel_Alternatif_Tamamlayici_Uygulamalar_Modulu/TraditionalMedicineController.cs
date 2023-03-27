//$A94A1B13
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class TraditionalMedicineController : Controller
    {
        public ActionResult GetatExaminationForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Geleneksel_Alternatif_Tamamlayici_Uygulamalar_Modulu/GetatExaminationForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
