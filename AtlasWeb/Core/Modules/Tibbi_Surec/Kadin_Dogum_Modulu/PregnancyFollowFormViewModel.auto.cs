//$E17BC0AB
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
    public partial class PregnancyFollowServiceController : Controller
{
    [HttpGet]
    public PregnancyFollowFormViewModel PregnancyFollowForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PregnancyFollowFormLoadInternal(input);
    }

    [HttpPost]
    public PregnancyFollowFormViewModel PregnancyFollowFormLoad(FormLoadInput input)
    {
        return PregnancyFollowFormLoadInternal(input);
    }

    private PregnancyFollowFormViewModel PregnancyFollowFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e63d630a-03f9-4d37-9a77-9c9e54e2f0e7");
        var objectDefID = Guid.Parse("b3e591b7-e1c2-4abb-803c-a06e94dbf601");
        var viewModel = new PregnancyFollowFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PregnancyFollow = objectContext.GetObject(id.Value, objectDefID) as PregnancyFollow;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PregnancyFollow, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PregnancyFollow, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PregnancyFollow);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PregnancyFollow);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PregnancyFollowForm(viewModel, viewModel._PregnancyFollow, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PregnancyFollow = new PregnancyFollow(objectContext);
                viewModel.FetusFollowGridList = new TTObjectClasses.FetusFollow[]{};
                viewModel.PregnancyDangerSignGridList = new TTObjectClasses.PregnancyDangerSign[]{};
                viewModel.ObligedRiskFactorsGridList = new TTObjectClasses.ObligedRiskFactors[]{};
                viewModel.PregnancyComplicationsGridList = new TTObjectClasses.PregnancyComplications[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PregnancyFollow, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PregnancyFollow, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PregnancyFollow);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PregnancyFollow);
                PreScript_PregnancyFollowForm(viewModel, viewModel._PregnancyFollow, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PregnancyFollowForm(PregnancyFollowFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PregnancyFollowFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PregnancyFollowFormInternal(PregnancyFollowFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e63d630a-03f9-4d37-9a77-9c9e54e2f0e7");
		objectContext.AddToRawObjectList(viewModel.SKRSGestasyonelDiyabetTaramasis);
        objectContext.AddToRawObjectList(viewModel.SKRSKadinSagligiIslemleris);
        objectContext.AddToRawObjectList(viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
        objectContext.AddToRawObjectList(viewModel.SKRSIdrardaProteins);
        objectContext.AddToRawObjectList(viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis);
        objectContext.AddToRawObjectList(viewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris);
        objectContext.AddToRawObjectList(viewModel.SKRSGebelikteRiskFaktorleris);
        objectContext.AddToRawObjectList(viewModel.SKRSDVitaminiLojistigiveDestegis);
        objectContext.AddToRawObjectList(viewModel.SKRSDemirLojistigiveDestegis);
        objectContext.AddToRawObjectList(viewModel.SKRSKacinciGebeIzlems);
        objectContext.AddToRawObjectList(viewModel.FetusFollowGridList);
        objectContext.AddToRawObjectList(viewModel.PregnancyDangerSignGridList);
        objectContext.AddToRawObjectList(viewModel.ObligedRiskFactorsGridList);
        objectContext.AddToRawObjectList(viewModel.PregnancyComplicationsGridList);
        objectContext.AddToRawObjectList(viewModel._PregnancyFollow);
        objectContext.ProcessRawObjects();
        var pregnancyFollow = (PregnancyFollow)objectContext.GetLoadedObject(viewModel._PregnancyFollow.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pregnancyFollow, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PregnancyFollow, formDefID);
        if (viewModel.FetusFollowGridList != null)
        {
            foreach (var item in viewModel.FetusFollowGridList)
            {
                var fetusFollowImported = (FetusFollow)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)fetusFollowImported).IsDeleted)
                    continue;
                fetusFollowImported.PregnancyFollow = pregnancyFollow;
            }
        }

        if (viewModel.PregnancyDangerSignGridList != null)
        {
            foreach (var item in viewModel.PregnancyDangerSignGridList)
            {
                var pregnancyDangerSignImported = (PregnancyDangerSign)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pregnancyDangerSignImported).IsDeleted)
                    continue;
                pregnancyDangerSignImported.PregnancyFollow = pregnancyFollow;
            }
        }

        if (viewModel.ObligedRiskFactorsGridList != null)
        {
            foreach (var item in viewModel.ObligedRiskFactorsGridList)
            {
                var obligedRiskFactorsImported = (ObligedRiskFactors)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)obligedRiskFactorsImported).IsDeleted)
                    continue;
                obligedRiskFactorsImported.PregnancyFollow = pregnancyFollow;
            }
        }

        if (viewModel.PregnancyComplicationsGridList != null)
        {
            foreach (var item in viewModel.PregnancyComplicationsGridList)
            {
                var pregnancyComplicationsImported = (PregnancyComplications)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pregnancyComplicationsImported).IsDeleted)
                    continue;
                pregnancyComplicationsImported.PregnancyFollow = pregnancyFollow;
            }
        }

        var transDef = pregnancyFollow.TransDef;
        PostScript_PregnancyFollowForm(viewModel, pregnancyFollow, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pregnancyFollow);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pregnancyFollow);
        AfterContextSaveScript_PregnancyFollowForm(viewModel, pregnancyFollow, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PregnancyFollowForm(PregnancyFollowFormViewModel viewModel, PregnancyFollow pregnancyFollow, TTObjectContext objectContext);
    partial void PostScript_PregnancyFollowForm(PregnancyFollowFormViewModel viewModel, PregnancyFollow pregnancyFollow, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PregnancyFollowForm(PregnancyFollowFormViewModel viewModel, PregnancyFollow pregnancyFollow, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PregnancyFollowFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.FetusFollowGridList = viewModel._PregnancyFollow.FetusFollow.OfType<FetusFollow>().ToArray();
        viewModel.PregnancyDangerSignGridList = viewModel._PregnancyFollow.PregnancyDangerSign.OfType<PregnancyDangerSign>().ToArray();
        viewModel.ObligedRiskFactorsGridList = viewModel._PregnancyFollow.ObligedRiskFactors.OfType<ObligedRiskFactors>().ToArray();
        viewModel.PregnancyComplicationsGridList = viewModel._PregnancyFollow.PregnancyComplications.OfType<PregnancyComplications>().ToArray();
        viewModel.SKRSGestasyonelDiyabetTaramasis = objectContext.LocalQuery<SKRSGestasyonelDiyabetTaramasi>().ToArray();
        viewModel.SKRSKadinSagligiIslemleris = objectContext.LocalQuery<SKRSKadinSagligiIslemleri>().ToArray();
        viewModel.SKRSKonjenitalAnomaliliDogumVarligis = objectContext.LocalQuery<SKRSKonjenitalAnomaliliDogumVarligi>().ToArray();
        viewModel.SKRSIdrardaProteins = objectContext.LocalQuery<SKRSIdrardaProtein>().ToArray();
        viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis = objectContext.LocalQuery<SKRSGebelikLohusalikSeyrindeTehlikeIsareti>().ToArray();
        viewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris = objectContext.LocalQuery<SKRSGebelikBildirimiZorunluRiskFaktorleri>().ToArray();
        viewModel.SKRSGebelikteRiskFaktorleris = objectContext.LocalQuery<SKRSGebelikteRiskFaktorleri>().ToArray();
        viewModel.SKRSDVitaminiLojistigiveDestegis = objectContext.LocalQuery<SKRSDVitaminiLojistigiveDestegi>().ToArray();
        viewModel.SKRSDemirLojistigiveDestegis = objectContext.LocalQuery<SKRSDemirLojistigiveDestegi>().ToArray();
        viewModel.SKRSKacinciGebeIzlems = objectContext.LocalQuery<SKRSKacinciGebeIzlem>().ToArray();
		ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGestasyonelDiyabetTaramasiList", viewModel.SKRSGestasyonelDiyabetTaramasis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKadinSagligiIslemleriList", viewModel.SKRSKadinSagligiIslemleris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKonjenitalAnomaliliDogumVarligiList", viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIdrardaProteinList", viewModel.SKRSIdrardaProteins);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikLohusalikSeyrindeTehlikeIsaretiList", viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikBildirimiZorunluRiskFaktorleriList", viewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikteRiskFaktorleriList", viewModel.SKRSGebelikteRiskFaktorleris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDVitaminiLojistigiveDestegiList", viewModel.SKRSDVitaminiLojistigiveDestegis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDemirLojistigiveDestegiList", viewModel.SKRSDemirLojistigiveDestegis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKacinciGebeIzlemList", viewModel.SKRSKacinciGebeIzlems);
    }
}
}


