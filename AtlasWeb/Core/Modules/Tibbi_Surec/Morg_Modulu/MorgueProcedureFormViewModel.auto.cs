//$A0E01180
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
    public partial class MorgueServiceController : Controller
{
    [HttpGet]
    public MorgueProcedureFormViewModel MorgueProcedureForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MorgueProcedureFormLoadInternal(input);
    }

    [HttpPost]
    public MorgueProcedureFormViewModel MorgueProcedureFormLoad(FormLoadInput input)
    {
        return MorgueProcedureFormLoadInternal(input);
    }

    private MorgueProcedureFormViewModel MorgueProcedureFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9ecc3331-92de-4829-9c71-ee7e7fe0a6e2");
        var objectDefID = Guid.Parse("adeb7bb4-e9fb-49a1-9506-2731d759c54b");
        var viewModel = new MorgueProcedureFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Morgue = objectContext.GetObject(id.Value, objectDefID) as Morgue;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Morgue, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Morgue);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Morgue);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MorgueProcedureForm(viewModel, viewModel._Morgue, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MorgueProcedureForm(MorgueProcedureFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return MorgueProcedureFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel MorgueProcedureFormInternal(MorgueProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9ecc3331-92de-4829-9c71-ee7e7fe0a6e2");
        objectContext.AddToRawObjectList(viewModel.SKRSIlceKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
        objectContext.AddToRawObjectList(viewModel.CupboardDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.SKRSICDs);
        objectContext.AddToRawObjectList(viewModel.SKRSOlumNedeniTurus);
        objectContext.AddToRawObjectList(viewModel.SKRSYaralanmaninYeris);
        objectContext.AddToRawObjectList(viewModel.SKRSOlumYeris);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.MernisDeathReasonDefinitions);
        objectContext.AddToRawObjectList(viewModel.SKRSOlumSeklis);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.StockCards);
        objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.OzelDurums);
        objectContext.AddToRawObjectList(viewModel.DeathReasonDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel.MorgueDeathTypeGridList);
        objectContext.AddToRawObjectList(viewModel.MaterialsGridGridList);
        objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
        objectContext.AddToRawObjectList(viewModel._Morgue);
        objectContext.ProcessRawObjects();
        var morgue = (Morgue)objectContext.GetLoadedObject(viewModel._Morgue.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(morgue, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
        if (viewModel.DeathReasonDiagnosisGridList != null)
        {
            foreach (var item in viewModel.DeathReasonDiagnosisGridList)
            {
                var deathReasonDiagnosisImported = (DeathReasonDiagnosis)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)deathReasonDiagnosisImported).IsDeleted)
                    continue;
                deathReasonDiagnosisImported.Morgue = morgue;
            }
        }

        if (viewModel.MorgueDeathTypeGridList != null)
        {
            foreach (var item in viewModel.MorgueDeathTypeGridList)
            {
                var morgueDeathTypeImported = (MorgueDeathType)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)morgueDeathTypeImported).IsDeleted)
                    continue;
                morgueDeathTypeImported.Morgue = morgue;
            }
        }

        if (viewModel.MaterialsGridGridList != null)
        {
            foreach (var item in viewModel.MaterialsGridGridList)
            {
                var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                    continue;
                treatmentMaterialsImported.EpisodeAction = morgue;
            }
        }

        if (viewModel.GridTreatmentMaterialsGridList != null)
        {
            foreach (var item in viewModel.GridTreatmentMaterialsGridList)
            {
                var morgueTreatmentMaterialsImported = (MorgueTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)morgueTreatmentMaterialsImported).IsDeleted)
                    continue;
                morgueTreatmentMaterialsImported.EpisodeAction = morgue;
            }
        }

        var transDef = morgue.TransDef;
        PostScript_MorgueProcedureForm(viewModel, morgue, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(morgue);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(morgue);
        AfterContextSaveScript_MorgueProcedureForm(viewModel, morgue, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_MorgueProcedureForm(MorgueProcedureFormViewModel viewModel, Morgue morgue, TTObjectContext objectContext);
    partial void PostScript_MorgueProcedureForm(MorgueProcedureFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MorgueProcedureForm(MorgueProcedureFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MorgueProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DeathReasonDiagnosisGridList = viewModel._Morgue.DeathReasonDiagnosis.OfType<DeathReasonDiagnosis>().ToArray();
        viewModel.MorgueDeathTypeGridList = viewModel._Morgue.MorgueDeathType.OfType<MorgueDeathType>().ToArray();
        viewModel.MaterialsGridGridList = viewModel._Morgue.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.GridTreatmentMaterialsGridList = viewModel._Morgue.MorgueTreatmentMaterials.OfType<MorgueTreatmentMaterial>().ToArray();
        viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.CupboardDefinitions = objectContext.LocalQuery<CupboardDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSOlumNedeniTurus = objectContext.LocalQuery<SKRSOlumNedeniTuru>().ToArray();
        viewModel.SKRSYaralanmaninYeris = objectContext.LocalQuery<SKRSYaralanmaninYeri>().ToArray();
        viewModel.SKRSOlumYeris = objectContext.LocalQuery<SKRSOlumYeri>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.MernisDeathReasonDefinitions = objectContext.LocalQuery<MernisDeathReasonDefinition>().ToArray();
        viewModel.SKRSOlumSeklis = objectContext.LocalQuery<SKRSOlumSekli>().ToArray();
        viewModel.Morgues = objectContext.LocalQuery<Morgue>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlceKodlariList", viewModel.SKRSIlceKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.SKRSILKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CupboardListDefinition", viewModel.CupboardDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumNedeniTuruList", viewModel.SKRSOlumNedeniTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYaralanmaninYeriList", viewModel.SKRSYaralanmaninYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumYeriList", viewModel.SKRSOlumYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicNurseListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MernisDeathReasonDefinitionList", viewModel.MernisDeathReasonDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumSekliList", viewModel.SKRSOlumSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
    }
}
}


namespace Core.Models
{
    public partial class MorgueProcedureFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Morgue _Morgue { get; set; }
        public TTObjectClasses.DeathReasonDiagnosis[] DeathReasonDiagnosisGridList { get; set; }
        public TTObjectClasses.MorgueDeathType[] MorgueDeathTypeGridList { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] MaterialsGridGridList { get; set; }
        public TTObjectClasses.MorgueTreatmentMaterial[] GridTreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.SKRSIlceKodlari[] SKRSIlceKodlaris { get; set; }
        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris { get; set; }
        public TTObjectClasses.CupboardDefinition[] CupboardDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSICD[] SKRSICDs { get; set; }
        public TTObjectClasses.SKRSOlumNedeniTuru[] SKRSOlumNedeniTurus { get; set; }
        public TTObjectClasses.SKRSYaralanmaninYeri[] SKRSYaralanmaninYeris { get; set; }
        public TTObjectClasses.SKRSOlumYeri[] SKRSOlumYeris { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.MernisDeathReasonDefinition[] MernisDeathReasonDefinitions { get; set; }
        public TTObjectClasses.SKRSOlumSekli[] SKRSOlumSeklis { get; set; }
        public TTObjectClasses.Morgue[] Morgues { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
    }
}
