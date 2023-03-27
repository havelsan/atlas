//$5CB1F1A3
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
    public partial class KuduzProfilaksiVeriSetiServiceController : Controller
{
    [HttpGet]
    public KuduzProfilaksiIzlemFormViewModel KuduzProfilaksiIzlemForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return KuduzProfilaksiIzlemFormLoadInternal(input);
    }

    [HttpPost]
    public KuduzProfilaksiIzlemFormViewModel KuduzProfilaksiIzlemFormLoad(FormLoadInput input)
    {
        return KuduzProfilaksiIzlemFormLoadInternal(input);
    }

    private KuduzProfilaksiIzlemFormViewModel KuduzProfilaksiIzlemFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7472f259-0bfc-47e7-beae-31a4cf4cce9a");
        var objectDefID = Guid.Parse("52fef827-20a4-40c8-b349-dceab769ce2e");
        var viewModel = new KuduzProfilaksiIzlemFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KuduzProfilaksiVeriSeti = objectContext.GetObject(id.Value, objectDefID) as KuduzProfilaksiVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KuduzProfilaksiVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KuduzProfilaksiVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._KuduzProfilaksiVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._KuduzProfilaksiVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_KuduzProfilaksiIzlemForm(viewModel, viewModel._KuduzProfilaksiVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KuduzProfilaksiVeriSeti = new KuduzProfilaksiVeriSeti(objectContext);
                viewModel.KuduzProfilaksiUygProfilakGridList = new TTObjectClasses.KuduzProfilaksiUygProfilak[]{};

                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KuduzProfilaksiVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KuduzProfilaksiVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._KuduzProfilaksiVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._KuduzProfilaksiVeriSeti);
                PreScript_KuduzProfilaksiIzlemForm(viewModel, viewModel._KuduzProfilaksiVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel KuduzProfilaksiIzlemForm(KuduzProfilaksiIzlemFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return KuduzProfilaksiIzlemFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel KuduzProfilaksiIzlemFormInternal(KuduzProfilaksiIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("7472f259-0bfc-47e7-beae-31a4cf4cce9a");
            objectContext.AddToRawObjectList(viewModel.SKRSImmunglobulinTurus);
            objectContext.AddToRawObjectList(viewModel.SKRSKuduzProfilaksisiTamamlanmaDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSUygulananKuduzProfilaksisis);
            objectContext.AddToRawObjectList(viewModel.KuduzProfilaksiUygProfilakGridList);
            objectContext.AddToRawObjectList(viewModel._KuduzProfilaksiVeriSeti);
            objectContext.ProcessRawObjects();

            var kuduzProfilaksiVeriSeti = (KuduzProfilaksiVeriSeti)objectContext.GetLoadedObject(viewModel._KuduzProfilaksiVeriSeti.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(kuduzProfilaksiVeriSeti, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KuduzProfilaksiVeriSeti, formDefID);

            if (viewModel.KuduzProfilaksiUygProfilakGridList != null)
            {
                foreach (var item in viewModel.KuduzProfilaksiUygProfilakGridList)
                {
                    var kuduzProfilaksiUygProfilakImported = (KuduzProfilaksiUygProfilak)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)kuduzProfilaksiUygProfilakImported).IsDeleted)
                        continue;
                    kuduzProfilaksiUygProfilakImported.KuduzProfilaksiVeriSeti = kuduzProfilaksiVeriSeti;
                }
            }
            var transDef = kuduzProfilaksiVeriSeti.TransDef;
            PostScript_KuduzProfilaksiIzlemForm(viewModel, kuduzProfilaksiVeriSeti, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kuduzProfilaksiVeriSeti);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kuduzProfilaksiVeriSeti);
            AfterContextSaveScript_KuduzProfilaksiIzlemForm(viewModel, kuduzProfilaksiVeriSeti, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

    partial void PreScript_KuduzProfilaksiIzlemForm(KuduzProfilaksiIzlemFormViewModel viewModel, KuduzProfilaksiVeriSeti kuduzProfilaksiVeriSeti, TTObjectContext objectContext);
    partial void PostScript_KuduzProfilaksiIzlemForm(KuduzProfilaksiIzlemFormViewModel viewModel, KuduzProfilaksiVeriSeti kuduzProfilaksiVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_KuduzProfilaksiIzlemForm(KuduzProfilaksiIzlemFormViewModel viewModel, KuduzProfilaksiVeriSeti kuduzProfilaksiVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(KuduzProfilaksiIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
            viewModel.KuduzProfilaksiUygProfilakGridList = viewModel._KuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak.OfType<KuduzProfilaksiUygProfilak>().ToArray();
            viewModel.SKRSImmunglobulinTurus = objectContext.LocalQuery<SKRSImmunglobulinTuru>().ToArray();
            viewModel.SKRSKuduzProfilaksisiTamamlanmaDurumus = objectContext.LocalQuery<SKRSKuduzProfilaksisiTamamlanmaDurumu>().ToArray();
            viewModel.SKRSUygulananKuduzProfilaksisis = objectContext.LocalQuery<SKRSUygulananKuduzProfilaksisi>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSImmunglobulinTuruList", viewModel.SKRSImmunglobulinTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKuduzProfilaksisiTamamlanmaDurumuList", viewModel.SKRSKuduzProfilaksisiTamamlanmaDurumus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSUygulananKuduzProfilaksisiList", viewModel.SKRSUygulananKuduzProfilaksisis);
        }
    }
}


namespace Core.Models
{
    public partial class KuduzProfilaksiIzlemFormViewModel
    {
        public TTObjectClasses.KuduzProfilaksiVeriSeti _KuduzProfilaksiVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.KuduzProfilaksiUygProfilak[] KuduzProfilaksiUygProfilakGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSImmunglobulinTuru[] SKRSImmunglobulinTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKuduzProfilaksisiTamamlanmaDurumu[] SKRSKuduzProfilaksisiTamamlanmaDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUygulananKuduzProfilaksisi[] SKRSUygulananKuduzProfilaksisis
        {
            get;
            set;
        }
    }
}
