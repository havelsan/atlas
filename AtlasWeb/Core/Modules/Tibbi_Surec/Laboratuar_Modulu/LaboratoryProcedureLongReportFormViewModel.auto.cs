//$CE3FB4BF
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
    public partial class LaboratoryProcedureServiceController : Controller
{
    [HttpGet]
    public LaboratoryProcedureLongReportFormViewModel LaboratoryProcedureLongReportForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return LaboratoryProcedureLongReportFormLoadInternal(input);
    }

    [HttpPost]
    public LaboratoryProcedureLongReportFormViewModel LaboratoryProcedureLongReportFormLoad(FormLoadInput input)
    {
        return LaboratoryProcedureLongReportFormLoadInternal(input);
    }

    private LaboratoryProcedureLongReportFormViewModel LaboratoryProcedureLongReportFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1ffaeef4-e4b2-414c-8860-6d38a5778128");
        var objectDefID = Guid.Parse("f87eac33-a91e-4934-a010-edf6029d2d18");
        var viewModel = new LaboratoryProcedureLongReportFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LaboratoryProcedure = objectContext.GetObject(id.Value, objectDefID) as LaboratoryProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._LaboratoryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._LaboratoryProcedure);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_LaboratoryProcedureLongReportForm(viewModel, viewModel._LaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel LaboratoryProcedureLongReportForm(LaboratoryProcedureLongReportFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1ffaeef4-e4b2-414c-8860-6d38a5778128");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._LaboratoryProcedure);
            objectContext.ProcessRawObjects();
            var laboratoryProcedure = (LaboratoryProcedure)objectContext.GetLoadedObject(viewModel._LaboratoryProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(laboratoryProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
            var transDef = laboratoryProcedure.TransDef;
            PostScript_LaboratoryProcedureLongReportForm(viewModel, laboratoryProcedure, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(laboratoryProcedure);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(laboratoryProcedure);
            AfterContextSaveScript_LaboratoryProcedureLongReportForm(viewModel, laboratoryProcedure, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_LaboratoryProcedureLongReportForm(LaboratoryProcedureLongReportFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTObjectContext objectContext);
    partial void PostScript_LaboratoryProcedureLongReportForm(LaboratoryProcedureLongReportFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_LaboratoryProcedureLongReportForm(LaboratoryProcedureLongReportFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(LaboratoryProcedureLongReportFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class LaboratoryProcedureLongReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure { get; set; }
    }
}
