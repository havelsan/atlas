
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class SurgeryServiceController
    {

        [HttpGet]
        public SurgerySummaryFormViewModel SurgerySummaryForm(Guid? id)
        {

            var viewModel = new SurgerySummaryFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var episodeAction = objectContext.GetObject(id.Value, "EpisodeAction") as EpisodeAction;
                    viewModel._EpisodeAction = episodeAction;
                    if (episodeAction is Surgery)
                    {

                    }else if (episodeAction is SubSurgery)
                    {

                    }


                    viewModel.ReadOnly = true; // şimdilik bu form hep Readonly olcak

              
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void SurgerySummaryForm(SurgerySummaryFormViewModel viewModel)
        {

        }

        public static SurgerySummaryFormViewModel[] GetOtherSurgerySummaryFormViewModellList(Surgery mainSurgery,EpisodeAction mySurgery)// mySurgery ,Subsuregry yada Surgery olabilir .mainSurgery'nin ,mySurgeri hariçindeki Ek ameliyat yada ana ameliyatların her biri için SurgerySummaryFormViewModel döndürülür
        {
            SurgeryServiceController surgeryServiceController = new SurgeryServiceController();
            List<SurgerySummaryFormViewModel> surgerySummaryFormViewModellList = new List<SurgerySummaryFormViewModel>();

            if(mainSurgery.ObjectID!= mySurgery.ObjectID)
            {
                SurgerySummaryFormViewModel mainSurgerySummaryFormViewModel = new SurgerySummaryFormViewModel();
                mainSurgerySummaryFormViewModel._EpisodeAction = mainSurgery;
                mainSurgerySummaryFormViewModel.ResponsibleDoctorName = mainSurgery.ProcedureDoctor == null ? "" : mainSurgery.ProcedureDoctor.Name;
                mainSurgerySummaryFormViewModel.DepartmentName = mainSurgery.FromResource.Name;
                mainSurgerySummaryFormViewModel.SurgeryReport = mainSurgery.SurgeryReport;
                mainSurgerySummaryFormViewModel.SurgeryProcedureFormViewModelList = SurgeryProcedureServiceController.GetSurgeryProcedureFormViewModelList(mainSurgery.MainSurgeryProcedures.ToList<SurgeryProcedure>());
                surgerySummaryFormViewModellList.Add(mainSurgerySummaryFormViewModel);
            }

            foreach (var subsurgery in mainSurgery.SubSurgeries)
            {
                if (subsurgery.ObjectID != mySurgery.ObjectID)
                {
                    SurgerySummaryFormViewModel subsurgerySurgerySummaryFormViewModel = new SurgerySummaryFormViewModel();
                    subsurgerySurgerySummaryFormViewModel._EpisodeAction = subsurgery;
                    subsurgerySurgerySummaryFormViewModel.ResponsibleDoctorName = subsurgery.ProcedureDoctor == null ? "" : subsurgery.ProcedureDoctor.Name;
                    subsurgerySurgerySummaryFormViewModel.DepartmentName = subsurgery.FromResource.Name;
                    subsurgerySurgerySummaryFormViewModel.SurgeryReport = subsurgery.SurgeryReport;
                    subsurgerySurgerySummaryFormViewModel.SurgeryProcedureFormViewModelList = SurgeryProcedureServiceController.GetSurgeryProcedureFormViewModelList(subsurgery.SubSurgeryProcedures.ToList<SurgeryProcedure>());
                    surgerySummaryFormViewModellList.Add(subsurgerySurgerySummaryFormViewModel);
                }
            }

            return surgerySummaryFormViewModellList.ToArray();
        }
    }
       
}

namespace Core.Models
{
    public class SurgerySummaryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EpisodeAction _EpisodeAction { get; set; }
        public string DepartmentName;
        public string ResponsibleDoctorName;
        public Object SurgeryReport;
        public SurgeryProcedureFormViewModel[] SurgeryProcedureFormViewModelList { get; set; }
    }
}
