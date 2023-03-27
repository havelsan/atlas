//$704F463B
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
        partial void AfterContextSaveScript_DistributionDocumentCompletedForm(DistributionDocumentCompletedFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
            {
                if (distributionDocument.CurrentStateDefID == DistributionDocument.States.Cancelled)
                {
                    if (distributionDocument.MKYS_AyniyatMakbuzID != null)
                        distributionDocument.SendDeleteMessageToMkys(true, distributionDocument.MKYS_AyniyatMakbuzID.Value, Common.CurrentResource.MkysPassword);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class DistributionDocumentCompletedFormViewModel
    {
    }
}