//$69BAD29A
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
    public partial class KadinaYonelikSiddetVeriSetServiceController
    {
        partial void PreScript_KadinaYonelikSiddetVeriSetiForm(KadinaYonelikSiddetVeriSetiFormViewModel viewModel, KadinaYonelikSiddetVeriSet kadinaYonelikSiddetVeriSet, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._KadinaYonelikSiddetVeriSet.EpisodeAction = episodeAction;
                viewModel._KadinaYonelikSiddetVeriSet.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class KadinaYonelikSiddetVeriSetiFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._KadinaYonelikSiddetVeriSet);

            if (this.KadinaYonelikSiddetSonucGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.KadinaYonelikSiddetSonucGridList)
                {
                    var kadinaYonelikSiddetSonuc = (KadinaYonelikSiddetSonuc)objectContext.AddObject(item);
                    kadinaYonelikSiddetSonuc.KadinaYonelikSiddetVeriSet = this._KadinaYonelikSiddetVeriSet;
                }
            }

            if (this.KadinaYonelikSiddetTuruGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.KadinaYonelikSiddetTuruGridList)
                {
                    var kadinaYonelikSiddetTuru = (KadinaYonelikSiddetTuru)objectContext.AddObject(item);
                    kadinaYonelikSiddetTuru.KadinaYonelikSiddetVeriSet = this._KadinaYonelikSiddetVeriSet;
                }
            }

           


            var kadinaYonelikSiddetVeriSet = (KadinaYonelikSiddetVeriSet)objectContext.GetLoadedObject(this._KadinaYonelikSiddetVeriSet.ObjectID);


            new SendToENabiz(objectContext, kadinaYonelikSiddetVeriSet.SubEpisode, kadinaYonelikSiddetVeriSet.ObjectID, kadinaYonelikSiddetVeriSet.ObjectDef.Name, "231", Common.RecTime());
        }
    }
}
