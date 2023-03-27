//$3A7CCB7E
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
    public partial class RegularObstetricServiceController : Controller
{
    [HttpGet]
    public RegularObstetricCesareanReqFormViewModel RegularObstetricCesareanReqForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return RegularObstetricCesareanReqFormLoadInternal(input);
    }

    [HttpPost]
    public RegularObstetricCesareanReqFormViewModel RegularObstetricCesareanReqFormLoad(FormLoadInput input)
    {
        return RegularObstetricCesareanReqFormLoadInternal(input);
    }

    private RegularObstetricCesareanReqFormViewModel RegularObstetricCesareanReqFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9d2e7867-bebb-4083-b4d1-a0795a78aa39");
        var objectDefID = Guid.Parse("7191b311-5e58-4837-a6a8-818c9e666f0c");
        var viewModel = new RegularObstetricCesareanReqFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RegularObstetric = objectContext.GetObject(id.Value, objectDefID) as RegularObstetric;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RegularObstetric, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RegularObstetric, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._RegularObstetric);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._RegularObstetric);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_RegularObstetricCesareanReqForm(viewModel, viewModel._RegularObstetric, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel RegularObstetricCesareanReqForm(RegularObstetricCesareanReqFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return RegularObstetricCesareanReqFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel RegularObstetricCesareanReqFormInternal(RegularObstetricCesareanReqFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9d2e7867-bebb-4083-b4d1-a0795a78aa39");
        objectContext.AddToRawObjectList(viewModel.Episodes);
        objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
        objectContext.AddToRawObjectList(viewModel.GridManipulationsGridList);
        objectContext.AddToRawObjectList(viewModel.GridPersonnelGridList);
        objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
        objectContext.AddToRawObjectList(viewModel._RegularObstetric);
        objectContext.ProcessRawObjects();
        var regularObstetric = (RegularObstetric)objectContext.GetLoadedObject(viewModel._RegularObstetric.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(regularObstetric, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RegularObstetric, formDefID);
        var episodeImported = regularObstetric.Episode;
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

        if (viewModel.GridManipulationsGridList != null)
        {
            foreach (var item in viewModel.GridManipulationsGridList)
            {
                var subactionProceduresImported = (SubActionProcedure)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)subactionProceduresImported).IsDeleted)
                    continue;
                subactionProceduresImported.EpisodeAction = regularObstetric;
            }
        }

        if (viewModel.GridPersonnelGridList != null)
        {
            foreach (var item in viewModel.GridPersonnelGridList)
            {
                var regularObstetricPersonelImported = (RegularObstetricPersonel)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)regularObstetricPersonelImported).IsDeleted)
                    continue;
                regularObstetricPersonelImported.RegularObstetric = regularObstetric;
            }
        }

        if (viewModel.GridTreatmentMaterialsGridList != null)
        {
            foreach (var item in viewModel.GridTreatmentMaterialsGridList)
            {
                var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                    continue;
                treatmentMaterialsImported.EpisodeAction = regularObstetric;
            }
        }

        var transDef = regularObstetric.TransDef;
        PostScript_RegularObstetricCesareanReqForm(viewModel, regularObstetric, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(regularObstetric);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(regularObstetric);
        AfterContextSaveScript_RegularObstetricCesareanReqForm(viewModel, regularObstetric, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_RegularObstetricCesareanReqForm(RegularObstetricCesareanReqFormViewModel viewModel, RegularObstetric regularObstetric, TTObjectContext objectContext);
    partial void PostScript_RegularObstetricCesareanReqForm(RegularObstetricCesareanReqFormViewModel viewModel, RegularObstetric regularObstetric, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_RegularObstetricCesareanReqForm(RegularObstetricCesareanReqFormViewModel viewModel, RegularObstetric regularObstetric, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(RegularObstetricCesareanReqFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._RegularObstetric.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.GridManipulationsGridList = viewModel._RegularObstetric.SubactionProcedures.OfType<SubActionProcedure>().ToArray();
        viewModel.GridPersonnelGridList = viewModel._RegularObstetric.RegularObstetricPersonel.OfType<RegularObstetricPersonel>().ToArray();
        viewModel.GridTreatmentMaterialsGridList = viewModel._RegularObstetric.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class RegularObstetricCesareanReqFormViewModel
    {
        public TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SubActionProcedure[] GridManipulationsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.RegularObstetricPersonel[] GridPersonnelGridList
        {
            get;
            set;
        }

        public TTObjectClasses.BaseTreatmentMaterial[] GridTreatmentMaterialsGridList
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

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}
