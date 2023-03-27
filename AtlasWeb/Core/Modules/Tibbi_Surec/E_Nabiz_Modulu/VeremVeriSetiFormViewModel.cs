//$A6A7725D
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
    public partial class VeremVeriSetiServiceController
    {
        partial void PreScript_VeremVeriSetiForm(VeremVeriSetiFormViewModel viewModel, VeremVeriSeti veremVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._VeremVeriSeti.EpisodeAction = episodeAction;
                viewModel._VeremVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class VeremVeriSetiFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._VeremVeriSeti);

            if (this.VeremHastalikTutumYeriGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.VeremHastalikTutumYeriGridList)
                {
                    var veremHastalikTutumYeri = (VeremHastalikTutumYeri)objectContext.AddObject(item);
                    veremHastalikTutumYeri.VeremVeriSeti = this._VeremVeriSeti;
                }
            }

            if (this.VeremIlacBilgisiGridList != null)
            {
                foreach (var item in this.VeremIlacBilgisiGridList)
                {
                    var veremIlacBilgisi = (VeremIlacBilgisi)objectContext.AddObject(item);
                    veremIlacBilgisi.VeremVeriSeti = this._VeremVeriSeti;
                }
            }

            if (this.VeremKlinikOrnegiGridList != null)
            {
                foreach (var item in this.VeremKlinikOrnegiGridList)
                {
                    var veremKlinikOrnegi = (VeremKlinikOrnegi)objectContext.AddObject(item);
                    veremKlinikOrnegi.VeremVeriSeti = this._VeremVeriSeti;
                }
            }

            if (this.VeremTedaviSonucBilgisiGridList != null)
            {
                foreach (var item in this.VeremTedaviSonucBilgisiGridList)
                {
                    var veremTedaviSonucBilgisi = (VeremTedaviSonucBilgisi)objectContext.AddObject(item);
                    veremTedaviSonucBilgisi.VeremVeriSeti = this._VeremVeriSeti;
                }
            }



            var veremVeriSeti = (VeremVeriSeti)objectContext.GetLoadedObject(this._VeremVeriSeti.ObjectID);


            new SendToENabiz(objectContext, veremVeriSeti.SubEpisode, veremVeriSeti.ObjectID, veremVeriSeti.ObjectDef.Name, "250", Common.RecTime());
        }
    }
}
