//$6BB38442
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
    public partial class HemodialysisInstructionServiceController
    {
        partial void PreScript_InstructionListForm(InstructionListFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTObjectContext objectContext)
        {
            Guid? activeEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (activeEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(activeEpisodeActionObjectID.Value);

                var baseMultipleDataEntryServiceController = new BaseMultipleDataEntryServiceController();
                // MultipleDataComponent için Eklendiði formun presine eklenir
                int summaryLimitCount = 5;
                viewModel.HemodialysisInstructionInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, episodeAction.BaseMultipleDataEntries.ToList<BaseMultipleDataEntry>());

                hemodialysisInstruction.EpisodeAction = episodeAction;
            }
        }
    }
}

namespace Core.Models
{
    public partial class InstructionListFormViewModel : BaseViewModel
    {
        public List<MultipleDataComponent_SummaryInfo> HemodialysisInstructionInfoList  // MultipleDataComponent için
        {
            get;
            set;
        }
    }
}
