//$F667BAED
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
    public partial class KuduzRiskliTemasVeriSetiServiceController : Controller
{
    [HttpGet]
    public KuduzRiskliTemasVeriSetiFormViewModel KuduzRiskliTemasVeriSetiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return KuduzRiskliTemasVeriSetiFormLoadInternal(input);
    }

    [HttpPost]
    public KuduzRiskliTemasVeriSetiFormViewModel KuduzRiskliTemasVeriSetiFormLoad(FormLoadInput input)
    {
        return KuduzRiskliTemasVeriSetiFormLoadInternal(input);
    }

    private KuduzRiskliTemasVeriSetiFormViewModel KuduzRiskliTemasVeriSetiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5e37de60-30d5-485c-a746-733275f9b443");
        var objectDefID = Guid.Parse("54d505f9-659e-4f98-96de-d3d61be1352e");
        var viewModel = new KuduzRiskliTemasVeriSetiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KuduzRiskliTemasVeriSeti = objectContext.GetObject(id.Value, objectDefID) as KuduzRiskliTemasVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KuduzRiskliTemasVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KuduzRiskliTemasVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._KuduzRiskliTemasVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._KuduzRiskliTemasVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_KuduzRiskliTemasVeriSetiForm(viewModel, viewModel._KuduzRiskliTemasVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KuduzRiskliTemasVeriSeti = new KuduzRiskliTemasVeriSeti(objectContext);
                viewModel.KuduzRiskliTemasTelefonGridList = new TTObjectClasses.KuduzRiskliTemasTelefon[]{};
                viewModel.KuduzRiskliTemasRiskTemTipGridList = new TTObjectClasses.KuduzRiskliTemasRiskTemTip[]{};
                viewModel.KuduzRiskliTemasPlanProfBiGridList = new TTObjectClasses.KuduzRiskliTemasPlanProfBi[]{};
                viewModel.KuduzRiskliTemasAdresGridList = new TTObjectClasses.KuduzRiskliTemasAdres[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KuduzRiskliTemasVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KuduzRiskliTemasVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._KuduzRiskliTemasVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._KuduzRiskliTemasVeriSeti);
                PreScript_KuduzRiskliTemasVeriSetiForm(viewModel, viewModel._KuduzRiskliTemasVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel KuduzRiskliTemasVeriSetiForm(KuduzRiskliTemasVeriSetiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return KuduzRiskliTemasVeriSetiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel KuduzRiskliTemasVeriSetiFormInternal(KuduzRiskliTemasVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5e37de60-30d5-485c-a746-733275f9b443");
        objectContext.AddToRawObjectList(viewModel.SKRSRiskliTemasaSebepOlanHayvans);
        objectContext.AddToRawObjectList(viewModel.SKRSKuduzRiskliTemasDegerlendirmeDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSKategorizasyons);
        objectContext.AddToRawObjectList(viewModel.SKRSImmunglobulinTurus);
        objectContext.AddToRawObjectList(viewModel.SKRSHayvaninSahiplikDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSHayvaninMevcutDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSTelefonTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSRiskliTemasTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSKisiyePlanlananKuduzProfilaksisis);
        objectContext.AddToRawObjectList(viewModel.SKRSAdresTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSBucakKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSCSBMTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSIlceKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSKoyKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSMahalleKodlaris);
        objectContext.AddToRawObjectList(viewModel.KuduzRiskliTemasTelefonGridList);
        objectContext.AddToRawObjectList(viewModel.KuduzRiskliTemasRiskTemTipGridList);
        objectContext.AddToRawObjectList(viewModel.KuduzRiskliTemasPlanProfBiGridList);
        objectContext.AddToRawObjectList(viewModel.KuduzRiskliTemasAdresGridList);
        objectContext.AddToRawObjectList(viewModel._KuduzRiskliTemasVeriSeti);
        objectContext.ProcessRawObjects();
        var kuduzRiskliTemasVeriSeti = (KuduzRiskliTemasVeriSeti)objectContext.GetLoadedObject(viewModel._KuduzRiskliTemasVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(kuduzRiskliTemasVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KuduzRiskliTemasVeriSeti, formDefID);
        if (viewModel.KuduzRiskliTemasTelefonGridList != null)
        {
            foreach (var item in viewModel.KuduzRiskliTemasTelefonGridList)
            {
                var kuduzRiskliTemasTelefonImported = (KuduzRiskliTemasTelefon)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)kuduzRiskliTemasTelefonImported).IsDeleted)
                    continue;
                kuduzRiskliTemasTelefonImported.KuduzRiskliTemasVeriSeti = kuduzRiskliTemasVeriSeti;
            }
        }

        if (viewModel.KuduzRiskliTemasRiskTemTipGridList != null)
        {
            foreach (var item in viewModel.KuduzRiskliTemasRiskTemTipGridList)
            {
                var kuduzRiskliTemasRiskTemTipImported = (KuduzRiskliTemasRiskTemTip)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)kuduzRiskliTemasRiskTemTipImported).IsDeleted)
                    continue;
                kuduzRiskliTemasRiskTemTipImported.KuduzRiskliTemasVeriSeti = kuduzRiskliTemasVeriSeti;
            }
        }

        if (viewModel.KuduzRiskliTemasPlanProfBiGridList != null)
        {
            foreach (var item in viewModel.KuduzRiskliTemasPlanProfBiGridList)
            {
                var kuduzRiskliTemasPlanProfBiImported = (KuduzRiskliTemasPlanProfBi)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)kuduzRiskliTemasPlanProfBiImported).IsDeleted)
                    continue;
                kuduzRiskliTemasPlanProfBiImported.KuduzRiskliTemasVeriSeti = kuduzRiskliTemasVeriSeti;
            }
        }

        if (viewModel.KuduzRiskliTemasAdresGridList != null)
        {
            foreach (var item in viewModel.KuduzRiskliTemasAdresGridList)
            {
                var kuduzRiskliTemasAdresImported = (KuduzRiskliTemasAdres)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)kuduzRiskliTemasAdresImported).IsDeleted)
                    continue;
                kuduzRiskliTemasAdresImported.KuduzRiskliTemasVeriSeti = kuduzRiskliTemasVeriSeti;
            }
        }

        var transDef = kuduzRiskliTemasVeriSeti.TransDef;
        PostScript_KuduzRiskliTemasVeriSetiForm(viewModel, kuduzRiskliTemasVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kuduzRiskliTemasVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kuduzRiskliTemasVeriSeti);
        AfterContextSaveScript_KuduzRiskliTemasVeriSetiForm(viewModel, kuduzRiskliTemasVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_KuduzRiskliTemasVeriSetiForm(KuduzRiskliTemasVeriSetiFormViewModel viewModel, KuduzRiskliTemasVeriSeti kuduzRiskliTemasVeriSeti, TTObjectContext objectContext);
    partial void PostScript_KuduzRiskliTemasVeriSetiForm(KuduzRiskliTemasVeriSetiFormViewModel viewModel, KuduzRiskliTemasVeriSeti kuduzRiskliTemasVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_KuduzRiskliTemasVeriSetiForm(KuduzRiskliTemasVeriSetiFormViewModel viewModel, KuduzRiskliTemasVeriSeti kuduzRiskliTemasVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(KuduzRiskliTemasVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.KuduzRiskliTemasTelefonGridList = viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon.OfType<KuduzRiskliTemasTelefon>().ToArray();
        viewModel.KuduzRiskliTemasRiskTemTipGridList = viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip.OfType<KuduzRiskliTemasRiskTemTip>().ToArray();
        viewModel.KuduzRiskliTemasPlanProfBiGridList = viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi.OfType<KuduzRiskliTemasPlanProfBi>().ToArray();
        viewModel.KuduzRiskliTemasAdresGridList = viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasAdres.OfType<KuduzRiskliTemasAdres>().ToArray();
        viewModel.SKRSRiskliTemasaSebepOlanHayvans = objectContext.LocalQuery<SKRSRiskliTemasaSebepOlanHayvan>().ToArray();
        viewModel.SKRSKuduzRiskliTemasDegerlendirmeDurumus = objectContext.LocalQuery<SKRSKuduzRiskliTemasDegerlendirmeDurumu>().ToArray();
        viewModel.SKRSKategorizasyons = objectContext.LocalQuery<SKRSKategorizasyon>().ToArray();
        viewModel.SKRSImmunglobulinTurus = objectContext.LocalQuery<SKRSImmunglobulinTuru>().ToArray();
        viewModel.SKRSHayvaninSahiplikDurumus = objectContext.LocalQuery<SKRSHayvaninSahiplikDurumu>().ToArray();
        viewModel.SKRSHayvaninMevcutDurumus = objectContext.LocalQuery<SKRSHayvaninMevcutDurumu>().ToArray();
        viewModel.SKRSTelefonTipis = objectContext.LocalQuery<SKRSTelefonTipi>().ToArray();
        viewModel.SKRSRiskliTemasTipis = objectContext.LocalQuery<SKRSRiskliTemasTipi>().ToArray();
        viewModel.SKRSKisiyePlanlananKuduzProfilaksisis = objectContext.LocalQuery<SKRSKisiyePlanlananKuduzProfilaksisi>().ToArray();
        viewModel.SKRSAdresTipis = objectContext.LocalQuery<SKRSAdresTipi>().ToArray();
        viewModel.SKRSBucakKodlaris = objectContext.LocalQuery<SKRSBucakKodlari>().ToArray();
        viewModel.SKRSCSBMTipis = objectContext.LocalQuery<SKRSCSBMTipi>().ToArray();
        viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.SKRSKoyKodlaris = objectContext.LocalQuery<SKRSKoyKodlari>().ToArray();
        viewModel.SKRSMahalleKodlaris = objectContext.LocalQuery<SKRSMahalleKodlari>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSRiskliTemasaSebepOlanHayvanList", viewModel.SKRSRiskliTemasaSebepOlanHayvans);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKuduzRiskliTemasDegerlendirmeDurumuList", viewModel.SKRSKuduzRiskliTemasDegerlendirmeDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKategorizasyonList", viewModel.SKRSKategorizasyons);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSImmunglobulinTuruList", viewModel.SKRSImmunglobulinTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHayvaninSahiplikDurumuList", viewModel.SKRSHayvaninSahiplikDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHayvaninMevcutDurumuList", viewModel.SKRSHayvaninMevcutDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTelefonTipiList", viewModel.SKRSTelefonTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSRiskliTemasTipiList", viewModel.SKRSRiskliTemasTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKisiyePlanlananKuduzProfilaksisiList", viewModel.SKRSKisiyePlanlananKuduzProfilaksisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAdresTipiList", viewModel.SKRSAdresTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBucakKodlariList", viewModel.SKRSBucakKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCSBMTipiList", viewModel.SKRSCSBMTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlceKodlariList", viewModel.SKRSIlceKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.SKRSILKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKoyKodlariList", viewModel.SKRSKoyKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMahalleKodlariList", viewModel.SKRSMahalleKodlaris);
    }
}
}


namespace Core.Models
{
    public partial class KuduzRiskliTemasVeriSetiFormViewModel
    {
        public TTObjectClasses.KuduzRiskliTemasVeriSeti _KuduzRiskliTemasVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.KuduzRiskliTemasTelefon[] KuduzRiskliTemasTelefonGridList
        {
            get;
            set;
        }

        public TTObjectClasses.KuduzRiskliTemasRiskTemTip[] KuduzRiskliTemasRiskTemTipGridList
        {
            get;
            set;
        }

        public TTObjectClasses.KuduzRiskliTemasPlanProfBi[] KuduzRiskliTemasPlanProfBiGridList
        {
            get;
            set;
        }

        public TTObjectClasses.KuduzRiskliTemasAdres[] KuduzRiskliTemasAdresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSRiskliTemasaSebepOlanHayvan[] SKRSRiskliTemasaSebepOlanHayvans
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKuduzRiskliTemasDegerlendirmeDurumu[] SKRSKuduzRiskliTemasDegerlendirmeDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKategorizasyon[] SKRSKategorizasyons
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSImmunglobulinTuru[] SKRSImmunglobulinTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSHayvaninSahiplikDurumu[] SKRSHayvaninSahiplikDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSHayvaninMevcutDurumu[] SKRSHayvaninMevcutDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTelefonTipi[] SKRSTelefonTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSRiskliTemasTipi[] SKRSRiskliTemasTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKisiyePlanlananKuduzProfilaksisi[] SKRSKisiyePlanlananKuduzProfilaksisis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAdresTipi[] SKRSAdresTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBucakKodlari[] SKRSBucakKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCSBMTipi[] SKRSCSBMTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIlceKodlari[] SKRSIlceKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKoyKodlari[] SKRSKoyKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMahalleKodlari[] SKRSMahalleKodlaris
        {
            get;
            set;
        }
    }
}
