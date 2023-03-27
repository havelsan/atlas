//$BA4DB9D7
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
    public partial class VeremVeriSetiServiceController : Controller
{
    [HttpGet]
    public VeremVeriSetiFormViewModel VeremVeriSetiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return VeremVeriSetiFormLoadInternal(input);
    }

    [HttpPost]
    public VeremVeriSetiFormViewModel VeremVeriSetiFormLoad(FormLoadInput input)
    {
        return VeremVeriSetiFormLoadInternal(input);
    }

    private VeremVeriSetiFormViewModel VeremVeriSetiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3283d688-fd25-4da9-9775-79ab3206bccd");
        var objectDefID = Guid.Parse("4ccaff90-1144-4500-a971-eb0adf32d5f3");
        var viewModel = new VeremVeriSetiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VeremVeriSeti = objectContext.GetObject(id.Value, objectDefID) as VeremVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VeremVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VeremVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._VeremVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._VeremVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_VeremVeriSetiForm(viewModel, viewModel._VeremVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VeremVeriSeti = new VeremVeriSeti(objectContext);
                viewModel.VeremTedaviSonucBilgisiGridList = new TTObjectClasses.VeremTedaviSonucBilgisi[]{};
                viewModel.VeremKlinikOrnegiGridList = new TTObjectClasses.VeremKlinikOrnegi[]{};
                viewModel.VeremIlacBilgisiGridList = new TTObjectClasses.VeremIlacBilgisi[]{};
                viewModel.VeremHastalikTutumYeriGridList = new TTObjectClasses.VeremHastalikTutumYeri[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VeremVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VeremVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._VeremVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._VeremVeriSeti);
                PreScript_VeremVeriSetiForm(viewModel, viewModel._VeremVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel VeremVeriSetiForm(VeremVeriSetiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return VeremVeriSetiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel VeremVeriSetiFormInternal(VeremVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3283d688-fd25-4da9-9775-79ab3206bccd");
        objectContext.AddToRawObjectList(viewModel.SKRSYaymaSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSVeremOlguTanimis);
        objectContext.AddToRawObjectList(viewModel.SKRSVeremHastasiTedaviYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSKulturSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSHastaninTedaviyeUyumus);
        objectContext.AddToRawObjectList(viewModel.SKRSDGTUygulamasiniYapanKisis);
        objectContext.AddToRawObjectList(viewModel.SKRSDGTUygulamaYeris);
        objectContext.AddToRawObjectList(viewModel.SKRSVeremTedaviSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSVeremHastasiKlinikOrnegis);
        objectContext.AddToRawObjectList(viewModel.SKRSIlacAdiVerems);
        objectContext.AddToRawObjectList(viewModel.SKRSIlacDirenciVerems);
        objectContext.AddToRawObjectList(viewModel.SKRSVeremHastaligininTutulumYeris);
        objectContext.AddToRawObjectList(viewModel.VeremTedaviSonucBilgisiGridList);
        objectContext.AddToRawObjectList(viewModel.VeremKlinikOrnegiGridList);
        objectContext.AddToRawObjectList(viewModel.VeremIlacBilgisiGridList);
        objectContext.AddToRawObjectList(viewModel.VeremHastalikTutumYeriGridList);
        objectContext.AddToRawObjectList(viewModel._VeremVeriSeti);
        objectContext.ProcessRawObjects();
        var veremVeriSeti = (VeremVeriSeti)objectContext.GetLoadedObject(viewModel._VeremVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(veremVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VeremVeriSeti, formDefID);
        if (viewModel.VeremTedaviSonucBilgisiGridList != null)
        {
            foreach (var item in viewModel.VeremTedaviSonucBilgisiGridList)
            {
                var veremTedaviSonucBilgisiImported = (VeremTedaviSonucBilgisi)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)veremTedaviSonucBilgisiImported).IsDeleted)
                    continue;
                veremTedaviSonucBilgisiImported.VeremVeriSeti = veremVeriSeti;
            }
        }

        if (viewModel.VeremKlinikOrnegiGridList != null)
        {
            foreach (var item in viewModel.VeremKlinikOrnegiGridList)
            {
                var veremKlinikOrnegiImported = (VeremKlinikOrnegi)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)veremKlinikOrnegiImported).IsDeleted)
                    continue;
                veremKlinikOrnegiImported.VeremVeriSeti = veremVeriSeti;
            }
        }

        if (viewModel.VeremIlacBilgisiGridList != null)
        {
            foreach (var item in viewModel.VeremIlacBilgisiGridList)
            {
                var veremIlacBilgisiImported = (VeremIlacBilgisi)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)veremIlacBilgisiImported).IsDeleted)
                    continue;
                veremIlacBilgisiImported.VeremVeriSeti = veremVeriSeti;
            }
        }

        if (viewModel.VeremHastalikTutumYeriGridList != null)
        {
            foreach (var item in viewModel.VeremHastalikTutumYeriGridList)
            {
                var veremHastalikTutumYeriImported = (VeremHastalikTutumYeri)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)veremHastalikTutumYeriImported).IsDeleted)
                    continue;
                veremHastalikTutumYeriImported.VeremVeriSeti = veremVeriSeti;
            }
        }

        var transDef = veremVeriSeti.TransDef;
        PostScript_VeremVeriSetiForm(viewModel, veremVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(veremVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(veremVeriSeti);
        AfterContextSaveScript_VeremVeriSetiForm(viewModel, veremVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_VeremVeriSetiForm(VeremVeriSetiFormViewModel viewModel, VeremVeriSeti veremVeriSeti, TTObjectContext objectContext);
    partial void PostScript_VeremVeriSetiForm(VeremVeriSetiFormViewModel viewModel, VeremVeriSeti veremVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_VeremVeriSetiForm(VeremVeriSetiFormViewModel viewModel, VeremVeriSeti veremVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(VeremVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.VeremTedaviSonucBilgisiGridList = viewModel._VeremVeriSeti.VeremTedaviSonucBilgisi.OfType<VeremTedaviSonucBilgisi>().ToArray();
        viewModel.VeremKlinikOrnegiGridList = viewModel._VeremVeriSeti.VeremKlinikOrnegi.OfType<VeremKlinikOrnegi>().ToArray();
        viewModel.VeremIlacBilgisiGridList = viewModel._VeremVeriSeti.VeremIlacBilgisi.OfType<VeremIlacBilgisi>().ToArray();
        viewModel.VeremHastalikTutumYeriGridList = viewModel._VeremVeriSeti.VeremHastalikTutumYeri.OfType<VeremHastalikTutumYeri>().ToArray();
        viewModel.SKRSYaymaSonucus = objectContext.LocalQuery<SKRSYaymaSonucu>().ToArray();
        viewModel.SKRSVeremOlguTanimis = objectContext.LocalQuery<SKRSVeremOlguTanimi>().ToArray();
        viewModel.SKRSVeremHastasiTedaviYontemis = objectContext.LocalQuery<SKRSVeremHastasiTedaviYontemi>().ToArray();
        viewModel.SKRSKulturSonucus = objectContext.LocalQuery<SKRSKulturSonucu>().ToArray();
        viewModel.SKRSHastaninTedaviyeUyumus = objectContext.LocalQuery<SKRSHastaninTedaviyeUyumu>().ToArray();
        viewModel.SKRSDGTUygulamasiniYapanKisis = objectContext.LocalQuery<SKRSDGTUygulamasiniYapanKisi>().ToArray();
        viewModel.SKRSDGTUygulamaYeris = objectContext.LocalQuery<SKRSDGTUygulamaYeri>().ToArray();
        viewModel.SKRSVeremTedaviSonucus = objectContext.LocalQuery<SKRSVeremTedaviSonucu>().ToArray();
        viewModel.SKRSVeremHastasiKlinikOrnegis = objectContext.LocalQuery<SKRSVeremHastasiKlinikOrnegi>().ToArray();
        viewModel.SKRSIlacAdiVerems = objectContext.LocalQuery<SKRSIlacAdiVerem>().ToArray();
        viewModel.SKRSIlacDirenciVerems = objectContext.LocalQuery<SKRSIlacDirenciVerem>().ToArray();
        viewModel.SKRSVeremHastaligininTutulumYeris = objectContext.LocalQuery<SKRSVeremHastaligininTutulumYeri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYaymaSonucuList", viewModel.SKRSYaymaSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVeremOlguTanimiList", viewModel.SKRSVeremOlguTanimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVeremHastasiTedaviYontemiList", viewModel.SKRSVeremHastasiTedaviYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKulturSonucuList", viewModel.SKRSKulturSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHastaninTedaviyeUyumuList", viewModel.SKRSHastaninTedaviyeUyumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDGTUygulamasiniYapanKisiList", viewModel.SKRSDGTUygulamasiniYapanKisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDGTUygulamaYeriList", viewModel.SKRSDGTUygulamaYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVeremTedaviSonucuList", viewModel.SKRSVeremTedaviSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVeremHastasiKlinikOrnegiList", viewModel.SKRSVeremHastasiKlinikOrnegis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlacAdiVeremList", viewModel.SKRSIlacAdiVerems);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlacDirenciVeremList", viewModel.SKRSIlacDirenciVerems);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVeremHastaligininTutulumYeriList", viewModel.SKRSVeremHastaligininTutulumYeris);
    }
}
}


namespace Core.Models
{
    public partial class VeremVeriSetiFormViewModel
    {
        public TTObjectClasses.VeremVeriSeti _VeremVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.VeremTedaviSonucBilgisi[] VeremTedaviSonucBilgisiGridList
        {
            get;
            set;
        }

        public TTObjectClasses.VeremKlinikOrnegi[] VeremKlinikOrnegiGridList
        {
            get;
            set;
        }

        public TTObjectClasses.VeremIlacBilgisi[] VeremIlacBilgisiGridList
        {
            get;
            set;
        }

        public TTObjectClasses.VeremHastalikTutumYeri[] VeremHastalikTutumYeriGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSYaymaSonucu[] SKRSYaymaSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSVeremOlguTanimi[] SKRSVeremOlguTanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSVeremHastasiTedaviYontemi[] SKRSVeremHastasiTedaviYontemis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKulturSonucu[] SKRSKulturSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSHastaninTedaviyeUyumu[] SKRSHastaninTedaviyeUyumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDGTUygulamasiniYapanKisi[] SKRSDGTUygulamasiniYapanKisis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDGTUygulamaYeri[] SKRSDGTUygulamaYeris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSVeremTedaviSonucu[] SKRSVeremTedaviSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSVeremHastasiKlinikOrnegi[] SKRSVeremHastasiKlinikOrnegis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIlacAdiVerem[] SKRSIlacAdiVerems
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIlacDirenciVerem[] SKRSIlacDirenciVerems
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSVeremHastaligininTutulumYeri[] SKRSVeremHastaligininTutulumYeris
        {
            get;
            set;
        }
    }
}
