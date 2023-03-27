//$8BDAD5F9
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
    public NuclearMedicineToDoctorFormViewModel NuclearMedicineToDoctorForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineToDoctorFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineToDoctorFormViewModel NuclearMedicineToDoctorFormLoad(FormLoadInput input)
    {
        return NuclearMedicineToDoctorFormLoadInternal(input);
    }

    private NuclearMedicineToDoctorFormViewModel NuclearMedicineToDoctorFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("69d2c518-8a0b-449b-8cec-05b01ca93148");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicineToDoctorFormViewModel();
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
                PreScript_NuclearMedicineToDoctorForm(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineToDoctorForm(NuclearMedicineToDoctorFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineToDoctorFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineToDoctorFormInternal(NuclearMedicineToDoctorFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("69d2c518-8a0b-449b-8cec-05b01ca93148");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.Patients);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
        objectContext.AddToRawObjectList(viewModel.OzelDurums);
        objectContext.AddToRawObjectList(viewModel.StockCards);
        objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.RadioPharmaceuticalUnitDefinitions);
        objectContext.AddToRawObjectList(viewModel.SagSols);
        objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
        objectContext.AddToRawObjectList(viewModel.DPADetailFirmPriceOffers);
        objectContext.AddToRawObjectList(viewModel.ProductDefinitions);
        objectContext.AddToRawObjectList(viewModel.DirectPurchaseActionDetails);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel.GridNuclearMedicineMaterialGridList);
        objectContext.AddToRawObjectList(viewModel.ttgrid2GridList);
        objectContext.AddToRawObjectList(viewModel.ttgridCokluOzelDurumGridList);
        objectContext.AddToRawObjectList(viewModel.SurgeryDirectPurchaseGridsGridList);
        objectContext.AddToRawObjectList(viewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList);
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

        if (viewModel.ttgridCokluOzelDurumGridList != null)
        {
            foreach (var item in viewModel.ttgridCokluOzelDurumGridList)
            {
                var cokluOzelDurumImported = (CokluOzelDurum)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)cokluOzelDurumImported).IsDeleted)
                    continue;
                cokluOzelDurumImported.NuclearMedicine = nuclearMedicine;
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

        var transDef = nuclearMedicine.TransDef;
        PostScript_NuclearMedicineToDoctorForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicineToDoctorForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineToDoctorForm(NuclearMedicineToDoctorFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineToDoctorForm(NuclearMedicineToDoctorFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineToDoctorForm(NuclearMedicineToDoctorFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineToDoctorFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._NuclearMedicine.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.GridNuclearMedicineMaterialGridList = viewModel._NuclearMedicine.NucMedTreatmentMats.OfType<NucMedTreatmentMat>().ToArray();
        viewModel.ttgrid2GridList = viewModel._NuclearMedicine.RadPharmMaterials.OfType<NucMedRadPharmMatGrid>().ToArray();
        viewModel.ttgridCokluOzelDurumGridList = viewModel._NuclearMedicine.CokluOzelDurum.OfType<CokluOzelDurum>().ToArray();
        viewModel.SurgeryDirectPurchaseGridsGridList = viewModel._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids.OfType<SurgeryDirectPurchaseGrid>().ToArray();
        viewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList = viewModel._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.OfType<RadyofarmasotikDirectPurchaseGrid>().ToArray();
        viewModel.DirectPurchaseGridsGridList = viewModel._NuclearMedicine.DirectPurchaseGrids.OfType<DirectPurchaseGrid>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.RadioPharmaceuticalUnitDefinitions = objectContext.LocalQuery<RadioPharmaceuticalUnitDefinition>().ToArray();
        viewModel.SagSols = objectContext.LocalQuery<SagSol>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        viewModel.DPADetailFirmPriceOffers = objectContext.LocalQuery<DPADetailFirmPriceOffer>().ToArray();
        viewModel.ProductDefinitions = objectContext.LocalQuery<ProductDefinition>().ToArray();
        viewModel.DirectPurchaseActionDetails = objectContext.LocalQuery<DirectPurchaseActionDetail>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisDefinitionList", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NucMedPharmMatListDef", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadioPharmaceuticalUnitListDefinition", viewModel.RadioPharmaceuticalUnitDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SagSolListDefinition", viewModel.SagSols);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DirectPurchaseActionDetailList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RadyofarmasotikDPADetaillList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineToDoctorFormViewModel
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

        public TTObjectClasses.CokluOzelDurum[] ttgridCokluOzelDurumGridList
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

        public TTObjectClasses.SagSol[] SagSols
        {
            get;
            set;
        }

        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis
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
    }
}
