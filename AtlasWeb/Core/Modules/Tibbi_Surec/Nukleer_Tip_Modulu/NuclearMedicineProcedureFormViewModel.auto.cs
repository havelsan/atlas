//$F16FD139
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
    public partial class NuclearMedicineServiceController : Controller
{
    [HttpGet]
    public NuclearMedicineProcedureFormViewModel NuclearMedicineProcedureForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineProcedureFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineProcedureFormViewModel NuclearMedicineProcedureFormLoad(FormLoadInput input)
    {
        return NuclearMedicineProcedureFormLoadInternal(input);
    }

    private NuclearMedicineProcedureFormViewModel NuclearMedicineProcedureFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6f85dbe8-bbe9-4a5e-aeab-e44c8e841d67");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicineProcedureFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NuclearMedicine = objectContext.GetObject(id.Value, objectDefID) as NuclearMedicine;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NuclearMedicine, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NuclearMedicine);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NuclearMedicine);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NuclearMedicineProcedureForm(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineProcedureForm(NuclearMedicineProcedureFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineProcedureFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineProcedureFormInternal(NuclearMedicineProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6f85dbe8-bbe9-4a5e-aeab-e44c8e841d67");
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.RadioPharmaceuticalUnitDefinitions);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel.GridNuclearMedicineMaterialGridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
        objectContext.AddToRawObjectList(viewModel.DirectPurchaseGridsGridList);
        objectContext.AddToRawObjectList(viewModel._NuclearMedicine);
        objectContext.ProcessRawObjects();
        var nuclearMedicine = (NuclearMedicine)objectContext.GetLoadedObject(viewModel._NuclearMedicine.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nuclearMedicine, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
        var episodeImported = nuclearMedicine.Episode;
        if (episodeImported != null)
        {
            if (viewModel.GridEpisodeDiagnosisGridList != null)
            {
                foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                {
                    var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.Episode = episodeImported;
                }
            }
        }

        if (viewModel.GridNuclearMedicineMaterialGridList != null)
        {
            foreach (var item in viewModel.GridNuclearMedicineMaterialGridList)
            {
                var nucMedTreatmentMatsImported = (NucMedTreatmentMat)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nucMedTreatmentMatsImported).IsDeleted)
                    continue;
                nucMedTreatmentMatsImported.NuclearMedicine = nuclearMedicine;
            }
        }

        if (viewModel.ttgrid2GridList != null)
        {
            foreach (var item in viewModel.ttgrid2GridList)
            {
                var radPharmMaterialsImported = (NucMedRadPharmMatGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)radPharmMaterialsImported).IsDeleted)
                    continue;
                radPharmMaterialsImported.NuclearMedicine = nuclearMedicine;
            }
        }

        if (viewModel.DirectPurchaseGridsGridList != null)
        {
            foreach (var item in viewModel.DirectPurchaseGridsGridList)
            {
                var directPurchaseGridsImported = (DirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)directPurchaseGridsImported).IsDeleted)
                    continue;
                directPurchaseGridsImported.EpisodeAction = nuclearMedicine;
            }
        }

        var transDef = nuclearMedicine.TransDef;
        PostScript_NuclearMedicineProcedureForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicineProcedureForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineProcedureForm(NuclearMedicineProcedureFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineProcedureForm(NuclearMedicineProcedureFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineProcedureForm(NuclearMedicineProcedureFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._NuclearMedicine.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.GridNuclearMedicineMaterialGridList = viewModel._NuclearMedicine.NucMedTreatmentMats.OfType<NucMedTreatmentMat>().ToArray();
        viewModel.ttgrid2GridList = viewModel._NuclearMedicine.RadPharmMaterials.OfType<NucMedRadPharmMatGrid>().ToArray();
        viewModel.DirectPurchaseGridsGridList = viewModel._NuclearMedicine.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.RadioPharmaceuticalUnitDefinitions = objectContext.LocalQuery<RadioPharmaceuticalUnitDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisDefinitionList", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NucMedPharmMatListDef", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadioPharmaceuticalUnitListDefinition", viewModel.RadioPharmaceuticalUnitDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineProcedureFormViewModel
    {
        public TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.NucMedTreatmentMat[] GridNuclearMedicineMaterialGridList
        {
            get;
            set;
        }

        public TTObjectClasses.NucMedRadPharmMatGrid[] ttgrid2GridList
        {
            get;
            set;
        }
		
		public TTObjectClasses.DirectPurchaseGrid[] DirectPurchaseGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.RadioPharmaceuticalUnitDefinition[] RadioPharmaceuticalUnitDefinitions
        {
            get;
            set;
        }
    }
}