namespace Core.Models
{
    public partial class PregnancyFollowFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PregnancyFollow _PregnancyFollow { get; set; }
        public TTObjectClasses.FetusFollow[] FetusFollowGridList { get; set; }
        public TTObjectClasses.PregnancyDangerSign[] PregnancyDangerSignGridList { get; set; }
        public TTObjectClasses.ObligedRiskFactors[] ObligedRiskFactorsGridList { get; set; }
        public TTObjectClasses.PregnancyComplications[] PregnancyComplicationsGridList { get; set; }
        public TTObjectClasses.SKRSGestasyonelDiyabetTaramasi[] SKRSGestasyonelDiyabetTaramasis { get; set; }
        public TTObjectClasses.SKRSKadinSagligiIslemleri[] SKRSKadinSagligiIslemleris { get; set; }
        public TTObjectClasses.SKRSKonjenitalAnomaliliDogumVarligi[] SKRSKonjenitalAnomaliliDogumVarligis { get; set; }
        public TTObjectClasses.SKRSIdrardaProtein[] SKRSIdrardaProteins { get; set; }
        public TTObjectClasses.SKRSGebelikLohusalikSeyrindeTehlikeIsareti[] SKRSGebelikLohusalikSeyrindeTehlikeIsaretis { get; set; }
        public TTObjectClasses.SKRSGebelikBildirimiZorunluRiskFaktorleri[] SKRSGebelikBildirimiZorunluRiskFaktorleris { get; set; }
        public TTObjectClasses.SKRSGebelikteRiskFaktorleri[] SKRSGebelikteRiskFaktorleris { get; set; }
        public TTObjectClasses.SKRSDVitaminiLojistigiveDestegi[] SKRSDVitaminiLojistigiveDestegis { get; set; }
        public TTObjectClasses.SKRSDemirLojistigiveDestegi[] SKRSDemirLojistigiveDestegis { get; set; }
        public TTObjectClasses.SKRSKacinciGebeIzlem[] SKRSKacinciGebeIzlems { get; set; }
    }
}
