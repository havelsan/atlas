//$8617AFC1
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
    public partial class PhysiotherapyRequestServiceController : Controller
{
    [HttpGet]
    public PhysiotherapyRequestPlannedFormViewModel PhysiotherapyRequestPlannedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PhysiotherapyRequestPlannedFormLoadInternal(input);
    }

    [HttpPost]
    public PhysiotherapyRequestPlannedFormViewModel PhysiotherapyRequestPlannedFormLoad(FormLoadInput input)
    {
        return PhysiotherapyRequestPlannedFormLoadInternal(input);
    }

    private PhysiotherapyRequestPlannedFormViewModel PhysiotherapyRequestPlannedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5625d46a-5cb4-4b8d-adaf-52b5093960e8");
        var objectDefID = Guid.Parse("43225fba-1931-42a1-b745-23599ea82b65");
        var viewModel = new PhysiotherapyRequestPlannedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyRequest = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PhysiotherapyRequestPlannedForm(viewModel, viewModel._PhysiotherapyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysiotherapyRequest = new PhysiotherapyRequest(objectContext);
                var entryStateID = Guid.Parse("ca426dd0-e1e8-48c1-bc3c-80e4244a366a");
                viewModel._PhysiotherapyRequest.CurrentStateDefID = entryStateID;
                viewModel.GridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysiotherapyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysiotherapyRequest);
                PreScript_PhysiotherapyRequestPlannedForm(viewModel, viewModel._PhysiotherapyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PhysiotherapyRequestPlannedForm(PhysiotherapyRequestPlannedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5625d46a-5cb4-4b8d-adaf-52b5093960e8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
            var entryStateID = Guid.Parse("ca426dd0-e1e8-48c1-bc3c-80e4244a366a");
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyRequest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var physiotherapyRequest = (PhysiotherapyRequest)objectContext.GetLoadedObject(viewModel._PhysiotherapyRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
            if (viewModel.GridTreatmentMaterialsGridList != null)
            {
                foreach (var item in viewModel.GridTreatmentMaterialsGridList)
                {
                    var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                        continue;
                    treatmentMaterialsImported.EpisodeAction = physiotherapyRequest;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(physiotherapyRequest);
            PostScript_PhysiotherapyRequestPlannedForm(viewModel, physiotherapyRequest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyRequest);
            AfterContextSaveScript_PhysiotherapyRequestPlannedForm(viewModel, physiotherapyRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PhysiotherapyRequestPlannedForm(PhysiotherapyRequestPlannedFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext);
    partial void PostScript_PhysiotherapyRequestPlannedForm(PhysiotherapyRequestPlannedFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PhysiotherapyRequestPlannedForm(PhysiotherapyRequestPlannedFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PhysiotherapyRequestPlannedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridTreatmentMaterialsGridList = viewModel._PhysiotherapyRequest.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
    }
}
}


namespace Core.Models
{
    public partial class PhysiotherapyRequestPlannedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] GridTreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
    }
}
