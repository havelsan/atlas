//$4C711DA0
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
    public partial class KuduzRiskliTemasVeriSetiServiceController
    {
        partial void PreScript_KuduzRiskliTemasVeriSetiForm(KuduzRiskliTemasVeriSetiFormViewModel viewModel, KuduzRiskliTemasVeriSeti kuduzRiskliTemasVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._KuduzRiskliTemasVeriSeti.EpisodeAction = episodeAction;
                viewModel._KuduzRiskliTemasVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class KuduzRiskliTemasVeriSetiFormViewModel : BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._KuduzRiskliTemasVeriSeti);

            if (this.KuduzRiskliTemasAdresGridList!= null)   // Ek nesneler i?in
            {
                foreach (var item in this.KuduzRiskliTemasAdresGridList)
                {
                    var kuduzRiskliTemasAdres = (KuduzRiskliTemasAdres)objectContext.AddObject(item);
                    kuduzRiskliTemasAdres.KuduzRiskliTemasVeriSeti = this._KuduzRiskliTemasVeriSeti;
                }
            }

            if (this.KuduzRiskliTemasPlanProfBiGridList!= null)
            {
                foreach (var item in this.KuduzRiskliTemasPlanProfBiGridList)
                {
                    var kuduzRiskliTemasPlanProfBi = (KuduzRiskliTemasPlanProfBi)objectContext.AddObject(item);
                    kuduzRiskliTemasPlanProfBi.KuduzRiskliTemasVeriSeti = this._KuduzRiskliTemasVeriSeti;
                }
            }

            if (this.KuduzRiskliTemasRiskTemTipGridList != null)
            {
                foreach (var item in this.KuduzRiskliTemasRiskTemTipGridList)
                {
                    var kuduzRiskliTemasRiskTemTip = (KuduzRiskliTemasRiskTemTip)objectContext.AddObject(item);
                    kuduzRiskliTemasRiskTemTip.KuduzRiskliTemasVeriSeti = this._KuduzRiskliTemasVeriSeti;
                }
            }

            if (this.KuduzRiskliTemasTelefonGridList != null)
            {
                foreach (var item in this.KuduzRiskliTemasTelefonGridList)
                {
                    var kuduzRiskliTemasTelefon = (KuduzRiskliTemasTelefon)objectContext.AddObject(item);
                    kuduzRiskliTemasTelefon.KuduzRiskliTemasVeriSeti = this._KuduzRiskliTemasVeriSeti;
                }
            }



            var kuduzRiskliTemasVeriSeti = (KuduzRiskliTemasVeriSeti)objectContext.GetLoadedObject(this._KuduzRiskliTemasVeriSeti.ObjectID);


            new SendToENabiz(objectContext, kuduzRiskliTemasVeriSeti.SubEpisode, kuduzRiskliTemasVeriSeti.ObjectID, kuduzRiskliTemasVeriSeti.ObjectDef.Name, "237", Common.RecTime());
        }
    }
}
