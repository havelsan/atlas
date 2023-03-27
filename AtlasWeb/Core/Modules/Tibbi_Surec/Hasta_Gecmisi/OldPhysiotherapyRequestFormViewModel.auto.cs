//$FEE79DDB
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
    public partial class PhysiotherapyRequestServiceController : Controller
{
    [HttpGet]
    public OldPhysiotherapyRequestFormViewModel OldPhysiotherapyRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldPhysiotherapyRequestFormLoadInternal(input);
    }

    [HttpPost]
    public OldPhysiotherapyRequestFormViewModel OldPhysiotherapyRequestFormLoad(FormLoadInput input)
    {
        return OldPhysiotherapyRequestFormLoadInternal(input);
    }

    private OldPhysiotherapyRequestFormViewModel OldPhysiotherapyRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1c2a27be-5d83-482e-aacc-f21d943900e8");
        var objectDefID = Guid.Parse("43225fba-1931-42a1-b745-23599ea82b65");
        var viewModel = new OldPhysiotherapyRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyRequest = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OldPhysiotherapyRequestForm(viewModel, viewModel._PhysiotherapyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OldPhysiotherapyRequestForm(OldPhysiotherapyRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1c2a27be-5d83-482e-aacc-f21d943900e8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyRequest);
            objectContext.ProcessRawObjects();
            var physiotherapyRequest = (PhysiotherapyRequest)objectContext.GetLoadedObject(viewModel._PhysiotherapyRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
            var transDef = physiotherapyRequest.TransDef;
            PostScript_OldPhysiotherapyRequestForm(viewModel, physiotherapyRequest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            retViewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyRequest);
            retViewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyRequest);
            AfterContextSaveScript_OldPhysiotherapyRequestForm(viewModel, physiotherapyRequest, transDef, objectContext);
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OldPhysiotherapyRequestForm(OldPhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext);
    partial void PostScript_OldPhysiotherapyRequestForm(OldPhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldPhysiotherapyRequestForm(OldPhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldPhysiotherapyRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class OldPhysiotherapyRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest { get; set; }
    }
}
