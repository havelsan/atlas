//$9BA9EB03
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class PhototherapyServiceController
    {
        partial void PreScript_PhototherapyForm(PhototherapyFormViewModel viewModel, Phototherapy phototherapy, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = phototherapy.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    phototherapy.EpisodeAction = episodeAction;
                }
            }
            phototherapy.EntryUser = Common.CurrentResource;

            viewModel.PhototherapyDefinitionList = new List<PhototherapyDefinitionDVO>();
            foreach (var item in PhototherapyDefinition.PhototherapyDefinitionNQL(""))
            {
                PhototherapyDefinitionDVO photo = new PhototherapyDefinitionDVO { ComplicatedExctrans = item.ComplicatedExcTrans, UncomplicatedExctrans = item.UncomplicatedExcTrans, ComplicatedPhototherapy = item.ComplicatedPhototherapy, UncomplicatedPhototherapy = item.UncomplicatedPhototherapy, StartTime = item.StartTime, FinishTime = item.FinishTime, MaxWeight = item.MaxWeight, MinWeight = item.MinWeight };
                viewModel.PhototherapyDefinitionList.Add(photo);
            }
        }
    }
}

namespace Core.Models
{
    public partial class PhototherapyFormViewModel: BaseViewModel
    {        public List<PhototherapyDefinitionDVO> PhototherapyDefinitionList
        {
            get;
            set;
        }
    }

    public class PhototherapyDefinitionDVO
    {
        public double? ComplicatedExctrans
        {
            get;
            set;
        }

        public double? UncomplicatedExctrans
        {
            get;
            set;
        }

        public double? ComplicatedPhototherapy
        {
            get;
            set;
        }

        public double? UncomplicatedPhototherapy
        {
            get;
            set;
        }

        public int? StartTime
        {
            get;
            set;
        }

        public int? FinishTime
        {
            get;
            set;
        }

        public int? MaxWeight
        {
            get;
            set;
        }

        public int? MinWeight
        {
            get;
            set;
        }


    }
}
