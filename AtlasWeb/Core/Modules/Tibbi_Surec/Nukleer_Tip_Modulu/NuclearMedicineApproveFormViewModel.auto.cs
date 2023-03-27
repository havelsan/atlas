//$B9E9F370
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
    public NuclearMedicineApproveFormViewModel NuclearMedicineApproveForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineApproveFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineApproveFormViewModel NuclearMedicineApproveFormLoad(FormLoadInput input)
    {
        return NuclearMedicineApproveFormLoadInternal(input);
    }

    private NuclearMedicineApproveFormViewModel NuclearMedicineApproveFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("625aff25-5c3f-44b5-ad71-a4861eb38ee1");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicineApproveFormViewModel();
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
                PreScript_NuclearMedicineApproveForm(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineApproveForm(NuclearMedicineApproveFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineApproveFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineApproveFormInternal(NuclearMedicineApproveFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("625aff25-5c3f-44b5-ad71-a4861eb38ee1");
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
        objectContext.AddToRawObjectList(viewModel.OzelDurums);
        objectContext.AddToRawObjectList(viewModel.RadioPharmaceuticalUnitDefinitions);
        objectContext.AddToRawObjectList(viewModel.DPADetailFirmPriceOffers);
        objectContext.AddToRawObjectList(viewModel.ProductDefinitions);
        objectContext.AddToRawObjectList(viewModel.DirectPurchaseActionDetails);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.Patients);
        objectContext.AddToRawObjectList(viewModel.GridNuclearMedicineMaterialGridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
        objectContext.AddToRawObjectList(viewModel.SurgeryDirectPurchaseGridsGridList);
        objectContext.AddToRawObjectList(viewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList);
        objectContext.AddToRawObjectList(viewModel.DirectPurchaseGridsGridList);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel._NuclearMedicine);
        objectContext.ProcessRawObjects();
        var nuclearMedicine = (NuclearMedicine)objectContext.GetLoadedObject(viewModel._NuclearMedicine.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nuclearMedicine, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
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

        if (viewModel.SurgeryDirectPurchaseGridsGridList != null)
        {
            foreach (var item in viewModel.SurgeryDirectPurchaseGridsGridList)
            {
                var nuclearMedicine_SurgeryDirectPurchaseGridsImported = (SurgeryDirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nuclearMedicine_SurgeryDirectPurchaseGridsImported).IsDeleted)
                    continue;
                nuclearMedicine_SurgeryDirectPurchaseGridsImported.EpisodeAction = nuclearMedicine;
            }
        }

        if (viewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList != null)
        {
            foreach (var item in viewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList)
            {
                var nuclearMedicine_RadyofarmasotikDirectPurchaseGridsImported = (RadyofarmasotikDirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nuclearMedicine_RadyofarmasotikDirectPurchaseGridsImported).IsDeleted)
                    continue;
                nuclearMedicine_RadyofarmasotikDirectPurchaseGridsImported.EpisodeAction = nuclearMedicine;
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

        var transDef = nuclearMedicine.TransDef;
        PostScript_NuclearMedicineApproveForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicineApproveForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineApproveForm(NuclearMedicineApproveFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineApproveForm(NuclearMedicineApproveFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineApproveForm(NuclearMedicineApproveFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineApproveFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridNuclearMedicineMaterialGridList = viewModel._NuclearMedicine.NucMedTreatmentMats.OfType<NucMedTreatmentMat>().ToArray();
        viewModel.ttgrid2GridList = viewModel._NuclearMedicine.RadPharmMaterials.OfType<NucMedRadPharmMatGrid>().ToArray();
        viewModel.SurgeryDirectPurchaseGridsGridList = viewModel._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids.OfType<SurgeryDirectPurchaseGrid>().ToArray();
        viewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList = viewModel._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.OfType<RadyofarmasotikDirectPurchaseGrid>().ToArray();
        viewModel.DirectPurchaseGridsGridList = viewModel._NuclearMedicine.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
        var episode = viewModel._NuclearMedicine.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.RadioPharmaceuticalUnitDefinitions = objectContext.LocalQuery<RadioPharmaceuticalUnitDefinition>().ToArray();
        viewModel.DPADetailFirmPriceOffers = objectContext.LocalQuery<DPADetailFirmPriceOffer>().ToArray();
        viewModel.ProductDefinitions = objectContext.LocalQuery<ProductDefinition>().ToArray();
        viewModel.DirectPurchaseActionDetails = objectContext.LocalQuery<DirectPurchaseActionDetail>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadioPharmaceuticalUnitListDefinition", viewModel.RadioPharmaceuticalUnitDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DirectPurchaseActionDetailList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadyofarmasotikDPADetaillList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisDefinitionList", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineApproveFormViewModel
    {
        public TTObjectClasses.NuclearMedicine _NuclearMedicine
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

        public TTObjectClasses.SurgeryDirectPurchaseGrid[] SurgeryDirectPurchaseGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadyofarmasotikDirectPurchaseGrid[] NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList
        {
            get;
            set;
        }
		
		
		public TTObjectClasses.DirectPurchaseGrid[] DirectPurchaseGridsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.MalzemeTuru[] MalzemeTurus
        {
            get;
            set;
        }

        public TTObjectClasses.OzelDurum[] OzelDurums
        {
            get;
            set;
        }

        public TTObjectClasses.RadioPharmaceuticalUnitDefinition[] RadioPharmaceuticalUnitDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.DPADetailFirmPriceOffer[] DPADetailFirmPriceOffers
        {
            get;
            set;
        }

        public TTObjectClasses.ProductDefinition[] ProductDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.DirectPurchaseActionDetail[] DirectPurchaseActionDetails
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

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }
    }
}
