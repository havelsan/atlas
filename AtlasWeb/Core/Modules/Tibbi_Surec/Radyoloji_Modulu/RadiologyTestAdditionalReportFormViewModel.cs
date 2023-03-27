//$3FD5477A
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
    public partial class RadiologyAdditionalReportServiceController
    {
        partial void PreScript_RadiologyTestAdditionalReportForm(RadiologyTestAdditionalReportFormViewModel viewModel, RadiologyAdditionalReport radiologyAdditionalReport, TTObjectContext objectContext)
        {

            if (radiologyAdditionalReport.ReportDate == null)
                radiologyAdditionalReport.ReportDate = DateTime.Now;
        }
        partial void PostScript_RadiologyTestAdditionalReportForm(RadiologyTestAdditionalReportFormViewModel viewModel, RadiologyAdditionalReport radiologyAdditionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                RadiologyTest radiologyTest = objectContext.GetObject<RadiologyTest>(selectedEpisodeActionID.Value);
                radiologyTest.RadiologyAdditionalReport = radiologyAdditionalReport;

            }
        }

    }
}

namespace Core.Models
{
    public partial class RadiologyTestAdditionalReportFormViewModel: BaseViewModel
    {
    }
}
