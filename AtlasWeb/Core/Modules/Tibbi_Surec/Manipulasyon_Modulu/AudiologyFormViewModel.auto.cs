//$82F17865
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
    public partial class AudiologyObjectServiceController : Controller
{
    [HttpGet]
    public AudiologyFormViewModel AudiologyForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AudiologyFormLoadInternal(input);
    }

    [HttpPost]
    public AudiologyFormViewModel AudiologyFormLoad(FormLoadInput input)
    {
        return AudiologyFormLoadInternal(input);
    }

    private AudiologyFormViewModel AudiologyFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("96d83e11-74db-4bbb-8c91-1e89b816f027");
        var objectDefID = Guid.Parse("b7cbcd64-59b4-4ec4-ab05-921f9621de6a");
        var viewModel = new AudiologyFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AudiologyObject = objectContext.GetObject(id.Value, objectDefID) as AudiologyObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AudiologyObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AudiologyObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AudiologyObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AudiologyObject);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AudiologyForm(viewModel, viewModel._AudiologyObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AudiologyObject = new AudiologyObject(objectContext);
                viewModel.AudiologyDiagnosisGridList = new TTObjectClasses.AudiologyDiagnosis[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AudiologyObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AudiologyObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AudiologyObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AudiologyObject);
                PreScript_AudiologyForm(viewModel, viewModel._AudiologyObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AudiologyForm(AudiologyFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AudiologyFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AudiologyFormInternal(AudiologyFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("96d83e11-74db-4bbb-8c91-1e89b816f027");
        objectContext.AddToRawObjectList(viewModel.AudiologyDiagnosisDefs);
        objectContext.AddToRawObjectList(viewModel.AudiologyDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel._AudiologyObject);
        objectContext.ProcessRawObjects();
        var audiologyObject = (AudiologyObject)objectContext.GetLoadedObject(viewModel._AudiologyObject.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(audiologyObject, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AudiologyObject, formDefID);
        if (viewModel.AudiologyDiagnosisGridList != null)
        {
            foreach (var item in viewModel.AudiologyDiagnosisGridList)
            {
                var audiologyDiagnosisImported = (AudiologyDiagnosis)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)audiologyDiagnosisImported).IsDeleted)
                    continue;
                audiologyDiagnosisImported.AudiologyObject = audiologyObject;
            }
        }

        var transDef = audiologyObject.TransDef;
        PostScript_AudiologyForm(viewModel, audiologyObject, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(audiologyObject);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(audiologyObject);
        AfterContextSaveScript_AudiologyForm(viewModel, audiologyObject, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AudiologyForm(AudiologyFormViewModel viewModel, AudiologyObject audiologyObject, TTObjectContext objectContext);
    partial void PostScript_AudiologyForm(AudiologyFormViewModel viewModel, AudiologyObject audiologyObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AudiologyForm(AudiologyFormViewModel viewModel, AudiologyObject audiologyObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AudiologyFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.AudiologyDiagnosisGridList = viewModel._AudiologyObject.AudiologyDiagnosis.OfType<AudiologyDiagnosis>().ToArray();
        viewModel.AudiologyDiagnosisDefs = objectContext.LocalQuery<AudiologyDiagnosisDef>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AudiologyDiagnosisDefList", viewModel.AudiologyDiagnosisDefs);
    }
}
}


namespace Core.Models
{
    public partial class AudiologyFormViewModel
    {
        public TTObjectClasses.AudiologyObject _AudiologyObject
        {
            get;
            set;
        }

        public TTObjectClasses.AudiologyDiagnosis[] AudiologyDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.AudiologyDiagnosisDef[] AudiologyDiagnosisDefs
        {
            get;
            set;
        }
    }
}
