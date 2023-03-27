//$CB7B8F75
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
    public partial class ConsultationServiceController : Controller
{
    [HttpGet]
    public ConsultationRequestFormViewModel ConsultationRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ConsultationRequestFormLoadInternal(input);
    }

    [HttpPost]
    public ConsultationRequestFormViewModel ConsultationRequestFormLoad(FormLoadInput input)
    {
        return ConsultationRequestFormLoadInternal(input);
    }

    private ConsultationRequestFormViewModel ConsultationRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("eda79ab4-a530-4700-915b-1eaeeb980342");
        var objectDefID = Guid.Parse("7a58decc-e858-41eb-87f8-61f97512f3ab");
        var viewModel = new ConsultationRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Consultation = objectContext.GetObject(id.Value, objectDefID) as Consultation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Consultation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Consultation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Consultation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ConsultationRequestForm(viewModel, viewModel._Consultation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Consultation = new Consultation(objectContext);
                var entryStateID = Guid.Parse("d4bc4848-5f2e-49b2-99f3-8c38ca161cea");
                viewModel._Consultation.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Consultation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Consultation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Consultation);
                PreScript_ConsultationRequestForm(viewModel, viewModel._Consultation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ConsultationRequestForm(ConsultationRequestFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ConsultationRequestFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ConsultationRequestFormInternal(ConsultationRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("eda79ab4-a530-4700-915b-1eaeeb980342");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.Episodes);
        var entryStateID = Guid.Parse("d4bc4848-5f2e-49b2-99f3-8c38ca161cea");
        objectContext.AddToRawObjectList(viewModel._Consultation, entryStateID);
        objectContext.ProcessRawObjects(false);
        var consultation = (Consultation)objectContext.GetLoadedObject(viewModel._Consultation.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(consultation, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(consultation);
        PostScript_ConsultationRequestForm(viewModel, consultation, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(consultation);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(consultation);
        AfterContextSaveScript_ConsultationRequestForm(viewModel, consultation, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ConsultationRequestForm(ConsultationRequestFormViewModel viewModel, Consultation consultation, TTObjectContext objectContext);
    partial void PostScript_ConsultationRequestForm(ConsultationRequestFormViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ConsultationRequestForm(ConsultationRequestFormViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ConsultationRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsultationRequesterUserList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsultationRequestResourceList", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
    }
}
}


namespace Core.Models
{
    public partial class ConsultationRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Consultation _Consultation { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
    }
}
