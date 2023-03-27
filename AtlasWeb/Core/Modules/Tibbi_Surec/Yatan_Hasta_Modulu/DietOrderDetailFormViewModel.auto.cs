//$15E12116
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
    public partial class DietOrderDetailServiceController : Controller
{
    [HttpGet]
    public DietOrderDetailFormViewModel DietOrderDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DietOrderDetailFormLoadInternal(input);
    }

    [HttpPost]
    public DietOrderDetailFormViewModel DietOrderDetailFormLoad(FormLoadInput input)
    {
        return DietOrderDetailFormLoadInternal(input);
    }

    private DietOrderDetailFormViewModel DietOrderDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1bb5f3ac-48da-44d8-9b04-a77907d15085");
        var objectDefID = Guid.Parse("bb947e4d-9beb-4922-a408-8cf969dcffd7");
        var viewModel = new DietOrderDetailFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DietOrderDetail = objectContext.GetObject(id.Value, objectDefID) as DietOrderDetail;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DietOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DietOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DietOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DietOrderDetail);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DietOrderDetailForm(viewModel, viewModel._DietOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DietOrderDetail = new DietOrderDetail(objectContext);
                var entryStateID = Guid.Parse("37611801-c62d-434b-98d0-ed28e2f77ebb");
                viewModel._DietOrderDetail.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DietOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DietOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DietOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DietOrderDetail);
                PreScript_DietOrderDetailForm(viewModel, viewModel._DietOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DietOrderDetailForm(DietOrderDetailFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1bb5f3ac-48da-44d8-9b04-a77907d15085");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.MealTypess);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            var entryStateID = Guid.Parse("37611801-c62d-434b-98d0-ed28e2f77ebb");
            objectContext.AddToRawObjectList(viewModel._DietOrderDetail, entryStateID);
            objectContext.ProcessRawObjects(false);
            var dietOrderDetail = (DietOrderDetail)objectContext.GetLoadedObject(viewModel._DietOrderDetail.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dietOrderDetail, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DietOrderDetail, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(dietOrderDetail);
            PostScript_DietOrderDetailForm(viewModel, dietOrderDetail, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dietOrderDetail);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dietOrderDetail);
            AfterContextSaveScript_DietOrderDetailForm(viewModel, dietOrderDetail, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DietOrderDetailForm(DietOrderDetailFormViewModel viewModel, DietOrderDetail dietOrderDetail, TTObjectContext objectContext);
    partial void PostScript_DietOrderDetailForm(DietOrderDetailFormViewModel viewModel, DietOrderDetail dietOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DietOrderDetailForm(DietOrderDetailFormViewModel viewModel, DietOrderDetail dietOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DietOrderDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MealTypess = objectContext.LocalQuery<MealTypes>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DietDefinitionList", viewModel.ProcedureDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class DietOrderDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DietOrderDetail _DietOrderDetail { get; set; }
        public TTObjectClasses.MealTypes[] MealTypess { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
    }
}
