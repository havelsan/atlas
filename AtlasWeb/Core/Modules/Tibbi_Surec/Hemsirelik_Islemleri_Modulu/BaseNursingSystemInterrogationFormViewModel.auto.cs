//$F6D9A940
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
    public partial class BaseNursingSystemInterrogationServiceController : Controller
{
    [HttpGet]
    public BaseNursingSystemInterrogationFormViewModel BaseNursingSystemInterrogationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseNursingSystemInterrogationFormLoadInternal(input);
    }

    [HttpPost]
    public BaseNursingSystemInterrogationFormViewModel BaseNursingSystemInterrogationFormLoad(FormLoadInput input)
    {
        return BaseNursingSystemInterrogationFormLoadInternal(input);
    }

    private BaseNursingSystemInterrogationFormViewModel BaseNursingSystemInterrogationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a3c22a42-52ba-4ca2-85e8-2431fcab9d23");
        var objectDefID = Guid.Parse("95eef192-03d5-41c4-ba80-72f93b112296");
        var viewModel = new BaseNursingSystemInterrogationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingSystemInterrogation = objectContext.GetObject(id.Value, objectDefID) as BaseNursingSystemInterrogation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingSystemInterrogation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingSystemInterrogation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseNursingSystemInterrogation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseNursingSystemInterrogation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseNursingSystemInterrogationForm(viewModel, viewModel._BaseNursingSystemInterrogation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingSystemInterrogation = new BaseNursingSystemInterrogation(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._BaseNursingSystemInterrogation.CurrentStateDefID = entryStateID;
                viewModel.NursingSystemInterrogationsGridList = new TTObjectClasses.NursingSystemInterrogation[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingSystemInterrogation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingSystemInterrogation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseNursingSystemInterrogation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseNursingSystemInterrogation);
                PreScript_BaseNursingSystemInterrogationForm(viewModel, viewModel._BaseNursingSystemInterrogation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseNursingSystemInterrogationForm(BaseNursingSystemInterrogationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a3c22a42-52ba-4ca2-85e8-2431fcab9d23");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SystemInterrogationDefinitions);
            objectContext.AddToRawObjectList(viewModel.NursingSystemInterrogationsGridList);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._BaseNursingSystemInterrogation, entryStateID);
            objectContext.ProcessRawObjects(false);
            var baseNursingSystemInterrogation = (BaseNursingSystemInterrogation)objectContext.GetLoadedObject(viewModel._BaseNursingSystemInterrogation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseNursingSystemInterrogation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingSystemInterrogation, formDefID);
            if (viewModel.NursingSystemInterrogationsGridList != null)
            {
                foreach (var item in viewModel.NursingSystemInterrogationsGridList)
                {
                    var nursingSystemInterrogationsImported = (NursingSystemInterrogation)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)nursingSystemInterrogationsImported).IsDeleted)
                        continue;
                    nursingSystemInterrogationsImported.BaseNursSysInterrogation = baseNursingSystemInterrogation;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(baseNursingSystemInterrogation);
            PostScript_BaseNursingSystemInterrogationForm(viewModel, baseNursingSystemInterrogation, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseNursingSystemInterrogation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseNursingSystemInterrogation);
            AfterContextSaveScript_BaseNursingSystemInterrogationForm(viewModel, baseNursingSystemInterrogation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseNursingSystemInterrogationForm(BaseNursingSystemInterrogationFormViewModel viewModel, BaseNursingSystemInterrogation baseNursingSystemInterrogation, TTObjectContext objectContext);
    partial void PostScript_BaseNursingSystemInterrogationForm(BaseNursingSystemInterrogationFormViewModel viewModel, BaseNursingSystemInterrogation baseNursingSystemInterrogation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseNursingSystemInterrogationForm(BaseNursingSystemInterrogationFormViewModel viewModel, BaseNursingSystemInterrogation baseNursingSystemInterrogation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseNursingSystemInterrogationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingSystemInterrogationsGridList = viewModel._BaseNursingSystemInterrogation.NursingSystemInterrogations.OfType<NursingSystemInterrogation>().ToArray();
        viewModel.SystemInterrogationDefinitions = objectContext.LocalQuery<SystemInterrogationDefinition>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class BaseNursingSystemInterrogationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseNursingSystemInterrogation _BaseNursingSystemInterrogation { get; set; }
        public TTObjectClasses.NursingSystemInterrogation[] NursingSystemInterrogationsGridList { get; set; }
        public TTObjectClasses.SystemInterrogationDefinition[] SystemInterrogationDefinitions { get; set; }
    }
}
