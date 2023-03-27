//$EEB7FB37
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ReturningDocumentServiceController
    {
        partial void AfterContextSaveScript_ReturningDocumentApprovalForm(ReturningDocumentApprovalFormViewModel viewModel, ReturningDocument returningDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._ReturningDocument.CurrentStateDefID == ReturningDocument.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    var sonucMesaji = returningDocument.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ReturningDocumentApprovalFormViewModel
    {
    }
}