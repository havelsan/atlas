//$266ACFEC
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
    public partial class KadinaYonelikSiddetVeriSetServiceController : Controller
{
    [HttpGet]
    public KadinaYonelikSiddetVeriSetiFormViewModel KadinaYonelikSiddetVeriSetiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return KadinaYonelikSiddetVeriSetiFormLoadInternal(input);
    }

    [HttpPost]
    public KadinaYonelikSiddetVeriSetiFormViewModel KadinaYonelikSiddetVeriSetiFormLoad(FormLoadInput input)
    {
        return KadinaYonelikSiddetVeriSetiFormLoadInternal(input);
    }

    private KadinaYonelikSiddetVeriSetiFormViewModel KadinaYonelikSiddetVeriSetiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6e92b8c2-de62-4ebc-8d54-062ab1acef85");
        var objectDefID = Guid.Parse("f77e4dd2-bb8b-4c82-9130-8d63626730bf");
        var viewModel = new KadinaYonelikSiddetVeriSetiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KadinaYonelikSiddetVeriSet = objectContext.GetObject(id.Value, objectDefID) as KadinaYonelikSiddetVeriSet;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KadinaYonelikSiddetVeriSet, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KadinaYonelikSiddetVeriSet, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._KadinaYonelikSiddetVeriSet);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._KadinaYonelikSiddetVeriSet);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_KadinaYonelikSiddetVeriSetiForm(viewModel, viewModel._KadinaYonelikSiddetVeriSet, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KadinaYonelikSiddetVeriSet = new KadinaYonelikSiddetVeriSet(objectContext);
                viewModel.KadinaYonelikSiddetTuruGridList = new TTObjectClasses.KadinaYonelikSiddetTuru[]{};
                viewModel.KadinaYonelikSiddetSonucGridList = new TTObjectClasses.KadinaYonelikSiddetSonuc[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KadinaYonelikSiddetVeriSet, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KadinaYonelikSiddetVeriSet, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._KadinaYonelikSiddetVeriSet);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._KadinaYonelikSiddetVeriSet);
                PreScript_KadinaYonelikSiddetVeriSetiForm(viewModel, viewModel._KadinaYonelikSiddetVeriSet, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel KadinaYonelikSiddetVeriSetiForm(KadinaYonelikSiddetVeriSetiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return KadinaYonelikSiddetVeriSetiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel KadinaYonelikSiddetVeriSetiFormInternal(KadinaYonelikSiddetVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6e92b8c2-de62-4ebc-8d54-062ab1acef85");
        objectContext.AddToRawObjectList(viewModel.SKRSSiddetTurus);
        objectContext.AddToRawObjectList(viewModel.SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirmes);
        objectContext.AddToRawObjectList(viewModel.KadinaYonelikSiddetTuruGridList);
        objectContext.AddToRawObjectList(viewModel.KadinaYonelikSiddetSonucGridList);
        objectContext.AddToRawObjectList(viewModel._KadinaYonelikSiddetVeriSet);
        objectContext.ProcessRawObjects();
        var kadinaYonelikSiddetVeriSet = (KadinaYonelikSiddetVeriSet)objectContext.GetLoadedObject(viewModel._KadinaYonelikSiddetVeriSet.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(kadinaYonelikSiddetVeriSet, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KadinaYonelikSiddetVeriSet, formDefID);
        if (viewModel.KadinaYonelikSiddetTuruGridList != null)
        {
            foreach (var item in viewModel.KadinaYonelikSiddetTuruGridList)
            {
                var kadinaYonelikSiddetTuruImported = (KadinaYonelikSiddetTuru)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)kadinaYonelikSiddetTuruImported).IsDeleted)
                    continue;
                kadinaYonelikSiddetTuruImported.KadinaYonelikSiddetVeriSet = kadinaYonelikSiddetVeriSet;
            }
        }

        if (viewModel.KadinaYonelikSiddetSonucGridList != null)
        {
            foreach (var item in viewModel.KadinaYonelikSiddetSonucGridList)
            {
                var kadinaYonelikSiddetSonucImported = (KadinaYonelikSiddetSonuc)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)kadinaYonelikSiddetSonucImported).IsDeleted)
                    continue;
                kadinaYonelikSiddetSonucImported.KadinaYonelikSiddetVeriSet = kadinaYonelikSiddetVeriSet;
            }
        }

        var transDef = kadinaYonelikSiddetVeriSet.TransDef;
        PostScript_KadinaYonelikSiddetVeriSetiForm(viewModel, kadinaYonelikSiddetVeriSet, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kadinaYonelikSiddetVeriSet);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kadinaYonelikSiddetVeriSet);
        AfterContextSaveScript_KadinaYonelikSiddetVeriSetiForm(viewModel, kadinaYonelikSiddetVeriSet, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_KadinaYonelikSiddetVeriSetiForm(KadinaYonelikSiddetVeriSetiFormViewModel viewModel, KadinaYonelikSiddetVeriSet kadinaYonelikSiddetVeriSet, TTObjectContext objectContext);
    partial void PostScript_KadinaYonelikSiddetVeriSetiForm(KadinaYonelikSiddetVeriSetiFormViewModel viewModel, KadinaYonelikSiddetVeriSet kadinaYonelikSiddetVeriSet, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_KadinaYonelikSiddetVeriSetiForm(KadinaYonelikSiddetVeriSetiFormViewModel viewModel, KadinaYonelikSiddetVeriSet kadinaYonelikSiddetVeriSet, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(KadinaYonelikSiddetVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.KadinaYonelikSiddetTuruGridList = viewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru.OfType<KadinaYonelikSiddetTuru>().ToArray();
        viewModel.KadinaYonelikSiddetSonucGridList = viewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc.OfType<KadinaYonelikSiddetSonuc>().ToArray();
        viewModel.SKRSSiddetTurus = objectContext.LocalQuery<SKRSSiddetTuru>().ToArray();
        viewModel.SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirmes = objectContext.LocalQuery<SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSiddetTuruList", viewModel.SKRSSiddetTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlen", viewModel.SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirmes);
    }
}
}


namespace Core.Models
{
    public partial class KadinaYonelikSiddetVeriSetiFormViewModel
    {
        public TTObjectClasses.KadinaYonelikSiddetVeriSet _KadinaYonelikSiddetVeriSet
        {
            get;
            set;
        }

        public TTObjectClasses.KadinaYonelikSiddetTuru[] KadinaYonelikSiddetTuruGridList
        {
            get;
            set;
        }

        public TTObjectClasses.KadinaYonelikSiddetSonuc[] KadinaYonelikSiddetSonucGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSiddetTuru[] SKRSSiddetTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme[] SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirmes
        {
            get;
            set;
        }
    }
}
