//$56CAC173
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
    public partial class GlaskowScoreServiceController
    {
        partial void PreScript_GlaskowScoreForm(GlaskowScoreFormViewModel viewModel, GlaskowScore glaskowScore, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = glaskowScore.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    glaskowScore.EpisodeAction = episodeAction;
                }
            }
            viewModel.GlaskowEyeDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._GlaskowScore.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.Eyes).OrderBy(x => x.Score).ToArray();
            viewModel.GlaskowOralAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._GlaskowScore.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.OralAnswer).OrderBy(x => x.Score).ToArray();
            viewModel.GlaskowMotorAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._GlaskowScore.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.MotorAnswer).OrderBy(x => x.Score).ToArray();

            glaskowScore.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class GlaskowScoreFormViewModel : BaseViewModel
    {
        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowEyeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowOralAnswerDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowMotorAnswerDefinitions
        {
            get;
            set;
        }
    }
}
