//$0545ED96
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
    public partial class NursingCareServiceController : Controller
{
    [HttpGet]
    public NursingCareMainFormViewModel NursingCareMainForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingCareMainFormLoadInternal(input);
    }

    [HttpPost]
    public NursingCareMainFormViewModel NursingCareMainFormLoad(FormLoadInput input)
    {
        return NursingCareMainFormLoadInternal(input);
    }

    private NursingCareMainFormViewModel NursingCareMainFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4562cfba-d59c-4159-9aae-fe9b62aa71e6");
        var objectDefID = Guid.Parse("49ccd696-fffa-476b-891e-317029907f41");
        var viewModel = new NursingCareMainFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingCare = objectContext.GetObject(id.Value, objectDefID) as NursingCare;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingCare, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingCare, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingCare);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingCare);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingCareMainForm(viewModel, viewModel._NursingCare, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingCare = new NursingCare(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingCare.CurrentStateDefID = entryStateID;
                viewModel.NursingCareGridsGridList = new TTObjectClasses.NursingCareGrid[]{};
                viewModel.NursingReasonGridsGridList = new TTObjectClasses.NursingReasonGrid[]{};
                viewModel.NursingTargetGridsGridList = new TTObjectClasses.NursingTargetGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingCare, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingCare, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingCare);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingCare);
                PreScript_NursingCareMainForm(viewModel, viewModel._NursingCare, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingCareMainForm(NursingCareMainFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingCareMainFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingCareMainFormInternal(NursingCareMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4562cfba-d59c-4159-9aae-fe9b62aa71e6");
        objectContext.AddToRawObjectList(viewModel.NursingProblemDefinitions);
        objectContext.AddToRawObjectList(viewModel.NursingCareDefinitions);
        objectContext.AddToRawObjectList(viewModel.NursingReasonDefinitions);
        objectContext.AddToRawObjectList(viewModel.NursingTargetDefinitions);
        objectContext.AddToRawObjectList(viewModel.NursingCareGridsGridList);
        objectContext.AddToRawObjectList(viewModel.NursingReasonGridsGridList);
        objectContext.AddToRawObjectList(viewModel.NursingTargetGridsGridList);
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingCare, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingCare = (NursingCare)objectContext.GetLoadedObject(viewModel._NursingCare.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingCare, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingCare, formDefID);
        if (viewModel.NursingCareGridsGridList != null)
        {
            foreach (var item in viewModel.NursingCareGridsGridList)
            {
                var nursingCareGridsImported = (NursingCareGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nursingCareGridsImported).IsDeleted)
                    continue;
                nursingCareGridsImported.NursingNanda = nursingCare;
            }
        }

        if (viewModel.NursingReasonGridsGridList != null)
        {
            foreach (var item in viewModel.NursingReasonGridsGridList)
            {
                var nursingReasonGridsImported = (NursingReasonGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nursingReasonGridsImported).IsDeleted)
                    continue;
                nursingReasonGridsImported.NursingNanda = nursingCare;
            }
        }

        if (viewModel.NursingTargetGridsGridList != null)
        {
            foreach (var item in viewModel.NursingTargetGridsGridList)
            {
                var nursingTargetGridsImported = (NursingTargetGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nursingTargetGridsImported).IsDeleted)
                    continue;
                nursingTargetGridsImported.NursingNanda = nursingCare;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingCare);
        PostScript_NursingCareMainForm(viewModel, nursingCare, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingCare);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingCare);
        AfterContextSaveScript_NursingCareMainForm(viewModel, nursingCare, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingCareMainForm(NursingCareMainFormViewModel viewModel, NursingCare nursingCare, TTObjectContext objectContext);
    partial void PostScript_NursingCareMainForm(NursingCareMainFormViewModel viewModel, NursingCare nursingCare, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingCareMainForm(NursingCareMainFormViewModel viewModel, NursingCare nursingCare, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingCareMainFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingCareGridsGridList = viewModel._NursingCare.NursingCareGrids.OfType<NursingCareGrid>().ToArray();
        viewModel.NursingReasonGridsGridList = viewModel._NursingCare.NursingReasonGrids.OfType<NursingReasonGrid>().ToArray();
        viewModel.NursingTargetGridsGridList = viewModel._NursingCare.NursingTargetGrids.OfType<NursingTargetGrid>().ToArray();
        viewModel.NursingProblemDefinitions = objectContext.LocalQuery<NursingProblemDefinition>().ToArray();
        viewModel.NursingCareDefinitions = objectContext.LocalQuery<NursingCareDefinition>().ToArray();
        viewModel.NursingReasonDefinitions = objectContext.LocalQuery<NursingReasonDefinition>().ToArray();
        viewModel.NursingTargetDefinitions = objectContext.LocalQuery<NursingTargetDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NursingProblemListDefinition", viewModel.NursingProblemDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NursingCareListDefinition", viewModel.NursingCareDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NursingReasonListDefinition", viewModel.NursingReasonDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NursingTargetListDefinition", viewModel.NursingTargetDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NursingCareMainFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingCare _NursingCare
        {
            get;
            set;
        }

        public TTObjectClasses.NursingCareGrid[] NursingCareGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.NursingReasonGrid[] NursingReasonGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.NursingTargetGrid[] NursingTargetGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.NursingProblemDefinition[] NursingProblemDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.NursingCareDefinition[] NursingCareDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.NursingReasonDefinition[] NursingReasonDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.NursingTargetDefinition[] NursingTargetDefinitions
        {
            get;
            set;
        }
    }
}

