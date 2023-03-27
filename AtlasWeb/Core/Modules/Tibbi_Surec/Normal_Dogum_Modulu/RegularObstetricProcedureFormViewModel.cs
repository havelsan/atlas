//$75A53969
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
    public partial class RegularObstetricServiceController
    {
        partial void PreScript_RegularObstetricProcedureForm(RegularObstetricProcedureFormViewModel viewModel, RegularObstetric regularObstetric, TTObjectContext objectContext)
        {
            regularObstetric.SetProcedureDoctorAsCurrentResource();
        }

    }
}

namespace Core.Models
{
    public partial class RegularObstetricProcedureFormViewModel: BaseViewModel
    {
    }
}
