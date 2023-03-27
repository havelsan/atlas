//$7F924788
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
    public partial class IntiharGirisimKrizVeriSetiServiceController
    {
        partial void PreScript_IntiharGirisimiKrizTespitVeriSetiForm(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel, IntiharGirisimKrizVeriSeti intiharGirisimKrizVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._IntiharGirisimKrizVeriSeti.EpisodeAction = episodeAction;
                viewModel._IntiharGirisimKrizVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class IntiharGirisimiKrizTespitVeriSetiFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._IntiharGirisimKrizVeriSeti);

            if (this.IntiharGirisimiKrizNedeniGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.IntiharGirisimiKrizNedeniGridList)
                {
                    var intiharGirisimiKrizNedeni = (IntiharGirisimiKrizNedeni)objectContext.AddObject(item);
                    intiharGirisimiKrizNedeni.IntiharGirisimKrizVeriSeti = this._IntiharGirisimKrizVeriSeti;
                }
            }

            if (this.IntiharGirisimiVakaSonucuGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.IntiharGirisimiVakaSonucuGridList)
                {
                    var intiharGirisimiVakaSonucu = (IntiharGirisimiVakaSonucu)objectContext.AddObject(item);
                    intiharGirisimiVakaSonucu.IntiharGirisimKrizVeriSeti = this._IntiharGirisimKrizVeriSeti;
                }
            }

            if (this.IntiharGirisimiYontemiGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.IntiharGirisimiYontemiGridList)
                {
                    var intiharGirisimiYontemi = (IntiharGirisimiYontemi)objectContext.AddObject(item);
                    intiharGirisimiYontemi.IntiharGirisimKrizVeriSeti = this._IntiharGirisimKrizVeriSeti;
                }
            }

            if (this.IntiharGirisimPsikiyatTaniGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.IntiharGirisimPsikiyatTaniGridList)
                {
                    var intiharGirisimPsikiyatTani = (IntiharGirisimPsikiyatTani)objectContext.AddObject(item);
                    intiharGirisimPsikiyatTani.IntiharGirisimKrizVeriSeti = this._IntiharGirisimKrizVeriSeti;
                }
            }


            var intiharGirisimKrizVeriSeti = (IntiharGirisimKrizVeriSeti)objectContext.GetLoadedObject(this._IntiharGirisimKrizVeriSeti.ObjectID);


            new SendToENabiz(objectContext, intiharGirisimKrizVeriSeti.SubEpisode, intiharGirisimKrizVeriSeti.ObjectID, intiharGirisimKrizVeriSeti.ObjectDef.Name, "230", Common.RecTime());
        }
    }
}
