//$60154395
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
    public partial class TutunKullanimiVeriSetiServiceController : Controller
{
    [HttpGet]
    public TutunKullanimiVeriSetiFormViewModel TutunKullanimiVeriSetiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return TutunKullanimiVeriSetiFormLoadInternal(input);
    }

    [HttpPost]
    public TutunKullanimiVeriSetiFormViewModel TutunKullanimiVeriSetiFormLoad(FormLoadInput input)
    {
        return TutunKullanimiVeriSetiFormLoadInternal(input);
    }

    private TutunKullanimiVeriSetiFormViewModel TutunKullanimiVeriSetiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("090bf1c1-11dc-4d39-883c-c6de99fe16d1");
        var objectDefID = Guid.Parse("00648ea4-7746-456d-86c9-08a57e85a363");
        var viewModel = new TutunKullanimiVeriSetiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TutunKullanimiVeriSeti = objectContext.GetObject(id.Value, objectDefID) as TutunKullanimiVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TutunKullanimiVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TutunKullanimiVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._TutunKullanimiVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._TutunKullanimiVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_TutunKullanimiVeriSetiForm(viewModel, viewModel._TutunKullanimiVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TutunKullanimiVeriSeti = new TutunKullanimiVeriSeti(objectContext);
                viewModel.TutunKullanimiTedaviSonucuGridList = new TTObjectClasses.TutunKullanimiTedaviSonucu[]{};
                viewModel.TutunKullanimiTedaviSekliGridList = new TTObjectClasses.TutunKullanimiTedaviSekli[]{};
                viewModel.TutunKullanimiBagimOldUrunGridList = new TTObjectClasses.TutunKullanimiBagimOldUrun[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TutunKullanimiVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TutunKullanimiVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._TutunKullanimiVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._TutunKullanimiVeriSeti);
                PreScript_TutunKullanimiVeriSetiForm(viewModel, viewModel._TutunKullanimiVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel TutunKullanimiVeriSetiForm(TutunKullanimiVeriSetiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return TutunKullanimiVeriSetiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel TutunKullanimiVeriSetiFormInternal(TutunKullanimiVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("090bf1c1-11dc-4d39-883c-c6de99fe16d1");
        objectContext.AddToRawObjectList(viewModel.SKRSTutunDumaninaMaruzKalmaPasificiciliks);
        objectContext.AddToRawObjectList(viewModel.SKRSSigaraKullanimis);
        objectContext.AddToRawObjectList(viewModel.SKRSTutunTedaviSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSTedaviSeklis);
        objectContext.AddToRawObjectList(viewModel.SKRSBagimliOlduguUruns);
        objectContext.AddToRawObjectList(viewModel.TutunKullanimiTedaviSonucuGridList);
        objectContext.AddToRawObjectList(viewModel.TutunKullanimiTedaviSekliGridList);
        objectContext.AddToRawObjectList(viewModel.TutunKullanimiBagimOldUrunGridList);
        objectContext.AddToRawObjectList(viewModel._TutunKullanimiVeriSeti);
        objectContext.ProcessRawObjects();
        var tutunKullanimiVeriSeti = (TutunKullanimiVeriSeti)objectContext.GetLoadedObject(viewModel._TutunKullanimiVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(tutunKullanimiVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TutunKullanimiVeriSeti, formDefID);
        if (viewModel.TutunKullanimiTedaviSonucuGridList != null)
        {
            foreach (var item in viewModel.TutunKullanimiTedaviSonucuGridList)
            {
                var tutunKullanimiTedaviSonucuImported = (TutunKullanimiTedaviSonucu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)tutunKullanimiTedaviSonucuImported).IsDeleted)
                    continue;
                tutunKullanimiTedaviSonucuImported.TutunKullanimiVeriSeti = tutunKullanimiVeriSeti;
            }
        }

        if (viewModel.TutunKullanimiTedaviSekliGridList != null)
        {
            foreach (var item in viewModel.TutunKullanimiTedaviSekliGridList)
            {
                var tutunKullanimiTedaviSekliImported = (TutunKullanimiTedaviSekli)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)tutunKullanimiTedaviSekliImported).IsDeleted)
                    continue;
                tutunKullanimiTedaviSekliImported.TutunKullanimiVeriSeti = tutunKullanimiVeriSeti;
            }
        }

        if (viewModel.TutunKullanimiBagimOldUrunGridList != null)
        {
            foreach (var item in viewModel.TutunKullanimiBagimOldUrunGridList)
            {
                var tutunKullanimiBagimOldUrunImported = (TutunKullanimiBagimOldUrun)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)tutunKullanimiBagimOldUrunImported).IsDeleted)
                    continue;
                tutunKullanimiBagimOldUrunImported.TutunKullanimiVeriSeti = tutunKullanimiVeriSeti;
            }
        }

        var transDef = tutunKullanimiVeriSeti.TransDef;
        PostScript_TutunKullanimiVeriSetiForm(viewModel, tutunKullanimiVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(tutunKullanimiVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(tutunKullanimiVeriSeti);
        AfterContextSaveScript_TutunKullanimiVeriSetiForm(viewModel, tutunKullanimiVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_TutunKullanimiVeriSetiForm(TutunKullanimiVeriSetiFormViewModel viewModel, TutunKullanimiVeriSeti tutunKullanimiVeriSeti, TTObjectContext objectContext);
    partial void PostScript_TutunKullanimiVeriSetiForm(TutunKullanimiVeriSetiFormViewModel viewModel, TutunKullanimiVeriSeti tutunKullanimiVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_TutunKullanimiVeriSetiForm(TutunKullanimiVeriSetiFormViewModel viewModel, TutunKullanimiVeriSeti tutunKullanimiVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(TutunKullanimiVeriSetiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.TutunKullanimiTedaviSonucuGridList = viewModel._TutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu.OfType<TutunKullanimiTedaviSonucu>().ToArray();
        viewModel.TutunKullanimiTedaviSekliGridList = viewModel._TutunKullanimiVeriSeti.TutunKullanimiTedaviSekli.OfType<TutunKullanimiTedaviSekli>().ToArray();
        viewModel.TutunKullanimiBagimOldUrunGridList = viewModel._TutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun.OfType<TutunKullanimiBagimOldUrun>().ToArray();
        viewModel.SKRSTutunDumaninaMaruzKalmaPasificiciliks = objectContext.LocalQuery<SKRSTutunDumaninaMaruzKalmaPasificicilik>().ToArray();
        viewModel.SKRSSigaraKullanimis = objectContext.LocalQuery<SKRSSigaraKullanimi>().ToArray();
        viewModel.SKRSTutunTedaviSonucus = objectContext.LocalQuery<SKRSTutunTedaviSonucu>().ToArray();
        viewModel.SKRSTedaviSeklis = objectContext.LocalQuery<SKRSTedaviSekli>().ToArray();
        viewModel.SKRSBagimliOlduguUruns = objectContext.LocalQuery<SKRSBagimliOlduguUrun>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTutunDumaninaMaruzKalmaPasificicilikList", viewModel.SKRSTutunDumaninaMaruzKalmaPasificiciliks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigaraKullanimiList", viewModel.SKRSSigaraKullanimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTutunTedaviSonucuList", viewModel.SKRSTutunTedaviSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTedaviSekliList", viewModel.SKRSTedaviSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBagimliOlduguUrunList", viewModel.SKRSBagimliOlduguUruns);
    }
}
}


namespace Core.Models
{
    public partial class TutunKullanimiVeriSetiFormViewModel
    {
        public TTObjectClasses.TutunKullanimiVeriSeti _TutunKullanimiVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.TutunKullanimiTedaviSonucu[] TutunKullanimiTedaviSonucuGridList
        {
            get;
            set;
        }

        public TTObjectClasses.TutunKullanimiTedaviSekli[] TutunKullanimiTedaviSekliGridList
        {
            get;
            set;
        }

        public TTObjectClasses.TutunKullanimiBagimOldUrun[] TutunKullanimiBagimOldUrunGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTutunDumaninaMaruzKalmaPasificicilik[] SKRSTutunDumaninaMaruzKalmaPasificiciliks
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSigaraKullanimi[] SKRSSigaraKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTutunTedaviSonucu[] SKRSTutunTedaviSonucus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTedaviSekli[] SKRSTedaviSeklis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBagimliOlduguUrun[] SKRSBagimliOlduguUruns
        {
            get;
            set;
        }
    }
}
