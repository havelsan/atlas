//$31323719
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ExtendExpirationDateServiceController
    {
        partial void AfterContextSaveScript_ExtendExpDateApprovalForm(ExtendExpDateApprovalFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = string.Empty;
            if (viewModel._ExtendExpirationDate.CurrentStateDefID == ExtendExpirationDate.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    if (viewModel._ExtendExpirationDate.OutMkysControl == null || viewModel._ExtendExpirationDate.OutMkysControl == false)
                    {
                        sonucMesaji = extendExpirationDate.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        if (viewModel._ExtendExpirationDate.InMkysControl == null || viewModel._ExtendExpirationDate.InMkysControl == false)
                        {
                            sonucMesaji += extendExpirationDate.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                    else if (viewModel._ExtendExpirationDate.InMkysControl == null || viewModel._ExtendExpirationDate.InMkysControl == false)
                    {
                        sonucMesaji = extendExpirationDate.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }

                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ExtendExpDateApprovalFormViewModel
    {
    }
}