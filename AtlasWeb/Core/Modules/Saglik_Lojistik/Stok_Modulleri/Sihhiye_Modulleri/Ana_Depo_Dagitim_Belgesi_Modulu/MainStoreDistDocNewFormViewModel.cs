//$68D95D39
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
        partial void PostScript_MainStoreDistDocNewForm(MainStoreDistDocNewFormViewModel viewModel, MainStoreDistributionDoc mainStoreDistributionDoc, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (mainStoreDistributionDoc.DestinationStore is PharmacySubStoreDefinition)
            {
                mainStoreDistributionDoc.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketimYatanHastaTedavisi;
            }
            else
            {
                if (mainStoreDistributionDoc.DestinationStore is SubStoreDefinition)
                {
                    if (((SubStoreDefinition)(mainStoreDistributionDoc.DestinationStore)).MKYS_CikisHareketTuru != null)
                        mainStoreDistributionDoc.MKYS_CikisStokHareketTuru = ((SubStoreDefinition)(mainStoreDistributionDoc.DestinationStore)).MKYS_CikisHareketTuru;
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class MainStoreDistDocNewFormViewModel: BaseViewModel
    {
    }
}
