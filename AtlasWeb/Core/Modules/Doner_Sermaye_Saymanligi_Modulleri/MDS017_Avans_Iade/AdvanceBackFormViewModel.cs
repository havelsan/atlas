//$0FC0C907
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
    public partial class AdvanceBackServiceController
    {
        partial void PreScript_AdvanceBackForm(AdvanceBackFormViewModel viewModel, AdvanceBack advanceBack, TTObjectContext objectContext)
        {
            if (((ITTObject)advanceBack).IsNew)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    viewModel._AdvanceBack.Episode = episode;
                }

                viewModel._AdvanceBack.PrepareNewAdvanceBack();
                ContextToViewModel(viewModel, objectContext);
            }
        }
    }
}

namespace Core.Models
{
    public partial class AdvanceBackFormViewModel
    {
    }
}