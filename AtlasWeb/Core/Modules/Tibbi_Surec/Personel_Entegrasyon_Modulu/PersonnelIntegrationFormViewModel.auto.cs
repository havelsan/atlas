//$8A596352
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
    public partial class PersonnelIntegrationServiceController : Controller
{
    [HttpGet]
    public PersonnelIntegrationFormViewModel PersonnelIntegrationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PersonnelIntegrationFormLoadInternal(input);
    }

    [HttpPost]
    public PersonnelIntegrationFormViewModel PersonnelIntegrationFormLoad(FormLoadInput input)
    {
        return PersonnelIntegrationFormLoadInternal(input);
    }

    private PersonnelIntegrationFormViewModel PersonnelIntegrationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("97676c8f-776e-4e93-a7cb-46193a0ba7f4");
        var objectDefID = Guid.Parse("6485ce65-5e29-46f6-9fcf-1ce29e047abc");
        var viewModel = new PersonnelIntegrationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PersonnelIntegration = objectContext.GetObject(id.Value, objectDefID) as PersonnelIntegration;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PersonnelIntegration, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PersonnelIntegration, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PersonnelIntegration);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PersonnelIntegration);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PersonnelIntegrationForm(viewModel, viewModel._PersonnelIntegration, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PersonnelIntegration = new PersonnelIntegration(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PersonnelIntegration, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PersonnelIntegration, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PersonnelIntegration);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PersonnelIntegration);
                PreScript_PersonnelIntegrationForm(viewModel, viewModel._PersonnelIntegration, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PersonnelIntegrationForm(PersonnelIntegrationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("97676c8f-776e-4e93-a7cb-46193a0ba7f4");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._PersonnelIntegration);
            objectContext.ProcessRawObjects();
            var personnelIntegration = (PersonnelIntegration)objectContext.GetLoadedObject(viewModel._PersonnelIntegration.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(personnelIntegration, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PersonnelIntegration, formDefID);
            var transDef = personnelIntegration.TransDef;
            PostScript_PersonnelIntegrationForm(viewModel, personnelIntegration, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(personnelIntegration);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(personnelIntegration);
            AfterContextSaveScript_PersonnelIntegrationForm(viewModel, personnelIntegration, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PersonnelIntegrationForm(PersonnelIntegrationFormViewModel viewModel, PersonnelIntegration personnelIntegration, TTObjectContext objectContext);
    partial void PostScript_PersonnelIntegrationForm(PersonnelIntegrationFormViewModel viewModel, PersonnelIntegration personnelIntegration, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PersonnelIntegrationForm(PersonnelIntegrationFormViewModel viewModel, PersonnelIntegration personnelIntegration, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PersonnelIntegrationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class PersonnelIntegrationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PersonnelIntegration _PersonnelIntegration { get; set; }
    }
}
