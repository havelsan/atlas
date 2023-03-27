//$5A397872
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
    public partial class DiyabetVeriSetiServiceController
    {
        partial void PreScript_DiyabetForm(DiyabetFormViewModel viewModel, DiyabetVeriSeti diyabetVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._DiyabetVeriSeti.EpisodeAction = episodeAction;
                viewModel._DiyabetVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class DiyabetFormViewModel: BaseViewModel,IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._DiyabetVeriSeti);

            if (this.DiyabetKompBilgisiGridList != null)
            {
                foreach (var item in this.DiyabetKompBilgisiGridList)
                {
                    var diyabetKompBilgisiGridListImported = (DiyabetKompBilgisi)objectContext.AddObject(item);
                    diyabetKompBilgisiGridListImported.DiyabetVeriSeti = this._DiyabetVeriSeti;
                }
            }

            var diyabet = (DiyabetVeriSeti)objectContext.GetLoadedObject(this._DiyabetVeriSeti.ObjectID);


            new SendToENabiz(objectContext, diyabet.SubEpisode, diyabet.ObjectID, diyabet.ObjectDef.Name, "215", Common.RecTime());
        }
    }
}
