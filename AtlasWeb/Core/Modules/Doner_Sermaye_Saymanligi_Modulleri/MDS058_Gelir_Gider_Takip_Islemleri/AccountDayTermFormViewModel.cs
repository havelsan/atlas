using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class AccountDayTermServiceController
    {
        [HttpPost]
        public BindingList<AccountDayTerm.GetAllAccountDayTerms_Class> GetAccountDays()
        {
            BindingList<AccountDayTerm.GetAllAccountDayTerms_Class> list = AccountDayTerm.GetAllAccountDayTerms();
            return list;
        }

        [HttpGet]
        public void DeleteSelectedAccountDay(Guid id)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountDayTerm av = objectContext.GetObject<AccountDayTerm>(id);
                av.CurrentStateDefID = AccountDayTerm.States.Cancelled;
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class AccountDayTermFormViewModel: BaseViewModel
    {
    }
}
