//$E8E183AD
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
    public partial class BaseHCExaminationDynamicObjectServiceController : Controller
{
    [HttpGet]
    public BaseHCExaminationDynamicObjectFormViewModel BaseHCExaminationDynamicObjectForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseHCExaminationDynamicObjectFormLoadInternal(input);
    }

    [HttpPost]
    public BaseHCExaminationDynamicObjectFormViewModel BaseHCExaminationDynamicObjectFormLoad(FormLoadInput input)
    {
        return BaseHCExaminationDynamicObjectFormLoadInternal(input);
    }

    private BaseHCExaminationDynamicObjectFormViewModel BaseHCExaminationDynamicObjectFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("0cc5ea92-a21f-4a5c-8771-0b28729398ba");
        var objectDefID = Guid.Parse("7284136a-2f57-43c6-8f1c-c2b54ed3c75e");
        var viewModel = new BaseHCExaminationDynamicObjectFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseHCExaminationDynamicObject = objectContext.GetObject(id.Value, objectDefID) as BaseHCExaminationDynamicObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseHCExaminationDynamicObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseHCExaminationDynamicObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseHCExaminationDynamicObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseHCExaminationDynamicObject);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseHCExaminationDynamicObjectForm(viewModel, viewModel._BaseHCExaminationDynamicObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseHCExaminationDynamicObject = new BaseHCExaminationDynamicObject(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseHCExaminationDynamicObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseHCExaminationDynamicObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseHCExaminationDynamicObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseHCExaminationDynamicObject);
                PreScript_BaseHCExaminationDynamicObjectForm(viewModel, viewModel._BaseHCExaminationDynamicObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseHCExaminationDynamicObjectForm(BaseHCExaminationDynamicObjectFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BaseHCExaminationDynamicObjectFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BaseHCExaminationDynamicObjectFormInternal(BaseHCExaminationDynamicObjectFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("0cc5ea92-a21f-4a5c-8771-0b28729398ba");
        objectContext.AddToRawObjectList(viewModel._BaseHCExaminationDynamicObject);
        objectContext.ProcessRawObjects();
        var baseHCExaminationDynamicObject = (BaseHCExaminationDynamicObject)objectContext.GetLoadedObject(viewModel._BaseHCExaminationDynamicObject.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseHCExaminationDynamicObject, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseHCExaminationDynamicObject, formDefID);
        var transDef = baseHCExaminationDynamicObject.TransDef;
        PostScript_BaseHCExaminationDynamicObjectForm(viewModel, baseHCExaminationDynamicObject, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseHCExaminationDynamicObject);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseHCExaminationDynamicObject);
        AfterContextSaveScript_BaseHCExaminationDynamicObjectForm(viewModel, baseHCExaminationDynamicObject, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BaseHCExaminationDynamicObjectForm(BaseHCExaminationDynamicObjectFormViewModel viewModel, BaseHCExaminationDynamicObject baseHCExaminationDynamicObject, TTObjectContext objectContext);
    partial void PostScript_BaseHCExaminationDynamicObjectForm(BaseHCExaminationDynamicObjectFormViewModel viewModel, BaseHCExaminationDynamicObject baseHCExaminationDynamicObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseHCExaminationDynamicObjectForm(BaseHCExaminationDynamicObjectFormViewModel viewModel, BaseHCExaminationDynamicObject baseHCExaminationDynamicObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseHCExaminationDynamicObjectFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BaseHCExaminationDynamicObjectFormViewModel
    {
        public TTObjectClasses.BaseHCExaminationDynamicObject _BaseHCExaminationDynamicObject
        {
            get;
            set;
        }
    }
}
