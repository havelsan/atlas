//$2A596F23
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class IQIntelligenceTestReportServiceController
    {
        partial void PreScript_IQIntelligenceTestReportForm(IQIntelligenceTestReportFormViewModel viewModel, IQIntelligenceTestReport iQIntelligenceTestReport, TTObjectContext objectContext)
        {
            if (iQIntelligenceTestReport.PsychologyBasedObject != null)
            {
                viewModel.isUserAuthorized = iQIntelligenceTestReport.PsychologyBasedObject.isUserAuthorized(iQIntelligenceTestReport);
            }
            else
            {
                viewModel.isUserAuthorized = true;
            }

            if (iQIntelligenceTestReport.AddedUser == null)
            {
                iQIntelligenceTestReport.AddedUser = Common.CurrentResource;
                ContextToViewModel(viewModel, objectContext);
            }
        }

        partial void PostScript_IQIntelligenceTestReportForm(IQIntelligenceTestReportFormViewModel viewModel, IQIntelligenceTestReport iQIntelligenceTestReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (iQIntelligenceTestReport.AddedDate == null)
            {
                iQIntelligenceTestReport.AddedDate = Common.RecTime();
            }
        }
    }
}

namespace Core.Models
{
    public partial class IQIntelligenceTestReportFormViewModel
    {
        public Boolean isUserAuthorized;
    }
}