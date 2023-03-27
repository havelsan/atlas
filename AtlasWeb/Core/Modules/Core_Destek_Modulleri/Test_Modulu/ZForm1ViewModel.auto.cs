//$B19E5380
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
    public partial class ZDeneme1ServiceController : Controller
{
    [HttpGet]
    public ZForm1ViewModel ZForm1(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ZForm1LoadInternal(input);
    }

    [HttpPost]
    public ZForm1ViewModel ZForm1Load(FormLoadInput input)
    {
        return ZForm1LoadInternal(input);
    }

    private ZForm1ViewModel ZForm1LoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9b3e9e75-9a2c-43c4-bc5a-2dd9ba7f7ced");
        var objectDefID = Guid.Parse("73a70b9b-7b2d-42c0-ad21-2b6555e46011");
        var viewModel = new ZForm1ViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ZDeneme1 = objectContext.GetObject(id.Value, objectDefID) as ZDeneme1;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ZDeneme1, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ZDeneme1, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ZDeneme1);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ZDeneme1);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ZForm1(viewModel, viewModel._ZDeneme1, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ZDeneme1 = new ZDeneme1(objectContext);
                var entryStateID = Guid.Parse("d1b5c702-86ec-40c7-bb17-aaa545595a40");
                viewModel._ZDeneme1.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ZDeneme1, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ZDeneme1, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ZDeneme1);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ZDeneme1);
                PreScript_ZForm1(viewModel, viewModel._ZDeneme1, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ZForm1(ZForm1ViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ZForm1Internal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ZForm1Internal(ZForm1ViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9b3e9e75-9a2c-43c4-bc5a-2dd9ba7f7ced");
        objectContext.AddToRawObjectList(viewModel.Citys);
        var entryStateID = Guid.Parse("d1b5c702-86ec-40c7-bb17-aaa545595a40");
        objectContext.AddToRawObjectList(viewModel._ZDeneme1, entryStateID);
        objectContext.ProcessRawObjects(false);
        var zDeneme1 = (ZDeneme1)objectContext.GetLoadedObject(viewModel._ZDeneme1.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(zDeneme1, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ZDeneme1, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(zDeneme1);
        PostScript_ZForm1(viewModel, zDeneme1, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(zDeneme1);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(zDeneme1);
        AfterContextSaveScript_ZForm1(viewModel, zDeneme1, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ZForm1(ZForm1ViewModel viewModel, ZDeneme1 zDeneme1, TTObjectContext objectContext);
    partial void PostScript_ZForm1(ZForm1ViewModel viewModel, ZDeneme1 zDeneme1, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ZForm1(ZForm1ViewModel viewModel, ZDeneme1 zDeneme1, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ZForm1ViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Citys = objectContext.LocalQuery<City>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.Citys);
    }
}
}


namespace Core.Models
{
    public partial class ZForm1ViewModel
    {
        public TTObjectClasses.ZDeneme1 _ZDeneme1
        {
            get;
            set;
        }

        public TTObjectClasses.City[] Citys
        {
            get;
            set;
        }
    }
}
