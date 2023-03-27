//$5BE69E1C
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
    public partial class ManipulationProcedureServiceController : Controller
{
    [HttpGet]
    public ManipulationProcedureRequestInfoViewModel ManipulationProcedureRequestInfo(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ManipulationProcedureRequestInfoLoadInternal(input);
    }

    [HttpPost]
    public ManipulationProcedureRequestInfoViewModel ManipulationProcedureRequestInfoLoad(FormLoadInput input)
    {
        return ManipulationProcedureRequestInfoLoadInternal(input);
    }

    private ManipulationProcedureRequestInfoViewModel ManipulationProcedureRequestInfoLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("58ca3137-c360-49fc-a4f2-a42dafbfe9f1");
        var objectDefID = Guid.Parse("31a0e057-d40a-495f-a6e4-2517543d0a20");
        var viewModel = new ManipulationProcedureRequestInfoViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManipulationProcedure = objectContext.GetObject(id.Value, objectDefID) as ManipulationProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManipulationProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ManipulationProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ManipulationProcedure);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ManipulationProcedureRequestInfo(viewModel, viewModel._ManipulationProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ManipulationProcedureRequestInfo(ManipulationProcedureRequestInfoViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ManipulationProcedureRequestInfoInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ManipulationProcedureRequestInfoInternal(ManipulationProcedureRequestInfoViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("58ca3137-c360-49fc-a4f2-a42dafbfe9f1");
        objectContext.AddToRawObjectList(viewModel._ManipulationProcedure);
        objectContext.ProcessRawObjects();
        var manipulationProcedure = (ManipulationProcedure)objectContext.GetLoadedObject(viewModel._ManipulationProcedure.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulationProcedure, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManipulationProcedure, formDefID);
        var transDef = manipulationProcedure.TransDef;
        PostScript_ManipulationProcedureRequestInfo(viewModel, manipulationProcedure, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manipulationProcedure);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manipulationProcedure);
        AfterContextSaveScript_ManipulationProcedureRequestInfo(viewModel, manipulationProcedure, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ManipulationProcedureRequestInfo(ManipulationProcedureRequestInfoViewModel viewModel, ManipulationProcedure manipulationProcedure, TTObjectContext objectContext);
    partial void PostScript_ManipulationProcedureRequestInfo(ManipulationProcedureRequestInfoViewModel viewModel, ManipulationProcedure manipulationProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ManipulationProcedureRequestInfo(ManipulationProcedureRequestInfoViewModel viewModel, ManipulationProcedure manipulationProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ManipulationProcedureRequestInfoViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class ManipulationProcedureRequestInfoViewModel
    {
        public TTObjectClasses.ManipulationProcedure _ManipulationProcedure
        {
            get;
            set;
        }
    }
}
