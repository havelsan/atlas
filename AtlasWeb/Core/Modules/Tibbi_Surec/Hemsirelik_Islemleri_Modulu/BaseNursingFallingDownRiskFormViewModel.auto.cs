//$58AE592F
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
    public partial class BaseNursingFallingDownRiskServiceController : Controller
{
    [HttpGet]
    public BaseNursingFallingDownRiskFormViewModel BaseNursingFallingDownRiskForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseNursingFallingDownRiskFormLoadInternal(input);
    }

    [HttpPost]
    public BaseNursingFallingDownRiskFormViewModel BaseNursingFallingDownRiskFormLoad(FormLoadInput input)
    {
        return BaseNursingFallingDownRiskFormLoadInternal(input);
    }

    private BaseNursingFallingDownRiskFormViewModel BaseNursingFallingDownRiskFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("aee9e039-6a5c-46ce-a4e3-68901badb042");
        var objectDefID = Guid.Parse("e6fb768b-f8e9-47a2-afc5-a27177bd1ca0");
        var viewModel = new BaseNursingFallingDownRiskFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingFallingDownRisk = objectContext.GetObject(id.Value, objectDefID) as BaseNursingFallingDownRisk;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingFallingDownRisk, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingFallingDownRisk, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseNursingFallingDownRisk);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseNursingFallingDownRisk);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseNursingFallingDownRiskForm(viewModel, viewModel._BaseNursingFallingDownRisk, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingFallingDownRisk = new BaseNursingFallingDownRisk(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._BaseNursingFallingDownRisk.CurrentStateDefID = entryStateID;
                viewModel.NursingFallingDownRisksGridList = new TTObjectClasses.NursingFallingDownRisk[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingFallingDownRisk, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingFallingDownRisk, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseNursingFallingDownRisk);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseNursingFallingDownRisk);
                PreScript_BaseNursingFallingDownRiskForm(viewModel, viewModel._BaseNursingFallingDownRisk, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseNursingFallingDownRiskForm(BaseNursingFallingDownRiskFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("aee9e039-6a5c-46ce-a4e3-68901badb042");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.FallingDownRiskDefinitions);
            objectContext.AddToRawObjectList(viewModel.NursingFallingDownRisksGridList);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._BaseNursingFallingDownRisk, entryStateID);
            objectContext.ProcessRawObjects(false);
            var baseNursingFallingDownRisk = (BaseNursingFallingDownRisk)objectContext.GetLoadedObject(viewModel._BaseNursingFallingDownRisk.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseNursingFallingDownRisk, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingFallingDownRisk, formDefID);
            if (viewModel.NursingFallingDownRisksGridList != null)
            {
                foreach (var item in viewModel.NursingFallingDownRisksGridList)
                {
                    var nursingFallingDownRisksImported = (NursingFallingDownRisk)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)nursingFallingDownRisksImported).IsDeleted)
                        continue;
                    nursingFallingDownRisksImported.BaseNursingFallingDownRisk = baseNursingFallingDownRisk;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(baseNursingFallingDownRisk);
            PostScript_BaseNursingFallingDownRiskForm(viewModel, baseNursingFallingDownRisk, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseNursingFallingDownRisk);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseNursingFallingDownRisk);
            AfterContextSaveScript_BaseNursingFallingDownRiskForm(viewModel, baseNursingFallingDownRisk, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseNursingFallingDownRiskForm(BaseNursingFallingDownRiskFormViewModel viewModel, BaseNursingFallingDownRisk baseNursingFallingDownRisk, TTObjectContext objectContext);
    partial void PostScript_BaseNursingFallingDownRiskForm(BaseNursingFallingDownRiskFormViewModel viewModel, BaseNursingFallingDownRisk baseNursingFallingDownRisk, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseNursingFallingDownRiskForm(BaseNursingFallingDownRiskFormViewModel viewModel, BaseNursingFallingDownRisk baseNursingFallingDownRisk, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseNursingFallingDownRiskFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingFallingDownRisksGridList = viewModel._BaseNursingFallingDownRisk.NursingFallingDownRisks.OfType<NursingFallingDownRisk>().ToArray();
        viewModel.FallingDownRiskDefinitions = objectContext.LocalQuery<FallingDownRiskDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FallingDownRiskFactorListDefinition", viewModel.FallingDownRiskDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class BaseNursingFallingDownRiskFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseNursingFallingDownRisk _BaseNursingFallingDownRisk { get; set; }
        public TTObjectClasses.NursingFallingDownRisk[] NursingFallingDownRisksGridList { get; set; }
        public TTObjectClasses.FallingDownRiskDefinition[] FallingDownRiskDefinitions { get; set; }
    }
}
