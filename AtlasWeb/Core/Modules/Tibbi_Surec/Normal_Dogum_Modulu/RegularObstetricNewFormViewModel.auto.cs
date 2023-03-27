//$0E46A432
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
        public RegularObstetricNewFormViewModel RegularObstetricNewForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return RegularObstetricNewFormLoadInternal(input);
        }

        [HttpPost]
        public RegularObstetricNewFormViewModel RegularObstetricNewFormLoad(FormLoadInput input)
        {
            return RegularObstetricNewFormLoadInternal(input);
        }

        private RegularObstetricNewFormViewModel RegularObstetricNewFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("d4df4530-d256-464e-94d6-21bb70976739");
            var objectDefID = Guid.Parse("7191b311-5e58-4837-a6a8-818c9e666f0c");
            var viewModel = new RegularObstetricNewFormViewModel();
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
                    PreScript_RegularObstetricNewForm(viewModel, viewModel._RegularObstetric, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._RegularObstetric = new RegularObstetric(objectContext);
                    var entryStateID = Guid.Parse("c7dba6dd-d8be-473f-9566-9a43dbdc8690");
                    viewModel._RegularObstetric.CurrentStateDefID = entryStateID;
                    viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                    viewModel.GridManipulationsGridList = new TTObjectClasses.SubActionProcedure[]{};
                    viewModel.GridPersonnelGridList = new TTObjectClasses.RegularObstetricPersonel[]{};
                    viewModel.GridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
                    viewModel.IndicationReasonsGridList = new TTObjectClasses.IndicationReason[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RegularObstetric, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RegularObstetric, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._RegularObstetric);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._RegularObstetric);
                    PreScript_RegularObstetricNewForm(viewModel, viewModel._RegularObstetric, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel RegularObstetricNewForm(RegularObstetricNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return RegularObstetricNewFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel RegularObstetricNewFormInternal(RegularObstetricNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("d4df4530-d256-464e-94d6-21bb70976739");
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.Pregnancys);
            objectContext.AddToRawObjectList(viewModel.SKRSDogumunGerceklestigiYers);
            objectContext.AddToRawObjectList(viewModel.SKRSGebelikAraligis);
            objectContext.AddToRawObjectList(viewModel.SKRSGebelikSonucus);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.GridManipulationsGridList);
            objectContext.AddToRawObjectList(viewModel.GridPersonnelGridList);
            objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.PregnantInfo);
            objectContext.AddToRawObjectList(viewModel.IndicationReasonsGridList);
            objectContext.AddToRawObjectList(viewModel.SKRSEndikasyonNedenleri);

            var entryStateID = Guid.Parse("c7dba6dd-d8be-473f-9566-9a43dbdc8690");
            objectContext.AddToRawObjectList(viewModel._RegularObstetric, entryStateID);
            objectContext.ProcessRawObjects(false);
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

            if(viewModel.IndicationReasonsGridList != null)
            {
                foreach(var item in viewModel.IndicationReasonsGridList)
                {
                    var indicationReasonsImported = (IndicationReason)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)indicationReasonsImported).IsDeleted)
                        continue;
                    indicationReasonsImported.RegularObstetric = regularObstetric;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(regularObstetric);
            PostScript_RegularObstetricNewForm(viewModel, regularObstetric, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(regularObstetric);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(regularObstetric);
            AfterContextSaveScript_RegularObstetricNewForm(viewModel, regularObstetric, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_RegularObstetricNewForm(RegularObstetricNewFormViewModel viewModel, RegularObstetric regularObstetric, TTObjectContext objectContext);
        partial void PostScript_RegularObstetricNewForm(RegularObstetricNewFormViewModel viewModel, RegularObstetric regularObstetric, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_RegularObstetricNewForm(RegularObstetricNewFormViewModel viewModel, RegularObstetric regularObstetric, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(RegularObstetricNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            var episode = viewModel._RegularObstetric.Episode;
            if (episode != null)
            {
                viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
            }

            viewModel.GridManipulationsGridList = viewModel._RegularObstetric.SubactionProcedures.OfType<SubActionProcedure>().ToArray();
            viewModel.GridPersonnelGridList = viewModel._RegularObstetric.RegularObstetricPersonel.OfType<RegularObstetricPersonel>().ToArray();
            viewModel.GridTreatmentMaterialsGridList = viewModel._RegularObstetric.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
            viewModel.IndicationReasonsGridList = viewModel._RegularObstetric.IndicationReasons.OfType<IndicationReason>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.Pregnancys = objectContext.LocalQuery<Pregnancy>().ToArray();
            viewModel.SKRSDogumunGerceklestigiYers = objectContext.LocalQuery<SKRSDogumunGerceklestigiYer>().ToArray();
            viewModel.SKRSGebelikAraligis = objectContext.LocalQuery<SKRSGebelikAraligi>().ToArray();
            viewModel.SKRSGebelikSonucus = objectContext.LocalQuery<SKRSGebelikSonucu>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
            viewModel.SKRSEndikasyonNedenleri = objectContext.LocalQuery<SKRSEndikasyonNedenleri>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgreyDepartmentListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikAraligiList", viewModel.SKRSGebelikAraligis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikSonucuList", viewModel.SKRSGebelikSonucus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEndikasyonNedenleriList", viewModel.SKRSEndikasyonNedenleri);
        }
    }
}


namespace Core.Models
{
    public partial class RegularObstetricNewFormViewModel
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

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.Pregnancy[] Pregnancys
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDogumunGerceklestigiYer[] SKRSDogumunGerceklestigiYers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGebelikAraligi[] SKRSGebelikAraligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGebelikSonucu[] SKRSGebelikSonucus
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

        public TTObjectClasses.MalzemeTuru[] MalzemeTurus
        {
            get;
            set;
        }
        public TTObjectClasses.IndicationReason[] IndicationReasonsGridList
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSEndikasyonNedenleri[] SKRSEndikasyonNedenleri
        {
            get;
            set;
        }

    }
}
