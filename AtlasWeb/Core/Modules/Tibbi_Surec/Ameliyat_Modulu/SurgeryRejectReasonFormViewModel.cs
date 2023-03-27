//$AA05E2FD
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
    public partial class SurgeryRejectReasonServiceController
    {
        partial void PreScript_SurgeryRejectReasonForm(SurgeryRejectReasonFormViewModel viewModel, SurgeryRejectReason surgeryRejectReason, TTObjectContext objectContext)
        {
            
        }
    }
}

namespace Core.Models
{
    public partial class SurgeryRejectReasonFormViewModel: BaseViewModel
    {
    }
}
