//$95788B6C
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
    public partial class PregnancyServiceController : Controller
{
    [HttpGet]
    public PreviousPregnancyFormViewModel PreviousPregnancyForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PreviousPregnancyFormLoadInternal(input);
    }

    [HttpPost]
    public PreviousPregnancyFormViewModel PreviousPregnancyFormLoad(FormLoadInput input)
    {
        return PreviousPregnancyFormLoadInternal(input);
    }

    private PreviousPregnancyFormViewModel PreviousPregnancyFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("edbd60c7-cbee-4aca-9056-74bee055f8f8");
        var objectDefID = Guid.Parse("25984dea-a4a6-4e5f-9f38-37c9420c84d1");
        var viewModel = new PreviousPregnancyFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Pregnancy = objectContext.GetObject(id.Value, objectDefID) as Pregnancy;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Pregnancy, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pregnancy, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Pregnancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Pregnancy);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PreviousPregnancyForm(viewModel, viewModel._Pregnancy, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Pregnancy = new Pregnancy(objectContext);
                viewModel.IndicationReasonsGridList = new TTObjectClasses.IndicationReason[]{};
                viewModel.PregnancyComplicationsGridList = new TTObjectClasses.PregnancyComplications[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Pregnancy, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pregnancy, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Pregnancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Pregnancy);
                PreScript_PreviousPregnancyForm(viewModel, viewModel._Pregnancy, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PreviousPregnancyForm(PreviousPregnancyFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PreviousPregnancyFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PreviousPregnancyFormInternal(PreviousPregnancyFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("edbd60c7-cbee-4aca-9056-74bee055f8f8");
        objectContext.AddToRawObjectList(viewModel.SKRSEndikasyonNedenleris);
        objectContext.AddToRawObjectList(viewModel.SKRSSezaryanEndikasyonlars);
        objectContext.AddToRawObjectList(viewModel.SKRSDogumYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSDogumunGerceklestigiYers);
        objectContext.AddToRawObjectList(viewModel.SKRSDogumaYardimEdens);
        objectContext.AddToRawObjectList(viewModel.SKRSGebelikteRiskFaktorleris);
        objectContext.AddToRawObjectList(viewModel.IndicationReasonsGridList);
        objectContext.AddToRawObjectList(viewModel.PregnancyComplicationsGridList);
        objectContext.AddToRawObjectList(viewModel._Pregnancy);
        objectContext.ProcessRawObjects();
        var pregnancy = (Pregnancy)objectContext.GetLoadedObject(viewModel._Pregnancy.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pregnancy, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pregnancy, formDefID);
        if (viewModel.IndicationReasonsGridList != null)
        {
            foreach (var item in viewModel.IndicationReasonsGridList)
            {
                var indicationReasonsImported = (IndicationReason)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)indicationReasonsImported).IsDeleted)
                    continue;
                indicationReasonsImported.Pregnancy = pregnancy;
            }
        }

        if (viewModel.PregnancyComplicationsGridList != null)
        {
            foreach (var item in viewModel.PregnancyComplicationsGridList)
            {
                var pregnancyComplicationsImported = (PregnancyComplications)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pregnancyComplicationsImported).IsDeleted)
                    continue;
                pregnancyComplicationsImported.Pregnancy = pregnancy;
            }
        }

        var transDef = pregnancy.TransDef;
        PostScript_PreviousPregnancyForm(viewModel, pregnancy, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pregnancy);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pregnancy);
        AfterContextSaveScript_PreviousPregnancyForm(viewModel, pregnancy, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PreviousPregnancyForm(PreviousPregnancyFormViewModel viewModel, Pregnancy pregnancy, TTObjectContext objectContext);
    partial void PostScript_PreviousPregnancyForm(PreviousPregnancyFormViewModel viewModel, Pregnancy pregnancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PreviousPregnancyForm(PreviousPregnancyFormViewModel viewModel, Pregnancy pregnancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PreviousPregnancyFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.IndicationReasonsGridList = viewModel._Pregnancy.IndicationReasons.OfType<IndicationReason>().ToArray();
        viewModel.PregnancyComplicationsGridList = viewModel._Pregnancy.PregnancyComplications.OfType<PregnancyComplications>().ToArray();
        viewModel.SKRSEndikasyonNedenleris = objectContext.LocalQuery<SKRSEndikasyonNedenleri>().ToArray();
        viewModel.SKRSSezaryanEndikasyonlars = objectContext.LocalQuery<SKRSSezaryanEndikasyonlar>().ToArray();
        viewModel.SKRSDogumYontemis = objectContext.LocalQuery<SKRSDogumYontemi>().ToArray();
        viewModel.SKRSDogumunGerceklestigiYers = objectContext.LocalQuery<SKRSDogumunGerceklestigiYer>().ToArray();
        viewModel.SKRSDogumaYardimEdens = objectContext.LocalQuery<SKRSDogumaYardimEden>().ToArray();
        viewModel.SKRSGebelikteRiskFaktorleris = objectContext.LocalQuery<SKRSGebelikteRiskFaktorleri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEndikasyonNedenleriList", viewModel.SKRSEndikasyonNedenleris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSezaryanEndikasyonlarList", viewModel.SKRSSezaryanEndikasyonlars);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumYontemiList", viewModel.SKRSDogumYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumunGerceklestigiYerList", viewModel.SKRSDogumunGerceklestigiYers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumaYardimEdenList", viewModel.SKRSDogumaYardimEdens);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikteRiskFaktorleriList", viewModel.SKRSGebelikteRiskFaktorleris);
    }
}
}


namespace Core.Models
{
    public partial class PreviousPregnancyFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Pregnancy _Pregnancy { get; set; }
        public TTObjectClasses.IndicationReason[] IndicationReasonsGridList { get; set; }
        public TTObjectClasses.PregnancyComplications[] PregnancyComplicationsGridList { get; set; }
        public TTObjectClasses.SKRSEndikasyonNedenleri[] SKRSEndikasyonNedenleris { get; set; }
        public TTObjectClasses.SKRSSezaryanEndikasyonlar[] SKRSSezaryanEndikasyonlars { get; set; }
        public TTObjectClasses.SKRSDogumYontemi[] SKRSDogumYontemis { get; set; }
        public TTObjectClasses.SKRSDogumunGerceklestigiYer[] SKRSDogumunGerceklestigiYers { get; set; }
        public TTObjectClasses.SKRSDogumaYardimEden[] SKRSDogumaYardimEdens { get; set; }
        public TTObjectClasses.SKRSGebelikteRiskFaktorleri[] SKRSGebelikteRiskFaktorleris { get; set; }
    }
}
