//$765D0F7E
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
    public partial class FTRVucutBolgesiServiceController : Controller
    {
        public class GetFTRVucutBolgesiDefinitionQuery_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class> GetFTRVucutBolgesiDefinitionQuery(GetFTRVucutBolgesiDefinitionQuery_Input input)
        {
            var ret = FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_ListDef_Getirme)]
        public BindingList<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class> GetFTRVucutBolgesiQuery()
        {
            var ret = FTRVucutBolgesi.GetFTRVucutBolgesiQuery();
            return ret;
        }
    }
}