//$3BD5D0E3
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
    public partial class PathologyTestProcedureServiceController : Controller
{
    [HttpGet]
    public PathologyTestRequestInfoFormViewModel PathologyTestRequestInfoForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PathologyTestRequestInfoFormLoadInternal(input);
    }

    [HttpPost]
    public PathologyTestRequestInfoFormViewModel PathologyTestRequestInfoFormLoad(FormLoadInput input)
    {
        return PathologyTestRequestInfoFormLoadInternal(input);
    }

    private PathologyTestRequestInfoFormViewModel PathologyTestRequestInfoFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4875e36d-f4e2-4577-bfed-5a7d0b817f4d");
        var objectDefID = Guid.Parse("94193f80-81ec-4fb5-9342-dc1bf4fcd0cd");
        var viewModel = new PathologyTestRequestInfoFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyTestProcedure = objectContext.GetObject(id.Value, objectDefID) as PathologyTestProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyTestProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyTestProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PathologyTestProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PathologyTestProcedure);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PathologyTestRequestInfoForm(viewModel, viewModel._PathologyTestProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PathologyTestRequestInfoForm(PathologyTestRequestInfoFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4875e36d-f4e2-4577-bfed-5a7d0b817f4d");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._PathologyTestProcedure);
            objectContext.ProcessRawObjects();
            var pathologyTestProcedure = (PathologyTestProcedure)objectContext.GetLoadedObject(viewModel._PathologyTestProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyTestProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyTestProcedure, formDefID);
            var transDef = pathologyTestProcedure.TransDef;
            PostScript_PathologyTestRequestInfoForm(viewModel, pathologyTestProcedure, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyTestProcedure);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyTestProcedure);
            AfterContextSaveScript_PathologyTestRequestInfoForm(viewModel, pathologyTestProcedure, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PathologyTestRequestInfoForm(PathologyTestRequestInfoFormViewModel viewModel, PathologyTestProcedure pathologyTestProcedure, TTObjectContext objectContext);
    partial void PostScript_PathologyTestRequestInfoForm(PathologyTestRequestInfoFormViewModel viewModel, PathologyTestProcedure pathologyTestProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PathologyTestRequestInfoForm(PathologyTestRequestInfoFormViewModel viewModel, PathologyTestProcedure pathologyTestProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PathologyTestRequestInfoFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class PathologyTestRequestInfoFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PathologyTestProcedure _PathologyTestProcedure { get; set; }
    }
}
