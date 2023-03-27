//$72173F10
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
    public partial class DrugDoseCompletionServiceController : Controller
{
    [HttpGet]
    public DrugDoseCompletionFormViewModel DrugDoseCompletionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DrugDoseCompletionFormLoadInternal(input);
    }

    [HttpPost]
    public DrugDoseCompletionFormViewModel DrugDoseCompletionFormLoad(FormLoadInput input)
    {
        return DrugDoseCompletionFormLoadInternal(input);
    }

    private DrugDoseCompletionFormViewModel DrugDoseCompletionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c56f5bd3-6a83-4b16-a4d8-dbf76319e5af");
        var objectDefID = Guid.Parse("b0c42c1e-c5c8-4b38-9471-48bddb4b0a30");
        var viewModel = new DrugDoseCompletionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugDoseCompletion = objectContext.GetObject(id.Value, objectDefID) as DrugDoseCompletion;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugDoseCompletion, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDoseCompletion, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DrugDoseCompletion);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DrugDoseCompletion);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DrugDoseCompletionForm(viewModel, viewModel._DrugDoseCompletion, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugDoseCompletion = new DrugDoseCompletion(objectContext);
                var entryStateID = Guid.Parse("15211637-18c2-4eb5-90e4-6aa9240a5b20");
                viewModel._DrugDoseCompletion.CurrentStateDefID = entryStateID;
                viewModel.DrugDoseCompletionDetailsGridList = new TTObjectClasses.DrugDoseCompletionDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugDoseCompletion, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDoseCompletion, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DrugDoseCompletion);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DrugDoseCompletion);
                PreScript_DrugDoseCompletionForm(viewModel, viewModel._DrugDoseCompletion, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DrugDoseCompletionForm(DrugDoseCompletionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DrugDoseCompletionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel DrugDoseCompletionFormInternal(DrugDoseCompletionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c56f5bd3-6a83-4b16-a4d8-dbf76319e5af");
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.Patients);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.DrugDoseCompletionDetailsGridList);
        var entryStateID = Guid.Parse("15211637-18c2-4eb5-90e4-6aa9240a5b20");
        objectContext.AddToRawObjectList(viewModel._DrugDoseCompletion, entryStateID);
        objectContext.ProcessRawObjects(false);
        var drugDoseCompletion = (DrugDoseCompletion)objectContext.GetLoadedObject(viewModel._DrugDoseCompletion.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugDoseCompletion, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDoseCompletion, formDefID);
        if (viewModel.DrugDoseCompletionDetailsGridList != null)
        {
            foreach (var item in viewModel.DrugDoseCompletionDetailsGridList)
            {
                var drugDoseCompletionDetailsImported = (DrugDoseCompletionDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)drugDoseCompletionDetailsImported).IsDeleted)
                    continue;
                drugDoseCompletionDetailsImported.DrugDoseCompletion = drugDoseCompletion;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(drugDoseCompletion);
        PostScript_DrugDoseCompletionForm(viewModel, drugDoseCompletion, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(drugDoseCompletion);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(drugDoseCompletion);
        AfterContextSaveScript_DrugDoseCompletionForm(viewModel, drugDoseCompletion, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DrugDoseCompletionForm(DrugDoseCompletionFormViewModel viewModel, DrugDoseCompletion drugDoseCompletion, TTObjectContext objectContext);
    partial void PostScript_DrugDoseCompletionForm(DrugDoseCompletionFormViewModel viewModel, DrugDoseCompletion drugDoseCompletion, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DrugDoseCompletionForm(DrugDoseCompletionFormViewModel viewModel, DrugDoseCompletion drugDoseCompletion, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DrugDoseCompletionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DrugDoseCompletionDetailsGridList = viewModel._DrugDoseCompletion.DrugDoseCompletionDetails.OfType<DrugDoseCompletionDetail>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class DrugDoseCompletionFormViewModel
    {
        public TTObjectClasses.DrugDoseCompletion _DrugDoseCompletion
        {
            get;
            set;
        }

        public TTObjectClasses.DrugDoseCompletionDetail[] DrugDoseCompletionDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}
