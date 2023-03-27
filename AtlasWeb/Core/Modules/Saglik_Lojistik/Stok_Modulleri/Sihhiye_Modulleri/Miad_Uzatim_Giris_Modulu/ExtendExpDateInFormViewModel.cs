//$291B09FA
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ExtendExpDateInServiceController
    {
        partial void AfterContextSaveScript_ExtendExpDateInForm(ExtendExpDateInFormViewModel viewModel, ExtendExpDateIn extendExpDateIn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = string.Empty;
            if (viewModel._ExtendExpDateIn.CurrentStateDefID == ExtendExpDateIn.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {

                    sonucMesaji = extendExpDateIn.SendUpdateMessageToMKYS(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ExtendExpDateInFormViewModel: BaseViewModel
    {
    }
}
