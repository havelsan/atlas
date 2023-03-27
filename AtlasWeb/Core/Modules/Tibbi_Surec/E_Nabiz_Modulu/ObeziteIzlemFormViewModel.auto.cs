//$F908D231
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
    public partial class ObeziteIzlemVeriSetiServiceController : Controller
{
    [HttpGet]
    public ObeziteIzlemFormViewModel ObeziteIzlemForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ObeziteIzlemFormLoadInternal(input);
    }

    [HttpPost]
    public ObeziteIzlemFormViewModel ObeziteIzlemFormLoad(FormLoadInput input)
    {
        return ObeziteIzlemFormLoadInternal(input);
    }

    private ObeziteIzlemFormViewModel ObeziteIzlemFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e7171532-91b9-48b0-92a4-d519ccb86794");
        var objectDefID = Guid.Parse("e70f6851-b0db-4eae-8327-fc28464d0da5");
        var viewModel = new ObeziteIzlemFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ObeziteIzlemVeriSeti = objectContext.GetObject(id.Value, objectDefID) as ObeziteIzlemVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ObeziteIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ObeziteIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ObeziteIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ObeziteIzlemVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ObeziteIzlemForm(viewModel, viewModel._ObeziteIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ObeziteIzlemVeriSeti = new ObeziteIzlemVeriSeti(objectContext);
                viewModel.ObeziteEkHastalikGridList = new TTObjectClasses.ObeziteEkHastalik[]{};
                viewModel.ObeziteEgzersizGridList = new TTObjectClasses.ObeziteEgzersiz[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ObeziteIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ObeziteIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ObeziteIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ObeziteIzlemVeriSeti);
                PreScript_ObeziteIzlemForm(viewModel, viewModel._ObeziteIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ObeziteIzlemForm(ObeziteIzlemFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e7171532-91b9-48b0-92a4-d519ccb86794");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSPsikolojikTedavis);
            objectContext.AddToRawObjectList(viewModel.SKRSObeziteIlacTedavisis);
            objectContext.AddToRawObjectList(viewModel.SKRSMorbidObezHastaLenfatikOdemVarligis);
            objectContext.AddToRawObjectList(viewModel.SKRSDiyetTedavisiTibbiBeslenmeTedavisis);
            objectContext.AddToRawObjectList(viewModel.SKRSICDs);
            objectContext.AddToRawObjectList(viewModel.SKRSEgzersizs);
            objectContext.AddToRawObjectList(viewModel.ObeziteEkHastalikGridList);
            objectContext.AddToRawObjectList(viewModel.ObeziteEgzersizGridList);
            objectContext.AddToRawObjectList(viewModel._ObeziteIzlemVeriSeti);
            objectContext.ProcessRawObjects();
            var obeziteIzlemVeriSeti = (ObeziteIzlemVeriSeti)objectContext.GetLoadedObject(viewModel._ObeziteIzlemVeriSeti.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(obeziteIzlemVeriSeti, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ObeziteIzlemVeriSeti, formDefID);
            if (viewModel.ObeziteEkHastalikGridList != null)
            {
                foreach (var item in viewModel.ObeziteEkHastalikGridList)
                {
                    var obeziteEkHastalikImported = (ObeziteEkHastalik)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)obeziteEkHastalikImported).IsDeleted)
                        continue;
                    obeziteEkHastalikImported.ObeziteIzlemVeriSeti = obeziteIzlemVeriSeti;
                }
            }

            if (viewModel.ObeziteEgzersizGridList != null)
            {
                foreach (var item in viewModel.ObeziteEgzersizGridList)
                {
                    var obeziteEgzersizImported = (ObeziteEgzersiz)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)obeziteEgzersizImported).IsDeleted)
                        continue;
                    obeziteEgzersizImported.ObeziteIzlemVeriSeti = obeziteIzlemVeriSeti;
                }
            }

            var transDef = obeziteIzlemVeriSeti.TransDef;
            PostScript_ObeziteIzlemForm(viewModel, obeziteIzlemVeriSeti, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(obeziteIzlemVeriSeti);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(obeziteIzlemVeriSeti);
            AfterContextSaveScript_ObeziteIzlemForm(viewModel, obeziteIzlemVeriSeti, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ObeziteIzlemForm(ObeziteIzlemFormViewModel viewModel, ObeziteIzlemVeriSeti obeziteIzlemVeriSeti, TTObjectContext objectContext);
    partial void PostScript_ObeziteIzlemForm(ObeziteIzlemFormViewModel viewModel, ObeziteIzlemVeriSeti obeziteIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ObeziteIzlemForm(ObeziteIzlemFormViewModel viewModel, ObeziteIzlemVeriSeti obeziteIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ObeziteIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ObeziteEkHastalikGridList = viewModel._ObeziteIzlemVeriSeti.ObeziteEkHastalik.OfType<ObeziteEkHastalik>().ToArray();
        viewModel.ObeziteEgzersizGridList = viewModel._ObeziteIzlemVeriSeti.ObeziteEgzersiz.OfType<ObeziteEgzersiz>().ToArray();
        viewModel.SKRSPsikolojikTedavis = objectContext.LocalQuery<SKRSPsikolojikTedavi>().ToArray();
        viewModel.SKRSObeziteIlacTedavisis = objectContext.LocalQuery<SKRSObeziteIlacTedavisi>().ToArray();
        viewModel.SKRSMorbidObezHastaLenfatikOdemVarligis = objectContext.LocalQuery<SKRSMorbidObezHastaLenfatikOdemVarligi>().ToArray();
        viewModel.SKRSDiyetTedavisiTibbiBeslenmeTedavisis = objectContext.LocalQuery<SKRSDiyetTedavisiTibbiBeslenmeTedavisi>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSEgzersizs = objectContext.LocalQuery<SKRSEgzersiz>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPsikolojikTedaviList", viewModel.SKRSPsikolojikTedavis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSObeziteIlacTedavisiList", viewModel.SKRSObeziteIlacTedavisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMorbidObezHastaLenfatikOdemVarligiList", viewModel.SKRSMorbidObezHastaLenfatikOdemVarligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyetTedavisiTibbiBeslenmeTedavisiList", viewModel.SKRSDiyetTedavisiTibbiBeslenmeTedavisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEgzersizList", viewModel.SKRSEgzersizs);
    }
}
}


namespace Core.Models
{
    public partial class ObeziteIzlemFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ObeziteIzlemVeriSeti _ObeziteIzlemVeriSeti { get; set; }
        public TTObjectClasses.ObeziteEkHastalik[] ObeziteEkHastalikGridList { get; set; }
        public TTObjectClasses.ObeziteEgzersiz[] ObeziteEgzersizGridList { get; set; }
        public TTObjectClasses.SKRSPsikolojikTedavi[] SKRSPsikolojikTedavis { get; set; }
        public TTObjectClasses.SKRSObeziteIlacTedavisi[] SKRSObeziteIlacTedavisis { get; set; }
        public TTObjectClasses.SKRSMorbidObezHastaLenfatikOdemVarligi[] SKRSMorbidObezHastaLenfatikOdemVarligis { get; set; }
        public TTObjectClasses.SKRSDiyetTedavisiTibbiBeslenmeTedavisi[] SKRSDiyetTedavisiTibbiBeslenmeTedavisis { get; set; }
        public TTObjectClasses.SKRSICD[] SKRSICDs { get; set; }
        public TTObjectClasses.SKRSEgzersiz[] SKRSEgzersizs { get; set; }
    }
}
