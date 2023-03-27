//$FA7EE2FC
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
        partial void PreScript_DistributionDocumentNewForm(DistributionDocumentNewFormViewModel viewModel, DistributionDocument distributionDocument, TTObjectContext objectContext)
        {
            string utsEnt = TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "");
            if (utsEnt != null || utsEnt != string.Empty)
                viewModel.UTSEntegration = bool.Parse(utsEnt);
            else
                viewModel.UTSEntegration = false;
        }

        partial void PostScript_DistributionDocumentNewForm(DistributionDocumentNewFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (distributionDocument.DestinationStore is PharmacySubStoreDefinition)
            {
                distributionDocument.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketimYatanHastaTedavisi;
            }
            else
            {
                if (distributionDocument.DestinationStore is SubStoreDefinition)
                {
                    if (((SubStoreDefinition)(distributionDocument.DestinationStore)).MKYS_CikisHareketTuru != null)
                        distributionDocument.MKYS_CikisStokHareketTuru = ((SubStoreDefinition)(distributionDocument.DestinationStore)).MKYS_CikisHareketTuru;
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class DistributionDocumentNewFormViewModel
    {
        public bool UTSEntegration { get; set; }
    }
}