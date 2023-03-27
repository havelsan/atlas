//$F9FD08A2
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
    public partial class NursingOrderDetailServiceController : Controller
{
    [HttpGet]
    public NursingOrderDetailFormViewModel NursingOrderDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingOrderDetailFormLoadInternal(input);
    }

    [HttpPost]
    public NursingOrderDetailFormViewModel NursingOrderDetailFormLoad(FormLoadInput input)
    {
        return NursingOrderDetailFormLoadInternal(input);
    }

    private NursingOrderDetailFormViewModel NursingOrderDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ffadb707-6870-4a6e-baaa-d43480f4c52a");
        var objectDefID = Guid.Parse("8c3337ca-5d28-4ae2-9b3c-51ae43cee8b7");
        var viewModel = new NursingOrderDetailFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingOrderDetail = objectContext.GetObject(id.Value, objectDefID) as NursingOrderDetail;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingOrderDetail);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingOrderDetailForm(viewModel, viewModel._NursingOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingOrderDetail = new NursingOrderDetail(objectContext);
                var entryStateID = Guid.Parse("95d0ea09-0398-42fc-ba11-45f2583520d3");
                viewModel._NursingOrderDetail.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingOrderDetail);
                PreScript_NursingOrderDetailForm(viewModel, viewModel._NursingOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingOrderDetailForm(NursingOrderDetailFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ffadb707-6870-4a6e-baaa-d43480f4c52a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.VitalSignAndNursingValueDefinitions);
            var entryStateID = Guid.Parse("95d0ea09-0398-42fc-ba11-45f2583520d3");
            objectContext.AddToRawObjectList(viewModel._NursingOrderDetail, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingOrderDetail = (NursingOrderDetail)objectContext.GetLoadedObject(viewModel._NursingOrderDetail.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingOrderDetail, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingOrderDetail, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingOrderDetail);
            PostScript_NursingOrderDetailForm(viewModel, nursingOrderDetail, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingOrderDetail);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingOrderDetail);
            AfterContextSaveScript_NursingOrderDetailForm(viewModel, nursingOrderDetail, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingOrderDetailForm(NursingOrderDetailFormViewModel viewModel, NursingOrderDetail nursingOrderDetail, TTObjectContext objectContext);
    partial void PostScript_NursingOrderDetailForm(NursingOrderDetailFormViewModel viewModel, NursingOrderDetail nursingOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingOrderDetailForm(NursingOrderDetailFormViewModel viewModel, NursingOrderDetail nursingOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingOrderDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.VitalSignAndNursingValueDefinitions = objectContext.LocalQuery<VitalSignAndNursingValueDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "VitalSignAndNursingListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "VitalSignAndNursingListValueDefinition", viewModel.VitalSignAndNursingValueDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NursingOrderDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingOrderDetail _NursingOrderDetail { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.VitalSignAndNursingValueDefinition[] VitalSignAndNursingValueDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
