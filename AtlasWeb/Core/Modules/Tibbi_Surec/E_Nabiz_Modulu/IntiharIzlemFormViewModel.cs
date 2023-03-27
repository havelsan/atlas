//$86E571BE
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
    public partial class IntiharIzlemVeriSetiServiceController
    {
        partial void PreScript_IntiharIzlemForm(IntiharIzlemFormViewModel viewModel, IntiharIzlemVeriSeti intiharIzlemVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);


                viewModel._IntiharIzlemVeriSeti.EpisodeAction = episodeAction;
                viewModel._IntiharIzlemVeriSeti.SubEpisode = episodeAction.SubEpisode;


            }

            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class IntiharIzlemFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._IntiharIzlemVeriSeti);

            if (this.IntiharIzlemNedeniGridList != null) 
            {
                foreach (var item in this.IntiharIzlemNedeniGridList)
                {
                    var intiharIzlemNedeni = (IntiharIzlemNedeni)objectContext.AddObject(item);
                    intiharIzlemNedeni.IntiharIzlemVeriSeti = this._IntiharIzlemVeriSeti;
                }
            }

            if (this.IntiharIzlemYontemiGridList != null)  
            {
                foreach (var item in this.IntiharIzlemYontemiGridList)
                {
                    var intiharIzlemYontem = (IntiharIzlemYontemi)objectContext.AddObject(item);
                    intiharIzlemYontem.IntiharIzlemVeriSeti = this._IntiharIzlemVeriSeti;
                }
            }

            if (this.IntiharIzlemVakaSonucuGridList != null)
            {
                foreach (var item in this.IntiharIzlemVakaSonucuGridList)
                {
                    var intiharIzlemVakaSonucu = (IntiharIzlemVakaSonucu)objectContext.AddObject(item);
                    intiharIzlemVakaSonucu.IntiharIzlemVeriSeti = this._IntiharIzlemVeriSeti;
                }
            }





            var intiharIzlemVeriSeti = (IntiharIzlemVeriSeti)objectContext.GetLoadedObject(this._IntiharIzlemVeriSeti.ObjectID);


            new SendToENabiz(objectContext, intiharIzlemVeriSeti.SubEpisode, intiharIzlemVeriSeti.ObjectID, intiharIzlemVeriSeti.ObjectDef.Name, "229", Common.RecTime());
        }
    }
}
