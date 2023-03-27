//$6178969A
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
    public partial class DentalExaminationServiceController : Controller
{
    [HttpGet]
    public DentalExaminationFormViewModel DentalExaminationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DentalExaminationFormLoadInternal(input);
    }

    [HttpPost]
    public DentalExaminationFormViewModel DentalExaminationFormLoad(FormLoadInput input)
    {
        return DentalExaminationFormLoadInternal(input);
    }

    private DentalExaminationFormViewModel DentalExaminationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("06b801db-fb6a-4efc-b88f-3827acb4f622");
        var objectDefID = Guid.Parse("37809a1b-4c90-45b9-b475-ef4c985fb9e3");
        var viewModel = new DentalExaminationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalExamination = objectContext.GetObject(id.Value, objectDefID) as DentalExamination;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalExamination, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DentalExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DentalExamination);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DentalExaminationForm(viewModel, viewModel._DentalExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalExamination = new DentalExamination(objectContext);
                var entryStateID = Guid.Parse("f16d3763-079c-438b-8abc-2cbabb4b9fed");
                viewModel._DentalExamination.CurrentStateDefID = entryStateID;
                viewModel.SecDiagnosisGridGridList = new TTObjectClasses.BaseDentalEpisodeActionDiagnosisGrid[]{};
                viewModel.DentalProsthesisGridList = new TTObjectClasses.DentalProcedure[]{};
                viewModel.DentalConsultationGridList = new TTObjectClasses.DentalConsultationRequest[]{};
                viewModel.UsedMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
                viewModel.ttgrid3GridList = new TTObjectClasses.DentalExaminationSuggestedProsthesis[]{};
                viewModel.DiagnosisGridGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalExamination, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DentalExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DentalExamination);
                PreScript_DentalExaminationForm(viewModel, viewModel._DentalExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DentalExaminationForm(DentalExaminationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("06b801db-fb6a-4efc-b88f-3827acb4f622");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.ResPoliclinics);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
            objectContext.AddToRawObjectList(viewModel.DentalProsthesisDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            //objectContext.AddToRawObjectList(viewModel.SecDiagnosisGridGridList);
            objectContext.AddToRawObjectList(viewModel.DentalProsthesisGridList);
            objectContext.AddToRawObjectList(viewModel.DentalConsultationGridList);
            objectContext.AddToRawObjectList(viewModel.UsedMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.ttgrid3GridList);
            objectContext.AddToRawObjectList(viewModel.DiagnosisGridGridList);
            var entryStateID = Guid.Parse("f16d3763-079c-438b-8abc-2cbabb4b9fed");
            objectContext.AddToRawObjectList(viewModel._DentalExamination, entryStateID);
            objectContext.ProcessRawObjects(false);
            var dentalExamination = (DentalExamination)objectContext.GetLoadedObject(viewModel._DentalExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dentalExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalExamination, formDefID);
            if (viewModel.SecDiagnosisGridGridList != null)
            {
                foreach (var item in viewModel.SecDiagnosisGridGridList)
                {
                    var diagnosisImported = (BaseDentalEpisodeActionDiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.EpisodeAction = dentalExamination;
                }
            }

            if (viewModel.DentalProsthesisGridList != null)
            {
                foreach (var item in viewModel.DentalProsthesisGridList)
                {
                    var dentalProceduresImported = (DentalProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dentalProceduresImported).IsDeleted)
                        continue;
                    dentalProceduresImported.DentalExamination = dentalExamination;
                }
            }

            if (viewModel.DentalConsultationGridList != null)
            {
                foreach (var item in viewModel.DentalConsultationGridList)
                {
                    var dentalConsultationRequestImported = (DentalConsultationRequest)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dentalConsultationRequestImported).IsDeleted)
                        continue;
                    dentalConsultationRequestImported.DentalExamination = dentalExamination;
                }
            }

            if (viewModel.UsedMaterialsGridList != null)
            {
                foreach (var item in viewModel.UsedMaterialsGridList)
                {
                    var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)treatmentMaterialsImported).IsDeleted)
                        continue;
                    treatmentMaterialsImported.EpisodeAction = dentalExamination;
                }
            }

            if (viewModel.ttgrid3GridList != null)
            {
                foreach (var item in viewModel.ttgrid3GridList)
                {
                    var suggestedProsthesisImported = (DentalExaminationSuggestedProsthesis)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)suggestedProsthesisImported).IsDeleted)
                        continue;
                    suggestedProsthesisImported.DentalExamination = dentalExamination;
                }
            }

            var episodeImported = dentalExamination.Episode;
            if (episodeImported != null)
            {
                if (viewModel.DiagnosisGridGridList != null)
                {
                    foreach (var item in viewModel.DiagnosisGridGridList)
                    {
                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episodeImported;
                    }
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(dentalExamination);
            PostScript_DentalExaminationForm(viewModel, dentalExamination, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dentalExamination);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dentalExamination);
            AfterContextSaveScript_DentalExaminationForm(viewModel, dentalExamination, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DentalExaminationForm(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination, TTObjectContext objectContext);
    partial void PostScript_DentalExaminationForm(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DentalExaminationForm(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DentalExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SecDiagnosisGridGridList = viewModel._DentalExamination.Diagnosis.OfType<BaseDentalEpisodeActionDiagnosisGrid>().ToArray();
        viewModel.DentalProsthesisGridList = viewModel._DentalExamination.DentalProcedures.OfType<DentalProcedure>().ToArray();
        viewModel.DentalConsultationGridList = viewModel._DentalExamination.DentalConsultationRequest.OfType<DentalConsultationRequest>().ToArray();
        viewModel.UsedMaterialsGridList = viewModel._DentalExamination.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
        viewModel.ttgrid3GridList = viewModel._DentalExamination.SuggestedProsthesis.OfType<DentalExaminationSuggestedProsthesis>().ToArray();
        var episode = viewModel._DentalExamination.Episode;
        if (episode != null)
        {
            viewModel.DiagnosisGridGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.ResPoliclinics = objectContext.LocalQuery<ResPoliclinic>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.DentalProsthesisDefinitions = objectContext.LocalQuery<DentalProsthesisDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResPoliclinics);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DentalProsthesisListDefinition", viewModel.DentalProsthesisDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class DentalExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DentalExamination _DentalExamination { get; set; }
        public TTObjectClasses.BaseDentalEpisodeActionDiagnosisGrid[] SecDiagnosisGridGridList { get; set; }
        public TTObjectClasses.DentalProcedure[] DentalProsthesisGridList { get; set; }
        public TTObjectClasses.DentalConsultationRequest[] DentalConsultationGridList { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] UsedMaterialsGridList { get; set; }
        public TTObjectClasses.DentalExaminationSuggestedProsthesis[] ttgrid3GridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] DiagnosisGridGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.ResPoliclinic[] ResPoliclinics { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.MalzemeTuru[] MalzemeTurus { get; set; }
        public TTObjectClasses.DentalProsthesisDefinition[] DentalProsthesisDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
    }
}
