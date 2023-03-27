//$140971B9
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
using static TTObjectClasses.AccountVoucher;

namespace Core.Controllers
{
    public partial class AccountVoucherServiceController
    {
        [HttpPost]
        public BindingList<AccountVoucher.GetAllAccountVouchers_Class> GetAccountVoucher()
        {
            BindingList<AccountVoucher.GetAllAccountVouchers_Class> list = AccountVoucher.GetAllAccountVouchers();
            return list;
        }

        [HttpPost]
        public BindingList<AccountPeriodDefinition.GetAccountPeriodOnlyYear_Class> GetAccountVoucherOnlyYear()
        {
            BindingList<AccountPeriodDefinition.GetAccountPeriodOnlyYear_Class> list = AccountPeriodDefinition.GetAccountPeriodOnlyYear();
            return list;
        }

        [HttpPost]
        public BindingList<AccountVoucher.GetAccountVoucherWithParam_Class> GetAccountVoucherWithParam(GetAccountVoucherDeptParam param)
        {
            BindingList<AccountVoucher.GetAccountVoucherWithParam_Class> list = AccountVoucher.GetAccountVoucherWithParam(param.Month, param.Year);
            return list;
        }

        [HttpPost]
        public BindingList<AccountVoucher.GetAccountVoucherDept_Class> GetAccountVoucherDept(GetAccountVoucherDeptParam param)
        {
            BindingList<AccountVoucher.GetAccountVoucherDept_Class> list = AccountVoucher.GetAccountVoucherDept(param.Month, param.Year);
            return list;
        }

        [HttpPost]
        public BindingList<AccountVoucher.GetAccountVoucherIsDept_Class> GetAccountVoucherIsDept(GetAccountVoucherDeptParam param)
        {
            BindingList<AccountVoucher.GetAccountVoucherIsDept_Class> list = AccountVoucher.GetAccountVoucherIsDept(param.Month, param.Year);
            return list;
        }

        [HttpPost]
        public List<AccountVoucher.AccountVoucherPeriodPricesInfo> GetToplamYekun(GetAccountVoucherDeptParam param)
        {
            List<AccountVoucher.AccountVoucherPeriodPricesInfo> list = AccountVoucher.GetAccountVoucherPeriodPrices(param.Year, param.Month);
            return list;
        }

        [HttpGet]
        public void DeleteSelectedAccountVoucher(Guid id)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountVoucher av = objectContext.GetObject<AccountVoucher>(id);
                av.CurrentStateDefID = AccountVoucher.States.Cancelled;
                objectContext.Save();
            }
        }

        partial void PostScript_AccountVoucherEntryForm(AccountVoucherEntryFormViewModel viewModel, AccountVoucher accountVoucher, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (accountVoucher.AccountVoucherCodeDefinition != null)
            {
                if (string.IsNullOrEmpty(accountVoucher.AccountVoucherCodeDefinition.Code))
                    throw new Exception("Hesap kodu boş. Gelir/Gider Tanımlarını kontrol ediniz.");

                if (accountVoucher.AccountVoucherCodeDefinition.Code.Count(x => x == '.') < 2)
                    throw new Exception("İlk iki kırılıma giriş yapılamaz. En az üç kırılımı olan bir kod seçiniz.");
            }

            BindingList<AccountVoucher.GetIsCodeAndPeriod_Class> list = AccountVoucher.GetIsCodeAndPeriod(accountVoucher.AccountPeriod.ObjectID.ToString(), accountVoucher.AccountVoucherCodeDefinition.ObjectID.ToString());
            foreach (AccountVoucher.GetIsCodeAndPeriod_Class item in list)
            {
                if(item.ObjectID != accountVoucher.ObjectID)
                    throw new Exception("Bu döneme ait bu kod ile kayıt bulunmaktadır.");
            }
        }

        [HttpPost]
        public BindingList<AccountDayTerm.GetAccountDayTermsByMonthYear_Class> GetAccountDayTerm(GetAccountDayTermParam param)
        {
            BindingList<AccountDayTerm.GetAccountDayTermsByMonthYear_Class> list = AccountDayTerm.GetAccountDayTermsByMonthYear(param.Month, param.Year);
            return list;
        }

        [HttpPost]
        public BindingList<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class> GetAccountTotalDebt(GetAccountDayTermParam param)
        {
            BindingList<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class> list = AccountTotalDebt.GetAccountTotalDebtsByMonthYear(param.Month, param.Year);
            return list;
        }

    }
}

namespace Core.Models
{
    public partial class AccountVoucherEntryFormViewModel : BaseViewModel
    {
    }

    public partial class GetAccountVoucherDeptParam : BaseViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public partial class GetAccountDayTermParam : BaseViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }


}
