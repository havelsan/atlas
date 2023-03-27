//$94D5459E
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class AdvanceServiceController
    {
        partial void PreScript_AdvanceForm(AdvanceFormViewModel viewModel, Advance advance, TTObjectContext objectContext)
        {
            if (((ITTObject)advance).IsNew)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    var episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    viewModel._Advance.Episode = episode;
                }

                viewModel._Advance.PrepareNewAdvance();
                ContextToViewModel(viewModel, objectContext);
                viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            }
        }
    }
}

namespace Core.Models
{
    public partial class AdvanceFormViewModel
    {
        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }
    }
}