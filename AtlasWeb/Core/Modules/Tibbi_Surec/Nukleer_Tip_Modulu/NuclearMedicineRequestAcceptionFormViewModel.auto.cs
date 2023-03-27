//$5C56A94E
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
    public NuclearMedicineRequestAcceptionFormViewModel NuclearMedicineRequestAcceptionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineRequestAcceptionFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineRequestAcceptionFormViewModel NuclearMedicineRequestAcceptionFormLoad(FormLoadInput input)
    {
        return NuclearMedicineRequestAcceptionFormLoadInternal(input);
    }

    private NuclearMedicineRequestAcceptionFormViewModel NuclearMedicineRequestAcceptionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4e7db74f-3622-4050-a5cf-8a1e5da69492");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicineRequestAcceptionFormViewModel();
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
                PreScript_NuclearMedicineRequestAcceptionForm(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineRequestAcceptionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineRequestAcceptionFormInternal(NuclearMedicineRequestAcceptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4e7db74f-3622-4050-a5cf-8a1e5da69492");
        objectContext.AddToRawObjectList(viewModel._NuclearMedicine);
        objectContext.AddToRawObjectList(viewModel.ResNuclearMedicineEquipments);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
        objectContext.AddToRawObjectList(viewModel.EpisodeActions);
        objectContext.AddToRawObjectList(viewModel.PackageDefinitions);
        objectContext.AddToRawObjectList(viewModel.SubActionProcedures);
        objectContext.AddToRawObjectList(viewModel.PatientMedulaHastaKabuls);
        objectContext.AddToRawObjectList(viewModel.SubEpisodes);
        objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.NuclearMedicineTestsGridList);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.ProcessRawObjects();
        var nuclearMedicine = (NuclearMedicine)objectContext.GetLoadedObject(viewModel._NuclearMedicine.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nuclearMedicine, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
        if (viewModel.NuclearMedicineTestsGridList != null)
        {
            foreach (var item in viewModel.NuclearMedicineTestsGridList)
            {
                var nuclearMedicineTestsImported = (NuclearMedicineTest)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)nuclearMedicineTestsImported).IsDeleted)
                    continue;
                nuclearMedicineTestsImported.NuclearMedicine = nuclearMedicine;
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
        PostScript_NuclearMedicineRequestAcceptionForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicineRequestAcceptionForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineRequestAcceptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NuclearMedicineTestsGridList = viewModel._NuclearMedicine.NuclearMedicineTests.OfType<NuclearMedicineTest>().ToArray();
        var episode = viewModel._NuclearMedicine.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ResNuclearMedicineEquipments = objectContext.LocalQuery<ResNuclearMedicineEquipment>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        viewModel.EpisodeActions = objectContext.LocalQuery<EpisodeAction>().ToArray();
        viewModel.PackageDefinitions = objectContext.LocalQuery<PackageDefinition>().ToArray();
        viewModel.SubActionProcedures = objectContext.LocalQuery<SubActionProcedure>().ToArray();
        viewModel.PatientMedulaHastaKabuls = objectContext.LocalQuery<PatientMedulaHastaKabul>().ToArray();
        viewModel.SubEpisodes = objectContext.LocalQuery<SubEpisode>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisDefinitionList", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineRequestAcceptionFormViewModel
    {
        public TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get;
            set;
        }

        public TTObjectClasses.NuclearMedicineTest[] NuclearMedicineTestsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResNuclearMedicineEquipment[] ResNuclearMedicineEquipments
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.EpisodeAction[] EpisodeActions
        {
            get;
            set;
        }

        public TTObjectClasses.PackageDefinition[] PackageDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SubActionProcedure[] SubActionProcedures
        {
            get;
            set;
        }

        public TTObjectClasses.PatientMedulaHastaKabul[] PatientMedulaHastaKabuls
        {
            get;
            set;
        }

        public TTObjectClasses.SubEpisode[] SubEpisodes
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }
    }
}
