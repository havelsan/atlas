//$549588C6
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class BondPaymentServiceController
    {
        partial void PreScript_BondPaymentForm(BondPaymentFormViewModel viewModel, BondPayment bondPayment, TTObjectContext objectContext)
        {
            if (((ITTObject)bondPayment).IsNew)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    viewModel._BondPayment.Episode = episode;
                }

                viewModel._BondPayment.PrepareNewBondpayment();
                ContextToViewModel(viewModel, objectContext);
            }
        }

        partial void PostScript_BondPaymentForm(BondPaymentFormViewModel viewModel, BondPayment bondPayment, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }
    }
}

namespace Core.Models
{
    public partial class BondPaymentFormViewModel
    {
    }
}