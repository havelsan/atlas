//$44685053
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
    public partial class ConvTestServiceController : Controller
{
    [HttpGet]
    public ConvTestApprooveFormViewModel ConvTestApprooveForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ConvTestApprooveFormLoadInternal(input);
    }

    [HttpPost]
    public ConvTestApprooveFormViewModel ConvTestApprooveFormLoad(FormLoadInput input)
    {
        return ConvTestApprooveFormLoadInternal(input);
    }

    private ConvTestApprooveFormViewModel ConvTestApprooveFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("232d5832-0eab-413a-b47d-9ca87da7db0a");
        var objectDefID = Guid.Parse("c4269c07-0ccc-4b38-b3a8-5a0a458b8cbb");
        var viewModel = new ConvTestApprooveFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ConvTest = objectContext.GetObject(id.Value, objectDefID) as ConvTest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ConvTest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConvTest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ConvTest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ConvTest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ConvTestApprooveForm(viewModel, viewModel._ConvTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ConvTestApprooveForm(ConvTestApprooveFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("232d5832-0eab-413a-b47d-9ca87da7db0a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Citys);
            objectContext.AddToRawObjectList(viewModel._ConvTest);
            objectContext.ProcessRawObjects();
            var convTest = (ConvTest)objectContext.GetLoadedObject(viewModel._ConvTest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(convTest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConvTest, formDefID);
            var transDef = convTest.TransDef;
            PostScript_ConvTestApprooveForm(viewModel, convTest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(convTest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(convTest);
            AfterContextSaveScript_ConvTestApprooveForm(viewModel, convTest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ConvTestApprooveForm(ConvTestApprooveFormViewModel viewModel, ConvTest convTest, TTObjectContext objectContext);
    partial void PostScript_ConvTestApprooveForm(ConvTestApprooveFormViewModel viewModel, ConvTest convTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ConvTestApprooveForm(ConvTestApprooveFormViewModel viewModel, ConvTest convTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ConvTestApprooveFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Citys = objectContext.LocalQuery<City>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.Citys);
    }
}
}


namespace Core.Models
{
    public partial class ConvTestApprooveFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ConvTest _ConvTest { get; set; }
        public TTObjectClasses.City[] Citys { get; set; }
    }
}
