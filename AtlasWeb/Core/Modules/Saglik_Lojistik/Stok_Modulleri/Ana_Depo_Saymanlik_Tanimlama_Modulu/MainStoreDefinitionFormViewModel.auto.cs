//$B8F077D0
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
    public partial class MainStoreDefinitionServiceController : Controller
{
    [HttpGet]
    public MainStoreDefinitionFormViewModel MainStoreDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MainStoreDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public MainStoreDefinitionFormViewModel MainStoreDefinitionFormLoad(FormLoadInput input)
    {
        return MainStoreDefinitionFormLoadInternal(input);
    }

    private MainStoreDefinitionFormViewModel MainStoreDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5a0e4bd0-ba57-4f61-ac61-6195e77bd885");
        var objectDefID = Guid.Parse("3958eb35-7eae-48e8-afe0-185d1faa29ea");
        var viewModel = new MainStoreDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MainStoreDefinition = objectContext.GetObject(id.Value, objectDefID) as MainStoreDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainStoreDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MainStoreDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MainStoreDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MainStoreDefinitionForm(viewModel, viewModel._MainStoreDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MainStoreDefinition = new MainStoreDefinition(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainStoreDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MainStoreDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MainStoreDefinition);
                PreScript_MainStoreDefinitionForm(viewModel, viewModel._MainStoreDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MainStoreDefinitionForm(MainStoreDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return MainStoreDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel MainStoreDefinitionFormInternal(MainStoreDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5a0e4bd0-ba57-4f61-ac61-6195e77bd885");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Accountancys);
        objectContext.AddToRawObjectList(viewModel._MainStoreDefinition);
        objectContext.ProcessRawObjects();
        var mainStoreDefinition = (MainStoreDefinition)objectContext.GetLoadedObject(viewModel._MainStoreDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(mainStoreDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreDefinition, formDefID);
        var transDef = mainStoreDefinition.TransDef;
        PostScript_MainStoreDefinitionForm(viewModel, mainStoreDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(mainStoreDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(mainStoreDefinition);
        AfterContextSaveScript_MainStoreDefinitionForm(viewModel, mainStoreDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_MainStoreDefinitionForm(MainStoreDefinitionFormViewModel viewModel, MainStoreDefinition mainStoreDefinition, TTObjectContext objectContext);
    partial void PostScript_MainStoreDefinitionForm(MainStoreDefinitionFormViewModel viewModel, MainStoreDefinition mainStoreDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MainStoreDefinitionForm(MainStoreDefinitionFormViewModel viewModel, MainStoreDefinition mainStoreDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MainStoreDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Accountancys = objectContext.LocalQuery<Accountancy>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountancyList", viewModel.Accountancys);
    }
}
}


namespace Core.Models
{
    public partial class MainStoreDefinitionFormViewModel
    {
        public TTObjectClasses.MainStoreDefinition _MainStoreDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.Accountancy[] Accountancys
        {
            get;
            set;
        }
    }
}
