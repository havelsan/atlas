//$91CCFE36
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
    public partial class CancerScreeningServiceController : Controller
{
    [HttpGet]
    public CancerScreeningFormViewModel CancerScreeningForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CancerScreeningFormLoadInternal(input);
    }

    [HttpPost]
    public CancerScreeningFormViewModel CancerScreeningFormLoad(FormLoadInput input)
    {
        return CancerScreeningFormLoadInternal(input);
    }

    private CancerScreeningFormViewModel CancerScreeningFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("52cc83d4-acb5-410e-813c-f314ddda77da");
        var objectDefID = Guid.Parse("600b891b-e179-4eee-9fea-f6905b95ab6d");
        var viewModel = new CancerScreeningFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CancerScreening = objectContext.GetObject(id.Value, objectDefID) as CancerScreening;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CancerScreening, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CancerScreening, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CancerScreening);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CancerScreening);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_CancerScreeningForm(viewModel, viewModel._CancerScreening, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CancerScreening = new CancerScreening(objectContext);
                viewModel.BreastBiopsyGridList = new TTObjectClasses.BreastBiopsy[]{};
                viewModel.CervicalCytologyResultsGridList = new TTObjectClasses.CervicalCytologyResults[]{};
                viewModel.CervicalBiopsyResultsGridList = new TTObjectClasses.CervicalBiopsyResults[]{};
                viewModel.ColorectalBiopsyResultsGridList = new TTObjectClasses.ColorectalBiopsyResults[]{};
                viewModel.ColonoscopyQualityCriteriaGridList = new TTObjectClasses.ColonoscopyQualityCriteria[]{};
                viewModel.HPVTypeInfoGridList = new TTObjectClasses.HPVTypeInfo[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CancerScreening, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CancerScreening, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CancerScreening);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CancerScreening);
                PreScript_CancerScreeningForm(viewModel, viewModel._CancerScreening, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CancerScreeningForm(CancerScreeningFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return CancerScreeningFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel CancerScreeningFormInternal(CancerScreeningFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("52cc83d4-acb5-410e-813c-f314ddda77da");
        objectContext.AddToRawObjectList(viewModel.SKRSTARAMATIPIs);
        objectContext.AddToRawObjectList(viewModel.SKRSMemedenBiyopsiAlimis);
        objectContext.AddToRawObjectList(viewModel.SKRSMemeBiyopsiSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSServikalSitolojiSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSServikalBiyopsiSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSKolorektalBiyopsiSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSKolonoskopiKaliteKriterleris);
        objectContext.AddToRawObjectList(viewModel.SKRSSigmoidoskopis);
        objectContext.AddToRawObjectList(viewModel.SKRSPapSmearTestis);
        objectContext.AddToRawObjectList(viewModel.SKRSMamografiSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSMamografis);
        objectContext.AddToRawObjectList(viewModel.SKRSKolposkopis);
        objectContext.AddToRawObjectList(viewModel.SKRSKolonoskopininSuresis);
        objectContext.AddToRawObjectList(viewModel.SKRSKlinikMemeMuayenesis);
        objectContext.AddToRawObjectList(viewModel.SKRSKendiKendineMemeMuayenesis);
        objectContext.AddToRawObjectList(viewModel.SKRSHPVTaramaTestis);
        objectContext.AddToRawObjectList(viewModel.SKRSKolonoskopis);
        objectContext.AddToRawObjectList(viewModel.SKRSKolonGoruntulemeYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSGaitadaGizliKanTestis);
        objectContext.AddToRawObjectList(viewModel.SKRSHpvTipis);
        objectContext.AddToRawObjectList(viewModel.BreastBiopsyGridList);
        objectContext.AddToRawObjectList(viewModel.CervicalCytologyResultsGridList);
        objectContext.AddToRawObjectList(viewModel.CervicalBiopsyResultsGridList);
        objectContext.AddToRawObjectList(viewModel.ColorectalBiopsyResultsGridList);
        objectContext.AddToRawObjectList(viewModel.ColonoscopyQualityCriteriaGridList);
        objectContext.AddToRawObjectList(viewModel.HPVTypeInfoGridList);
        objectContext.AddToRawObjectList(viewModel._CancerScreening);
        objectContext.ProcessRawObjects();
        var cancerScreening = (CancerScreening)objectContext.GetLoadedObject(viewModel._CancerScreening.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(cancerScreening, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CancerScreening, formDefID);
        if (viewModel.BreastBiopsyGridList != null)
        {
            foreach (var item in viewModel.BreastBiopsyGridList)
            {
                var breastBiopsyImported = (BreastBiopsy)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)breastBiopsyImported).IsDeleted)
                    continue;
                breastBiopsyImported.CancerScreening = cancerScreening;
            }
        }

        if (viewModel.CervicalCytologyResultsGridList != null)
        {
            foreach (var item in viewModel.CervicalCytologyResultsGridList)
            {
                var cervicalCytologyResultsImported = (CervicalCytologyResults)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)cervicalCytologyResultsImported).IsDeleted)
                    continue;
                cervicalCytologyResultsImported.CancerScreening = cancerScreening;
            }
        }

        if (viewModel.CervicalBiopsyResultsGridList != null)
        {
            foreach (var item in viewModel.CervicalBiopsyResultsGridList)
            {
                var cervicalBiopsyResultsImported = (CervicalBiopsyResults)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)cervicalBiopsyResultsImported).IsDeleted)
                    continue;
                cervicalBiopsyResultsImported.CancerScreening = cancerScreening;
            }
        }

        if (viewModel.ColorectalBiopsyResultsGridList != null)
        {
            foreach (var item in viewModel.ColorectalBiopsyResultsGridList)
            {
                var colorectalBiopsyResultsImported = (ColorectalBiopsyResults)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)colorectalBiopsyResultsImported).IsDeleted)
                    continue;
                colorectalBiopsyResultsImported.CancerScreening = cancerScreening;
            }
        }

        if (viewModel.ColonoscopyQualityCriteriaGridList != null)
        {
            foreach (var item in viewModel.ColonoscopyQualityCriteriaGridList)
            {
                var colonoscopyQualityCriteriaImported = (ColonoscopyQualityCriteria)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)colonoscopyQualityCriteriaImported).IsDeleted)
                    continue;
                colonoscopyQualityCriteriaImported.CancerScreening = cancerScreening;
            }
        }

        if (viewModel.HPVTypeInfoGridList != null)
        {
            foreach (var item in viewModel.HPVTypeInfoGridList)
            {
                var hPVTypeInfoImported = (HPVTypeInfo)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)hPVTypeInfoImported).IsDeleted)
                    continue;
                hPVTypeInfoImported.CancerScreening = cancerScreening;
            }
        }

        var transDef = cancerScreening.TransDef;
        PostScript_CancerScreeningForm(viewModel, cancerScreening, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(cancerScreening);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(cancerScreening);
        AfterContextSaveScript_CancerScreeningForm(viewModel, cancerScreening, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_CancerScreeningForm(CancerScreeningFormViewModel viewModel, CancerScreening cancerScreening, TTObjectContext objectContext);
    partial void PostScript_CancerScreeningForm(CancerScreeningFormViewModel viewModel, CancerScreening cancerScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CancerScreeningForm(CancerScreeningFormViewModel viewModel, CancerScreening cancerScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CancerScreeningFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.BreastBiopsyGridList = viewModel._CancerScreening.BreastBiopsy.OfType<BreastBiopsy>().ToArray();
        viewModel.CervicalCytologyResultsGridList = viewModel._CancerScreening.CervicalCytologyResults.OfType<CervicalCytologyResults>().ToArray();
        viewModel.CervicalBiopsyResultsGridList = viewModel._CancerScreening.CervicalBiopsyResults.OfType<CervicalBiopsyResults>().ToArray();
        viewModel.ColorectalBiopsyResultsGridList = viewModel._CancerScreening.ColorectalBiopsyResults.OfType<ColorectalBiopsyResults>().ToArray();
        viewModel.ColonoscopyQualityCriteriaGridList = viewModel._CancerScreening.ColonoscopyQualityCriteria.OfType<ColonoscopyQualityCriteria>().ToArray();
        viewModel.HPVTypeInfoGridList = viewModel._CancerScreening.HPVTypeInfo.OfType<HPVTypeInfo>().ToArray();
        viewModel.SKRSTARAMATIPIs = objectContext.LocalQuery<SKRSTARAMATIPI>().ToArray();
        viewModel.SKRSMemedenBiyopsiAlimis = objectContext.LocalQuery<SKRSMemedenBiyopsiAlimi>().ToArray();
        viewModel.SKRSMemeBiyopsiSonucus = objectContext.LocalQuery<SKRSMemeBiyopsiSonucu>().ToArray();
        viewModel.SKRSServikalSitolojiSonucus = objectContext.LocalQuery<SKRSServikalSitolojiSonucu>().ToArray();
        viewModel.SKRSServikalBiyopsiSonucus = objectContext.LocalQuery<SKRSServikalBiyopsiSonucu>().ToArray();
        viewModel.SKRSKolorektalBiyopsiSonucus = objectContext.LocalQuery<SKRSKolorektalBiyopsiSonucu>().ToArray();
        viewModel.SKRSKolonoskopiKaliteKriterleris = objectContext.LocalQuery<SKRSKolonoskopiKaliteKriterleri>().ToArray();
        viewModel.SKRSSigmoidoskopis = objectContext.LocalQuery<SKRSSigmoidoskopi>().ToArray();
        viewModel.SKRSPapSmearTestis = objectContext.LocalQuery<SKRSPapSmearTesti>().ToArray();
        viewModel.SKRSMamografiSonucus = objectContext.LocalQuery<SKRSMamografiSonucu>().ToArray();
        viewModel.SKRSMamografis = objectContext.LocalQuery<SKRSMamografi>().ToArray();
        viewModel.SKRSKolposkopis = objectContext.LocalQuery<SKRSKolposkopi>().ToArray();
        viewModel.SKRSKolonoskopininSuresis = objectContext.LocalQuery<SKRSKolonoskopininSuresi>().ToArray();
        viewModel.SKRSKlinikMemeMuayenesis = objectContext.LocalQuery<SKRSKlinikMemeMuayenesi>().ToArray();
        viewModel.SKRSKendiKendineMemeMuayenesis = objectContext.LocalQuery<SKRSKendiKendineMemeMuayenesi>().ToArray();
        viewModel.SKRSHPVTaramaTestis = objectContext.LocalQuery<SKRSHPVTaramaTesti>().ToArray();
        viewModel.SKRSKolonoskopis = objectContext.LocalQuery<SKRSKolonoskopi>().ToArray();
        viewModel.SKRSKolonGoruntulemeYontemis = objectContext.LocalQuery<SKRSKolonGoruntulemeYontemi>().ToArray();
        viewModel.SKRSGaitadaGizliKanTestis = objectContext.LocalQuery<SKRSGaitadaGizliKanTesti>().ToArray();
        viewModel.SKRSHpvTipis = objectContext.LocalQuery<SKRSHpvTipi>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTARAMATIPIList", viewModel.SKRSTARAMATIPIs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMemedenBiyopsiAlimiList", viewModel.SKRSMemedenBiyopsiAlimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMemeBiyopsiSonucuList", viewModel.SKRSMemeBiyopsiSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSServikalSitolojiSonucuList", viewModel.SKRSServikalSitolojiSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSServikalBiyopsiSonucuList", viewModel.SKRSServikalBiyopsiSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKolorektalBiyopsiSonucuList", viewModel.SKRSKolorektalBiyopsiSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKolonoskopiKaliteKriterleriList", viewModel.SKRSKolonoskopiKaliteKriterleris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigmoidoskopiList", viewModel.SKRSSigmoidoskopis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPapSmearTestiList", viewModel.SKRSPapSmearTestis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMamografiSonucuList", viewModel.SKRSMamografiSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMamografiList", viewModel.SKRSMamografis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKolposkopiList", viewModel.SKRSKolposkopis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKolonoskopininSuresiList", viewModel.SKRSKolonoskopininSuresis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKlinikMemeMuayenesiList", viewModel.SKRSKlinikMemeMuayenesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKendiKendineMemeMuayenesiList", viewModel.SKRSKendiKendineMemeMuayenesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHPVTaramaTestiList", viewModel.SKRSHPVTaramaTestis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKolonoskopiList", viewModel.SKRSKolonoskopis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKolonGoruntulemeYontemiList", viewModel.SKRSKolonGoruntulemeYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGaitadaGizliKanTestiList", viewModel.SKRSGaitadaGizliKanTestis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHpvTipiList", viewModel.SKRSHpvTipis);
    }
}
}


