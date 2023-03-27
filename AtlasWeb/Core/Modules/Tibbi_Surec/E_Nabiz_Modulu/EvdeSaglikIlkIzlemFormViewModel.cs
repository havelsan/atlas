//$1715F5D4
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class EvdeSaglikIlkIzlemVeriSetiServiceController
    {
        partial void PreScript_EvdeSaglikIlkIzlemForm(EvdeSaglikIlkIzlemFormViewModel viewModel, EvdeSaglikIlkIzlemVeriSeti glassesReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                foreach (ENabiz eNabizObject in episodeAction.ENabiz)
                {
                    if (eNabizObject.EpisodeAction.Equals(episodeAction) && eNabizObject.SubEpisode.Equals(episodeAction.SubEpisode))
                    {
                        if (eNabizObject.ObjectDef.ID.ToString().Equals("0e5c5729-9ee9-4881-ada8-af71f09f3b5f"))
                        {
                            viewModel._EvdeSaglikIlkIzlemVeriSeti = (EvdeSaglikIlkIzlemVeriSeti)eNabizObject;
                            break;
                        }
                    }
                }
            
                viewModel._EvdeSaglikIlkIzlemVeriSeti.EpisodeAction = episodeAction;
                viewModel._EvdeSaglikIlkIzlemVeriSeti.SubEpisode = episodeAction.SubEpisode;
            }
        }

        partial void PostScript_EvdeSaglikIlkIzlemForm(EvdeSaglikIlkIzlemFormViewModel viewModel, EvdeSaglikIlkIzlemVeriSeti evdeSaglikIlkIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            new SendToENabiz(objectContext, evdeSaglikIlkIzlemVeriSeti.SubEpisode, evdeSaglikIlkIzlemVeriSeti.ObjectID, evdeSaglikIlkIzlemVeriSeti.ObjectDef.Name, "219", Common.RecTime());
        }
    }
}

namespace Core.Models
{
    public partial class EvdeSaglikIlkIzlemFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._EvdeSaglikIlkIzlemVeriSeti);

            if (this.KullandigiYardimciAraclarGridList != null)
            {
                foreach (var item in this.KullandigiYardimciAraclarGridList)
                {
                    var yardimciAraclarImported = (KullandigiYardimciAraclar)objectContext.AddObject(item);
                    yardimciAraclarImported.EvdeSaglikIlkIzlemVeriSeti = this._EvdeSaglikIlkIzlemVeriSeti;
                }
            }

            if (this.PsikolojikDurumGridList != null)
            {
                foreach (var item in this.PsikolojikDurumGridList)
                {
                    var psikolojikDurumImported = (PsikolojikDurum)objectContext.AddObject(item);
                    psikolojikDurumImported.EvdeSaglikIlkIzlemVeriSeti = this._EvdeSaglikIlkIzlemVeriSeti;
                }
            }

            if (this.VerilenEgitimlerGridList != null)
            {
                foreach (var item in this.VerilenEgitimlerGridList)
                {
                    var verilenEgitimlerImported = (VerilenEgitimler)objectContext.AddObject(item);
                    verilenEgitimlerImported.EvdeSaglikIlkIzlemVeriSeti = this._EvdeSaglikIlkIzlemVeriSeti;
                }
            }

            var evdeSaglik = (EvdeSaglikIlkIzlemVeriSeti)objectContext.GetLoadedObject(this._EvdeSaglikIlkIzlemVeriSeti.ObjectID);


            new SendToENabiz(objectContext, evdeSaglik.SubEpisode, evdeSaglik.ObjectID, evdeSaglik.ObjectDef.Name, "219", Common.RecTime());

        }

    }
}