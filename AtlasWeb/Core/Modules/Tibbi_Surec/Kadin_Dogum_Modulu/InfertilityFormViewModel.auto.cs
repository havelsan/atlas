//$DAC76A88
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
    public partial class InfertilityServiceController : Controller
{
    [HttpGet]
    public InfertilityFormViewModel InfertilityForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InfertilityFormLoadInternal(input);
    }

    [HttpPost]
    public InfertilityFormViewModel InfertilityFormLoad(FormLoadInput input)
    {
        return InfertilityFormLoadInternal(input);
    }

    private InfertilityFormViewModel InfertilityFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("30a0ea5d-e525-4dc6-aa57-5462fd12390e");
        var objectDefID = Guid.Parse("19f61637-025f-46c8-a38b-322c8626a2c1");
        var viewModel = new InfertilityFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Infertility = objectContext.GetObject(id.Value, objectDefID) as Infertility;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Infertility, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Infertility, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Infertility);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Infertility);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InfertilityForm(viewModel, viewModel._Infertility, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Infertility = new Infertility(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Infertility, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Infertility, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Infertility);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Infertility);
                PreScript_InfertilityForm(viewModel, viewModel._Infertility, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InfertilityForm(InfertilityFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return InfertilityFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel InfertilityFormInternal(InfertilityFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("30a0ea5d-e525-4dc6-aa57-5462fd12390e");
        objectContext.AddToRawObjectList(viewModel.Patients);
        objectContext.AddToRawObjectList(viewModel._Infertility);
        objectContext.ProcessRawObjects();
        var infertility = (Infertility)objectContext.GetLoadedObject(viewModel._Infertility.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(infertility, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Infertility, formDefID);
        var transDef = infertility.TransDef;
        PostScript_InfertilityForm(viewModel, infertility, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(infertility);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(infertility);
        AfterContextSaveScript_InfertilityForm(viewModel, infertility, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_InfertilityForm(InfertilityFormViewModel viewModel, Infertility infertility, TTObjectContext objectContext);
    partial void PostScript_InfertilityForm(InfertilityFormViewModel viewModel, Infertility infertility, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InfertilityForm(InfertilityFormViewModel viewModel, Infertility infertility, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InfertilityFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class InfertilityFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Infertility _Infertility { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
    }
}
