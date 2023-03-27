//$374FFEDD
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class DistributionDocumentServiceController
    {
        partial void AfterContextSaveScript_DistributionDocumentApprovalForm(DistributionDocumentApprovalFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._DistributionDocument.CurrentStateDefID == DistributionDocument.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    var sonucMesaji = distributionDocument.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class DistributionDocumentApprovalFormViewModel
    {
        public OuttableLotDTO[] OuttableLotList { get; set; }
    }
}