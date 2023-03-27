//$09A9F831
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
    public partial class DietOrderServiceController : Controller
{
    [HttpGet]
    public DietOrderFormViewModel DietOrderForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DietOrderFormLoadInternal(input);
    }

    [HttpPost]
    public DietOrderFormViewModel DietOrderFormLoad(FormLoadInput input)
    {
        return DietOrderFormLoadInternal(input);
    }

    private DietOrderFormViewModel DietOrderFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("8ac69390-833a-4ca8-b6d3-2b34db05348e");
        var objectDefID = Guid.Parse("9bc877e0-1e3d-4953-8098-40ddb2255b90");
        var viewModel = new DietOrderFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DietOrder = objectContext.GetObject(id.Value, objectDefID) as DietOrder;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DietOrder, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DietOrder, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DietOrder);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DietOrder);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DietOrderForm(viewModel, viewModel._DietOrder, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DietOrder = new DietOrder(objectContext);
                var entryStateID = Guid.Parse("e8466bb5-62a3-49ee-81ab-a0e4112ccd53");
                viewModel._DietOrder.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DietOrder, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DietOrder, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DietOrder);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DietOrder);
                PreScript_DietOrderForm(viewModel, viewModel._DietOrder, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DietOrderForm(DietOrderFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("8ac69390-833a-4ca8-b6d3-2b34db05348e");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("e8466bb5-62a3-49ee-81ab-a0e4112ccd53");
            objectContext.AddToRawObjectList(viewModel._DietOrder, entryStateID);
            objectContext.ProcessRawObjects(false);
            var dietOrder = (DietOrder)objectContext.GetLoadedObject(viewModel._DietOrder.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dietOrder, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DietOrder, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(dietOrder);
            PostScript_DietOrderForm(viewModel, dietOrder, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dietOrder);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dietOrder);
            AfterContextSaveScript_DietOrderForm(viewModel, dietOrder, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DietOrderForm(DietOrderFormViewModel viewModel, DietOrder dietOrder, TTObjectContext objectContext);
    partial void PostScript_DietOrderForm(DietOrderFormViewModel viewModel, DietOrder dietOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DietOrderForm(DietOrderFormViewModel viewModel, DietOrder dietOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DietOrderFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class DietOrderFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DietOrder _DietOrder { get; set; }
    }
}
