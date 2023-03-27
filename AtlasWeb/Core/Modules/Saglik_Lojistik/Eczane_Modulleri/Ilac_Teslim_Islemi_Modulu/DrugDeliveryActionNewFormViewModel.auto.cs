//$FFF501F9
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
    public partial class DrugDeliveryActionServiceController : Controller
{
    [HttpGet]
    public DrugDeliveryActionNewFormViewModel DrugDeliveryActionNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DrugDeliveryActionNewFormLoadInternal(input);
    }

    [HttpPost]
    public DrugDeliveryActionNewFormViewModel DrugDeliveryActionNewFormLoad(FormLoadInput input)
    {
        return DrugDeliveryActionNewFormLoadInternal(input);
    }

    private DrugDeliveryActionNewFormViewModel DrugDeliveryActionNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("15140a8e-41f1-47c3-a659-eda969c15ca8");
        var objectDefID = Guid.Parse("c7182c9f-61c8-4d95-b1a9-81b3ffddbbbc");
        var viewModel = new DrugDeliveryActionNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugDeliveryAction = objectContext.GetObject(id.Value, objectDefID) as DrugDeliveryAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugDeliveryAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDeliveryAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DrugDeliveryAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DrugDeliveryAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DrugDeliveryActionNewForm(viewModel, viewModel._DrugDeliveryAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugDeliveryAction = new DrugDeliveryAction(objectContext);
                var entryStateID = Guid.Parse("df9a3cd6-b48f-4c47-a649-758b7d2ac65a");
                viewModel._DrugDeliveryAction.CurrentStateDefID = entryStateID;
                viewModel.DrugDeliveryActionDetailsGridList = new TTObjectClasses.DrugDeliveryActionDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugDeliveryAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDeliveryAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DrugDeliveryAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DrugDeliveryAction);
                PreScript_DrugDeliveryActionNewForm(viewModel, viewModel._DrugDeliveryAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DrugDeliveryActionNewForm(DrugDeliveryActionNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("15140a8e-41f1-47c3-a659-eda969c15ca8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.DrugDeliveryActionDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.DrugOrderDetails);
            var entryStateID = Guid.Parse("df9a3cd6-b48f-4c47-a649-758b7d2ac65a");
            objectContext.AddToRawObjectList(viewModel._DrugDeliveryAction, entryStateID);
            objectContext.ProcessRawObjects(false);
            var drugDeliveryAction = (DrugDeliveryAction)objectContext.GetLoadedObject(viewModel._DrugDeliveryAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugDeliveryAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDeliveryAction, formDefID);
            if (viewModel.DrugDeliveryActionDetailsGridList != null)
            {
                foreach (var item in viewModel.DrugDeliveryActionDetailsGridList)
                {
                    var drugDeliveryActionDetailsImported = (DrugDeliveryActionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugDeliveryActionDetailsImported).IsDeleted)
                        continue;
                    drugDeliveryActionDetailsImported.DrugDeliveryAction = drugDeliveryAction;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(drugDeliveryAction);
            PostScript_DrugDeliveryActionNewForm(viewModel, drugDeliveryAction, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(drugDeliveryAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(drugDeliveryAction);
            AfterContextSaveScript_DrugDeliveryActionNewForm(viewModel, drugDeliveryAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DrugDeliveryActionNewForm(DrugDeliveryActionNewFormViewModel viewModel, DrugDeliveryAction drugDeliveryAction, TTObjectContext objectContext);
    partial void PostScript_DrugDeliveryActionNewForm(DrugDeliveryActionNewFormViewModel viewModel, DrugDeliveryAction drugDeliveryAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DrugDeliveryActionNewForm(DrugDeliveryActionNewFormViewModel viewModel, DrugDeliveryAction drugDeliveryAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DrugDeliveryActionNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DrugDeliveryActionDetailsGridList = viewModel._DrugDeliveryAction.DrugDeliveryActionDetails.OfType<DrugDeliveryActionDetail>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class DrugDeliveryActionNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DrugDeliveryAction _DrugDeliveryAction { get; set; }
        public TTObjectClasses.DrugDeliveryActionDetail[] DrugDeliveryActionDetailsGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.DrugOrderDetail[] DrugOrderDetails { get; set; }
    }
}