namespace Core.Models
{
    public partial class CancerScreeningFormViewModel
    {
        public TTObjectClasses.CancerScreening _CancerScreening
        {
            get;
            set;
        }

        public TTObjectClasses.BreastBiopsy[] BreastBiopsyGridList
        {
            get;
            set;
        }

        public TTObjectClasses.CervicalCytologyResults[] CervicalCytologyResultsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.CervicalBiopsyResults[] CervicalBiopsyResultsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ColorectalBiopsyResults[] ColorectalBiopsyResultsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ColonoscopyQualityCriteria[] ColonoscopyQualityCriteriaGridList
        {
            get;
            set;
        }

        public TTObjectClasses.HPVTypeInfo[] HPVTypeInfoGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTARAMATIPI[] SKRSTARAMATIPIs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMemedenBiyopsiAlimi[] SKRSMemedenBiyopsiAlimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMemeBiyopsiSonucu[] SKRSMemeBiyopsiSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSServikalSitolojiSonucu[] SKRSServikalSitolojiSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSServikalBiyopsiSonucu[] SKRSServikalBiyopsiSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKolorektalBiyopsiSonucu[] SKRSKolorektalBiyopsiSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKolonoskopiKaliteKriterleri[] SKRSKolonoskopiKaliteKriterleris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSigmoidoskopi[] SKRSSigmoidoskopis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPapSmearTesti[] SKRSPapSmearTestis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMamografiSonucu[] SKRSMamografiSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMamografi[] SKRSMamografis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKolposkopi[] SKRSKolposkopis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKolonoskopininSuresi[] SKRSKolonoskopininSuresis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKlinikMemeMuayenesi[] SKRSKlinikMemeMuayenesis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKendiKendineMemeMuayenesi[] SKRSKendiKendineMemeMuayenesis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSHPVTaramaTesti[] SKRSHPVTaramaTestis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKolonoskopi[] SKRSKolonoskopis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKolonGoruntulemeYontemi[] SKRSKolonGoruntulemeYontemis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGaitadaGizliKanTesti[] SKRSGaitadaGizliKanTestis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSHpvTipi[] SKRSHpvTipis
        {
            get;
            set;
        }
    }
}
