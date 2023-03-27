//$BDDC2465
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ConvTestServiceController : Controller
    {
        public class NoyuBirArttir_Input
        {
            public int no
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public int NoyuBirArttir(NoyuBirArttir_Input input)
        {
            var ret = ConvTest.NoyuBirArttir(input.no);
            return ret;
        }
    }
}