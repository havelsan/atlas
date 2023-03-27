//$3F2C0DB7
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
    public partial class MainStoreDistributionDocServiceController
    {
        partial void AfterContextSaveScript_MainStoreDistDocApprovalForm(MainStoreDistDocApprovalFormViewModel viewModel, MainStoreDistributionDoc mainStoreDistributionDoc, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._MainStoreDistributionDoc.CurrentStateDefID == DistributionDocument.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    var sonucMesaji = mainStoreDistributionDoc.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class MainStoreDistDocApprovalFormViewModel: BaseViewModel
    {
    }
}
