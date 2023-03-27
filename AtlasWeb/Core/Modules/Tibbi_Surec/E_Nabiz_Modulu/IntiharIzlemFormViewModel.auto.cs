//$6A18204F
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
    public partial class IntiharIzlemVeriSetiServiceController : Controller
{
    [HttpGet]
    public IntiharIzlemFormViewModel IntiharIzlemForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return IntiharIzlemFormLoadInternal(input);
    }

    [HttpPost]
    public IntiharIzlemFormViewModel IntiharIzlemFormLoad(FormLoadInput input)
    {
        return IntiharIzlemFormLoadInternal(input);
    }

    private IntiharIzlemFormViewModel IntiharIzlemFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("06655b7a-3baa-4706-8363-5707437c3803");
        var objectDefID = Guid.Parse("a9d54496-7fd2-4537-8d14-5464b8b2e310");
        var viewModel = new IntiharIzlemFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IntiharIzlemVeriSeti = objectContext.GetObject(id.Value, objectDefID) as IntiharIzlemVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IntiharIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntiharIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._IntiharIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._IntiharIzlemVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_IntiharIzlemForm(viewModel, viewModel._IntiharIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IntiharIzlemVeriSeti = new IntiharIzlemVeriSeti(objectContext);
                viewModel.IntiharIzlemYontemiGridList = new TTObjectClasses.IntiharIzlemYontemi[]{};
                viewModel.IntiharIzlemVakaSonucuGridList = new TTObjectClasses.IntiharIzlemVakaSonucu[]{};
                viewModel.IntiharIzlemNedeniGridList = new TTObjectClasses.IntiharIzlemNedeni[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IntiharIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntiharIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._IntiharIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._IntiharIzlemVeriSeti);
                PreScript_IntiharIzlemForm(viewModel, viewModel._IntiharIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel IntiharIzlemForm(IntiharIzlemFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return IntiharIzlemFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel IntiharIzlemFormInternal(IntiharIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("06655b7a-3baa-4706-8363-5707437c3803");
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharKrizVakaTurus);
        objectContext.AddToRawObjectList(viewModel.SKRSICDs);
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharKrizVakaSonucus);
        objectContext.AddToRawObjectList(viewModel.SKRSIntiharGirisimiyadaKrizNedenleris);
        objectContext.AddToRawObjectList(viewModel.IntiharIzlemYontemiGridList);
        objectContext.AddToRawObjectList(viewModel.IntiharIzlemVakaSonucuGridList);
        objectContext.AddToRawObjectList(viewModel.IntiharIzlemNedeniGridList);
        objectContext.AddToRawObjectList(viewModel._IntiharIzlemVeriSeti);
        objectContext.ProcessRawObjects();
        var intiharIzlemVeriSeti = (IntiharIzlemVeriSeti)objectContext.GetLoadedObject(viewModel._IntiharIzlemVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(intiharIzlemVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntiharIzlemVeriSeti, formDefID);
        if (viewModel.IntiharIzlemYontemiGridList != null)
        {
            foreach (var item in viewModel.IntiharIzlemYontemiGridList)
            {
                var intiharIzlemYontemiImported = (IntiharIzlemYontemi)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharIzlemYontemiImported).IsDeleted)
                    continue;
                intiharIzlemYontemiImported.IntiharIzlemVeriSeti = intiharIzlemVeriSeti;
            }
        }

        if (viewModel.IntiharIzlemVakaSonucuGridList != null)
        {
            foreach (var item in viewModel.IntiharIzlemVakaSonucuGridList)
            {
                var intiharIzlemVakaSonucuImported = (IntiharIzlemVakaSonucu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharIzlemVakaSonucuImported).IsDeleted)
                    continue;
                intiharIzlemVakaSonucuImported.IntiharIzlemVeriSeti = intiharIzlemVeriSeti;
            }
        }

        if (viewModel.IntiharIzlemNedeniGridList != null)
        {
            foreach (var item in viewModel.IntiharIzlemNedeniGridList)
            {
                var intiharIzlemNedeniImported = (IntiharIzlemNedeni)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)intiharIzlemNedeniImported).IsDeleted)
                    continue;
                intiharIzlemNedeniImported.IntiharIzlemVeriSeti = intiharIzlemVeriSeti;
            }
        }

        var transDef = intiharIzlemVeriSeti.TransDef;
        PostScript_IntiharIzlemForm(viewModel, intiharIzlemVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(intiharIzlemVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(intiharIzlemVeriSeti);
        AfterContextSaveScript_IntiharIzlemForm(viewModel, intiharIzlemVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_IntiharIzlemForm(IntiharIzlemFormViewModel viewModel, IntiharIzlemVeriSeti intiharIzlemVeriSeti, TTObjectContext objectContext);
    partial void PostScript_IntiharIzlemForm(IntiharIzlemFormViewModel viewModel, IntiharIzlemVeriSeti intiharIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_IntiharIzlemForm(IntiharIzlemFormViewModel viewModel, IntiharIzlemVeriSeti intiharIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(IntiharIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.IntiharIzlemYontemiGridList = viewModel._IntiharIzlemVeriSeti.IntiharIzlemYontemi.OfType<IntiharIzlemYontemi>().ToArray();
        viewModel.IntiharIzlemVakaSonucuGridList = viewModel._IntiharIzlemVeriSeti.IntiharIzlemVakaSonucu.OfType<IntiharIzlemVakaSonucu>().ToArray();
        viewModel.IntiharIzlemNedeniGridList = viewModel._IntiharIzlemVeriSeti.IntiharIzlemNedeni.OfType<IntiharIzlemNedeni>().ToArray();
        viewModel.SKRSIntiharKrizVakaTurus = objectContext.LocalQuery<SKRSIntiharKrizVakaTuru>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSIntiharKrizVakaSonucus = objectContext.LocalQuery<SKRSIntiharKrizVakaSonucu>().ToArray();
        viewModel.SKRSIntiharGirisimiyadaKrizNedenleris = objectContext.LocalQuery<SKRSIntiharGirisimiyadaKrizNedenleri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharKrizVakaTuruList", viewModel.SKRSIntiharKrizVakaTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharKrizVakaSonucuList", viewModel.SKRSIntiharKrizVakaSonucus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIntiharGirisimiyadaKrizNedenleriList", viewModel.SKRSIntiharGirisimiyadaKrizNedenleris);
    }
}
}


namespace Core.Models
{
    public partial class IntiharIzlemFormViewModel
    {
        public TTObjectClasses.IntiharIzlemVeriSeti _IntiharIzlemVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharIzlemYontemi[] IntiharIzlemYontemiGridList
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharIzlemVakaSonucu[] IntiharIzlemVakaSonucuGridList
        {
            get;
            set;
        }

        public TTObjectClasses.IntiharIzlemNedeni[] IntiharIzlemNedeniGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIntiharKrizVakaTuru[] SKRSIntiharKrizVakaTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICD[] SKRSICDs
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
