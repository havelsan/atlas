//$496860F4
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class SafeSurgeryCheckListController : Controller
    {
        public ActionResult SafeSurgeryCheckListForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Ameliyat_Modulu/SafeSurgeryCheckListForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
