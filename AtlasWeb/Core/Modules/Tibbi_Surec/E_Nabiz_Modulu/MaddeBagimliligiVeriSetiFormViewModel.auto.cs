//$D9B1D086
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class MaddeBagimliligiVeriSetiServiceController : Controller
{
    [HttpGet]
    public MaddeBagimliligiVeriSetiFormViewModel MaddeBagimliligiVeriSetiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MaddeBagimliligiVeriSetiFormLoadInternal(input);
    }

    [HttpPost]
    public MaddeBagimliligiVeriSetiFormViewModel MaddeBagimliligiVeriSetiFormLoad(FormLoadInput input)
    {
        return MaddeBagimliligiVeriSetiFormLoadInternal(input);
    }

    private MaddeBagimliligiVeriSetiFormViewModel MaddeBagimliligiVeriSetiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("fe54eaec-9ad5-4599-a4bc-d0a02d01861e");
        var objectDefID = Guid.Parse("73391a5b-f3e3-4287-9e05-867c1462f6e0");
        var viewModel = new MaddeBagimliligiVeriSetiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MaddeBagimliligiVeriSeti = objectContext.GetObject(id.Value, objectDefID) as MaddeBagimliligiVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MaddeBagimliligiVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MaddeBagimliligiVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MaddeBagimliligiVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MaddeBagimliligiVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MaddeBagimliligiVeriSetiForm(viewModel, viewModel._MaddeBagimliligiVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MaddeBagimliligiVeriSeti = new MaddeBagimliligiVeriSeti(objectContext);
                viewModel.MaddeBagimliligiKulMaddeGridList = new TTObjectClasses.MaddeBagimliligiKulMadde[]{};
                viewModel.MaddeBagimBulasiciHastalikGridList = new TTObjectClasses.MaddeBagimBulasiciHastalik[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MaddeBagimliligiVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MaddeBagimliligiVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MaddeBagimliligiVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MaddeBagimliligiVeriSeti);
                PreScript_MaddeBagimliligiVeriSetiForm(viewModel, viewModel._MaddeBagimliligiVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MaddeBagimliligiVeriSetiForm(MaddeBagimliligiVeriSetiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return MaddeBagimliligiVeriSetiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel MaddeBagimliligiVeriSetiFormInternal(MaddeBagimliligiVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("fe54eaec-9ad5-4599-a4bc-d0a02d01861e");
        objectContext.AddToRawObjectList(viewModel.SKRSYasamBicimis);
        objectContext.AddToRawObjectList(viewModel.SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSYasadigiBolges);
        objectContext.AddToRawObjectList(viewModel.SKRSUygulananTedaviTuruMaddeBagimliligis);
        objectContext.AddToRawObjectList(viewModel.SKRSTedaviSonucuMaddeBagimliligis);
        objectContext.AddToRawObjectList(viewModel.SKRSTedaviMerkeziTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSSigaraKullanimis);
        objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSKullanilanMaddes);
        objectContext.AddToRawObjectList(viewModel.SKRSIsDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSGonderenBirims);
        objectContext.AddToRawObjectList(viewModel.SKRSEnjektorPaylasimDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSAlkolKullanimis);
        objectContext.AddToRawObjectList(viewModel.SKRSMaddeKullanimSikligis);
        objectContext.AddToRawObjectList(viewModel.SKRSMaddeKullanimYolus);
        objectContext.AddToRawObjectList(viewModel.SKRSBulasiciHastalikDurumus);
        objectContext.AddToRawObjectList(viewModel.MaddeBagimliligiKulMaddeGridList);
        objectContext.AddToRawObjectList(viewModel.MaddeBagimBulasiciHastalikGridList);
        objectContext.AddToRawObjectList(viewModel._MaddeBagimliligiVeriSeti);
        objectContext.ProcessRawObjects();
        var maddeBagimliligiVeriSeti = (MaddeBagimliligiVeriSeti)objectContext.GetLoadedObject(viewModel._MaddeBagimliligiVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(maddeBagimliligiVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MaddeBagimliligiVeriSeti, formDefID);
        if (viewModel.MaddeBagimliligiKulMaddeGridList != null)
        {
            foreach (var item in viewModel.MaddeBagimliligiKulMaddeGridList)
            {
                var maddeBagimliligiKulMaddeImported = (MaddeBagimliligiKulMadde)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)maddeBagimliligiKulMaddeImported).IsDeleted)
                    continue;
                maddeBagimliligiKulMaddeImported.MaddeBagimliligiVeriSeti = maddeBagimliligiVeriSeti;
            }
        }

        if (viewModel.MaddeBagimBulasiciHastalikGridList != null)
        {
            foreach (var item in viewModel.MaddeBagimBulasiciHastalikGridList)
            {
                var maddeBagimBulasiciHastalikImported = (MaddeBagimBulasiciHastalik)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)maddeBagimBulasiciHastalikImported).IsDeleted)
                    continue;
                maddeBagimBulasiciHastalikImported.MaddeBagimliligiVeriSeti = maddeBagimliligiVeriSeti;
            }
        }

        var transDef = maddeBagimliligiVeriSeti.TransDef;
        PostScript_MaddeBagimliligiVeriSetiForm(viewModel, maddeBagimliligiVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(maddeBagimliligiVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(maddeBagimliligiVeriSeti);
        AfterContextSaveScript_MaddeBagimliligiVeriSetiForm(viewModel, maddeBagimliligiVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_MaddeBagimliligiVeriSetiForm(MaddeBagimliligiVeriSetiFormViewModel viewModel, MaddeBagimliligiVeriSeti maddeBagimliligiVeriSeti, TTObjectContext objectContext);
    partial void PostScript_MaddeBagimliligiVeriSetiForm(MaddeBagimliligiVeriSetiFormViewModel viewModel, MaddeBagimliligiVeriSeti maddeBagimliligiVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MaddeBagimliligiVeriSetiForm(MaddeBagimliligiVeriSetiFormViewModel viewModel, MaddeBagimliligiVeriSeti maddeBagimliligiVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MaddeBagimliligiVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MaddeBagimliligiKulMaddeGridList = viewModel._MaddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde.OfType<MaddeBagimliligiKulMadde>().ToArray();
        viewModel.MaddeBagimBulasiciHastalikGridList = viewModel._MaddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik.OfType<MaddeBagimBulasiciHastalik>().ToArray();
        viewModel.SKRSYasamBicimis = objectContext.LocalQuery<SKRSYasamBicimi>().ToArray();
        viewModel.SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumus = objectContext.LocalQuery<SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu>().ToArray();
        viewModel.SKRSYasadigiBolges = objectContext.LocalQuery<SKRSYasadigiBolge>().ToArray();
        viewModel.SKRSUygulananTedaviTuruMaddeBagimliligis = objectContext.LocalQuery<SKRSUygulananTedaviTuruMaddeBagimliligi>().ToArray();
        viewModel.SKRSTedaviSonucuMaddeBagimliligis = objectContext.LocalQuery<SKRSTedaviSonucuMaddeBagimliligi>().ToArray();
        viewModel.SKRSTedaviMerkeziTipis = objectContext.LocalQuery<SKRSTedaviMerkeziTipi>().ToArray();
        viewModel.SKRSSigaraKullanimis = objectContext.LocalQuery<SKRSSigaraKullanimi>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        viewModel.SKRSKullanilanMaddes = objectContext.LocalQuery<SKRSKullanilanMadde>().ToArray();
        viewModel.SKRSIsDurumus = objectContext.LocalQuery<SKRSIsDurumu>().ToArray();
        viewModel.SKRSGonderenBirims = objectContext.LocalQuery<SKRSGonderenBirim>().ToArray();
        viewModel.SKRSEnjektorPaylasimDurumus = objectContext.LocalQuery<SKRSEnjektorPaylasimDurumu>().ToArray();
        viewModel.SKRSAlkolKullanimis = objectContext.LocalQuery<SKRSAlkolKullanimi>().ToArray();
        viewModel.SKRSMaddeKullanimSikligis = objectContext.LocalQuery<SKRSMaddeKullanimSikligi>().ToArray();
        viewModel.SKRSMaddeKullanimYolus = objectContext.LocalQuery<SKRSMaddeKullanimYolu>().ToArray();
        viewModel.SKRSBulasiciHastalikDurumus = objectContext.LocalQuery<SKRSBulasiciHastalikDurumu>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYasamBicimiList", viewModel.SKRSYasamBicimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumuL", viewModel.SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYasadigiBolgeList", viewModel.SKRSYasadigiBolges);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSUygulananTedaviTuruMaddeBagimliligiList", viewModel.SKRSUygulananTedaviTuruMaddeBagimliligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTedaviSonucuMaddeBagimliligiList", viewModel.SKRSTedaviSonucuMaddeBagimliligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTedaviMerkeziTipiList", viewModel.SKRSTedaviMerkeziTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigaraKullanimiList", viewModel.SKRSSigaraKullanimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKullanilanMaddeList", viewModel.SKRSKullanilanMaddes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIsDurumuList", viewModel.SKRSIsDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGonderenBirimList", viewModel.SKRSGonderenBirims);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEnjektorPaylasimDurumuList", viewModel.SKRSEnjektorPaylasimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAlkolKullanimiList", viewModel.SKRSAlkolKullanimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMaddeKullanimSikligiList", viewModel.SKRSMaddeKullanimSikligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMaddeKullanimYoluList", viewModel.SKRSMaddeKullanimYolus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBulasiciHastalikDurumuList", viewModel.SKRSBulasiciHastalikDurumus);
    }
}
}


namespace Core.Models
{
    public partial class MaddeBagimliligiVeriSetiFormViewModel
    {
        public TTObjectClasses.MaddeBagimliligiVeriSeti _MaddeBagimliligiVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.MaddeBagimliligiKulMadde[] MaddeBagimliligiKulMaddeGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MaddeBagimBulasiciHastalik[] MaddeBagimBulasiciHastalikGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSYasamBicimi[] SKRSYasamBicimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu[] SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSYasadigiBolge[] SKRSYasadigiBolges
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUygulananTedaviTuruMaddeBagimliligi[] SKRSUygulananTedaviTuruMaddeBagimliligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTedaviSonucuMaddeBagimliligi[] SKRSTedaviSonucuMaddeBagimliligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTedaviMerkeziTipi[] SKRSTedaviMerkeziTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSigaraKullanimi[] SKRSSigaraKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKullanilanMadde[] SKRSKullanilanMaddes
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIsDurumu[] SKRSIsDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGonderenBirim[] SKRSGonderenBirims
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSEnjektorPaylasimDurumu[] SKRSEnjektorPaylasimDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAlkolKullanimi[] SKRSAlkolKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMaddeKullanimSikligi[] SKRSMaddeKullanimSikligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMaddeKullanimYolu[] SKRSMaddeKullanimYolus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBulasiciHastalikDurumu[] SKRSBulasiciHastalikDurumus
        {
            get;
            set;
        }
    }
}
