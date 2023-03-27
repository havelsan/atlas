//$5C83F230
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
    public LaboratoryProcedureDetailFormViewModel LaboratoryProcedureDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return LaboratoryProcedureDetailFormLoadInternal(input);
    }

    [HttpPost]
    public LaboratoryProcedureDetailFormViewModel LaboratoryProcedureDetailFormLoad(FormLoadInput input)
    {
        return LaboratoryProcedureDetailFormLoadInternal(input);
    }

    private LaboratoryProcedureDetailFormViewModel LaboratoryProcedureDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("63811f5d-2b79-4ab1-af9e-221f9c43963c");
        var objectDefID = Guid.Parse("f87eac33-a91e-4934-a010-edf6029d2d18");
        var viewModel = new LaboratoryProcedureDetailFormViewModel();
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
                PreScript_LaboratoryProcedureDetailForm(viewModel, viewModel._LaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel LaboratoryProcedureDetailForm(LaboratoryProcedureDetailFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("63811f5d-2b79-4ab1-af9e-221f9c43963c");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.GridSubProceduresGridList);
            objectContext.AddToRawObjectList(viewModel._LaboratoryProcedure);
            objectContext.ProcessRawObjects();
            var laboratoryProcedure = (LaboratoryProcedure)objectContext.GetLoadedObject(viewModel._LaboratoryProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(laboratoryProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
            if (viewModel.GridSubProceduresGridList != null)
            {
                foreach (var item in viewModel.GridSubProceduresGridList)
                {
                    var laboratorySubProceduresImported = (LaboratorySubProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)laboratorySubProceduresImported).IsDeleted)
                        continue;
                    laboratorySubProceduresImported.LaboratoryProcedure = laboratoryProcedure;
                }
            }

            var transDef = laboratoryProcedure.TransDef;
            PostScript_LaboratoryProcedureDetailForm(viewModel, laboratoryProcedure, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(laboratoryProcedure);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(laboratoryProcedure);
            AfterContextSaveScript_LaboratoryProcedureDetailForm(viewModel, laboratoryProcedure, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_LaboratoryProcedureDetailForm(LaboratoryProcedureDetailFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTObjectContext objectContext);
    partial void PostScript_LaboratoryProcedureDetailForm(LaboratoryProcedureDetailFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_LaboratoryProcedureDetailForm(LaboratoryProcedureDetailFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(LaboratoryProcedureDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridSubProceduresGridList = viewModel._LaboratoryProcedure.LaboratorySubProcedures.OfType<LaboratorySubProcedure>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "LaboratoryTestListDefinition", viewModel.ProcedureDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class LaboratoryProcedureDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure { get; set; }
        public TTObjectClasses.LaboratorySubProcedure[] GridSubProceduresGridList { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
    }
}
