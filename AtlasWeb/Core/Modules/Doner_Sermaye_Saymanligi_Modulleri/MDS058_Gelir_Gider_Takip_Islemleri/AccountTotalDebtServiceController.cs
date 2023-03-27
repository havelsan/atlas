//$9B5AE8D5
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
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class AccountTotalDebtServiceController : Controller
    {
        [HttpPost]
        public BindingList<AccountTotalDebt.GetAllAccountTotalDebts_Class> GetTotalDebts()
        {
            BindingList<AccountTotalDebt.GetAllAccountTotalDebts_Class> list = AccountTotalDebt.GetAllAccountTotalDebts();
            return list;
        }

        [HttpGet]
        public void DeleteSelectedTotalDebt(Guid id)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountTotalDebt atd = objectContext.GetObject<AccountTotalDebt>(id);
                atd.CurrentStateDefID = AccountTotalDebt.States.Cancelled;
                objectContext.Save();
            }
        }

        partial void PostScript_AccountTotalDebtForm(AccountTotalDebtFormViewModel viewModel, AccountTotalDebt accountTotalDebt, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            BindingList<AccountTotalDebt.GetAllAccountTotalDebts_Class> list = AccountTotalDebt.GetAllAccountTotalDebts();
            if (list.Any(x => x.Month == accountTotalDebt.AccountPeriod.Month && x.Year == accountTotalDebt.AccountPeriod.Year && x.ObjectID != accountTotalDebt.ObjectID))
                throw new TTException("Bu döneme ait kayýt bulunmaktadýr.");
        }
    }
}