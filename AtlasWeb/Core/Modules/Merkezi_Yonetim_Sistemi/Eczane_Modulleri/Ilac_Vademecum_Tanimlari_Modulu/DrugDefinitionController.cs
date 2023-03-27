//$8F4159B5
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class DrugDefinitionController : Controller
    {
        public ActionResult CheckSitesBeforeChangeDrugToConsumableMaterialForm()
        {
            const string viewVirtualPath = "~/Modules/Merkezi_Yonetim_Sistemi/Eczane_Modulleri/Ilac_Vademecum_Tanimlari_Modulu/CheckSitesBeforeChangeDrugToConsumableMaterialForm.cshtml";
            return View(viewVirtualPath);
        }
    }
}
