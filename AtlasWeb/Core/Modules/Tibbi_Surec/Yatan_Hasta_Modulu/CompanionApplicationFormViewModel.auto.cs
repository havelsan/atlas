//$8E0FEF1F
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
    public partial class CompanionApplicationServiceController : Controller
{
    [HttpGet]
    public CompanionApplicationFormViewModel CompanionApplicationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CompanionApplicationFormLoadInternal(input);
    }

    [HttpPost]
    public CompanionApplicationFormViewModel CompanionApplicationFormLoad(FormLoadInput input)
    {
        return CompanionApplicationFormLoadInternal(input);
    }

    private CompanionApplicationFormViewModel CompanionApplicationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3449c4ef-580c-480e-b006-e07ff5e7cf67");
        var objectDefID = Guid.Parse("efd14cbb-fcf0-43b0-9750-ee202a104907");
        var viewModel = new CompanionApplicationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CompanionApplication = objectContext.GetObject(id.Value, objectDefID) as CompanionApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CompanionApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CompanionApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CompanionApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CompanionApplication);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_CompanionApplicationForm(viewModel, viewModel._CompanionApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CompanionApplication = new CompanionApplication(objectContext);
                var entryStateID = Guid.Parse("3d890ec5-141c-451b-88b9-180a46b6b56d");
                viewModel._CompanionApplication.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CompanionApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CompanionApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CompanionApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CompanionApplication);
                PreScript_CompanionApplicationForm(viewModel, viewModel._CompanionApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CompanionApplicationForm(CompanionApplicationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3449c4ef-580c-480e-b006-e07ff5e7cf67");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
            objectContext.AddToRawObjectList(viewModel.DietDefinitions);
            var entryStateID = Guid.Parse("3d890ec5-141c-451b-88b9-180a46b6b56d");
            objectContext.AddToRawObjectList(viewModel._CompanionApplication, entryStateID);
            objectContext.ProcessRawObjects(false);
            var companionApplication = (CompanionApplication)objectContext.GetLoadedObject(viewModel._CompanionApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(companionApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CompanionApplication, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(companionApplication);
            PostScript_CompanionApplicationForm(viewModel, companionApplication, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(companionApplication);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(companionApplication);
            AfterContextSaveScript_CompanionApplicationForm(viewModel, companionApplication, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_CompanionApplicationForm(CompanionApplicationFormViewModel viewModel, CompanionApplication companionApplication, TTObjectContext objectContext);
    partial void PostScript_CompanionApplicationForm(CompanionApplicationFormViewModel viewModel, CompanionApplication companionApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CompanionApplicationForm(CompanionApplicationFormViewModel viewModel, CompanionApplication companionApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CompanionApplicationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.DietDefinitions = objectContext.LocalQuery<DietDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DietListDefinition", viewModel.DietDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class CompanionApplicationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.CompanionApplication _CompanionApplication { get; set; }
        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets { get; set; }
        public TTObjectClasses.DietDefinition[] DietDefinitions { get; set; }
    }
}
