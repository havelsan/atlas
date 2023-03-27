using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Modules.Tibbi_Surec.Laboratuar_Is_Listesi
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class LaboratoryWorkListServiceController : Controller
    {
    }
}