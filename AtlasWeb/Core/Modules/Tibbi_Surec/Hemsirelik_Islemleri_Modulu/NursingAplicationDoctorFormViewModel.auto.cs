//$91588288
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
    public partial class NursingApplicationServiceController : Controller
{
    [HttpGet]
    public NursingAplicationDoctorFormViewModel NursingAplicationDoctorForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingAplicationDoctorFormLoadInternal(input);
    }

    [HttpPost]
    public NursingAplicationDoctorFormViewModel NursingAplicationDoctorFormLoad(FormLoadInput input)
    {
        return NursingAplicationDoctorFormLoadInternal(input);
    }

    private NursingAplicationDoctorFormViewModel NursingAplicationDoctorFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7c860586-ca11-4e54-b79f-fb6096295b7e");
        var objectDefID = Guid.Parse("eb1d324d-9956-438f-8056-e4177421ad56");
        var viewModel = new NursingAplicationDoctorFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingApplication = objectContext.GetObject(id.Value, objectDefID) as NursingApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingApplication);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingAplicationDoctorForm(viewModel, viewModel._NursingApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingAplicationDoctorForm(NursingAplicationDoctorFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingAplicationDoctorFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingAplicationDoctorFormInternal(NursingAplicationDoctorFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("7c860586-ca11-4e54-b79f-fb6096295b7e");
        objectContext.AddToRawObjectList(viewModel._NursingApplication);
        objectContext.ProcessRawObjects();
        var nursingApplication = (NursingApplication)objectContext.GetLoadedObject(viewModel._NursingApplication.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingApplication, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingApplication, formDefID);
        var transDef = nursingApplication.TransDef;
        PostScript_NursingAplicationDoctorForm(viewModel, nursingApplication, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingApplication);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingApplication);
        AfterContextSaveScript_NursingAplicationDoctorForm(viewModel, nursingApplication, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingAplicationDoctorForm(NursingAplicationDoctorFormViewModel viewModel, NursingApplication nursingApplication, TTObjectContext objectContext);
    partial void PostScript_NursingAplicationDoctorForm(NursingAplicationDoctorFormViewModel viewModel, NursingApplication nursingApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingAplicationDoctorForm(NursingAplicationDoctorFormViewModel viewModel, NursingApplication nursingApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingAplicationDoctorFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingAplicationDoctorFormViewModel
    {
        public TTObjectClasses.NursingApplication _NursingApplication
        {
            get;
            set;
        }
    }
}
