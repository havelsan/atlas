//$5849EF9A
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ProcedureResultInfoController : Controller
    {
        public ActionResult ProcedureResultInfoForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureResultInfoForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
