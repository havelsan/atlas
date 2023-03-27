//$6F9678E2
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DentalProsthesisProcedureServiceController : Controller
    {
        public class DentalProthesisPrintOutSQL_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class> DentalProthesisPrintOutSQL(DentalProthesisPrintOutSQL_Input input)
        {
            var ret = DentalProsthesisProcedure.DentalProthesisPrintOutSQL(input.OBJECTID);
            return ret;
        }

        public class DentalProthesisProcedureNQL_Input
        {
            public string DENTALPROSTHESISPROCEDURE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalProsthesisProcedure.DentalProthesisProcedureNQL_Class> DentalProthesisProcedureNQL(DentalProthesisProcedureNQL_Input input)
        {
            var ret = DentalProsthesisProcedure.DentalProthesisProcedureNQL(input.DENTALPROSTHESISPROCEDURE);
            return ret;
        }

        [HttpPost]
        public BindingList<DentalProsthesisProcedure.VEM_DISPROTEZ_Class> VEM_DISPROTEZ()
        {
            var ret = DentalProsthesisProcedure.VEM_DISPROTEZ();
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalProsthesisProcedure.VEM_DISPROTEZ_DETAY_Class> VEM_DISPROTEZ_DETAY()
        {
            var ret = DentalProsthesisProcedure.VEM_DISPROTEZ_DETAY();
            return ret;
        }
    }
}