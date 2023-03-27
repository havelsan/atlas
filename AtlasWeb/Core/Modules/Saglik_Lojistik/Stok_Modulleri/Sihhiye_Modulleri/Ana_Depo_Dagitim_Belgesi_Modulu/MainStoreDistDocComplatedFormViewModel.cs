//$F35BDA15
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

        partial void AfterContextSaveScript_MainStoreDistDocComplatedForm(MainStoreDistDocComplatedFormViewModel viewModel, MainStoreDistributionDoc mainStoreDistributionDoc, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
            {
                if (mainStoreDistributionDoc.CurrentStateDefID == DistributionDocument.States.Cancelled)
                {
                    if (mainStoreDistributionDoc.MKYS_AyniyatMakbuzID != null)
                        mainStoreDistributionDoc.SendDeleteMessageToMkys(true, mainStoreDistributionDoc.MKYS_AyniyatMakbuzID.Value, Common.CurrentResource.MkysPassword);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class MainStoreDistDocComplatedFormViewModel: BaseViewModel
    {
    }
}
