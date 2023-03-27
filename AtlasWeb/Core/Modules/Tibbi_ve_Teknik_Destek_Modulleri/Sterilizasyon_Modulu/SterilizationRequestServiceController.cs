//$E47E06B5
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class SterilizationRequestServiceController : Controller
    {
    }
}