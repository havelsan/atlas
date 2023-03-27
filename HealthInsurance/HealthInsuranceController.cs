using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance
{
    [Route("api/[controller]/[action]/{id?}")]
    public partial class HealthInsuranceController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
        public string Test()
        {
            return "deneme";
        }

    }
}
