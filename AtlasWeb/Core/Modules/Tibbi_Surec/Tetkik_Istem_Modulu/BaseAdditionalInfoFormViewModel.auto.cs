//$FB635B6F
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
    public partial class BaseAdditionalInfoFormServiceController : Controller
{
    [HttpGet]
    public BaseAdditionalInfoFormViewModel BaseAdditionalInfoForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseAdditionalInfoFormLoadInternal(input);
    }

    [HttpPost]
    public BaseAdditionalInfoFormViewModel BaseAdditionalInfoFormLoad(FormLoadInput input)
    {
        return BaseAdditionalInfoFormLoadInternal(input);
    }

    private BaseAdditionalInfoFormViewModel BaseAdditionalInfoFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("578489ff-db6f-4cda-bdaf-96259590c593");
        var objectDefID = Guid.Parse("19f8c7c0-a24f-43cb-b615-d846e0b3697a");
        var viewModel = new BaseAdditionalInfoFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseAdditionalInfo = objectContext.GetObject(id.Value, objectDefID) as BaseAdditionalInfo;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseAdditionalInfo, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAdditionalInfo, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseAdditionalInfo);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseAdditionalInfo);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseAdditionalInfo(viewModel, viewModel._BaseAdditionalInfo, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseAdditionalInfo = new BaseAdditionalInfo(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseAdditionalInfo, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAdditionalInfo, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseAdditionalInfo);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseAdditionalInfo);
                PreScript_BaseAdditionalInfo(viewModel, viewModel._BaseAdditionalInfo, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseAdditionalInfoForm(BaseAdditionalInfoFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BaseAdditionalInfoFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BaseAdditionalInfoFormInternal(BaseAdditionalInfoFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("578489ff-db6f-4cda-bdaf-96259590c593");
        objectContext.AddToRawObjectList(viewModel._BaseAdditionalInfo);
        objectContext.ProcessRawObjects();
        var baseAdditionalInfoForm = (BaseAdditionalInfo)objectContext.GetLoadedObject(viewModel._BaseAdditionalInfo.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseAdditionalInfoForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAdditionalInfo, formDefID);
        var transDef = baseAdditionalInfoForm.TransDef;
        PostScript_BaseAdditionalInfo(viewModel, baseAdditionalInfoForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseAdditionalInfoForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseAdditionalInfoForm);
        AfterContextSaveScript_BaseAdditionalInfoForm(viewModel, baseAdditionalInfoForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BaseAdditionalInfo(BaseAdditionalInfoFormViewModel viewModel, BaseAdditionalInfo baseAdditionalInfoForm, TTObjectContext objectContext);
    partial void PostScript_BaseAdditionalInfo(BaseAdditionalInfoFormViewModel viewModel, BaseAdditionalInfo baseAdditionalInfoForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseAdditionalInfoForm(BaseAdditionalInfoFormViewModel viewModel, BaseAdditionalInfo baseAdditionalInfoForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseAdditionalInfoFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BaseAdditionalInfoFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseAdditionalInfo _BaseAdditionalInfo { get; set; }
    }
}
