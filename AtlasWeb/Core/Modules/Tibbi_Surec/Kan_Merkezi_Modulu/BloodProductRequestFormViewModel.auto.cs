//$F2732042
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
    public partial class BloodProductRequestServiceController : Controller
{
    [HttpGet]
    public BloodProductRequestFormViewModel BloodProductRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BloodProductRequestFormLoadInternal(input);
    }

    [HttpPost]
    public BloodProductRequestFormViewModel BloodProductRequestFormLoad(FormLoadInput input)
    {
        return BloodProductRequestFormLoadInternal(input);
    }

    private BloodProductRequestFormViewModel BloodProductRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4135fcc9-942b-47c3-8c52-c2071a4effcf");
        var objectDefID = Guid.Parse("335964a9-0a5a-4a7a-9b4e-e47097c0e13b");
        var viewModel = new BloodProductRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BloodProductRequest = objectContext.GetObject(id.Value, objectDefID) as BloodProductRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BloodProductRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodProductRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BloodProductRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BloodProductRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BloodProductRequestForm(viewModel, viewModel._BloodProductRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BloodProductRequest = new BloodProductRequest(objectContext);
                var entryStateID = Guid.Parse("91d194a3-3acf-4936-b176-751907af3522");
                viewModel._BloodProductRequest.CurrentStateDefID = entryStateID;
                viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                viewModel.ttgrid1GridList = new TTObjectClasses.BloodBankBloodProducts[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BloodProductRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodProductRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BloodProductRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BloodProductRequest);
                PreScript_BloodProductRequestForm(viewModel, viewModel._BloodProductRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BloodProductRequestForm(BloodProductRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4135fcc9-942b-47c3-8c52-c2071a4effcf");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
            var entryStateID = Guid.Parse("91d194a3-3acf-4936-b176-751907af3522");
            objectContext.AddToRawObjectList(viewModel._BloodProductRequest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var bloodProductRequest = (BloodProductRequest)objectContext.GetLoadedObject(viewModel._BloodProductRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bloodProductRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodProductRequest, formDefID);
            var episodeImported = bloodProductRequest.Episode;
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

            if (viewModel.ttgrid1GridList != null)
            {
                foreach (var item in viewModel.ttgrid1GridList)
                {
                    var bloodProductsImported = (BloodBankBloodProducts)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)bloodProductsImported).IsDeleted)
                        continue;
                    bloodProductsImported.BloodProductRequest = bloodProductRequest;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(bloodProductRequest);
            PostScript_BloodProductRequestForm(viewModel, bloodProductRequest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bloodProductRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bloodProductRequest);
            AfterContextSaveScript_BloodProductRequestForm(viewModel, bloodProductRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BloodProductRequestForm(BloodProductRequestFormViewModel viewModel, BloodProductRequest bloodProductRequest, TTObjectContext objectContext);
    partial void PostScript_BloodProductRequestForm(BloodProductRequestFormViewModel viewModel, BloodProductRequest bloodProductRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BloodProductRequestForm(BloodProductRequestFormViewModel viewModel, BloodProductRequest bloodProductRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BloodProductRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var episode = viewModel._BloodProductRequest.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.ttgrid1GridList = viewModel._BloodProductRequest.BloodProducts.OfType<BloodBankBloodProducts>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BloodBankBloodProductsList", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
    }
}
}


namespace Core.Models
{
    public partial class BloodProductRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BloodProductRequest _BloodProductRequest { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.BloodBankBloodProducts[] ttgrid1GridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
    }
}
