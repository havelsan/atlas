//$834C54FD
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
    public partial class PsychologyTestServiceController : Controller
{
    [HttpGet]
    public PsychologyTestRequestInfoFormViewModel PsychologyTestRequestInfoForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PsychologyTestRequestInfoFormLoadInternal(input);
    }

    [HttpPost]
    public PsychologyTestRequestInfoFormViewModel PsychologyTestRequestInfoFormLoad(FormLoadInput input)
    {
        return PsychologyTestRequestInfoFormLoadInternal(input);
    }

    private PsychologyTestRequestInfoFormViewModel PsychologyTestRequestInfoFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("128d0b01-aefe-4b0c-9ba5-88e6b0134fda");
        var objectDefID = Guid.Parse("cb823169-f7ce-49eb-bfff-bfe6c8b02593");
        var viewModel = new PsychologyTestRequestInfoFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologyTest = objectContext.GetObject(id.Value, objectDefID) as PsychologyTest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologyTest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyTest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PsychologyTest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PsychologyTest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PsychologyTestRequestInfoForm(viewModel, viewModel._PsychologyTest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PsychologyTestRequestInfoForm(PsychologyTestRequestInfoFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("128d0b01-aefe-4b0c-9ba5-88e6b0134fda");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.EpisodeActions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._PsychologyTest);
            objectContext.ProcessRawObjects();
            var psychologyTest = (PsychologyTest)objectContext.GetLoadedObject(viewModel._PsychologyTest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(psychologyTest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologyTest, formDefID);
            var transDef = psychologyTest.TransDef;
            PostScript_PsychologyTestRequestInfoForm(viewModel, psychologyTest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(psychologyTest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(psychologyTest);
            AfterContextSaveScript_PsychologyTestRequestInfoForm(viewModel, psychologyTest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PsychologyTestRequestInfoForm(PsychologyTestRequestInfoFormViewModel viewModel, PsychologyTest psychologyTest, TTObjectContext objectContext);
    partial void PostScript_PsychologyTestRequestInfoForm(PsychologyTestRequestInfoFormViewModel viewModel, PsychologyTest psychologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PsychologyTestRequestInfoForm(PsychologyTestRequestInfoFormViewModel viewModel, PsychologyTest psychologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PsychologyTestRequestInfoFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.EpisodeActions = objectContext.LocalQuery<EpisodeAction>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class PsychologyTestRequestInfoFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PsychologyTest _PsychologyTest { get; set; }
        public TTObjectClasses.EpisodeAction[] EpisodeActions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
