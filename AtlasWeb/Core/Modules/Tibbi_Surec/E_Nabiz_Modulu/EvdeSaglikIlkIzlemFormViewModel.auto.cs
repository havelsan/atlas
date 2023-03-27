//$FD8068C3
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
    public partial class EvdeSaglikIlkIzlemVeriSetiServiceController : Controller
{
    [HttpGet]
    public EvdeSaglikIlkIzlemFormViewModel EvdeSaglikIlkIzlemForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return EvdeSaglikIlkIzlemFormLoadInternal(input);
    }

    [HttpPost]
    public EvdeSaglikIlkIzlemFormViewModel EvdeSaglikIlkIzlemFormLoad(FormLoadInput input)
    {
        return EvdeSaglikIlkIzlemFormLoadInternal(input);
    }

    private EvdeSaglikIlkIzlemFormViewModel EvdeSaglikIlkIzlemFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("13d7a7ae-45a2-4a4d-b5ec-105d02f8bb68");
        var objectDefID = Guid.Parse("0e5c5729-9ee9-4881-ada8-af71f09f3b5f");
        var viewModel = new EvdeSaglikIlkIzlemFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EvdeSaglikIlkIzlemVeriSeti = objectContext.GetObject(id.Value, objectDefID) as EvdeSaglikIlkIzlemVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EvdeSaglikIlkIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EvdeSaglikIlkIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._EvdeSaglikIlkIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._EvdeSaglikIlkIzlemVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_EvdeSaglikIlkIzlemForm(viewModel, viewModel._EvdeSaglikIlkIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti(objectContext);
                viewModel.VerilenEgitimlerGridList = new TTObjectClasses.VerilenEgitimler[]{};
                viewModel.PsikolojikDurumGridList = new TTObjectClasses.PsikolojikDurum[]{};
                viewModel.KullandigiYardimciAraclarGridList = new TTObjectClasses.KullandigiYardimciAraclar[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EvdeSaglikIlkIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EvdeSaglikIlkIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EvdeSaglikIlkIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EvdeSaglikIlkIzlemVeriSeti);
                PreScript_EvdeSaglikIlkIzlemForm(viewModel, viewModel._EvdeSaglikIlkIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel EvdeSaglikIlkIzlemForm(EvdeSaglikIlkIzlemFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("13d7a7ae-45a2-4a4d-b5ec-105d02f8bb68");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSVerilenEgitimlers);
            objectContext.AddToRawObjectList(viewModel.SKRSPsikolojikDurumDegerlendirmesis);
            objectContext.AddToRawObjectList(viewModel.SKRSKullandigiYardimciAraclars);
            objectContext.AddToRawObjectList(viewModel.SKRSYatagaBagimliliks);
            objectContext.AddToRawObjectList(viewModel.SKRSKullanilanHelaTipis);
            objectContext.AddToRawObjectList(viewModel.SKRSKonutTipis);
            objectContext.AddToRawObjectList(viewModel.SKRSKisiselHijyens);
            objectContext.AddToRawObjectList(viewModel.SKRSKisiselBakims);
            objectContext.AddToRawObjectList(viewModel.SKRSIsinmas);
            objectContext.AddToRawObjectList(viewModel.SKRSGuvenliks);
            objectContext.AddToRawObjectList(viewModel.SKRSEvHijyenis);
            objectContext.AddToRawObjectList(viewModel.SKRSICDs);
            objectContext.AddToRawObjectList(viewModel.SKRSBirSonrakiHizmetIhtiyacis);
            objectContext.AddToRawObjectList(viewModel.SKRSBeslenmes);
            objectContext.AddToRawObjectList(viewModel.SKRSBasvuruTurus);
            objectContext.AddToRawObjectList(viewModel.SKRSBasiDegerlendirmesis);
            objectContext.AddToRawObjectList(viewModel.SKRSBakimveDestekIhtiyacis);
            objectContext.AddToRawObjectList(viewModel.SKRSAydinlatmas);
            objectContext.AddToRawObjectList(viewModel.SKRSAgris);
            objectContext.AddToRawObjectList(viewModel.VerilenEgitimlerGridList);
            objectContext.AddToRawObjectList(viewModel.PsikolojikDurumGridList);
            objectContext.AddToRawObjectList(viewModel.KullandigiYardimciAraclarGridList);
            objectContext.AddToRawObjectList(viewModel._EvdeSaglikIlkIzlemVeriSeti);
            objectContext.ProcessRawObjects();
            var evdeSaglikIlkIzlemVeriSeti = (EvdeSaglikIlkIzlemVeriSeti)objectContext.GetLoadedObject(viewModel._EvdeSaglikIlkIzlemVeriSeti.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(evdeSaglikIlkIzlemVeriSeti, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EvdeSaglikIlkIzlemVeriSeti, formDefID);
            if (viewModel.VerilenEgitimlerGridList != null)
            {
                foreach (var item in viewModel.VerilenEgitimlerGridList)
                {
                    var verilenEgitimlerImported = (VerilenEgitimler)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)verilenEgitimlerImported).IsDeleted)
                        continue;
                    verilenEgitimlerImported.EvdeSaglikIlkIzlemVeriSeti = evdeSaglikIlkIzlemVeriSeti;
                }
            }

            if (viewModel.PsikolojikDurumGridList != null)
            {
                foreach (var item in viewModel.PsikolojikDurumGridList)
                {
                    var psikolojikDurumImported = (PsikolojikDurum)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)psikolojikDurumImported).IsDeleted)
                        continue;
                    psikolojikDurumImported.EvdeSaglikIlkIzlemVeriSeti = evdeSaglikIlkIzlemVeriSeti;
                }
            }

            if (viewModel.KullandigiYardimciAraclarGridList != null)
            {
                foreach (var item in viewModel.KullandigiYardimciAraclarGridList)
                {
                    var kullandigiYardimciAraclarImported = (KullandigiYardimciAraclar)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)kullandigiYardimciAraclarImported).IsDeleted)
                        continue;
                    kullandigiYardimciAraclarImported.EvdeSaglikIlkIzlemVeriSeti = evdeSaglikIlkIzlemVeriSeti;
                }
            }

            var transDef = evdeSaglikIlkIzlemVeriSeti.TransDef;
            PostScript_EvdeSaglikIlkIzlemForm(viewModel, evdeSaglikIlkIzlemVeriSeti, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(evdeSaglikIlkIzlemVeriSeti);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(evdeSaglikIlkIzlemVeriSeti);
            AfterContextSaveScript_EvdeSaglikIlkIzlemForm(viewModel, evdeSaglikIlkIzlemVeriSeti, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_EvdeSaglikIlkIzlemForm(EvdeSaglikIlkIzlemFormViewModel viewModel, EvdeSaglikIlkIzlemVeriSeti evdeSaglikIlkIzlemVeriSeti, TTObjectContext objectContext);
    partial void PostScript_EvdeSaglikIlkIzlemForm(EvdeSaglikIlkIzlemFormViewModel viewModel, EvdeSaglikIlkIzlemVeriSeti evdeSaglikIlkIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_EvdeSaglikIlkIzlemForm(EvdeSaglikIlkIzlemFormViewModel viewModel, EvdeSaglikIlkIzlemVeriSeti evdeSaglikIlkIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(EvdeSaglikIlkIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.VerilenEgitimlerGridList = viewModel._EvdeSaglikIlkIzlemVeriSeti.VerilenEgitimler.OfType<VerilenEgitimler>().ToArray();
        viewModel.PsikolojikDurumGridList = viewModel._EvdeSaglikIlkIzlemVeriSeti.PsikolojikDurum.OfType<PsikolojikDurum>().ToArray();
        viewModel.KullandigiYardimciAraclarGridList = viewModel._EvdeSaglikIlkIzlemVeriSeti.KullandigiYardimciAraclar.OfType<KullandigiYardimciAraclar>().ToArray();
        viewModel.SKRSVerilenEgitimlers = objectContext.LocalQuery<SKRSVerilenEgitimler>().ToArray();
        viewModel.SKRSPsikolojikDurumDegerlendirmesis = objectContext.LocalQuery<SKRSPsikolojikDurumDegerlendirmesi>().ToArray();
        viewModel.SKRSKullandigiYardimciAraclars = objectContext.LocalQuery<SKRSKullandigiYardimciAraclar>().ToArray();
        viewModel.SKRSYatagaBagimliliks = objectContext.LocalQuery<SKRSYatagaBagimlilik>().ToArray();
        viewModel.SKRSKullanilanHelaTipis = objectContext.LocalQuery<SKRSKullanilanHelaTipi>().ToArray();
        viewModel.SKRSKonutTipis = objectContext.LocalQuery<SKRSKonutTipi>().ToArray();
        viewModel.SKRSKisiselHijyens = objectContext.LocalQuery<SKRSKisiselHijyen>().ToArray();
        viewModel.SKRSKisiselBakims = objectContext.LocalQuery<SKRSKisiselBakim>().ToArray();
        viewModel.SKRSIsinmas = objectContext.LocalQuery<SKRSIsinma>().ToArray();
        viewModel.SKRSGuvenliks = objectContext.LocalQuery<SKRSGuvenlik>().ToArray();
        viewModel.SKRSEvHijyenis = objectContext.LocalQuery<SKRSEvHijyeni>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSBirSonrakiHizmetIhtiyacis = objectContext.LocalQuery<SKRSBirSonrakiHizmetIhtiyaci>().ToArray();
        viewModel.SKRSBeslenmes = objectContext.LocalQuery<SKRSBeslenme>().ToArray();
        viewModel.SKRSBasvuruTurus = objectContext.LocalQuery<SKRSBasvuruTuru>().ToArray();
        viewModel.SKRSBasiDegerlendirmesis = objectContext.LocalQuery<SKRSBasiDegerlendirmesi>().ToArray();
        viewModel.SKRSBakimveDestekIhtiyacis = objectContext.LocalQuery<SKRSBakimveDestekIhtiyaci>().ToArray();
        viewModel.SKRSAydinlatmas = objectContext.LocalQuery<SKRSAydinlatma>().ToArray();
        viewModel.SKRSAgris = objectContext.LocalQuery<SKRSAgri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVerilenEgitimlerList", viewModel.SKRSVerilenEgitimlers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPsikolojikDurumDegerlendirmesiList", viewModel.SKRSPsikolojikDurumDegerlendirmesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKullandigiYardimciAraclarList", viewModel.SKRSKullandigiYardimciAraclars);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYatagaBagimlilikList", viewModel.SKRSYatagaBagimliliks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKullanilanHelaTipiList", viewModel.SKRSKullanilanHelaTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKonutTipiList", viewModel.SKRSKonutTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKisiselHijyenList", viewModel.SKRSKisiselHijyens);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKisiselBakimList", viewModel.SKRSKisiselBakims);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIsinmaList", viewModel.SKRSIsinmas);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGuvenlikList", viewModel.SKRSGuvenliks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEvHijyeniList", viewModel.SKRSEvHijyenis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBirSonrakiHizmetIhtiyaciList", viewModel.SKRSBirSonrakiHizmetIhtiyacis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBeslenmeList", viewModel.SKRSBeslenmes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBasvuruTuruList", viewModel.SKRSBasvuruTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBasiDegerlendirmesiList", viewModel.SKRSBasiDegerlendirmesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBakimveDestekIhtiyaciList", viewModel.SKRSBakimveDestekIhtiyacis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAydinlatmaList", viewModel.SKRSAydinlatmas);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAgriList", viewModel.SKRSAgris);
    }
}
}


