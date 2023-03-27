//$CFD93C1E
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
    public partial class SurgeryProcedureServiceController : Controller
{
    [HttpGet]
    public SurgeryProcedureFormViewModel SurgeryProcedureForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SurgeryProcedureFormLoadInternal(input);
    }

    [HttpPost]
    public SurgeryProcedureFormViewModel SurgeryProcedureFormLoad(FormLoadInput input)
    {
        return SurgeryProcedureFormLoadInternal(input);
    }

    private SurgeryProcedureFormViewModel SurgeryProcedureFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e53dfd24-4bae-4345-9480-c674ed1611ad");
        var objectDefID = Guid.Parse("92532fda-beeb-47e4-9dc5-be36a6eabf8a");
        var viewModel = new SurgeryProcedureFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SurgeryProcedure = objectContext.GetObject(id.Value, objectDefID) as SurgeryProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SurgeryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SurgeryProcedure);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SurgeryProcedureForm(viewModel, viewModel._SurgeryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SurgeryProcedureForm(SurgeryProcedureFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return SurgeryProcedureFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel SurgeryProcedureFormInternal(SurgeryProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e53dfd24-4bae-4345-9480-c674ed1611ad");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
        objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
        objectContext.AddToRawObjectList(viewModel.SurgeryResponsibleDoctorsGridList);
        objectContext.AddToRawObjectList(viewModel._SurgeryProcedure);
        objectContext.ProcessRawObjects();
        var surgeryProcedure = (SurgeryProcedure)objectContext.GetLoadedObject(viewModel._SurgeryProcedure.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgeryProcedure, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryProcedure, formDefID);
        if (viewModel.SurgeryResponsibleDoctorsGridList != null)
        {
            foreach (var item in viewModel.SurgeryResponsibleDoctorsGridList)
            {
                var surgeryResponsibleDoctorsImported = (SurgeryResponsibleDoctor)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)surgeryResponsibleDoctorsImported).IsDeleted)
                    continue;
                surgeryResponsibleDoctorsImported.SurgeryProcedure = surgeryProcedure;
            }
        }

        var transDef = surgeryProcedure.TransDef;
        PostScript_SurgeryProcedureForm(viewModel, surgeryProcedure, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgeryProcedure);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgeryProcedure);
        AfterContextSaveScript_SurgeryProcedureForm(viewModel, surgeryProcedure, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_SurgeryProcedureForm(SurgeryProcedureFormViewModel viewModel, SurgeryProcedure surgeryProcedure, TTObjectContext objectContext);
    partial void PostScript_SurgeryProcedureForm(SurgeryProcedureFormViewModel viewModel, SurgeryProcedure surgeryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SurgeryProcedureForm(SurgeryProcedureFormViewModel viewModel, SurgeryProcedure surgeryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SurgeryProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SurgeryResponsibleDoctorsGridList = viewModel._SurgeryProcedure.SurgeryResponsibleDoctors.OfType<SurgeryResponsibleDoctor>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SurgeryListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
    }
}
}


namespace Core.Models
{
    public partial class SurgeryProcedureFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SurgeryProcedure _SurgeryProcedure { get; set; }
        public TTObjectClasses.SurgeryResponsibleDoctor[] SurgeryResponsibleDoctorsGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis { get; set; }
    }
}
