//$F764824B
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
    public partial class OrthesisProsthesisRequestServiceController : Controller
{
    [HttpGet]
    public OrthesisProsthesisRequestFormViewModel OrthesisProsthesisRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OrthesisProsthesisRequestFormLoadInternal(input);
    }

    [HttpPost]
    public OrthesisProsthesisRequestFormViewModel OrthesisProsthesisRequestFormLoad(FormLoadInput input)
    {
        return OrthesisProsthesisRequestFormLoadInternal(input);
    }

    private OrthesisProsthesisRequestFormViewModel OrthesisProsthesisRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e79ea6b9-86ce-4c7b-ad5f-b6dedd6a2b4a");
        var objectDefID = Guid.Parse("29f8be50-7930-426f-94f5-83536cc7a4c4");
        var viewModel = new OrthesisProsthesisRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OrthesisProsthesisRequest = objectContext.GetObject(id.Value, objectDefID) as OrthesisProsthesisRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._OrthesisProsthesisRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._OrthesisProsthesisRequest);
                PreScript_OrthesisProsthesisRequestForm(viewModel, viewModel._OrthesisProsthesisRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OrthesisProsthesisRequest = new OrthesisProsthesisRequest(objectContext);
                var entryStateID = Guid.Parse("a5c6ccd3-41ca-4f1f-a12d-a818c0733665");
                viewModel._OrthesisProsthesisRequest.CurrentStateDefID = entryStateID;
                viewModel.OrthesisProsthesisProceduresGridList = new TTObjectClasses.OrthesisProsthesisProcedure[]{};
                viewModel.ReturnDescriptionGridGridList = new TTObjectClasses.OrthesisProsthesis_ReturnDescriptionsGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._OrthesisProsthesisRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._OrthesisProsthesisRequest);
                PreScript_OrthesisProsthesisRequestForm(viewModel, viewModel._OrthesisProsthesisRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OrthesisProsthesisRequestForm(OrthesisProsthesisRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e79ea6b9-86ce-4c7b-ad5f-b6dedd6a2b4a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.OrthesisProsthesisProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.ReturnDescriptionGridGridList);
            var entryStateID = Guid.Parse("a5c6ccd3-41ca-4f1f-a12d-a818c0733665");
            objectContext.AddToRawObjectList(viewModel._OrthesisProsthesisRequest, entryStateID);
            objectContext.ProcessRawObjects(false);
            var orthesisProsthesisRequest = (OrthesisProsthesisRequest)objectContext.GetLoadedObject(viewModel._OrthesisProsthesisRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(orthesisProsthesisRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
            if (viewModel.OrthesisProsthesisProceduresGridList != null)
            {
                foreach (var item in viewModel.OrthesisProsthesisProceduresGridList)
                {
                    var orthesisProsthesisProceduresImported = (OrthesisProsthesisProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)orthesisProsthesisProceduresImported).IsDeleted)
                        continue;
                    orthesisProsthesisProceduresImported.OrthesisProsthesisRequest = orthesisProsthesisRequest;
                }
            }

            if (viewModel.ReturnDescriptionGridGridList != null)
            {
                foreach (var item in viewModel.ReturnDescriptionGridGridList)
                {
                    var returnDescriptionsImported = (OrthesisProsthesis_ReturnDescriptionsGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)returnDescriptionsImported).IsDeleted)
                        continue;
                    returnDescriptionsImported.OrthesisProsthesisRequest = orthesisProsthesisRequest;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(orthesisProsthesisRequest);
            PostScript_OrthesisProsthesisRequestForm(viewModel, orthesisProsthesisRequest, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            retViewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(orthesisProsthesisRequest);
            retViewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(orthesisProsthesisRequest);
            AfterContextSaveScript_OrthesisProsthesisRequestForm(viewModel, orthesisProsthesisRequest, transDef, objectContext);
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OrthesisProsthesisRequestForm(OrthesisProsthesisRequestFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTObjectContext objectContext);
    partial void PostScript_OrthesisProsthesisRequestForm(OrthesisProsthesisRequestFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OrthesisProsthesisRequestForm(OrthesisProsthesisRequestFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OrthesisProsthesisRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.OrthesisProsthesisProceduresGridList = viewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.OfType<OrthesisProsthesisProcedure>().ToArray();
        viewModel.ReturnDescriptionGridGridList = viewModel._OrthesisProsthesisRequest.ReturnDescriptions.OfType<OrthesisProsthesis_ReturnDescriptionsGrid>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OrtesisProsthesisListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TechnicianList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
    }
}
}

namespace Core.Models
{
    public partial class OrthesisProsthesisRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get;
            set;
        }

        public TTObjectClasses.OrthesisProsthesisProcedure[] OrthesisProsthesisProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.OrthesisProsthesis_ReturnDescriptionsGrid[] ReturnDescriptionGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
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

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }
    }
}