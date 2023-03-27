//$160D6B86
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
    public NuclearMedicinePreparationFormViewModel NuclearMedicinePreparationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicinePreparationFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicinePreparationFormViewModel NuclearMedicinePreparationFormLoad(FormLoadInput input)
    {
        return NuclearMedicinePreparationFormLoadInternal(input);
    }

    private NuclearMedicinePreparationFormViewModel NuclearMedicinePreparationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("b4797c05-985d-4613-ae56-a2545e4943c8");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicinePreparationFormViewModel();
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
                PreScript_NuclearMedicinePreparationForm(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicinePreparationForm(NuclearMedicinePreparationFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicinePreparationFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicinePreparationFormInternal(NuclearMedicinePreparationFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("b4797c05-985d-4613-ae56-a2545e4943c8");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.StockCards);
        objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.RadioPharmaceuticalUnitDefinitions);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel.GridNuclearMedicineMaterialGridList);
        objectContext.AddToRawObjectList(viewModel.GridRadPharmMaterialsGridList);
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

        if (viewModel.GridRadPharmMaterialsGridList != null)
        {
            foreach (var item in viewModel.GridRadPharmMaterialsGridList)
            {
                var radPharmMaterialsImported = (NucMedRadPharmMatGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)radPharmMaterialsImported).IsDeleted)
                    continue;
                radPharmMaterialsImported.NuclearMedicine = nuclearMedicine;
            }
        }

        var transDef = nuclearMedicine.TransDef;
        PostScript_NuclearMedicinePreparationForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicinePreparationForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicinePreparationForm(NuclearMedicinePreparationFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicinePreparationForm(NuclearMedicinePreparationFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicinePreparationForm(NuclearMedicinePreparationFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicinePreparationFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._NuclearMedicine.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.GridNuclearMedicineMaterialGridList = viewModel._NuclearMedicine.NucMedTreatmentMats.OfType<NucMedTreatmentMat>().ToArray();
        viewModel.GridRadPharmMaterialsGridList = viewModel._NuclearMedicine.RadPharmMaterials.OfType<NucMedRadPharmMatGrid>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.RadioPharmaceuticalUnitDefinitions = objectContext.LocalQuery<RadioPharmaceuticalUnitDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisDefinitionList", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NucMedPharmMatListDef", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadioPharmaceuticalUnitListDefinition", viewModel.RadioPharmaceuticalUnitDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicinePreparationFormViewModel
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

        public TTObjectClasses.NucMedRadPharmMatGrid[] GridRadPharmMaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
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

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
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
