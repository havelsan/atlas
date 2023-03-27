//$29157AF3
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
    public partial class PregnancyResultServiceController : Controller
{
    [HttpGet]
    public PregnancyResultFormViewModel PregnancyResultForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PregnancyResultFormLoadInternal(input);
    }

    [HttpPost]
    public PregnancyResultFormViewModel PregnancyResultFormLoad(FormLoadInput input)
    {
        return PregnancyResultFormLoadInternal(input);
    }

    private PregnancyResultFormViewModel PregnancyResultFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ffbbf653-1ecb-4193-8008-179f66d1dfa3");
        var objectDefID = Guid.Parse("1a520a61-52a4-4fc9-9574-41fbf03885d5");
        var viewModel = new PregnancyResultFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PregnancyResult = objectContext.GetObject(id.Value, objectDefID) as PregnancyResult;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PregnancyResult, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PregnancyResult, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PregnancyResult);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PregnancyResult);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PregnancyResultForm(viewModel, viewModel._PregnancyResult, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PregnancyResult = new PregnancyResult(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PregnancyResult, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PregnancyResult, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PregnancyResult);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PregnancyResult);
                PreScript_PregnancyResultForm(viewModel, viewModel._PregnancyResult, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PregnancyResultForm(PregnancyResultFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PregnancyResultFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PregnancyResultFormInternal(PregnancyResultFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ffbbf653-1ecb-4193-8008-179f66d1dfa3");
        objectContext.AddToRawObjectList(viewModel.SKRSDogumYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
        objectContext.AddToRawObjectList(viewModel.SKRSGebelikSonucus);
        objectContext.AddToRawObjectList(viewModel.Pregnancys);
        objectContext.AddToRawObjectList(viewModel._PregnancyResult);
        objectContext.ProcessRawObjects();
        var pregnancyResult = (PregnancyResult)objectContext.GetLoadedObject(viewModel._PregnancyResult.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pregnancyResult, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PregnancyResult, formDefID);
        var transDef = pregnancyResult.TransDef;
        PostScript_PregnancyResultForm(viewModel, pregnancyResult, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pregnancyResult);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pregnancyResult);
        AfterContextSaveScript_PregnancyResultForm(viewModel, pregnancyResult, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PregnancyResultForm(PregnancyResultFormViewModel viewModel, PregnancyResult pregnancyResult, TTObjectContext objectContext);
    partial void PostScript_PregnancyResultForm(PregnancyResultFormViewModel viewModel, PregnancyResult pregnancyResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PregnancyResultForm(PregnancyResultFormViewModel viewModel, PregnancyResult pregnancyResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PregnancyResultFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSDogumYontemis = objectContext.LocalQuery<SKRSDogumYontemi>().ToArray();
        viewModel.SKRSKonjenitalAnomaliliDogumVarligis = objectContext.LocalQuery<SKRSKonjenitalAnomaliliDogumVarligi>().ToArray();
        viewModel.SKRSGebelikSonucus = objectContext.LocalQuery<SKRSGebelikSonucu>().ToArray();
        viewModel.Pregnancys = objectContext.LocalQuery<Pregnancy>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumYontemiList", viewModel.SKRSDogumYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKonjenitalAnomaliliDogumVarligiList", viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikSonucuList", viewModel.SKRSGebelikSonucus);
    }
}
}


namespace Core.Models
{
    public partial class PregnancyResultFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PregnancyResult _PregnancyResult { get; set; }
        public TTObjectClasses.SKRSDogumYontemi[] SKRSDogumYontemis { get; set; }
        public TTObjectClasses.SKRSKonjenitalAnomaliliDogumVarligi[] SKRSKonjenitalAnomaliliDogumVarligis { get; set; }
        public TTObjectClasses.SKRSGebelikSonucu[] SKRSGebelikSonucus { get; set; }
        public TTObjectClasses.Pregnancy[] Pregnancys { get; set; }
    }
}
