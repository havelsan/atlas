//$AAFA9523
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
    public partial class DirectMaterialSupplyActionServiceController : Controller
{
    [HttpGet]
    public BaseDirectMaterialSupplyFormViewModel BaseDirectMaterialSupplyForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseDirectMaterialSupplyFormLoadInternal(input);
    }

    [HttpPost]
    public BaseDirectMaterialSupplyFormViewModel BaseDirectMaterialSupplyFormLoad(FormLoadInput input)
    {
        return BaseDirectMaterialSupplyFormLoadInternal(input);
    }

    private BaseDirectMaterialSupplyFormViewModel BaseDirectMaterialSupplyFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("cab65462-1087-4817-8ba1-da66f4194ef3");
        var objectDefID = Guid.Parse("eb8545ad-b542-4489-8e4c-b903b5f0fe28");
        var viewModel = new BaseDirectMaterialSupplyFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DirectMaterialSupplyAction = objectContext.GetObject(id.Value, objectDefID) as DirectMaterialSupplyAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DirectMaterialSupplyAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DirectMaterialSupplyAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DirectMaterialSupplyAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DirectMaterialSupplyAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseDirectMaterialSupplyForm(viewModel, viewModel._DirectMaterialSupplyAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseDirectMaterialSupplyForm(BaseDirectMaterialSupplyFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("cab65462-1087-4817-8ba1-da66f4194ef3");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.TreatmentMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel._DirectMaterialSupplyAction);
            objectContext.ProcessRawObjects();
            var directMaterialSupplyAction = (DirectMaterialSupplyAction)objectContext.GetLoadedObject(viewModel._DirectMaterialSupplyAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(directMaterialSupplyAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DirectMaterialSupplyAction, formDefID);
            if (viewModel.TreatmentMaterialsGridList != null)
            {
                foreach (var item in viewModel.TreatmentMaterialsGridList)
                {
                    var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                        continue;
                    treatmentMaterialsImported.EpisodeAction = directMaterialSupplyAction;
                }
            }

            var transDef = directMaterialSupplyAction.TransDef;
            PostScript_BaseDirectMaterialSupplyForm(viewModel, directMaterialSupplyAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(directMaterialSupplyAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(directMaterialSupplyAction);
            AfterContextSaveScript_BaseDirectMaterialSupplyForm(viewModel, directMaterialSupplyAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseDirectMaterialSupplyForm(BaseDirectMaterialSupplyFormViewModel viewModel, DirectMaterialSupplyAction directMaterialSupplyAction, TTObjectContext objectContext);
    partial void PostScript_BaseDirectMaterialSupplyForm(BaseDirectMaterialSupplyFormViewModel viewModel, DirectMaterialSupplyAction directMaterialSupplyAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseDirectMaterialSupplyForm(BaseDirectMaterialSupplyFormViewModel viewModel, DirectMaterialSupplyAction directMaterialSupplyAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseDirectMaterialSupplyFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.TreatmentMaterialsGridList = viewModel._DirectMaterialSupplyAction.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PatientListDefinition", viewModel.Patients);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class BaseDirectMaterialSupplyFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DirectMaterialSupplyAction _DirectMaterialSupplyAction { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] TreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
    }
}
