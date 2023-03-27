//$FBB5A259
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
    public partial class IntiharGirisimKrizVeriSetiServiceController : Controller
{
    [HttpGet]
    public IntiharGirisimiKrizTespitVeriSetiFormViewModel IntiharGirisimiKrizTespitVeriSetiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return IntiharGirisimiKrizTespitVeriSetiFormLoadInternal(input);
    }

    [HttpPost]
    public IntiharGirisimiKrizTespitVeriSetiFormViewModel IntiharGirisimiKrizTespitVeriSetiFormLoad(FormLoadInput input)
    {
        return IntiharGirisimiKrizTespitVeriSetiFormLoadInternal(input);
    }

    private IntiharGirisimiKrizTespitVeriSetiFormViewModel IntiharGirisimiKrizTespitVeriSetiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5e27aa9d-5aaf-430b-92ae-172eac4a789d");
        var objectDefID = Guid.Parse("f95eb719-ecba-4fa2-b029-48b40ad04b66");
        var viewModel = new IntiharGirisimiKrizTespitVeriSetiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IntiharGirisimKrizVeriSeti = objectContext.GetObject(id.Value, objectDefID) as IntiharGirisimKrizVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IntiharGirisimKrizVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntiharGirisimKrizVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._IntiharGirisimKrizVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._IntiharGirisimKrizVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_IntiharGirisimiKrizTespitVeriSetiForm(viewModel, viewModel._IntiharGirisimKrizVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IntiharGirisimKrizVeriSeti = new IntiharGirisimKrizVeriSeti(objectContext);
                viewModel.IntiharGirisimPsikiyatTaniGridList = new TTObjectClasses.IntiharGirisimPsikiyatTani[]{};
                viewModel.IntiharGirisimiYontemiGridList = new TTObjectClasses.IntiharGirisimiYontemi[]{};
                viewModel.IntiharGirisimiVakaSonucuGridList = new TTObjectClasses.IntiharGirisimiVakaSonucu[]{};
                viewModel.IntiharGirisimiKrizNedeniGridList = new TTObjectClasses.IntiharGirisimiKrizNedeni[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IntiharGirisimKrizVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntiharGirisimKrizVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._IntiharGirisimKrizVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._IntiharGirisimKrizVeriSeti);
                PreScript_IntiharGirisimiKrizTespitVeriSetiForm(viewModel, viewModel._IntiharGirisimKrizVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel IntiharGirisimiKrizTespitVeriSetiForm(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return IntiharGirisimiKrizTespitVeriSetiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel IntiharGirisimiKrizTespitVeriSetiFormInternal(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5e27aa9d-5aaf-430b-92ae-172eac4a789d");
        objectContext.AddToRawObjectList(viewModel.SKRSICDs);
        objectContext.AddToRawObjectList(viewModel.SKRSPsikiyatrikTedaviGecmisis);
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharKrizVakaTurus);
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharGirisimiGecmisis);
        objectContext.AddToRawObjectList(viewModel.SKRSAilesindePsikiyatrikVakas);
        objectContext.AddToRawObjectList(viewModel.SKRSAilesindeIntiharGirisimis);
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharKrizVakaSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharGirisimiyadaKrizNedenleris);
        objectContext.AddToRawObjectList(viewModel.IntiharGirisimPsikiyatTaniGridList);
        objectContext.AddToRawObjectList(viewModel.IntiharGirisimiYontemiGridList);
        objectContext.AddToRawObjectList(viewModel.IntiharGirisimiVakaSonucuGridList);
        objectContext.AddToRawObjectList(viewModel.IntiharGirisimiKrizNedeniGridList);
        objectContext.AddToRawObjectList(viewModel._IntiharGirisimKrizVeriSeti);
        objectContext.ProcessRawObjects();
        var intiharGirisimKrizVeriSeti = (IntiharGirisimKrizVeriSeti)objectContext.GetLoadedObject(viewModel._IntiharGirisimKrizVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(intiharGirisimKrizVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntiharGirisimKrizVeriSeti, formDefID);
        if (viewModel.IntiharGirisimPsikiyatTaniGridList != null)
        {
            foreach (var item in viewModel.IntiharGirisimPsikiyatTaniGridList)
            {
                var intiharGirisimPsikiyatTaniImported = (IntiharGirisimPsikiyatTani)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharGirisimPsikiyatTaniImported).IsDeleted)
                    continue;
                intiharGirisimPsikiyatTaniImported.IntiharGirisimKrizVeriSeti = intiharGirisimKrizVeriSeti;
            }
        }

        if (viewModel.IntiharGirisimiYontemiGridList != null)
        {
            foreach (var item in viewModel.IntiharGirisimiYontemiGridList)
            {
                var intiharGirisimiYontemiImported = (IntiharGirisimiYontemi)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharGirisimiYontemiImported).IsDeleted)
                    continue;
                intiharGirisimiYontemiImported.IntiharGirisimKrizVeriSeti = intiharGirisimKrizVeriSeti;
            }
        }

        if (viewModel.IntiharGirisimiVakaSonucuGridList != null)
        {
            foreach (var item in viewModel.IntiharGirisimiVakaSonucuGridList)
            {
                var intiharGirisimiVakaSonucuImported = (IntiharGirisimiVakaSonucu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharGirisimiVakaSonucuImported).IsDeleted)
                    continue;
                intiharGirisimiVakaSonucuImported.IntiharGirisimKrizVeriSeti = intiharGirisimKrizVeriSeti;
            }
        }

        if (viewModel.IntiharGirisimiKrizNedeniGridList != null)
        {
            foreach (var item in viewModel.IntiharGirisimiKrizNedeniGridList)
            {
                var intiharGirisimiKrizNedeniImported = (IntiharGirisimiKrizNedeni)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharGirisimiKrizNedeniImported).IsDeleted)
                    continue;
                intiharGirisimiKrizNedeniImported.IntiharGirisimKrizVeriSeti = intiharGirisimKrizVeriSeti;
            }
        }

        var transDef = intiharGirisimKrizVeriSeti.TransDef;
        PostScript_IntiharGirisimiKrizTespitVeriSetiForm(viewModel, intiharGirisimKrizVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(intiharGirisimKrizVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(intiharGirisimKrizVeriSeti);
        AfterContextSaveScript_IntiharGirisimiKrizTespitVeriSetiForm(viewModel, intiharGirisimKrizVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_IntiharGirisimiKrizTespitVeriSetiForm(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel, IntiharGirisimKrizVeriSeti intiharGirisimKrizVeriSeti, TTObjectContext objectContext);
    partial void PostScript_IntiharGirisimiKrizTespitVeriSetiForm(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel, IntiharGirisimKrizVeriSeti intiharGirisimKrizVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_IntiharGirisimiKrizTespitVeriSetiForm(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel, IntiharGirisimKrizVeriSeti intiharGirisimKrizVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(IntiharGirisimiKrizTespitVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.IntiharGirisimPsikiyatTaniGridList = viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani.OfType<IntiharGirisimPsikiyatTani>().ToArray();
        viewModel.IntiharGirisimiYontemiGridList = viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiYontemi.OfType<IntiharGirisimiYontemi>().ToArray();
        viewModel.IntiharGirisimiVakaSonucuGridList = viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu.OfType<IntiharGirisimiVakaSonucu>().ToArray();
        viewModel.IntiharGirisimiKrizNedeniGridList = viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni.OfType<IntiharGirisimiKrizNedeni>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSPsikiyatrikTedaviGecmisis = objectContext.LocalQuery<SKRSPsikiyatrikTedaviGecmisi>().ToArray();
        viewModel.SKRSIntiharKrizVakaTurus = objectContext.LocalQuery<SKRSIntiharKrizVakaTuru>().ToArray();
        viewModel.SKRSIntiharGirisimiGecmisis = objectContext.LocalQuery<SKRSIntiharGirisimiGecmisi>().ToArray();
        viewModel.SKRSAilesindePsikiyatrikVakas = objectContext.LocalQuery<SKRSAilesindePsikiyatrikVaka>().ToArray();
        viewModel.SKRSAilesindeIntiharGirisimis = objectContext.LocalQuery<SKRSAilesindeIntiharGirisimi>().ToArray();
        viewModel.SKRSIntiharKrizVakaSonucus = objectContext.LocalQuery<SKRSIntiharKrizVakaSonucu>().ToArray();
        viewModel.SKRSIntiharGirisimiyadaKrizNedenleris = objectContext.LocalQuery<SKRSIntiharGirisimiyadaKrizNedenleri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPsikiyatrikTedaviGecmisiList", viewModel.SKRSPsikiyatrikTedaviGecmisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharKrizVakaTuruList", viewModel.SKRSIntiharKrizVakaTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharGirisimiGecmisiList", viewModel.SKRSIntiharGirisimiGecmisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAilesindePsikiyatrikVakaList", viewModel.SKRSAilesindePsikiyatrikVakas);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAilesindeIntiharGirisimiList", viewModel.SKRSAilesindeIntiharGirisimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharKrizVakaSonucuList", viewModel.SKRSIntiharKrizVakaSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharGirisimiyadaKrizNedenleriList", viewModel.SKRSIntiharGirisimiyadaKrizNedenleris);
    }
}
}


namespace Core.Models
{
    public partial class IntiharGirisimiKrizTespitVeriSetiFormViewModel
    {
        public TTObjectClasses.IntiharGirisimKrizVeriSeti _IntiharGirisimKrizVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharGirisimPsikiyatTani[] IntiharGirisimPsikiyatTaniGridList
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharGirisimiYontemi[] IntiharGirisimiYontemiGridList
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharGirisimiVakaSonucu[] IntiharGirisimiVakaSonucuGridList
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharGirisimiKrizNedeni[] IntiharGirisimiKrizNedeniGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICD[] SKRSICDs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPsikiyatrikTedaviGecmisi[] SKRSPsikiyatrikTedaviGecmisis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIntiharKrizVakaTuru[] SKRSIntiharKrizVakaTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIntiharGirisimiGecmisi[] SKRSIntiharGirisimiGecmisis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAilesindePsikiyatrikVaka[] SKRSAilesindePsikiyatrikVakas
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAilesindeIntiharGirisimi[] SKRSAilesindeIntiharGirisimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIntiharKrizVakaSonucu[] SKRSIntiharKrizVakaSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIntiharGirisimiyadaKrizNedenleri[] SKRSIntiharGirisimiyadaKrizNedenleris
        {
            get;
            set;
        }
    }
}
