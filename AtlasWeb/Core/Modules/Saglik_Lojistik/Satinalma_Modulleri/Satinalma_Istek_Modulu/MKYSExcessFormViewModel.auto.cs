//$5FCDCC6D
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
    public partial class SupplyRequestPoolDetailServiceController : Controller
{
    [HttpGet]
    public MKYSExcessFormViewModel MKYSExcessForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MKYSExcessFormLoadInternal(input);
    }

    [HttpPost]
    public MKYSExcessFormViewModel MKYSExcessFormLoad(FormLoadInput input)
    {
        return MKYSExcessFormLoadInternal(input);
    }

    private MKYSExcessFormViewModel MKYSExcessFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("f717ec20-e1a5-486c-ae06-ae2b3561ed3b");
        var objectDefID = Guid.Parse("6112708e-2d3d-4de7-9667-6ec115e65bc0");
        var viewModel = new MKYSExcessFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequestPoolDetail = objectContext.GetObject(id.Value, objectDefID) as SupplyRequestPoolDetail;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SupplyRequestPoolDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SupplyRequestPoolDetail);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MKYSExcessForm(viewModel, viewModel._SupplyRequestPoolDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequestPoolDetail = new SupplyRequestPoolDetail(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SupplyRequestPoolDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SupplyRequestPoolDetail);
                PreScript_MKYSExcessForm(viewModel, viewModel._SupplyRequestPoolDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MKYSExcessForm(MKYSExcessFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("f717ec20-e1a5-486c-ae06-ae2b3561ed3b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel._SupplyRequestPoolDetail);
            objectContext.ProcessRawObjects();
            var supplyRequestPoolDetail = (SupplyRequestPoolDetail)objectContext.GetLoadedObject(viewModel._SupplyRequestPoolDetail.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(supplyRequestPoolDetail, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
            var transDef = supplyRequestPoolDetail.TransDef;
            PostScript_MKYSExcessForm(viewModel, supplyRequestPoolDetail, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(supplyRequestPoolDetail);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(supplyRequestPoolDetail);
            AfterContextSaveScript_MKYSExcessForm(viewModel, supplyRequestPoolDetail, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MKYSExcessForm(MKYSExcessFormViewModel viewModel, SupplyRequestPoolDetail supplyRequestPoolDetail, TTObjectContext objectContext);
    partial void PostScript_MKYSExcessForm(MKYSExcessFormViewModel viewModel, SupplyRequestPoolDetail supplyRequestPoolDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MKYSExcessForm(MKYSExcessFormViewModel viewModel, SupplyRequestPoolDetail supplyRequestPoolDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MKYSExcessFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class MKYSExcessFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SupplyRequestPoolDetail _SupplyRequestPoolDetail { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
    }
}
