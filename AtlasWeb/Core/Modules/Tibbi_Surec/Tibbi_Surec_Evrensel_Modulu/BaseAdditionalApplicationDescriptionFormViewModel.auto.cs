//$51F47D62
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
    public partial class BaseAdditionalApplicationServiceController : Controller
{
    [HttpGet]
    public BaseAdditionalApplicationDescriptionFormViewModel BaseAdditionalApplicationDescriptionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseAdditionalApplicationDescriptionFormLoadInternal(input);
    }

    [HttpPost]
    public BaseAdditionalApplicationDescriptionFormViewModel BaseAdditionalApplicationDescriptionFormLoad(FormLoadInput input)
    {
        return BaseAdditionalApplicationDescriptionFormLoadInternal(input);
    }

    private BaseAdditionalApplicationDescriptionFormViewModel BaseAdditionalApplicationDescriptionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e9990234-5a19-4dd8-9cee-7ae3be8ed642");
        var objectDefID = Guid.Parse("34ae8af9-fe35-48e1-914a-51d967b2ab1d");
        var viewModel = new BaseAdditionalApplicationDescriptionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseAdditionalApplication = objectContext.GetObject(id.Value, objectDefID) as BaseAdditionalApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseAdditionalApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAdditionalApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseAdditionalApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseAdditionalApplication);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseAdditionalApplicationDescriptionForm(viewModel, viewModel._BaseAdditionalApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseAdditionalApplicationDescriptionForm(BaseAdditionalApplicationDescriptionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BaseAdditionalApplicationDescriptionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BaseAdditionalApplicationDescriptionFormInternal(BaseAdditionalApplicationDescriptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e9990234-5a19-4dd8-9cee-7ae3be8ed642");
        objectContext.AddToRawObjectList(viewModel._BaseAdditionalApplication);
        objectContext.ProcessRawObjects();
        var baseAdditionalApplication = (BaseAdditionalApplication)objectContext.GetLoadedObject(viewModel._BaseAdditionalApplication.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseAdditionalApplication, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAdditionalApplication, formDefID);
        var transDef = baseAdditionalApplication.TransDef;
        PostScript_BaseAdditionalApplicationDescriptionForm(viewModel, baseAdditionalApplication, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseAdditionalApplication);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseAdditionalApplication);
        AfterContextSaveScript_BaseAdditionalApplicationDescriptionForm(viewModel, baseAdditionalApplication, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BaseAdditionalApplicationDescriptionForm(BaseAdditionalApplicationDescriptionFormViewModel viewModel, BaseAdditionalApplication baseAdditionalApplication, TTObjectContext objectContext);
    partial void PostScript_BaseAdditionalApplicationDescriptionForm(BaseAdditionalApplicationDescriptionFormViewModel viewModel, BaseAdditionalApplication baseAdditionalApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseAdditionalApplicationDescriptionForm(BaseAdditionalApplicationDescriptionFormViewModel viewModel, BaseAdditionalApplication baseAdditionalApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseAdditionalApplicationDescriptionFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BaseAdditionalApplicationDescriptionFormViewModel
    {
        public TTObjectClasses.BaseAdditionalApplication _BaseAdditionalApplication
        {
            get;
            set;
        }
    }
}
