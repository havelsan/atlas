//$C1FB456D
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
    public partial class PathologyPanicAlertServiceController : Controller
{
    [HttpGet]
    public PanicAlertFormViewModel PanicAlertForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PanicAlertFormLoadInternal(input);
    }

    [HttpPost]
    public PanicAlertFormViewModel PanicAlertFormLoad(FormLoadInput input)
    {
        return PanicAlertFormLoadInternal(input);
    }

    private PanicAlertFormViewModel PanicAlertFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("758ce303-ae0d-4d97-b388-6ca1106a0c4b");
        var objectDefID = Guid.Parse("65af8261-fbce-46e0-b3ad-387632b82659");
        var viewModel = new PanicAlertFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyPanicAlert = objectContext.GetObject(id.Value, objectDefID) as PathologyPanicAlert;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyPanicAlert, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyPanicAlert, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PathologyPanicAlert);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PathologyPanicAlert);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PanicAlertForm(viewModel, viewModel._PathologyPanicAlert, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PathologyPanicAlert = new PathologyPanicAlert(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PathologyPanicAlert, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyPanicAlert, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PathologyPanicAlert);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PathologyPanicAlert);
                PreScript_PanicAlertForm(viewModel, viewModel._PathologyPanicAlert, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PanicAlertForm(PanicAlertFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PanicAlertFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PanicAlertFormInternal(PanicAlertFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("758ce303-ae0d-4d97-b388-6ca1106a0c4b");
        objectContext.AddToRawObjectList(viewModel.PathologyPanicReasonDefs);
        objectContext.AddToRawObjectList(viewModel._PathologyPanicAlert);
        objectContext.ProcessRawObjects();
        var pathologyPanicAlert = (PathologyPanicAlert)objectContext.GetLoadedObject(viewModel._PathologyPanicAlert.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(pathologyPanicAlert, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PathologyPanicAlert, formDefID);
        var transDef = pathologyPanicAlert.TransDef;
        PostScript_PanicAlertForm(viewModel, pathologyPanicAlert, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(pathologyPanicAlert);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(pathologyPanicAlert);
        AfterContextSaveScript_PanicAlertForm(viewModel, pathologyPanicAlert, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PanicAlertForm(PanicAlertFormViewModel viewModel, PathologyPanicAlert pathologyPanicAlert, TTObjectContext objectContext);
    partial void PostScript_PanicAlertForm(PanicAlertFormViewModel viewModel, PathologyPanicAlert pathologyPanicAlert, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PanicAlertForm(PanicAlertFormViewModel viewModel, PathologyPanicAlert pathologyPanicAlert, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PanicAlertFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PathologyPanicReasonDefs = objectContext.LocalQuery<PathologyPanicReasonDef>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PathologyPanicListDef", viewModel.PathologyPanicReasonDefs);
    }
}
}


namespace Core.Models
{
    public partial class PanicAlertFormViewModel
    {
        public TTObjectClasses.PathologyPanicAlert _PathologyPanicAlert
        {
            get;
            set;
        }

        public TTObjectClasses.PathologyPanicReasonDef[] PathologyPanicReasonDefs
        {
            get;
            set;
        }
    }
}
