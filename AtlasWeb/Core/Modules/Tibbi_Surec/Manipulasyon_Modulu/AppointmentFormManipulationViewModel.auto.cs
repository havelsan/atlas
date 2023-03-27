//$19DE0669
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
    public partial class ManipulationServiceController : Controller
{
    [HttpGet]
    public AppointmentFormManipulationViewModel AppointmentFormManipulation(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AppointmentFormManipulationLoadInternal(input);
    }

    [HttpPost]
    public AppointmentFormManipulationViewModel AppointmentFormManipulationLoad(FormLoadInput input)
    {
        return AppointmentFormManipulationLoadInternal(input);
    }

    private AppointmentFormManipulationViewModel AppointmentFormManipulationLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2c11f438-9fac-43f8-bcf8-313f5f0f2ad6");
        var objectDefID = Guid.Parse("528f1264-6f0b-41ab-b8a3-a8eda6d9134a");
        var viewModel = new AppointmentFormManipulationViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Manipulation = objectContext.GetObject(id.Value, objectDefID) as Manipulation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Manipulation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Manipulation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Manipulation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AppointmentFormManipulation(viewModel, viewModel._Manipulation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AppointmentFormManipulation(AppointmentFormManipulationViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2c11f438-9fac-43f8-bcf8-313f5f0f2ad6");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._Manipulation);
            objectContext.ProcessRawObjects();
            var manipulation = (Manipulation)objectContext.GetLoadedObject(viewModel._Manipulation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(manipulation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Manipulation, formDefID);
            var transDef = manipulation.TransDef;
            PostScript_AppointmentFormManipulation(viewModel, manipulation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manipulation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manipulation);
            AfterContextSaveScript_AppointmentFormManipulation(viewModel, manipulation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AppointmentFormManipulation(AppointmentFormManipulationViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext);
    partial void PostScript_AppointmentFormManipulation(AppointmentFormManipulationViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AppointmentFormManipulation(AppointmentFormManipulationViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AppointmentFormManipulationViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AppointmentFormManipulationViewModel : BaseViewModel
    {
        public TTObjectClasses.Manipulation _Manipulation { get; set; }
    }
}
