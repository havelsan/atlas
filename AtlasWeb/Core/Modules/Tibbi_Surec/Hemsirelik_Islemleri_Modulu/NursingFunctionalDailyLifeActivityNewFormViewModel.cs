//$8732C6B5
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class NursingDailyLifeActivityServiceController
    {
        partial void PreScript_NursingFunctionalDailyLifeActivityNewForm(NursingFunctionalDailyLifeActivityNewFormViewModel viewModel, NursingDailyLifeActivity nursingDailyLifeActivity, TTObjectContext objectContext)
        {
            viewModel.FunctionalDailyLifeActivityList = DailyLifeActivityDefinition.GetDailyLifeActivityDefinitionList(objectContext, true).Where(p => p.ActivityGroup == NursingDailyLifeActivityGrupEnum.Functional).OrderBy(x => x.Name).ToArray();
            List<NursingFunctionalDailyLifeActivity> nList = new List<NursingFunctionalDailyLifeActivity>();
            if (((ITTObject)nursingDailyLifeActivity).IsNew)
            {
                foreach (var dailyLifeActivity in viewModel.FunctionalDailyLifeActivityList)
                {
                    NursingFunctionalDailyLifeActivity ss = new NursingFunctionalDailyLifeActivity(objectContext);
                    ss.DailyLifeActivity = dailyLifeActivity;
                    ss.IsCheck = false;
                    ss.DetailNote = String.Empty;
                    nList.Add(ss);
                }

                viewModel.NursingFunctionalDailyLifeActivityGridList = nList.ToArray();
                viewModel.DailyLifeActivityDefinitions = nList.Select(p => p.DailyLifeActivity).ToArray();


            }
            else
            {
                if (!viewModel.ReadOnly)
                {
                    using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                    {
                        viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingDailyLifeActivity);
                    }
                }
            }

            if (nursingDailyLifeActivity.ApplicationUser == null)
            {
                nursingDailyLifeActivity.ApplicationUser = Common.CurrentResource;
            }

            if (nursingDailyLifeActivity.NursingApplication?.SubEpisode?.InpatientAdmission?.HospitalInPatientDate != null)
                viewModel.QuarantineInPatientDate = (DateTime)nursingDailyLifeActivity.NursingApplication?.SubEpisode?.InpatientAdmission?.HospitalInPatientDate;
        }
    }
}

namespace Core.Models
{
    public partial class NursingFunctionalDailyLifeActivityNewFormViewModel
    {
        public TTObjectClasses.DailyLifeActivityDefinition[] FunctionalDailyLifeActivityList
        {
            get;
            set;
        }
        public DateTime QuarantineInPatientDate
        {
            get;
            set;
        }
    }
}