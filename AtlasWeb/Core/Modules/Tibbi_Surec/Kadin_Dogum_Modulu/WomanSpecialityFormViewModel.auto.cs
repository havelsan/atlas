//$D553D7DF
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
    public partial class WomanSpecialityObjectServiceController : Controller
{
    [HttpGet]
    public WomanSpecialityFormViewModel WomanSpecialityForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return WomanSpecialityFormLoadInternal(input);
    }

    [HttpPost]
    public WomanSpecialityFormViewModel WomanSpecialityFormLoad(FormLoadInput input)
    {
        return WomanSpecialityFormLoadInternal(input);
    }

    private WomanSpecialityFormViewModel WomanSpecialityFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("33168094-9d46-498e-971b-d5e9c3c9a740");
        var objectDefID = Guid.Parse("b62d311a-65be-4ab9-9352-539628da7580");
        var viewModel = new WomanSpecialityFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._WomanSpecialityObject = objectContext.GetObject(id.Value, objectDefID) as WomanSpecialityObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._WomanSpecialityObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._WomanSpecialityObject);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_WomanSpecialityForm(viewModel, viewModel._WomanSpecialityObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._WomanSpecialityObject = new WomanSpecialityObject(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._WomanSpecialityObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._WomanSpecialityObject);
                PreScript_WomanSpecialityForm(viewModel, viewModel._WomanSpecialityObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel WomanSpecialityForm(WomanSpecialityFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return WomanSpecialityFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel WomanSpecialityFormInternal(WomanSpecialityFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("33168094-9d46-498e-971b-d5e9c3c9a740");
        objectContext.AddToRawObjectList(viewModel.Gynecologys);
        objectContext.AddToRawObjectList(viewModel.ReproductiveAbnormalityDefinitions);
        objectContext.AddToRawObjectList(viewModel._WomanSpecialityObject);
        objectContext.ProcessRawObjects();
        var womanSpecialityObject = (WomanSpecialityObject)objectContext.GetLoadedObject(viewModel._WomanSpecialityObject.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(womanSpecialityObject, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WomanSpecialityObject, formDefID);
        var transDef = womanSpecialityObject.TransDef;
        PostScript_WomanSpecialityForm(viewModel, womanSpecialityObject, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(womanSpecialityObject);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(womanSpecialityObject);
        AfterContextSaveScript_WomanSpecialityForm(viewModel, womanSpecialityObject, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_WomanSpecialityForm(WomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTObjectContext objectContext);
    partial void PostScript_WomanSpecialityForm(WomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_WomanSpecialityForm(WomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(WomanSpecialityFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Gynecologys = objectContext.LocalQuery<Gynecology>().ToArray();
        viewModel.ReproductiveAbnormalityDefinitions = objectContext.LocalQuery<ReproductiveAbnormalityDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ReproductiveAbnormalityList", viewModel.ReproductiveAbnormalityDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class WomanSpecialityFormViewModel : BaseViewModel
    {
        public TTObjectClasses.WomanSpecialityObject _WomanSpecialityObject { get; set; }
        public TTObjectClasses.Gynecology[] Gynecologys { get; set; }
        public TTObjectClasses.ReproductiveAbnormalityDefinition[] ReproductiveAbnormalityDefinitions { get; set; }
    }
}
