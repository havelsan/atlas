//$F2091BA1
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
    public partial class MaddeBagimliligiVeriSetiServiceController
    {
        partial void PreScript_MaddeBagimliligiVeriSetiForm(MaddeBagimliligiVeriSetiFormViewModel viewModel, MaddeBagimliligiVeriSeti maddeBagimliligiVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._MaddeBagimliligiVeriSeti.EpisodeAction = episodeAction;
                viewModel._MaddeBagimliligiVeriSeti.SubEpisode = episodeAction.SubEpisode;

            }
            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class MaddeBagimliligiVeriSetiFormViewModel : BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._MaddeBagimliligiVeriSeti);

            if (this.MaddeBagimBulasiciHastalikGridList != null)   // Ek nesneler için
            {
                foreach (var item in this.MaddeBagimBulasiciHastalikGridList)
                {
                    var maddeBagimBulasiciHastalik = (MaddeBagimBulasiciHastalik)objectContext.AddObject(item);
                    maddeBagimBulasiciHastalik.MaddeBagimliligiVeriSeti = this._MaddeBagimliligiVeriSeti;
                }
            }

            if (this.MaddeBagimliligiKulMaddeGridList!= null)
            {
                foreach (var item in this.MaddeBagimliligiKulMaddeGridList)
                {
                    var maddeBagimliligiKulMadde = (MaddeBagimliligiKulMadde)objectContext.AddObject(item);
                    maddeBagimliligiKulMadde.MaddeBagimliligiVeriSeti= this._MaddeBagimliligiVeriSeti;
                }
            }

         

            var maddeBagimliligiVeriSeti = (MaddeBagimliligiVeriSeti)objectContext.GetLoadedObject(this._MaddeBagimliligiVeriSeti.ObjectID);


            new SendToENabiz(objectContext, maddeBagimliligiVeriSeti.SubEpisode, maddeBagimliligiVeriSeti.ObjectID, maddeBagimliligiVeriSeti.ObjectDef.Name, "239", Common.RecTime());
        }
    }
}
