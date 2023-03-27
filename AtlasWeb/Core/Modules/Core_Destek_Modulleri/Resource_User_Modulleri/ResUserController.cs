//$5830EE25
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class ResUserController : Controller
    {
        public ActionResult ResUserDefinitionForm()
        {
            const string viewVirtualPath = "~/Modules/Core_Destek_Modulleri/Resource_User_Modulleri/ResUserDefinitionForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
