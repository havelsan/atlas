//$CEC31912
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
    public partial class PathologyAdditionalReportServiceController
    {
        partial void PreScript_PathologyAdditionalReportForm(PathologyAdditionalReportFormViewModel viewModel, PathologyAdditionalReport pathologyAdditionalReport, TTObjectContext objectContext)
        {
            if (pathologyAdditionalReport.CurrentStateDefID == PathologyAdditionalReport.States.New && pathologyAdditionalReport.ReportDate == null)
            {
                pathologyAdditionalReport.ReportDate = DateTime.Now;
            }
        }

        partial void PostScript_PathologyAdditionalReportForm(PathologyAdditionalReportFormViewModel viewModel, PathologyAdditionalReport pathologyAdditionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //if (pathologyAdditionalReport.Pathology == null)
            //{
                //Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
                //if (selectedEpisodeActionID.HasValue)
                //{
                //    Pathology pathology = objectContext.GetObject<Pathology>(selectedEpisodeActionID.Value);
                //    pathology.PathologyAdditionalReport = pathologyAdditionalReport;
                //    //pathologyAdditionalReport.Pathology = episodeAction as Pathology;
                //}
            //}

            if (pathologyAdditionalReport.CurrentStateDefID == PathologyAdditionalReport.States.Approved)
            {
                pathologyAdditionalReport.ApproveDate = DateTime.Now;
            }

            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                Pathology pathology = objectContext.GetObject<Pathology>(selectedEpisodeActionID.Value);
                pathology.PathologyAdditionalReport = pathologyAdditionalReport;
               
            }
        }
    }
}

namespace Core.Models
{
    public partial class PathologyAdditionalReportFormViewModel
    {
    }
}