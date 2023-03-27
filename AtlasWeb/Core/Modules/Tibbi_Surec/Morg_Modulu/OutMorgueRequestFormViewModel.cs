//$91F8F7DA
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
    public partial class MorgueServiceController
    {
        partial void PostScript_OutMorgueRequestForm(OutMorgueRequestFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            morgue.Episode.Patient.DeathReportNo = viewModel._Morgue.DeathReportNo;
            morgue.Episode.Patient.ExDate = viewModel._Morgue.DateTimeOfDeath;

        }

        partial void AfterContextSaveScript_OutMorgueRequestForm(OutMorgueRequestFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //viewModel.Patients[0].DeathReportNo = viewModel._Morgue.DeathReportNo;
        }
    }
}

namespace Core.Models
{
    public partial class OutMorgueRequestFormViewModel
    {
    }
}
