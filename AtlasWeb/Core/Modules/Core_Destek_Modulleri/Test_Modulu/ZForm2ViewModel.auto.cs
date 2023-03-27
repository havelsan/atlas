//$E352E0BB
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
    public ZForm2ViewModel ZForm2(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ZForm2LoadInternal(input);
    }

    [HttpPost]
    public ZForm2ViewModel ZForm2Load(FormLoadInput input)
    {
        return ZForm2LoadInternal(input);
    }

    private ZForm2ViewModel ZForm2LoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d0896c9d-ecbb-4473-9ab7-722b9b47a879");
        var objectDefID = Guid.Parse("73a70b9b-7b2d-42c0-ad21-2b6555e46011");
        var viewModel = new ZForm2ViewModel();
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
                PreScript_ZForm2(viewModel, viewModel._ZDeneme1, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ZForm2(ZForm2ViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ZForm2Internal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ZForm2Internal(ZForm2ViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d0896c9d-ecbb-4473-9ab7-722b9b47a879");
        objectContext.AddToRawObjectList(viewModel.SKRSKanGrubus);
        objectContext.AddToRawObjectList(viewModel.Citys);
        objectContext.AddToRawObjectList(viewModel._ZDeneme1);
        objectContext.ProcessRawObjects();
        var zDeneme1 = (ZDeneme1)objectContext.GetLoadedObject(viewModel._ZDeneme1.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(zDeneme1, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ZDeneme1, formDefID);
        var transDef = zDeneme1.TransDef;
        PostScript_ZForm2(viewModel, zDeneme1, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(zDeneme1);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(zDeneme1);
        AfterContextSaveScript_ZForm2(viewModel, zDeneme1, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ZForm2(ZForm2ViewModel viewModel, ZDeneme1 zDeneme1, TTObjectContext objectContext);
    partial void PostScript_ZForm2(ZForm2ViewModel viewModel, ZDeneme1 zDeneme1, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ZForm2(ZForm2ViewModel viewModel, ZDeneme1 zDeneme1, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ZForm2ViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSKanGrubus = objectContext.LocalQuery<SKRSKanGrubu>().ToArray();
        viewModel.Citys = objectContext.LocalQuery<City>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKanGrubuList", viewModel.SKRSKanGrubus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.Citys);
    }
}
}


namespace Core.Models
{
    public partial class ZForm2ViewModel
    {
        public TTObjectClasses.ZDeneme1 _ZDeneme1
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKanGrubu[] SKRSKanGrubus
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
