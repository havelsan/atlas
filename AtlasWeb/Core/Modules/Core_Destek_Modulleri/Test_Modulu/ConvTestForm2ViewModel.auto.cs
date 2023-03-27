//$2DCFBB8F
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
    public ConvTestForm2ViewModel ConvTestForm2(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ConvTestForm2LoadInternal(input);
    }

    [HttpPost]
    public ConvTestForm2ViewModel ConvTestForm2Load(FormLoadInput input)
    {
        return ConvTestForm2LoadInternal(input);
    }

    private ConvTestForm2ViewModel ConvTestForm2LoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("70efd43b-7548-443e-a894-b6c6df4bd4a3");
        var objectDefID = Guid.Parse("c4269c07-0ccc-4b38-b3a8-5a0a458b8cbb");
        var viewModel = new ConvTestForm2ViewModel();
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
                PreScript_ConvTestForm2(viewModel, viewModel._ConvTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ConvTest = new ConvTest(objectContext);
                var entryStateID = Guid.Parse("4f2a01d9-69d5-4602-8943-4a9b9f41c86b");
                viewModel._ConvTest.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ConvTest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConvTest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ConvTest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ConvTest);
                PreScript_ConvTestForm2(viewModel, viewModel._ConvTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ConvTestForm2(ConvTestForm2ViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("70efd43b-7548-443e-a894-b6c6df4bd4a3");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Citys);
            var entryStateID = Guid.Parse("4f2a01d9-69d5-4602-8943-4a9b9f41c86b");
            objectContext.AddToRawObjectList(viewModel._ConvTest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var convTest = (ConvTest)objectContext.GetLoadedObject(viewModel._ConvTest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(convTest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConvTest, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(convTest);
            PostScript_ConvTestForm2(viewModel, convTest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(convTest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(convTest);
            AfterContextSaveScript_ConvTestForm2(viewModel, convTest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ConvTestForm2(ConvTestForm2ViewModel viewModel, ConvTest convTest, TTObjectContext objectContext);
    partial void PostScript_ConvTestForm2(ConvTestForm2ViewModel viewModel, ConvTest convTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ConvTestForm2(ConvTestForm2ViewModel viewModel, ConvTest convTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ConvTestForm2ViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Citys = objectContext.LocalQuery<City>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.Citys);
    }
}
}


namespace Core.Models
{
    public partial class ConvTestForm2ViewModel : BaseViewModel
    {
        public TTObjectClasses.ConvTest _ConvTest { get; set; }
        public TTObjectClasses.City[] Citys { get; set; }
    }
}
