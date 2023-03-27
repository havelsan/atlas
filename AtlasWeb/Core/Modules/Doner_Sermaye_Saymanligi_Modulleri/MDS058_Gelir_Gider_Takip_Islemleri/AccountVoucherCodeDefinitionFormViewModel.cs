//$5B3DE244
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class AccountVoucherCodeDefinitionServiceController
    {
        partial void PostScript_AccountVoucherCodeDefinitionForm(AccountVoucherCodeDefinitionFormViewModel viewModel, AccountVoucherCodeDefinition accountVoucherCodeDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            BindingList<AccountVoucherCodeDefinition.GetIsCodeBe_Class> list = AccountVoucherCodeDefinition.GetIsCodeBe(viewModel._AccountVoucherCodeDefinition.Code);
            foreach (AccountVoucherCodeDefinition.GetIsCodeBe_Class item in list)
            {
                if (item.ObjectID != viewModel._AccountVoucherCodeDefinition.ObjectID)
                    throw new Exception("Bu kod ile tanım bulunmaktadır.");
            }
        }
    }
}

namespace Core.Models
{
    public partial class AccountVoucherCodeDefinitionFormViewModel : BaseViewModel
    {
    }
}
