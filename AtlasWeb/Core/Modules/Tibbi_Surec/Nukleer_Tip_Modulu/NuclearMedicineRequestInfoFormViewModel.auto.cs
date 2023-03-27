//$7FC835E0
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
    public partial class NuclearMedicineServiceController : Controller
{
    [HttpGet]
    public NuclearMedicineRequestInfoFormViewModel NuclearMedicineRequestInfoForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineRequestInfoFormLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineRequestInfoFormViewModel NuclearMedicineRequestInfoFormLoad(FormLoadInput input)
    {
        return NuclearMedicineRequestInfoFormLoadInternal(input);
    }

    private NuclearMedicineRequestInfoFormViewModel NuclearMedicineRequestInfoFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2039b65f-c354-4e66-80b8-0c0c69d0b864");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicineRequestInfoFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NuclearMedicine = objectContext.GetObject(id.Value, objectDefID) as NuclearMedicine;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NuclearMedicine, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NuclearMedicine);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NuclearMedicine);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NuclearMedicineRequestInfoForm(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineRequestInfoForm(NuclearMedicineRequestInfoFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineRequestInfoFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineRequestInfoFormInternal(NuclearMedicineRequestInfoFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2039b65f-c354-4e66-80b8-0c0c69d0b864");
        objectContext.AddToRawObjectList(viewModel._NuclearMedicine);
        objectContext.ProcessRawObjects();
        var nuclearMedicine = (NuclearMedicine)objectContext.GetLoadedObject(viewModel._NuclearMedicine.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nuclearMedicine, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
        var transDef = nuclearMedicine.TransDef;
        PostScript_NuclearMedicineRequestInfoForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicineRequestInfoForm(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineRequestInfoForm(NuclearMedicineRequestInfoFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineRequestInfoForm(NuclearMedicineRequestInfoFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineRequestInfoForm(NuclearMedicineRequestInfoFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineRequestInfoFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineRequestInfoFormViewModel
    {
        public TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get;
            set;
        }
    }
}