namespace Core.Models
{
    public partial class EvdeSaglikIlkIzlemFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EvdeSaglikIlkIzlemVeriSeti _EvdeSaglikIlkIzlemVeriSeti { get; set; }
        public TTObjectClasses.VerilenEgitimler[] VerilenEgitimlerGridList { get; set; }
        public TTObjectClasses.PsikolojikDurum[] PsikolojikDurumGridList { get; set; }
        public TTObjectClasses.KullandigiYardimciAraclar[] KullandigiYardimciAraclarGridList { get; set; }
        public TTObjectClasses.SKRSVerilenEgitimler[] SKRSVerilenEgitimlers { get; set; }
        public TTObjectClasses.SKRSPsikolojikDurumDegerlendirmesi[] SKRSPsikolojikDurumDegerlendirmesis { get; set; }
        public TTObjectClasses.SKRSKullandigiYardimciAraclar[] SKRSKullandigiYardimciAraclars { get; set; }
        public TTObjectClasses.SKRSYatagaBagimlilik[] SKRSYatagaBagimliliks { get; set; }
        public TTObjectClasses.SKRSKullanilanHelaTipi[] SKRSKullanilanHelaTipis { get; set; }
        public TTObjectClasses.SKRSKonutTipi[] SKRSKonutTipis { get; set; }
        public TTObjectClasses.SKRSKisiselHijyen[] SKRSKisiselHijyens { get; set; }
        public TTObjectClasses.SKRSKisiselBakim[] SKRSKisiselBakims { get; set; }
        public TTObjectClasses.SKRSIsinma[] SKRSIsinmas { get; set; }
        public TTObjectClasses.SKRSGuvenlik[] SKRSGuvenliks { get; set; }
        public TTObjectClasses.SKRSEvHijyeni[] SKRSEvHijyenis { get; set; }
        public TTObjectClasses.SKRSICD[] SKRSICDs { get; set; }
        public TTObjectClasses.SKRSBirSonrakiHizmetIhtiyaci[] SKRSBirSonrakiHizmetIhtiyacis { get; set; }
        public TTObjectClasses.SKRSBeslenme[] SKRSBeslenmes { get; set; }
        public TTObjectClasses.SKRSBasvuruTuru[] SKRSBasvuruTurus { get; set; }
        public TTObjectClasses.SKRSBasiDegerlendirmesi[] SKRSBasiDegerlendirmesis { get; set; }
        public TTObjectClasses.SKRSBakimveDestekIhtiyaci[] SKRSBakimveDestekIhtiyacis { get; set; }
        public TTObjectClasses.SKRSAydinlatma[] SKRSAydinlatmas { get; set; }
        public TTObjectClasses.SKRSAgri[] SKRSAgris { get; set; }
    }
}
