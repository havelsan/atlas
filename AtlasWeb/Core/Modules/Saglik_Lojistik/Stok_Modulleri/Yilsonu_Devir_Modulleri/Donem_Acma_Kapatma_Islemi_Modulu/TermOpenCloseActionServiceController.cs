//$1608E346
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using TTUtils;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class TermOpenCloseActionServiceController : Controller
    {
        public class GetAccountingTerm_Input
        {
            public MainStoreDefinition mainStore { get; set; }
        }

        public class GetAccountingTerm_Output
        {
            public AccountingTerm accountingTerm { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Saymanlik_Donemi_Tanimlari, TTRoleNames.Saymanlik_Donemi_Tanimlari_Guncelleme, TTRoleNames.Saymanlik_Tanimlari_Kayit)]
        public GetAccountingTerm_Output GetHalfOpenAccountingTermByMainStore(GetAccountingTerm_Input input)
        {
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)readOnlyContext.GetObject(input.mainStore.ObjectID, typeof(MainStoreDefinition));

            AccountingTerm halfOpenAccountingTerm = mainStoreDefinition.Accountancy.GetHalfOpenAccountingTerm();
            GetAccountingTerm_Output halfOpenAcc = new GetAccountingTerm_Output();

            halfOpenAcc.accountingTerm = halfOpenAccountingTerm;
            return halfOpenAcc;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Saymanlik_Donemi_Tanimlari, TTRoleNames.Saymanlik_Donemi_Tanimlari_Guncelleme, TTRoleNames.Saymanlik_Tanimlari_Kayit)]
        public GetAccountingTerm_Output GetOpenAccountingTermByMainStore(GetAccountingTerm_Input input)
        {
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)readOnlyContext.GetObject(input.mainStore.ObjectID, typeof(MainStoreDefinition));

            AccountingTerm openAccountingTerm = mainStoreDefinition.Accountancy.GetOpenAccountingTerm();
            GetAccountingTerm_Output openAcc = new GetAccountingTerm_Output();

            if (openAccountingTerm == null)
                throw new TTException(input.mainStore.Name + " için açýk dönem bulunamamýþtýr");

            openAcc.accountingTerm = openAccountingTerm;
            return openAcc;
        }

    }
}