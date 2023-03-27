//$00410AD8
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
    public partial class TutunKullanimiVeriSetiServiceController
    {
        partial void PreScript_TutunKullanimiVeriSetiForm(TutunKullanimiVeriSetiFormViewModel viewModel, TutunKullanimiVeriSeti tutunKullanimiVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
               
                
                viewModel._TutunKullanimiVeriSeti.EpisodeAction = episodeAction;
                viewModel._TutunKullanimiVeriSeti.SubEpisode = episodeAction.SubEpisode;
                

            }

            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class TutunKullanimiVeriSetiFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._TutunKullanimiVeriSeti);

            if (this.TutunKullanimiBagimOldUrunGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.TutunKullanimiBagimOldUrunGridList)
                {
                    var tutunKullanimiBagimOldUrun = (TutunKullanimiBagimOldUrun)objectContext.AddObject(item);
                    tutunKullanimiBagimOldUrun.TutunKullanimiVeriSeti = this._TutunKullanimiVeriSeti;
                }
            }

            if (this.TutunKullanimiTedaviSekliGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.TutunKullanimiTedaviSekliGridList)
                {
                    var tutunKullanimiTedaviSekli = (TutunKullanimiTedaviSekli)objectContext.AddObject(item);
                    tutunKullanimiTedaviSekli.TutunKullanimiVeriSeti = this._TutunKullanimiVeriSeti;
                }
            }

            if (this.TutunKullanimiTedaviSonucuGridList != null)
            {
                foreach (var item in this.TutunKullanimiTedaviSonucuGridList)
                {
                    var tutunKullanimiTedaviSonucu = (TutunKullanimiTedaviSonucu)objectContext.AddObject(item);
                    tutunKullanimiTedaviSonucu.TutunKullanimiVeriSeti = this._TutunKullanimiVeriSeti;
                }
            }

           



            var tutunKullanimiVeriSeti = (TutunKullanimiVeriSeti)objectContext.GetLoadedObject(this._TutunKullanimiVeriSeti.ObjectID);


            new SendToENabiz(objectContext, tutunKullanimiVeriSeti.SubEpisode, tutunKullanimiVeriSeti.ObjectID, tutunKullanimiVeriSeti.ObjectDef.Name, "248", Common.RecTime());
        }
    }
}
