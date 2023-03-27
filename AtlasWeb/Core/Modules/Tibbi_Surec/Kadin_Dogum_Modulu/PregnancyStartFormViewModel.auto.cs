//$740A90A8
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
    public PregnancyStartFormViewModel PregnancyStartForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PregnancyStartFormLoadInternal(input);
    }

    [HttpPost]
    public PregnancyStartFormViewModel PregnancyStartFormLoad(FormLoadInput input)
    {
        return PregnancyStartFormLoadInternal(input);
    }

    private PregnancyStartFormViewModel PregnancyStartFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e9f91cd1-0a39-47e6-8144-b2306b23c036");
        var objectDefID = Guid.Parse("25984dea-a4a6-4e5f-9f38-37c9420c84d1");
        var viewModel = new PregnancyStartFormViewModel();
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
                PreScript_PregnancyStartForm(viewModel, viewModel._Pregnancy, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Pregnancy = new Pregnancy(objectContext);
                viewModel.PregnancyNotificationGridList = new TTObjectClasses.PregnancyNotification[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Pregnancy, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pregnancy, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Pregnancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Pregnancy);
                PreScript_PregnancyStartForm(viewModel, viewModel._Pregnancy, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PregnancyStartForm(PregnancyStartFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PregnancyStartFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PregnancyStartFormInternal(PregnancyStartFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e9f91cd1-0a39-47e6-8144-b2306b23c036");
        objectContext.AddToRawObjectList(viewModel.SKRSGebeBilgilendirmeveDanismanliks);
        objectContext.AddToRawObjectList(viewModel.PregnancyNotificationGridList);
        objectContext.AddToRawObjectList(viewModel._Pregnancy);
        objectContext.ProcessRawObjects();
        var pregnancy = (Pregnancy)objectContext.GetLoadedObject(viewModel._Pregnancy.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pregnancy, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Pregnancy, formDefID);
        if (viewModel.PregnancyNotificationGridList != null)
        {
            foreach (var item in viewModel.PregnancyNotificationGridList)
            {
                var pregnancyNotificationImported = (PregnancyNotification)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pregnancyNotificationImported).IsDeleted)
                    continue;
                pregnancyNotificationImported.Pregnancy = pregnancy;
            }
        }

        var transDef = pregnancy.TransDef;
        PostScript_PregnancyStartForm(viewModel, pregnancy, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pregnancy);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pregnancy);
        AfterContextSaveScript_PregnancyStartForm(viewModel, pregnancy, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PregnancyStartForm(PregnancyStartFormViewModel viewModel, Pregnancy pregnancy, TTObjectContext objectContext);
    partial void PostScript_PregnancyStartForm(PregnancyStartFormViewModel viewModel, Pregnancy pregnancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PregnancyStartForm(PregnancyStartFormViewModel viewModel, Pregnancy pregnancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PregnancyStartFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PregnancyNotificationGridList = viewModel._Pregnancy.PregnancyNotification.OfType<PregnancyNotification>().ToArray();
        viewModel.SKRSGebeBilgilendirmeveDanismanliks = objectContext.LocalQuery<SKRSGebeBilgilendirmeveDanismanlik>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebeBilgilendirmeveDanismanlikList", viewModel.SKRSGebeBilgilendirmeveDanismanliks);
    }
}
}


namespace Core.Models
{
    public partial class PregnancyStartFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Pregnancy _Pregnancy { get; set; }
        public TTObjectClasses.PregnancyNotification[] PregnancyNotificationGridList { get; set; }
        public TTObjectClasses.SKRSGebeBilgilendirmeveDanismanlik[] SKRSGebeBilgilendirmeveDanismanliks { get; set; }
    }
}
