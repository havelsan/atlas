//$750FB118
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
    public partial class MHRSYonetimServiceController : Controller
{
    [HttpGet]
    public MHRSYonetimFormViewModel MHRSYonetimForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MHRSYonetimFormLoadInternal(input);
    }

    [HttpPost]
    public MHRSYonetimFormViewModel MHRSYonetimFormLoad(FormLoadInput input)
    {
        return MHRSYonetimFormLoadInternal(input);
    }

    private MHRSYonetimFormViewModel MHRSYonetimFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9ea0ee2a-eb72-473b-a4f4-7bfcc0474284");
        var objectDefID = Guid.Parse("d4d54b71-36eb-4d3f-922b-d7b8df1c8d55");
        var viewModel = new MHRSYonetimFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MHRSYonetim = objectContext.GetObject(id.Value, objectDefID) as MHRSYonetim;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MHRSYonetim, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MHRSYonetim, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MHRSYonetim);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MHRSYonetim);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MHRSYonetimForm(viewModel, viewModel._MHRSYonetim, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MHRSYonetim = new MHRSYonetim(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MHRSYonetim, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MHRSYonetim, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MHRSYonetim);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MHRSYonetim);
                PreScript_MHRSYonetimForm(viewModel, viewModel._MHRSYonetim, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MHRSYonetimForm(MHRSYonetimFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9ea0ee2a-eb72-473b-a4f4-7bfcc0474284");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._MHRSYonetim);
            objectContext.ProcessRawObjects();
            var mHRSYonetim = (MHRSYonetim)objectContext.GetLoadedObject(viewModel._MHRSYonetim.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(mHRSYonetim, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MHRSYonetim, formDefID);
            var transDef = mHRSYonetim.TransDef;
            PostScript_MHRSYonetimForm(viewModel, mHRSYonetim, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(mHRSYonetim);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(mHRSYonetim);
            AfterContextSaveScript_MHRSYonetimForm(viewModel, mHRSYonetim, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MHRSYonetimForm(MHRSYonetimFormViewModel viewModel, MHRSYonetim mHRSYonetim, TTObjectContext objectContext);
    partial void PostScript_MHRSYonetimForm(MHRSYonetimFormViewModel viewModel, MHRSYonetim mHRSYonetim, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MHRSYonetimForm(MHRSYonetimFormViewModel viewModel, MHRSYonetim mHRSYonetim, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MHRSYonetimFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class MHRSYonetimFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MHRSYonetim _MHRSYonetim { get; set; }
    }
}
