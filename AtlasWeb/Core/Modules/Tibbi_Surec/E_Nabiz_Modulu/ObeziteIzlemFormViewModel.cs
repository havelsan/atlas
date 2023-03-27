//$82AF8012
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
    public partial class ObeziteIzlemVeriSetiServiceController
    {
        partial void PreScript_ObeziteIzlemForm(ObeziteIzlemFormViewModel viewModel, ObeziteIzlemVeriSeti obeziteIzlemVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._ObeziteIzlemVeriSeti.EpisodeAction = episodeAction;
                viewModel._ObeziteIzlemVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class ObeziteIzlemFormViewModel : BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._ObeziteIzlemVeriSeti);

            if (this.ObeziteEgzersizGridList != null)
            {
                foreach (var item in this.ObeziteEgzersizGridList)
                {
                    var egzersizImported = (ObeziteEgzersiz)objectContext.AddObject(item);
                    egzersizImported.ObeziteIzlemVeriSeti = this._ObeziteIzlemVeriSeti;
                }
            }

            if (this.ObeziteEkHastalikGridList != null)
            {
                foreach (var item in this.ObeziteEkHastalikGridList)
                {
                    var ekHastalikImported = (ObeziteEkHastalik)objectContext.AddObject(item);
                    ekHastalikImported.ObeziteIzlemVeriSeti = this._ObeziteIzlemVeriSeti;
                }
            }

            var obeziteIzlem = (ObeziteIzlemVeriSeti)objectContext.GetLoadedObject(this._ObeziteIzlemVeriSeti.ObjectID);


            new SendToENabiz(objectContext, obeziteIzlem.SubEpisode, obeziteIzlem.ObjectID, obeziteIzlem.ObjectDef.Name, "240", Common.RecTime());
        }
    }
}
