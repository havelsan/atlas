//$A39AF078
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
    public partial class AdvanceBackServiceController : Controller
{
    [HttpGet]
    public AdvanceBackFormViewModel AdvanceBackForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AdvanceBackFormLoadInternal(input);
    }

    [HttpPost]
    public AdvanceBackFormViewModel AdvanceBackFormLoad(FormLoadInput input)
    {
        return AdvanceBackFormLoadInternal(input);
    }

    private AdvanceBackFormViewModel AdvanceBackFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4cdc4fa0-f7ee-463a-9096-89485fde4153");
        var objectDefID = Guid.Parse("9e7b1902-56e4-4b30-8a6d-3587815a0492");
        var viewModel = new AdvanceBackFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AdvanceBack = objectContext.GetObject(id.Value, objectDefID) as AdvanceBack;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AdvanceBack, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AdvanceBack, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AdvanceBack);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AdvanceBack);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AdvanceBackForm(viewModel, viewModel._AdvanceBack, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AdvanceBack = new AdvanceBack(objectContext);
                var entryStateID = Guid.Parse("f548fd32-0c26-41d0-a6a9-ae40e1202033");
                viewModel._AdvanceBack.CurrentStateDefID = entryStateID;
                viewModel.GRIDAdvanceDetailGridList = new TTObjectClasses.AdvanceBackAdvanceDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AdvanceBack, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AdvanceBack, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AdvanceBack);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AdvanceBack);
                PreScript_AdvanceBackForm(viewModel, viewModel._AdvanceBack, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AdvanceBackForm(AdvanceBackFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4cdc4fa0-f7ee-463a-9096-89485fde4153");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.AdvanceBackDocuments);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.GRIDAdvanceDetailGridList);
            var entryStateID = Guid.Parse("f548fd32-0c26-41d0-a6a9-ae40e1202033");
            objectContext.AddToRawObjectList(viewModel._AdvanceBack, entryStateID);
            objectContext.ProcessRawObjects(false);
            var advanceBack = (AdvanceBack)objectContext.GetLoadedObject(viewModel._AdvanceBack.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(advanceBack, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AdvanceBack, formDefID);
            if (viewModel.GRIDAdvanceDetailGridList != null)
            {
                foreach (var item in viewModel.GRIDAdvanceDetailGridList)
                {
                    var advanceBackAdvanceDetailImported = (AdvanceBackAdvanceDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)advanceBackAdvanceDetailImported).IsDeleted)
                        continue;
                    advanceBackAdvanceDetailImported.AdvanceBack = advanceBack;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(advanceBack);
            PostScript_AdvanceBackForm(viewModel, advanceBack, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(advanceBack);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(advanceBack);
            AfterContextSaveScript_AdvanceBackForm(viewModel, advanceBack, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AdvanceBackForm(AdvanceBackFormViewModel viewModel, AdvanceBack advanceBack, TTObjectContext objectContext);
    partial void PostScript_AdvanceBackForm(AdvanceBackFormViewModel viewModel, AdvanceBack advanceBack, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AdvanceBackForm(AdvanceBackFormViewModel viewModel, AdvanceBack advanceBack, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AdvanceBackFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GRIDAdvanceDetailGridList = viewModel._AdvanceBack.AdvanceBackAdvanceDetail.OfType<AdvanceBackAdvanceDetail>().ToArray();
        viewModel.AdvanceBackDocuments = objectContext.LocalQuery<AdvanceBackDocument>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class AdvanceBackFormViewModel : BaseViewModel
    {
        public TTObjectClasses.AdvanceBack _AdvanceBack { get; set; }
        public TTObjectClasses.AdvanceBackAdvanceDetail[] GRIDAdvanceDetailGridList { get; set; }
        public TTObjectClasses.AdvanceBackDocument[] AdvanceBackDocuments { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
