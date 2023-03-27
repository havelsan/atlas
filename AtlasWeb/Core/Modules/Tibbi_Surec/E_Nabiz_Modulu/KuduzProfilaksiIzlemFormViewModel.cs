//$C8FE8645
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
    public partial class KuduzProfilaksiVeriSetiServiceController
    {
        partial void PreScript_KuduzProfilaksiIzlemForm(KuduzProfilaksiIzlemFormViewModel viewModel, KuduzProfilaksiVeriSeti kuduzProfilaksiVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._KuduzProfilaksiVeriSeti.EpisodeAction = episodeAction;
                viewModel._KuduzProfilaksiVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class KuduzProfilaksiIzlemFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._KuduzProfilaksiVeriSeti);

            if (this.KuduzProfilaksiUygProfilakGridList!= null)
            {
                foreach (var item in this.KuduzProfilaksiUygProfilakGridList)
                {
                    var kuduzProfilaksiUygProfilak = (KuduzProfilaksiUygProfilak)objectContext.AddObject(item);
                    kuduzProfilaksiUygProfilak.KuduzProfilaksiVeriSeti = this._KuduzProfilaksiVeriSeti;
                }
            }


            var kuduzProfilaksiIzlemVeriSeti = (KuduzProfilaksiVeriSeti)objectContext.GetLoadedObject(this._KuduzProfilaksiVeriSeti.ObjectID);


            new SendToENabiz(objectContext, kuduzProfilaksiIzlemVeriSeti.SubEpisode, kuduzProfilaksiIzlemVeriSeti.ObjectID, kuduzProfilaksiIzlemVeriSeti.ObjectDef.Name, "236", Common.RecTime());
        }
    }
}
