//$DD9D885B
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
    public partial class DentalLaboratoryProcedureServiceController : Controller
{
    [HttpGet]
    public DentalLaboratoryFormViewModel DentalLaboratoryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DentalLaboratoryFormLoadInternal(input);
    }

    [HttpPost]
    public DentalLaboratoryFormViewModel DentalLaboratoryFormLoad(FormLoadInput input)
    {
        return DentalLaboratoryFormLoadInternal(input);
    }

    private DentalLaboratoryFormViewModel DentalLaboratoryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3b427d3e-e2d5-4949-88c8-5c08014d1faa");
        var objectDefID = Guid.Parse("e0f27717-e6c9-4da8-93ad-19e783cf9922");
        var viewModel = new DentalLaboratoryFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalLaboratoryProcedure = objectContext.GetObject(id.Value, objectDefID) as DentalLaboratoryProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalLaboratoryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalLaboratoryProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DentalLaboratoryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DentalLaboratoryProcedure);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DentalLaboratoryForm(viewModel, viewModel._DentalLaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalLaboratoryProcedure = new DentalLaboratoryProcedure(objectContext);
                var entryStateID = Guid.Parse("ddb24399-916f-4b31-88fd-e62530b409f6");
                viewModel._DentalLaboratoryProcedure.CurrentStateDefID = entryStateID;
                viewModel.gridProceduresGridList = new TTObjectClasses.DentalExaminationSuggestedProsthesis[]{};
                viewModel.TreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalLaboratoryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalLaboratoryProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DentalLaboratoryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DentalLaboratoryProcedure);
                PreScript_DentalLaboratoryForm(viewModel, viewModel._DentalLaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DentalLaboratoryForm(DentalLaboratoryFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3b427d3e-e2d5-4949-88c8-5c08014d1faa");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DentalProsthesisDefinitions);
            objectContext.AddToRawObjectList(viewModel.Technicians);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.gridProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.TreatmentMaterialsGridList);
            var entryStateID = Guid.Parse("ddb24399-916f-4b31-88fd-e62530b409f6");
            objectContext.AddToRawObjectList(viewModel._DentalLaboratoryProcedure, entryStateID);
            objectContext.ProcessRawObjects(false);
            var dentalLaboratoryProcedure = (DentalLaboratoryProcedure)objectContext.GetLoadedObject(viewModel._DentalLaboratoryProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dentalLaboratoryProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalLaboratoryProcedure, formDefID);
            if (viewModel.gridProceduresGridList != null)
            {
                foreach (var item in viewModel.gridProceduresGridList)
                {
                    var suggestedProsthesisImported = (DentalExaminationSuggestedProsthesis)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)suggestedProsthesisImported).IsDeleted)
                        continue;
                    suggestedProsthesisImported.DentalLaboratoryProcedure = dentalLaboratoryProcedure;
                }
            }

            if (viewModel.TreatmentMaterialsGridList != null)
            {
                foreach (var item in viewModel.TreatmentMaterialsGridList)
                {
                    var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                        continue;
                    treatmentMaterialsImported.EpisodeAction = dentalLaboratoryProcedure;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(dentalLaboratoryProcedure);
            PostScript_DentalLaboratoryForm(viewModel, dentalLaboratoryProcedure, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dentalLaboratoryProcedure);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dentalLaboratoryProcedure);
            AfterContextSaveScript_DentalLaboratoryForm(viewModel, dentalLaboratoryProcedure, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DentalLaboratoryForm(DentalLaboratoryFormViewModel viewModel, DentalLaboratoryProcedure dentalLaboratoryProcedure, TTObjectContext objectContext);
    partial void PostScript_DentalLaboratoryForm(DentalLaboratoryFormViewModel viewModel, DentalLaboratoryProcedure dentalLaboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DentalLaboratoryForm(DentalLaboratoryFormViewModel viewModel, DentalLaboratoryProcedure dentalLaboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DentalLaboratoryFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.gridProceduresGridList = viewModel._DentalLaboratoryProcedure.SuggestedProsthesis.OfType<DentalExaminationSuggestedProsthesis>().ToArray();
        viewModel.TreatmentMaterialsGridList = viewModel._DentalLaboratoryProcedure.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.DentalProsthesisDefinitions = objectContext.LocalQuery<DentalProsthesisDefinition>().ToArray();
        viewModel.Technicians = objectContext.LocalQuery<Technician>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DentalProsthesisListDefinition", viewModel.DentalProsthesisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DentalTechnicianList", viewModel.Technicians);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class DentalLaboratoryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DentalLaboratoryProcedure _DentalLaboratoryProcedure { get; set; }
        public TTObjectClasses.DentalExaminationSuggestedProsthesis[] gridProceduresGridList { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] TreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.DentalProsthesisDefinition[] DentalProsthesisDefinitions { get; set; }
        public TTObjectClasses.Technician[] Technicians { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.MalzemeTuru[] MalzemeTurus { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
