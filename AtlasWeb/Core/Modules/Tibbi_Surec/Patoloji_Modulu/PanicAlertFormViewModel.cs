//$5598AB9F
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class PathologyPanicAlertServiceController
    {
        partial void PreScript_PanicAlertForm(PanicAlertFormViewModel viewModel, PathologyPanicAlert pathologyPanicAlert, TTObjectContext objectContext)
        {
            if (pathologyPanicAlert.PanicAlertDate == null)
                 pathologyPanicAlert.PanicAlertDate = DateTime.Now;

            viewModel.UserName = Common.CurrentResource.Name;
            viewModel.DoctorName = "";
            viewModel.NotifiedDoctorName = "";
            
            Guid ? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                Pathology pathology = objectContext.GetObject<Pathology>(selectedEpisodeActionID.Value);
                viewModel.DoctorName = pathology.ProcedureDoctor != null ? pathology.ProcedureDoctor.Name : "";
                viewModel.NotifiedDoctorName = pathology.PathologyRequest.RequestDoctor.Name;

            }
           
        }
        partial void PostScript_PanicAlertForm(PanicAlertFormViewModel viewModel, PathologyPanicAlert pathologyPanicAlert, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //if (pathologyPanicAlert.Pathology == null)
            //{
            //    Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            //    if (selectedEpisodeActionID.HasValue)
            //    {
            //        EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
            //        pathologyPanicAlert.Pathology = episodeAction as Pathology;
            //    }
            //}
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                Pathology pathology = objectContext.GetObject<Pathology>(selectedEpisodeActionID.Value);
                pathology.PathologyPanicAlert = pathologyPanicAlert;

               
            }
            pathologyPanicAlert.User = viewModel.UserName;


        }

    }
}

namespace Core.Models
{
    public partial class PanicAlertFormViewModel: BaseViewModel
    {
        public string UserName { get; set; } //Panik Bildirim Yapan Kullanýcý
        public string DoctorName { get; set; } //Panik Bildirim Yapan Doktor
        public string NotifiedDoctorName { get; set; } //Panik Bildirim Yapýlan Doktor
    }
}
